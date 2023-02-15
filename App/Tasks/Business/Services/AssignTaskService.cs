using CSharp_intro_1.Common.Business.ResponseMessages;
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

        public TaskDto AssignTask(Guid taskId, Guid personId)
        {
      
            var task = _repo.AssignTask(taskId, personId);
            if(task == null){
                throw new Exception(ResponseMessages.TaskOrPersonNotFound);
            }
            return task; 
        }
    }
}
