
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
            GetById(entity.Id);
            return _repo.Update(entity);
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
            GetById(id);
            return _repo.UpdateByStatus(id, newStatus);
        }
        
        public bool HasPersonTasks(Guid personId)
        {
            return _repo.HasPersonTasks(personId);
        }

       
    }
}
