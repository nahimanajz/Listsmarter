using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private readonly IValidator<PersonDto> _personValidator;
        public PersonService(IRepository<PersonDto> repo, IRepository<TaskDto> taskRepo, IValidator<PersonDto> _personValidator)
        {
            _repo = repo;
            _taskRepo = taskRepo;
            _personValidator = _personValidator ?? throw new ArgumentException();

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
        public bool Delete(Guid id)
        {

            bool hasTask = _taskRepo.GetAll().Any(task => task.Assignee == id);

            if (!hasTask)
            {
                _repo.Delete(id);
                return true;
            }
            else return false;


        }
    }
}
