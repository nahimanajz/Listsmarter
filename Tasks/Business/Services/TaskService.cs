
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;
using CSharp_intro_1.Services.interfaces;
using CSharp_intro_1.Tasks.Business.Services;

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

            IsBucketFull(newTask.Bucket.Id);
            return _repo.Create(newTask);
        }
        private void IsBucketFull(Guid bucketId)
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
        public void Delete(Guid id)
        {
            IsTaskExist(id);
            _repo.Delete(id);
        }

        public List<TaskDto> GetAll()
        {
            return _repo.GetAll();
        }

        public List<TaskDto> GetByBucketAndStatus(Guid bucketId, int status)
        {
            var bucket = _taskRepo.GetByBucketAndStatus(bucketId, status);
            if (bucket.Count == 0)
            {
                throw new Exception($"There is no Task{bucketId} and status {status} found");
            }
            return bucket;

        }

        public TaskDto GetById(Guid id)
        {
            return _repo.GetById(id);

        }

        public TaskDto Update(TaskDto entity)
        {
            IsTaskExist(entity.Id);
            return _repo.Update(entity);
        }

        public void UpdateByStatus(int status, int newStatus) => _taskRepo.UpdateByStatus(status, newStatus);
        public void AssignTask(Guid taskId, Guid personId) => _taskRepo.AssignTask(taskId, personId);
        private void IsTaskExist(Guid id)
        {
            if (GetById(id) == null)
            {
                throw new Exception("Task does not exist");
            }
        }
    }
}
