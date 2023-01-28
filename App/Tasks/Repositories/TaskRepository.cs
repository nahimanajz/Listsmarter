
using AutoMapper;
using CSharp_intro_1.DB;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories.Models;
using Task = CSharp_intro_1.Repositories.Models.Task;

namespace CSharp_intro_1.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IMapper _mapper;

        public TaskRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<TaskDto> GetAll()
        {
            return _mapper.Map<List<TaskDto>>(TempDb.tasks.ToList());

        }

        public List<TaskDto> GetByBucketAndStatus(Guid bucketId, int status)
        {
            var tasks = TempDb.tasks.Where(task => task.Bucket.Id == bucketId && task.Status == status).Select(task => task);
            return _mapper.Map<List<TaskDto>>(tasks);

        }

        public TaskDto GetById(Guid id)
        {

            return _mapper.Map<TaskDto>(TempDb.tasks.FirstOrDefault(task => task.Id == id, null)); ;

        }

        public TaskDto Create(TaskDto newTask)
        {
            TempDb.tasks.Add(_mapper.Map<Task>(newTask));
            return _mapper.Map<TaskDto>(newTask);
        }

        public TaskDto Update(TaskDto task)
        {
            var updatedTask = TempDb.tasks.First(currentTask => currentTask.Id == task.Id);

            updatedTask.Title = task.Title;
            updatedTask.Description = task.Description;
            updatedTask.Status = (int)task.Status;

            return _mapper.Map<TaskDto>(updatedTask);
        }

        public void Delete(Guid taskId)
        {
            TempDb.tasks.RemoveAll(task => task.Id == taskId);
        }
        public List<TaskDto> UpdateByStatus(Guid id, int status, int newStatus)
        {
            var updatedTask = TempDb.tasks.Where(task => task.Status == status).Select(registeredTask =>
            {
                registeredTask.Status = newStatus;
                return registeredTask;
            }).ToList();
            return _mapper.Map<List<TaskDto>>(updatedTask);

        }

        public List<TaskDto> AssignTask(Guid taskId, Guid personId)
        {
            Person person = TempDb.persons.FirstOrDefault(currentPerson => currentPerson.Id == personId, null);

            var updatedTask = TempDb.tasks.Where(task => task.Id == taskId).Select(task =>
            {
                task.Person = person;
                return task;
            }).ToList();

            return _mapper.Map<List<TaskDto>>(updatedTask);
        }
        public int CountBucketTasks(Guid bucketId)
        {
            return TempDb.tasks.Count(task => task.Bucket.Id == bucketId);
        }
        public bool HasBucketTasks(Guid bucketId)
        {

            return TempDb.tasks.Any(task => task.Bucket.Id == bucketId);
        }

        public bool HasPersonTasks(Guid personId)
        {
            return TempDb.tasks.Any(task => task.Person.Id == personId);

        }


    }

}
