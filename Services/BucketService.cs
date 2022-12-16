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
    public class BucketService : IService<BucketDto>
    {
        private readonly IRepository<BucketDto> _repo;
        private readonly IValidator<BucketDto> _personValidator;
        public BucketService(IRepository<BucketDto> repo, IValidator<BucketDto> _personValidator)
        {
            _repo = repo;
            _personValidator = _personValidator ?? throw new ArgumentException();

        }

        public void Create(BucketDto entity)
        {
            _repo.Create(entity);
        }

         public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public List<BucketDto> GetAll()
        {
            return _repo.GetAll();
        }

        public BucketDto GetById(int id)
        {
           return _repo.GetById(id);

        }

        public void Update(BucketDto entity)
        {
           _repo.Update(entity);
        }
    }
}
