
using AutoMapper;
using CSharp_intro_1.Common.Repository.DataAccess;
using CSharp_intro_1.DB;
using CSharp_intro_1.Models;
using CSharp_intro_1.People.Repositories.Modal;
using CSharp_intro_1.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using Task = CSharp_intro_1.Repositories.Models.Task;

namespace CSharp_intro_1.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IMapper _mapper;
        private readonly AppContexts _context;

        public TaskRepository(IMapper mapper, AppContexts context)
        {
            _mapper = mapper;
            _context = context; 
        }

        public List<TaskDto> GetAll()
        {
            var tasks = _context.tasks.Include(task => task.Bucket).Include(task => task.Person).ToList();
            return _mapper.Map<List<TaskDto>>(tasks);
        }

        public List<TaskDto> GetByBucketAndStatus(Guid bucketId, int status)
        {
            var tasks = _context.tasks
                .Include(task => task.Bucket)
                .Include(task => task.Person)
                .Where(task => task.Bucket.Id == bucketId && task.Status == status)
                .Select(task => task);

            return _mapper.Map<List<TaskDto>>(tasks);

        }

        public TaskDto GetById(Guid id)
        {
            var task = _context.tasks
                       .Include(task => task.Bucket)
                       .Include(task => task.Person)
                       .FirstOrDefault(task => task.Id == id);

            return _mapper.Map<TaskDto>(task); 

        }

      
        public TaskDto Create(TaskDto newTask)
        {
            var task = _mapper.Map<Task>(newTask);
    
            _context.tasks.Add(task);
            _context.SaveChanges();

            return _mapper.Map<TaskDto>(task);

        }

        public TaskDto Update(TaskDto task)
        {
            var updatedTask = _context.tasks.Include(task => task.Bucket).Include(task => task.Person).First(currentTask => currentTask.Id == task.Id);

            updatedTask.Title = task.Title;
            updatedTask.Description = task.Description;
            updatedTask.Status = (int)task.Status;

            _context.SaveChanges();

            return _mapper.Map<TaskDto>(updatedTask);
        }

        public void Delete(Guid taskId) { 
            var task = _context.tasks.First(task => task.Id == taskId);
            _context.tasks.Remove(task);
            _context.SaveChanges();

        }
        public TaskDto UpdateByStatus(Guid id, int newStatus)
        {
           
            var updatedTask = _context.tasks.Include(task => task.Bucket).Include(task => task.Person).First(task =>task.Id == id);
           
            updatedTask.Status = newStatus;

            _context.SaveChanges();

            return _mapper.Map<TaskDto>(updatedTask);

        }

        public TaskDto AssignTask(Guid taskId, Guid personId)
        {
            var person = _context.persons.FirstOrDefault(person => person.Id == personId);
            var task = _context.tasks.FirstOrDefault(currentTask => currentTask.Id == taskId);
            if(person == null || task == null){
                return _mapper.Map<TaskDto>(null);
            }

            task.PersonId = personId;
            _context.SaveChanges();

            return _mapper.Map<TaskDto>(task);
        }
        public int CountBucketTasks(Guid bucketId)
        {
            return _context.tasks.Count(task => task.Bucket.Id == bucketId);
        }
        public bool HasBucketTasks(Guid bucketId)
        {

            return _context.tasks.Any(task => task.Bucket.Id == bucketId);
        }

        public bool HasPersonTasks(Guid personId)
        {
            return _context.tasks.Any(task => task.Person.Id == personId);
        }


    }

}
