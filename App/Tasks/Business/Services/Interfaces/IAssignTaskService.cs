using CSharp_intro_1.Models;

namespace CSharp_intro_1.Tasks.Business.Services.Interfaces
{
    public interface IAssignTaskService
    {
        TaskDto AssignTask(Guid taskId, Guid personId);
    }
}
