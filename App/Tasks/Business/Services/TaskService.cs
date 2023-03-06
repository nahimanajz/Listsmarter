
using CSharp_intro_1.Common.Business.ResponseMessages;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;
using CSharp_intro_1.Services.interfaces;

namespace CSharp_intro_1.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repo;
        
        public TaskService(ITaskRepository repo)
        {
            _repo = repo;
        }

        public void Delete(Guid id)
        {
            GetById(id);
            _repo.Delete(id);
        }

        public List<TaskDto> GetAll()
        {
            return  _repo.GetAll();
        }

        public List<TaskDto> GetByBucketAndStatus(Guid bucketId, int status)
        {
            return _repo.GetByBucketAndStatus(bucketId, status);
        }
        public TaskDto Update(TaskDto entity)
        {

            var task = GetById(entity.Id);
           
            task.Title = entity.Title;
            task.Description = entity.Description;
            task.Priority = entity.Priority;

            return _repo.Update(task);
        }
        
        public TaskDto GetById(Guid id)
        {
            var task = _repo.GetById(id);
            if (task == null)
            {
                throw new Exception(ResponseMessages.TaskNotFound);
            }
            return task;
        }

        public TaskDto UpdateByStatus(Guid id, int newStatus)
        {
            
            CheckStatus(newStatus);
            
            var task =  GetById(id);
            task.Status = (Status) newStatus;

            return _repo.Update(task);
        }
        
        public bool HasPersonTasks(Guid personId)
        {
            return _repo.HasPersonTasks(personId);
        }

        public List<TaskDto> GetBucketTasks(Guid bucketId)
        {
           return _repo.GetBucketTasks(bucketId);
        }
        private void CheckStatus(int newStatus)
        {
            if (newStatus > (int)Status.Cancelled || newStatus < (int)Status.Open)
            {
                throw new Exception(ResponseMessages.TaskInvalidStatus);
            }
        }
    }
}
