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
    public class BucketService : IBucketService
    {
        private readonly IRepository<BucketDto> _repo;
        private readonly IRepository<TaskDto> _taskRepo;

        private readonly IValidator<BucketDto> _personValidator;
        public BucketService(IRepository<BucketDto> repo, IRepository<TaskDto> taskRepo, IValidator<BucketDto> _personValidator)
        {
            _repo = repo;
            _taskRepo = taskRepo;

            _personValidator = _personValidator ?? throw new ArgumentException();

        }

        public BucketDto Create(BucketDto entity)
        {
           return _repo.Create(entity);
        }


        public List<BucketDto> GetAll()
        {
            return _repo.GetAll();
        }

        public BucketDto GetById(Guid id)
        {
            return _repo.GetById(id);

        }

        public void Update(BucketDto entity)
        {
            _repo.Update(entity);
        }
        public bool Delete(Guid id)
        {
            
            bool isBucketEmpty = _taskRepo.GetAll().Any<TaskDto>(task => task.Bucket.Id == id);
            if (isBucketEmpty == false)
            {
                _repo.Delete(id);
                return true;
            }
            else
            {
                Console.WriteLine("Bucket is not empty");
                return false;
            }

        }

        public BucketDto GetByStatus(int status)
        {
            throw new NotImplementedException();
        }
    }
}
