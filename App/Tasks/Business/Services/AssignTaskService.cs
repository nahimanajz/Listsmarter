using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_intro_1.Models;

using CSharp_intro_1.Tasks.Business.Services.Interfaces;

namespace CSharp_intro_1.Tasks.Business.Services
{
    public class AssignTaskService : IAssignTaskService
    {
        private readonly ITaskRepository _repo;
        public AssignTaskService(ITaskRepository repo)
        {
            _repo= repo;
            
        }

        public List<TaskDto> AssignTask(Guid taskId, Guid personId)
        {
      
            var task = _repo.AssignTask(taskId, personId);
            if(task == null){
                throw new Exception("Invalid person or task id");
            }
            return task;
        }
    }
}
