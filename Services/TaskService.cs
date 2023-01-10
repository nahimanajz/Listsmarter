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
        private readonly ITaskRepository _bucketRepo;
        private readonly IValidator<TaskDto> _personValidator;
        public TaskService(IRepository<TaskDto> repo,  ITaskRepository taskRepo, IValidator<TaskDto> _personValidator)
        {
            _repo = repo;
            _taskRepo= taskRepo;
            _bucketRepo= bucketRepo;
            _personValidator = _personValidator ?? throw new ArgumentException();

        }


        public void Create(TaskDto entity)
        {
            //check if bucket exists on buckets list
            //if not -> add the bucket
            //assign newly created bucket to task
            //if exits
            //assign bucket to task
            var bucket = _bucketRepo.GetById(entity.Bucket.Id);
            if (bucket == null)
            {
                bucket = _bucketRepo.Create(entity.Bucket);
                entity.Bucket = bucket;
            }
            else
            {
                entity.Bucket = bucket;
            }
            
            _repo.Create(entity);
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

        public void Update(TaskDto entity)
        {
            _repo.Update(entity);
        }

        public void UpdateByStatus(int status, int newStatus) => _taskRepo.UpdateByStatus(status, newStatus);
        public void AssignTask(Guid taskId, Guid personId) => _taskRepo.AssignTask(taskId, personId);
    }
}
