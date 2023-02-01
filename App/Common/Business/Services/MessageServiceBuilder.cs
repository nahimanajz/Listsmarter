using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_intro_1.Common.Business.Services
{
    public class MessageServiceBuilder
    {
        private string personNotFound;
        private string BucketNotFound;
        private string TaskNotFound;
        private string PersonHasTask;
        private string BucketHasTask;
        private string TaskOrPersonNotFound;

        public MessageServiceBuilder BuildPersonNotFound(string message) {
            personNotFound = message;
            return this;
        }
        public MessageServiceBuilder BuildBucketNotFound(string message)
        {
            BucketNotFound = message;
            return this;
        }
        public MessageServiceBuilder BuildTaskNotFound(string message)
        {
            TaskNotFound = message;
            return this;
        }
        public MessageServiceBuilder BuildTaskOrPersonNotFound(string message)
        {
            TaskOrPersonNotFound = message;
            return this;
        }
        public MessageServiceBuilder BuildPersonHasTask(string message)
        {
            PersonHasTask = message;
            return this;
        }
        public MessageServiceBuilder BuildBucketHasTask(string message)
        {
            PersonHasTask = message;
            return this;
        }
        public MessageService build()
        {
            return new MessageService(personNotFound, BucketNotFound, TaskNotFound, PersonHasTask, BucketHasTask, TaskOrPersonNotFound);
        }

    }
}
