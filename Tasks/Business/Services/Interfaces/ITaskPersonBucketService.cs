using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_intro_1.Tasks.Business.Services.Interfaces
{
    public interface ITaskPersonBucketService
    {
        bool HasTask(Guid id);
    }
}
