
using CSharp_intro_1.Models;
using CSharp_intro_1.Services;

namespace CSharp_intro_1
{
    public class TaskController
    {
        private readonly  TaskService _service;
        public TaskController(TaskService service)
        {
            _service = service;
        }

        public List<TaskDto> GetAll() { 
           
            return _service.GetAll();
        }
        public TaskDto GetById(Guid id)
        {

            return _service.GetById(id); 
        }
        public void Create(TaskDto task)
        {
            
            _service.Create(task);
        }
        public void Delete(Guid id)
        {
            _service.Delete(id);
        }
        public void Update(TaskDto task)
        {
            _service.Update(task);
        }
         public void Update(TaskDto task)
        {
            _service.Update(task);
        }
       

    }
}
