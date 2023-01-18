using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;
using CSharp_intro_1.Tasks.Business.Services.Interfaces;

namespace CSharp_intro_1.Tasks.Business.Services
{
    public class TaskBucketService : ITaskAndModels
    {
        private readonly IRepository<TaskDto> _repo;
        public TaskBucketService(IRepository<TaskDto> repo)
        {
            _repo = repo;
        }

        public bool HasTask(Guid bucketId)
        {
            var hasTasks = _repo.GetAll().Any<TaskDto>(task => task.Bucket.Id == bucketId);
            if (hasTasks == true)
            {
                throw new Exception("Bucket has some tasks");
            }
            else
            {
                return false;

            }
        }
    }
}
