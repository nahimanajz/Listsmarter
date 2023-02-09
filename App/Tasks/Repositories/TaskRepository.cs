
using AutoMapper;
using CSharp_intro_1.Common.Repository.DataAccess;
using CSharp_intro_1.DB;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories.Models;
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
            return _mapper.Map<List<TaskDto>>(_context.tasks.ToList());

        }

        public List<TaskDto> GetByBucketAndStatus(Guid bucketId, int status)
        {
            var tasks = _context.tasks.Where(task => task.Bucket.Id == bucketId && task.Status == status).Select(task => task);
            return _mapper.Map<List<TaskDto>>(tasks);

        }

        public TaskDto GetById(Guid id)
        {

            return _mapper.Map<TaskDto>(_context.tasks.FirstOrDefault(task => task.Id == id, null)); 

        }

        public TaskDto Create(TaskDto newTask)
        {
            _context.tasks.Add(_mapper.Map<Task>(newTask));
            return _mapper.Map<TaskDto>(newTask);
        }

        public TaskDto Update(TaskDto task)
        {
            var updatedTask = _context.tasks.First(currentTask => currentTask.Id == task.Id);

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
            var updatedTask = TempDb.tasks.First(task => task.Status == status && task.Id == id);
            updatedTask.Status = newStatus;

            return _mapper.Map<List<TaskDto>>(updatedTask);

        }

        public List<TaskDto> AssignTask(Guid taskId, Guid personId)
        {
            var person = _context.persons.FirstOrDefault(currentPerson => currentPerson.Id == personId, null);
            var task = _context.tasks.FirstOrDefault(task => task.Id == taskId, null);
            if(person == null || task == null){
                return _mapper.Map<List<TaskDto>>(null);
            }

            task.PersonId = personId;
        
            return _mapper.Map<List<TaskDto>>(task);
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
