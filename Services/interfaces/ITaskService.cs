using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_intro_1.Models;

namespace CSharp_intro_1.Services.interfaces
{
    public interface ITaskService
    {
        List<TaskDto> GetAll();
        List<TaskDto> GetByBucketAndStatus(Guid bucketId, int status);

        TaskDto GetById(Guid id);
        void Create(TaskDto TaskDto);
        void Update(TaskDto TaskDto);
        void Delete(Guid id);
       // TODO: Update task status to desired value
      // void UpdateByStatus(int status, int value);
      
    }
}