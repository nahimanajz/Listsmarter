
using CSharp_intro_1.Common.Business.ResponseMessages;
using CSharp_intro_1.Common.Repository;
using CSharp_intro_1.Models;
using CSharp_intro_1.People.Repositories.Modal;
using CSharp_intro_1.Services.interfaces;


namespace CSharp_intro_1.Services
{
    public class PersonService : IPersonService
    {

        private readonly IGenericRepository<Person, PersonDto> _repo;
        private readonly ITaskService _taskService;
        public PersonService(IGenericRepository<Person, PersonDto> repo, ITaskService taskService)
        {
            _repo = repo;
            _taskService = taskService;
        }
        public PersonDto Create(PersonDto entity)
        {
            return _repo.Create(entity);
        }
        public List<PersonDto> GetAll()
        {
            return _repo.GetAll();
        }
        public PersonDto GetById(Guid id)
        {
            var person = _repo.GetById(id);

            if (person == null)
            {
                throw new Exception(ResponseMessages.PersonNotFound);
            }
            return person;
        }
        public PersonDto Update(PersonDto entity)
        {
            GetById(entity.Id);
            return _repo.Update(entity);
        }
        public void Delete(Guid id)
        {
            GetById(id);
            if (!_taskService.HasPersonTasks(id))
            {
                _repo.Delete(id);
            }
            else
            {
                throw new Exception(ResponseMessages.PersonNotDeleted);
            }

        }
    }
}
