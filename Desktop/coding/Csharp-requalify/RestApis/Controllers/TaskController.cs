using AutoMapper;
using CSharp_intro_1.Models;
using CSharp_intro_1.Models.Validators;
using CSharp_intro_1.Repositories.Models;
using CSharp_intro_1.Services.interfaces;
using Microsoft.AspNetCore.Mvc;
using Task = System.Threading.Tasks.Task;

namespace RestApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _service;
        private readonly IMapper _mapper;
        private CreateTaskValidator _createTaskValidator;
        public TaskController(ITaskService service, CreateTaskValidator createTaskValidator, IMapper mapper)
        {
            _service = service;
            _createTaskValidator = createTaskValidator;
            _mapper = mapper;
        }
        [HttpGet(Name = "GetTasks")]
        public async Task<ActionResult<List<TaskDto>>> GetAll()
        {

            return await Task.FromResult(_service.GetAll());
        }
        [HttpGet("task/{id}")]
        public async Task<ActionResult<TaskDto>> GetById([FromRoute] Guid id)
        {
            var task = _service.GetById(id);
            if (task == null)
            {
                return await Task.FromResult(NotFound("Task is not found"));
            }
            return await Task.FromResult(Ok(task));

        }
        [HttpGet("bucket/{bucketId:Guid}/status/{status}")]
        public async Task<ActionResult> GetByBucketAndStatus([FromRoute] Guid bucketId, [FromRoute] int status)
        {
           
            return await Task.FromResult(Ok( _service.GetByBucketAndStatus(bucketId, status)));
        }

        [HttpPost(Name = "CreateTask")]
        public async Task<ActionResult<TaskDto>> Create([FromBody] CreateTaskDto task)
        {
            var result = _createTaskValidator.Validate(task);
            if (result.IsValid)
            {
                var personDto = _mapper.Map<TaskDto>(task);
                return await Task.FromResult(Ok(_service.Create(personDto)));
            }
            
            throw new Exception($" Validations error: {string.Join(",", result.Errors)}");
         
        }

        [HttpDelete("task/{id:Guid}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            _service.Delete(id);
            return await Task.FromResult(Ok("Task is deleted"));
        }
        [HttpPut("task/{id:Guid}")]
        public async Task<ActionResult<TaskDto>> Update([FromRoute] Guid id, [FromBody] CreateTaskDto task)
        {
            var updatedTask = new TaskDto
            {
                Id = id,
                Title = task.Title,
                Description = task.Description
            };
            return await Task.FromResult(Ok(_service.Update(updatedTask)));

        }
        [HttpPut("{status}/{newStatus}")]
        public async Task<ActionResult> UpdateByStatus([FromRoute] int status, [FromRoute] int newStatus)
        {
            _service.UpdateByStatus(status, newStatus);
            return await Task.FromResult(Ok("Tasks statuses are updated"));
        }
        [HttpPut("task/{taskId}/person/{personId}")]
        public async Task<ActionResult> AssignTask([FromRoute] Guid taskId, [FromRoute] Guid personId)
        {
            _service.AssignTask(taskId, personId);
            return await Task.FromResult(Ok("Task is assigneed to specified person successfully"));
        }

    }
}
