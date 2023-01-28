
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
            return _repo.GetAll();
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
                throw new Exception($"Task with this {id} Id is not exist");
            }
            return task;
        }


        public List<TaskDto> UpdateByStatus(Guid id, int status, int newStatus)
        {
            GetById(id);
            return _repo.UpdateByStatus(id, status, newStatus);
        }
        public List<TaskDto> AssignTask(Guid taskId, Guid personId)
        {
            GetById(taskId);

            return _repo.AssignTask(taskId, personId);
        }

        public bool HasBucketTasks(Guid bucketId)
        {
            return _repo.HasBucketTasks(bucketId);
        }

        public bool HasPersonTasks(Guid personId)
        {
            return _repo.HasPersonTasks(personId);
        }
    }
}
