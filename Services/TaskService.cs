
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;
using CSharp_intro_1.Services.interfaces;
using FluentValidation;

namespace CSharp_intro_1.Services
{

    public class TaskService : ITaskService
    {
        private readonly IRepository<TaskDto> _repo;
        private readonly ITaskRepository _taskRepo;
        private readonly IRepository<BucketDto> _bucketRepo;
        private readonly IRepository<PersonDto> _personRepo;

        public TaskService(IRepository<TaskDto> repo, ITaskRepository taskRepo, IRepository<PersonDto> personRepo, IRepository<BucketDto> bucketRepo)
        {
            _repo = repo;
            _taskRepo = taskRepo;
            _bucketRepo = bucketRepo;
            _personRepo = personRepo;
           //TODO: implement builder to limit number of parameter in the construcor

        }

        public TaskDto Create(CreateTaskDto task)
        {
            // TODO: BUCKET SHOULD HAVE FIXED NUMBER OF TASKS   
            var newTask = new TaskDto
            {
                Title = task.Title,
                Description = task.Description,
                Status = task.Status
            };

            var bucket = _bucketRepo.GetById(task.Bucket); // TODO: call service rather than repository
            if (bucket == null)
            {
                bucket = new BucketDto { Id = task.Bucket, Title = "Default created Bucket" };
                bucket = _bucketRepo.Create(bucket);
                newTask.Bucket = bucket;
            }
            else
            {
                newTask.Bucket = bucket;
            }
            //TODO: verify if bucket is full
            if(bucket.Tasks.Count == bucket.MaxTasks){
                //TODO: THROW EXCEPTION AND SHOW USER THAT HE CAN NOT ADD MORE TASK
                throw new Exception("Bucket is full,");
            }
            var person = _personRepo.GetById(task.Assignee); // TODO: call service rather than repository
            if (person == null)
            {
                person = new PersonDto { Id = task.Assignee, FirstName = "Janvier", LastName = "Nahimana" };
                person = _personRepo.Create(person);
                newTask.Assignee = person;
            }
            else
            {
                newTask.Assignee = _personRepo.GetById(task.Assignee);
            }
            return _repo.Create(newTask);
        }

        public void Delete(Guid id)
        {
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
            return _repo.GetById(id);

        }

        public TaskDto Update(TaskDto entity)
        {
            return _repo.Update(entity);
        }

        public void UpdateByStatus(int status, int newStatus) => _taskRepo.UpdateByStatus(status, newStatus);
        public void AssignTask(Guid taskId, Guid personId) => _taskRepo.AssignTask(taskId, personId);
    }
}
