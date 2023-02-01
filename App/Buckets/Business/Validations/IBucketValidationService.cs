using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_intro_1.Buckets.Business.Validations
{
    public interface IBucketValidationService
    {
        bool HasBucketTasks(Guid id);
    }
}
