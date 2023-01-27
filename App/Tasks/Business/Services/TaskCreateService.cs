﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories.Models;
using CSharp_intro_1.Services.interfaces;
using CSharp_intro_1.Tasks.Business.Services.Interfaces;

namespace CSharp_intro_1.Tasks.Business.Services
{
    public class TaskCreateService : ITaskCreateService
    {
        private readonly ITaskRepository _repo;

        private readonly IBucketService _bucketService;
        private readonly IPersonService _personService;
        private const int ALLOWED_TASKS = 10;

        public TaskCreateService(ITaskRepository repo, IBucketService bucketService, IPersonService personService)
        {
            _repo = repo;
            _bucketService = bucketService;
            _personService = personService;
        }

        public TaskDto Create(TaskDto task)
        {
            var newTask = new TaskDto
            {
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                Assignee = _personService.GetById(task.Assignee.Id)
            };
            var bucket =(BucketDto) null;

            try
            {
                 bucket = _bucketService.GetById(task.Bucket.Id);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
                AssignTaskToBucket(bucket, newTask);
               // CheckWhetherBucketIsFull(newTask.Bucket.Id);
        
            return _repo.Create(newTask);
        }

        private void CheckWhetherBucketIsFull(Guid bucketId)
        {
            if (ALLOWED_TASKS < _repo.CountBucketTasks(bucketId))
            {
                throw new Exception("Bucke t is full,");
            }

        }
        private void AssignTaskToBucket(BucketDto bucket, TaskDto newTask)
        {
            if (bucket == null)
            {
                bucket = new BucketDto { Title = "Bucket" + Guid.NewGuid().ToString("n").Substring(0, 2) };
                bucket = _bucketService.Create(bucket);
                newTask.Bucket = bucket;
            }
            else
            {
                newTask.Bucket = bucket;
            }

        }
    }
}
