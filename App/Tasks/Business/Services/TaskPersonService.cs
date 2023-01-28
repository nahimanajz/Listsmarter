using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;
using CSharp_intro_1.Repositories.Models;
using CSharp_intro_1.Tasks.Business.Services.Interfaces;

namespace CSharp_intro_1.Tasks.Business.Services
{
    public class TaskPersonService : ITaskPersonBucketService
    {
        private readonly IRepository<TaskDto> _repo;
        public TaskPersonService(IRepository<TaskDto> repo)
        {
            _repo = repo;
        }
        public bool HasTask(Guid personId)
        {
            var hasTasks = _repo.GetAll().Any<TaskDto>(task => task.Person.Id == personId);
            if (hasTasks == true)
            {
                throw new Exception("Person has some tasks");
            }
            else
            {
                return false;

            }
           

        }
    }
}
