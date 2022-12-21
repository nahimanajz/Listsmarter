using CSharp_intro_1.Models;
using CSharp_intro_1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _service;
        public TaskController(TaskService service)
        {
            _service = service;
        }
        [HttpGet (Name="GetTasks")]
        public List<TaskDto> GetAll()
        {

            return _service.GetAll();
        }
        [HttpGet("{id}")]
        public TaskDto GetById(Guid id)
        {

            return _service.GetById(id);
        }
        [HttpPost(Name = "CreateTask")]
        public void Create(TaskDto task)
        {

            _service.Create(task);
        }
        [HttpDelete(Name = "DeleteTask")]
        public void Delete(Guid id)
        {
            _service.Delete(id);
        }
        [HttpPut(Name = "UpdateTask")]
        public void Update(TaskDto task)
        {
            _service.Update(task);
        }
        [HttpPut("{status}/{newStatus}")]
        public void UpdateByStatus(int status, int newStatus)
        {
            _service.UpdateByStatus(status, newStatus);
        }
    }
}
