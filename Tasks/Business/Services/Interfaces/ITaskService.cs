using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_intro_1.Models;

namespace CSharp_intro_1.Services.interfaces
{
    public interface ITaskService
    {
        List<TaskDto> GetAll();

        TaskDto GetById(Guid id);
        TaskDto Create(CreateTaskDto TaskDto);
        TaskDto Update(TaskDto TaskDto);
        void Delete(Guid id);
        void AssignTask(Guid taskId, Guid personId);
        List<TaskDto> GetByBucketAndStatus(Guid bucketId, int status);

        void UpdateByStatus(int currentStatus, int newStatus);


    }
}