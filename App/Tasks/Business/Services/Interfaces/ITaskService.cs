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
        
        TaskDto Update(TaskDto TaskDto);
        void Delete(Guid id);
        
        List<TaskDto> GetByBucketAndStatus(Guid bucketId, int status);

        List<TaskDto> UpdateByStatus(Guid id, int currentStatus, int newStatus);
        bool HasBucketTasks(Guid bucketId);
        bool HasPersonTasks(Guid personId);


    }
}