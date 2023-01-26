
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;
using CSharp_intro_1.Services.interfaces;

namespace CSharp_intro_1.Services
{
    public class TaskService : ITaskService
    {
        private readonly IRepository<TaskDto> _repo;
        private readonly ITaskRepository _taskRepo;
        private readonly IBucketService _bucketService;
        private readonly IPersonService _personService;
        private const int ALLOWED_TASKS = 10;

        public TaskService(IRepository<TaskDto> repo, ITaskRepository taskRepo, IBucketService bucketService, IPersonService personService)
        {
            _repo = repo;
            _taskRepo = taskRepo;
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

            var bucket = _bucketService.GetById(task.Bucket.Id);
            AssignTaskToBucket(bucket, newTask);
            CheckWhetherBucketIsFull(newTask.Bucket.Id);
            
            return _repo.Create(newTask);
        }
        public void Delete(Guid id)
        {
            CheckTaskExistence(id);
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
            var task = _repo.GetById(id);
            if (task == null)
            {
                throw new Exception($"Task with this {id} Id is not exist");
            }
            return task;
        }
        public TaskDto Update(TaskDto entity)
        {
            CheckTaskExistence(entity.Id);
            return _repo.Update(entity);
        }

        public void UpdateByStatus(int status, int newStatus) => _taskRepo.UpdateByStatus(status, newStatus);
        public void AssignTask(Guid taskId, Guid personId) => _taskRepo.AssignTask(taskId, personId);
        private void CheckTaskExistence(Guid id)
        {
            GetById(id);
        }
        private void CheckWhetherBucketIsFull(Guid bucketId)
        {
            var bucket = _repo.GetAll().FindAll(task => task.Bucket.Id == bucketId).ToList();
            if (ALLOWED_TASKS < bucket.Count)
            {
                throw new Exception("Bucket is full,");
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
