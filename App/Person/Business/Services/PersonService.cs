
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;
using CSharp_intro_1.Services.interfaces;
using CSharp_intro_1.Tasks.Business.Services.Interfaces;
using FluentValidation;
using Microsoft.Extensions.Hosting;

namespace CSharp_intro_1.Services
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<PersonDto> _repo;
   
        private readonly ITaskPersonBucketService _taskService;

        public PersonService(IRepository<PersonDto> repo, ITaskPersonBucketService taskService)
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
            
            if(person ==null ){
                throw new Exception($"Bucket with {id} does not exist");
            }
            return person;
        }
        public PersonDto Update(PersonDto entity)
        {
            CheckPersonExistence(entity.Id);
            return _repo.Update(entity);
        }
        public void Delete(Guid id)
        {
            CheckPersonExistence(id);
            if (!_taskService.HasTask(id))
            {
                _repo.Delete(id);
            }
        }
        private void CheckPersonExistence(Guid id)
        {
            if (GetById(id) == null)
            {
                throw new Exception("Person does not exist");
            }
        }
    }
}
