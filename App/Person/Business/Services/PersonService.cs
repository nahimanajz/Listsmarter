
using CSharp_intro_1.Common.Business.ResponseMessages;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;
using CSharp_intro_1.Services.interfaces;
using CSharp_intro_1.Tasks.Business.Services.Interfaces;

namespace CSharp_intro_1.Services
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<PersonDto> _repo;
        private readonly ITaskService _taskService;
        public PersonService(IRepository<PersonDto> repo, ITaskService taskService)
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
