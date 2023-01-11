using System.Xml;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_intro_1.DB;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;
using CSharp_intro_1.Services.interfaces;
using FluentValidation;
using Microsoft.Extensions.Hosting;

namespace CSharp_intro_1.Services
{

    public class TaskService : ITaskService
    {
        private readonly IRepository<TaskDto> _repo;
        private readonly ITaskRepository _taskRepo;
        private readonly IRepository<BucketDto> _bucketRepo;
        private readonly IRepository<PersonDto> _personRepo;
        private readonly IValidator<TaskDto> _personValidator;
        public TaskService(IRepository<TaskDto> repo, ITaskRepository taskRepo, IRepository<PersonDto> personRepo, IRepository<BucketDto> bucketRepo, IValidator<TaskDto> _personValidator)
        {
            _repo = repo;
            _taskRepo = taskRepo;
            _bucketRepo = bucketRepo;
            _personRepo = personRepo;
            _personValidator = _personValidator ?? throw new ArgumentException();

        }


        public TaskDto Create(TaskDto entity)
        {
            //check if bucket exists on buckets list
            //if not -> add the bucket
            //assign newly created bucket to task
            //if exits
            //assign bucket to task
            var bucket = _bucketRepo.GetById(entity.Bucket);
            if (bucket == null)
            {
                bucket = new BucketDto {Id= entity.Bucket, Title= "Default created Bucket" };
                bucket = _bucketRepo.Create(bucket);
                entity.Bucket = bucket.Id;
            }
            else
            {
                entity.Bucket = bucket.Id;
            }

            var person = _personRepo.GetById(entity.Assignee);
            if (person == null)
            {
                person = new PersonDto {Id= entity.Assignee, FirstName= "Janvier", LastName="Nahimana"};
                person = _personRepo.Create(person);
                entity.Assignee = person.Id;
            }
            else
            {
                entity.Assignee = person.Id;
            }
      
           return _repo.Create(entity);
        }

        public void Delete(Guid id)
        {
            _repo.Delete(id);
        }

        public List<TaskDto> GetAll()
        {
            return _repo.GetAll();
        }

        public List<TaskDto> GetByBucketAndStatus(Guid bucketId, int status)
        {

            return _taskRepo.GetByBucketAndStatus(bucketId, status);
        }

        public TaskDto GetById(Guid id)
        {
            return _repo.GetById(id);

        }

        public TaskDto Update(TaskDto entity)
        {
            return _repo.Update(entity);
        }

        public void UpdateByStatus(int status, int newStatus) => _taskRepo.UpdateByStatus(status, newStatus);
        public void AssignTask(Guid taskId, Guid personId) => _taskRepo.AssignTask(taskId, personId);
    }
}
