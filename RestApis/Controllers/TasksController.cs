using AutoMapper;
using CSharp_intro_1.Models;
using CSharp_intro_1.Models.Validators;
using CSharp_intro_1.Services.interfaces;
using CSharp_intro_1.Tasks.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Task = System.Threading.Tasks.Task;

namespace RestApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly ITaskCreateService _createTaskService;

        private readonly IMapper _mapper;
        private CreateTaskValidator _createTaskValidator;
        public TasksController(ITaskService taskService, ITaskCreateService createTaskService, CreateTaskValidator createTaskValidator, IMapper mapper)
        {
            _taskService = taskService;
            _createTaskService = createTaskService;
            _createTaskValidator = createTaskValidator;
            _mapper = mapper;
        }


        [HttpGet(Name = "GetTasks")]
        public async Task<ActionResult<List<TaskDto>>> GetAll()
        {

            return await Task.FromResult(_taskService.GetAll());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDto>> GetById([FromRoute] Guid id)
        {
            return await Task.FromResult(Ok(_taskService.GetById(id)));

        }


        [HttpGet("bucket/{bucketId:Guid}/status/{status}")]
        public async Task<ActionResult> GetByBucketAndStatus([FromRoute] Guid bucketId, [FromRoute] int status)
        {
            return await Task.FromResult(Ok(_taskService.GetByBucketAndStatus(bucketId, status)));
        }


        [HttpPost(Name = "CreateTask")]
        public async Task<ActionResult<TaskDto>> Create([FromBody] CreateTaskDto task)
        {
            var result = _createTaskValidator.Validate(task);
            if (result.IsValid)
            {
                var taskDto = _mapper.Map<TaskDto>(task);
                return await Task.FromResult(Ok(_createTaskService.Create(taskDto)));
            }

            throw new Exception($" Validations error: {string.Join(",", result.Errors)}");
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            _taskService.Delete(id);
            return await Task.FromResult(Ok("Task is deleted"));
        }


        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<TaskDto>> Update([FromRoute] Guid id, [FromBody] UpdateTaskDto task)
        {
            var updatedTask = new TaskDto
            {
                Id = id,
                Title = task.Title,
                Description = task.Description
            };
            return await Task.FromResult(Ok(_taskService.Update(updatedTask)));

        }

        [HttpPut("{id}/{newStatus}")]
        public async Task<ActionResult> UpdateByStatus([FromRoute] Guid id, [FromRoute] int newStatus)
        {
            return await Task.FromResult(Ok(_taskService.UpdateByStatus(id, newStatus)));
        }

        
    }
}
