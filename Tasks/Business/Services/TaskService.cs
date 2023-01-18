
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;
using CSharp_intro_1.Services.interfaces;


namespace CSharp_intro_1.Services
{

    public class TaskService : ITaskService
    {
        private readonly IRepository<TaskDto> _repo;
        private readonly ITaskRepository _taskRepo;
        private readonly BucketService _bucketService;
        private readonly PersonService _personService;
        private const int MAXIMUM_TASKS  = 1; 

        public TaskService(IRepository<TaskDto> repo, ITaskRepository taskRepo, BucketService bucketService, PersonService personSerice)
        {
            _repo = repo;
            _taskRepo = taskRepo;
            _bucketService = bucketService;
          _personService = personSerice;
         
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

            var bucket = _bucketService.GetById(task.Bucket); // TODO: call service rather than repository
            if (bucket == null)
            {
                bucket = new BucketDto { Id = task.Bucket, Title = "Default created Bucket" }; // TODO: Add dynamism to this title
                bucket = _bucketService.Create(bucket);
                newTask.Bucket = bucket;
            }
            else
            {
                newTask.Bucket = bucket;
            }
             IsBucketFull(newTask.Bucket.Id);

            var person = _personService.GetById(task.Assignee); // TODO: call service rather than repository
            SetTaskToPerson(task, newTask, person);
            return _repo.Create(newTask);
        }
        private void IsBucketFull(Guid bucketId)
        {
           var bucket = _repo.GetAll().FindAll(task=> task.Bucket.Id == bucketId).ToList();
            if ( MAXIMUM_TASKS  < bucket.Count)
            {
                throw new Exception("Bucket is full,");
            }

        }
        private TaskDto SetTaskToPerson(CreateTaskDto task, TaskDto newTask, PersonDto person)
        { //TODO: throw exception if user is not there
            if (person == null)
            {
                person = new PersonDto { Id = task.Assignee, FirstName = "Janvier", LastName = "Nahimana" };
                person = _personService.Create(person);
                newTask.Assignee = person;
            }
            else
            {
                newTask.Assignee = _personService.GetById(task.Assignee);
            }
            return newTask;
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