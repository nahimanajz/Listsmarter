
using AutoMapper;
using CSharp_intro_1.DB;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories.Models;
using Task = CSharp_intro_1.Repositories.Models.Task;

namespace CSharp_intro_1.Repositories
{
    public class TaskRepository : IRepository<TaskDto>, ITaskRepository
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
            var tasks = TempDb.tasks.Where(task => task.Bucket == bucketId && task.Status == status).Select(task => task);
            return _mapper.Map<List<TaskDto>>(tasks);

        }

        public TaskDto GetById(Guid id)
        {

            return _mapper.Map<TaskDto>(TempDb.tasks.FirstOrDefault(task => task.Id == id, null)); ;

        }

        public TaskDto Create(TaskDto newTask)
        {
            TempDb.tasks.Add(_mapper.Map<Task>(newTask));
            return _mapper.Map<TaskDto>(TempDb.tasks.Last());
        }

        public TaskDto Update(TaskDto registeredTask)
        {
            var updatedTask = TempDb.tasks.Where(task => task.Id == registeredTask.Id).Select(task =>
             {
                 task.Title = registeredTask.Title == null ? task.Title : registeredTask.Title;
                 task.Description = task.Description == null ? task.Description : registeredTask.Description;

                 task.Status = registeredTask.Status == null ? task.Status : (int)registeredTask.Status;


                 return task;
             }).ToList();
            return GetById(registeredTask.Id);
        }

        public void Delete(Guid taskId)
        {
            var deleteRecord = TempDb.tasks.RemoveAll(task => task.Id == taskId);
        }
        public void UpdateByStatus(int status, int newStatus)
        {
            var taskByStatus = TempDb.tasks.Where(task => task.Status == status).Select(registeredTask =>
            {
                registeredTask.Status = newStatus;
                return registeredTask;
            }).ToList();

        }

        public void AssignTask(Guid taskId, Guid personId)
        {
            Person person = TempDb.people.Where(currentPerson => currentPerson.Id == personId).First();
            var assignByPerson = TempDb.tasks.Where(task => task.Id == taskId).Select(registeredTask =>
            {
                registeredTask.Assignee = person.Id;
                return registeredTask;
            }).ToList();
        }
    }

}
