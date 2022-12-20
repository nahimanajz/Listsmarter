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
        void Create(TaskDto TaskDto);
        void Update(TaskDto TaskDto);
        void Delete(Guid id);
    }
}