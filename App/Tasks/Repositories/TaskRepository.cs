
using System.Net.Sockets;
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
            var tasks = _context.Tasks.Include(task => task.Bucket).Include(task => task.Person).ToList();
            return _mapper.Map<List<TaskDto>>(tasks);
        }

        public List<TaskDto> GetByBucketAndStatus(Guid bucketId, int status)
        {
            var tasks = _context.Tasks
                .Include(task => task.Bucket)
                .Include(task => task.Person)
                .Where(task => task.Bucket.Id == bucketId && task.Status == status)
                .Select(task => task);

            return _mapper.Map<List<TaskDto>>(tasks);

        }

        public TaskDto GetById(Guid id)
        {
            var task = _context.Tasks
                       .Include(task => task.Bucket)
                       .Include(task => task.Person)
                       .FirstOrDefault(task => task.Id == id);

            return _mapper.Map<TaskDto>(task); 

        }

      
        public TaskDto Create(TaskDto newTask)
        {
            var task = _mapper.Map<Task>(newTask);
    
            _context.Tasks.Add(task);
            _context.SaveChanges();

            return _mapper.Map<TaskDto>(task);

        }

        public TaskDto Update(TaskDto entity)
        {
            var updatedTask = _context.Tasks.First(task => entity.Id == task.Id);
        
            _mapper.Map(entity, updatedTask);
            _context.SaveChanges();

            return _mapper.Map<TaskDto>(updatedTask);
        }

        public void Delete(Guid taskId) { 
            var task = _context.Tasks.First(task => task.Id == taskId);
            _context.Tasks.Remove(task);
            _context.SaveChanges();

        }
        public TaskDto AssignTask(Guid taskId, Guid personId)
        {
            var person = _context.Persons.FirstOrDefault(person => person.Id == personId);
            var task = _context.Tasks.Include(task=>task.Person).Include(task=>task.Bucket).FirstOrDefault(currentTask => currentTask.Id == taskId);
            if(person == null || task == null){
                return _mapper.Map<TaskDto>(null);
            }

            task.PersonId = personId;
            _context.SaveChanges();

            return _mapper.Map<TaskDto>(task);
        }
        public int CountBucketTasks(Guid bucketId)
        {
            return _context.Tasks.Count(task => task.Bucket.Id == bucketId);
        }
        public bool HasBucketTasks(Guid bucketId)
        {

            return _context.Tasks.Any(task => task.Bucket.Id == bucketId);
        }

        public bool HasPersonTasks(Guid personId)
        {
            return _context.Tasks.Any(task => task.Person.Id == personId);
        }


    }

}
