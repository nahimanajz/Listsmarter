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
    public class PersonService
    {
        private readonly IRepository<PersonDto> _repo;
        private readonly IValidator<PersonDto> _personValidator;
        public PersonService(IRepository<PersonDto> repo, IValidator<PersonDto> _personValidator)
        {
            _repo = repo;
            _personValidator = _personValidator ?? throw new ArgumentException();

        }

        public void Create(PersonDto entity)
        {
            _repo.Create(entity);
        }

         public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public List<PersonDto> GetAll()
        {
            return _repo.GetAll();
        }

        public PersonDto GetById(int id)
        {
           return _repo.GetById(id);

        }

        public void Update(PersonDto entity)
        {
           _repo.Update(entity);
        }
    }
}
