using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_intro_1.Common.Business.Services
{
    public class MessageService
    {
        private string PersonNotFound;
        private string BucketNotFound;
        private string TaskNotFound;
        private string PersonHasTask;
        private string BucketHasTask;
        private string TaskOrPersonNotFound;

        public MessageService(string PersonNotFound, string bucketNotFound, string taskNotFound, string personHasTask, string bucketHasTask, string taskOrPersonNotFound)
        {
            PersonNotFound = PersonNotFound;
            BucketNotFound = bucketNotFound;
            TaskNotFound = taskNotFound;
            PersonHasTask = personHasTask;
            BucketHasTask = bucketHasTask;
            TaskOrPersonNotFound = taskOrPersonNotFound;
        }
    }
  
}
