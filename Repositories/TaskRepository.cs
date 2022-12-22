
using AutoMapper;
using CSharp_intro_1.DB;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories.Models;
using Task = CSharp_intro_1.Repositories.Models.Task;

namespace CSharp_intro_1.Repositories
{
    public class TaskRepository : IRepository<TaskDto>
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

        public TaskDto GetById(Guid id)
        {

            return _mapper.Map<TaskDto>(TempDb.tasks.FirstOrDefault(task => task.Id == id, null)); ;

        }

        public void Create(TaskDto task)
        {
            var mappedObject = _mapper.Map<Task>(task);
            TempDb.tasks.Add(mappedObject);



        }

        public void Update(TaskDto tsk)
        {
            TempDb.tasks.Where(task => task.Id == tsk.Id).Select(task =>
            {
                task.Title = tsk.Title == null ? task.Title : tsk.Title;
                task.Description = task.Description == null ? task.Description : tsk.Description;

                task.Status = tsk.Status == null ? task.Status : (int)tsk.Status;


                return task;
            }).ToList();
        }

        public void Delete(Guid taskId)
        {
            var deleteRecord = TempDb.tasks.RemoveAll(task => task.Id == taskId);
        }
        public void UpdateByStatus(int status, int newStatus)
        {
            var taskByStatus = TempDb.tasks.Where(task => task.Status == status).Select(tsk =>
            {
                tsk.Status = newStatus;
                return tsk;
            }).ToList();
           
        }



    }

}
