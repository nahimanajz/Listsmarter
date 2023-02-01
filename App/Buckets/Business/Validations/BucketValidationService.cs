using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;
using CSharp_intro_1.Services.interfaces;

namespace CSharp_intro_1.Buckets.Business.Validations
{
    public class BucketValidationService : IBucketValidationService
    {
 
        private readonly IBucketRepository _repo;

        public BucketValidationService( IBucketRepository repo)
        {
           
            _repo = repo;
        }

        public bool HasBucketTasks(Guid id)
        {
            return _repo.HasBucketTasks(id);
            /*
            if (!)
            {
                throw new Exception("Bucket can not be deleted due to some tasks assigned to it");
            }
    */

        }
    }
}
