
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;
using CSharp_intro_1.Services.interfaces;
using FluentValidation;
using Microsoft.Extensions.Hosting;

namespace CSharp_intro_1.Services
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<PersonDto> _repo;
        private readonly IRepository<TaskDto> _taskRepo;
  
        public PersonService(IRepository<PersonDto> repo, IRepository<TaskDto> taskRepo)
        {
            _repo = repo;
            _taskRepo = taskRepo;
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
            return _repo.GetById(id);
        }
        public PersonDto Update(PersonDto entity)
        {
            return _repo.Update(entity);
        }
        public void Delete(Guid id)
        {
            /*
            bool hasTask = _taskRepo.GetAll().Any(task => task.Assignee.Id == id);
            if (!hasTask)
            {
                _repo.Delete(id);
            }
            else
            {
                throw new("Person can not be deleted since he has some task");
            }
            */
        }
    }
}
