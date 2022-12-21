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

        public void Create(PersonDto entity)
        {
            _repo.Create(entity);
        }


        public List<PersonDto> GetAll()
        {
            
            return _repo.GetAll();
        }

        public PersonDto GetById(Guid id)
        {



            return _repo.GetById(id);

        }

        public void Update(PersonDto entity)
        {
            _repo.Update(entity);
        }
        public void Delete(Guid id)
        {
            System.Console.WriteLine($"You are trying to delete {id}");
            bool hasTask = _taskRepo.GetAll().All(task => task.Assignee.Id == id);
            System.Console.WriteLine($"You are trying to delete {id} hasId{hasTask}");

            if(hasTask){
                Console.WriteLine($"Can not delete because ther is a task assinged to this person");
                return;
            }
            _repo.Delete(id);
        }


    }
}
