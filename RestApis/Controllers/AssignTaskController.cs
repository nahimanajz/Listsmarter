using CSharp_intro_1.Tasks.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace RestApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignTaskController : ControllerBase
    {
        private readonly IAssignTaskService _assignTaskService;

        public AssignTaskController(IAssignTaskService assignTaskService)
        {
            _assignTaskService = assignTaskService;
        }

        [HttpPut("task/{taskId}/person/{personId}")]
        public async Task<ActionResult> AssignTask([FromRoute] Guid taskId, [FromRoute] Guid personId)
        {
            return await Task.FromResult(Ok(_assignTaskService.AssignTask(taskId, personId)));
        }

    }
}
