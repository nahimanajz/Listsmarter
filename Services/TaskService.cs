using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;
using FluentValidation;
using Microsoft.Extensions.Hosting;

namespace CSharp_intro_1.Services
{
    // TODO: WE IMPORT REPOSITORIES TO ACCESS PERSON, BUCKETS MODAL
    public class TaskService 
    {
        private readonly IRepository<TaskDto> _repo;
        private readonly IValidator<TaskDto> _personValidator;
        public TaskService(IRepository<TaskDto> repo, IValidator<TaskDto> _personValidator)
        {
            _repo = repo;
            _personValidator = _personValidator ?? throw new ArgumentException();

        }

        public void Create(TaskDto entity)
        {
            _repo.Create(entity);
        }

         public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public List<TaskDto> GetAll()
        {
            return _repo.GetAll();
        }

        public TaskDto GetById(int id)
        {
           return _repo.GetById(id);

        }

        public void Update(TaskDto entity)
        {
           _repo.Update(entity);
        }
    }
}
