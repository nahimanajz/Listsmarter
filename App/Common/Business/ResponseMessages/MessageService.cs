using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_intro_1.Common.Business.ResponseMessages
{
    public class MessageService
    {
        public string PersonNotFound;
        public string PersonNotDeleted;

        public string BucketNotFound;
        public string BucketNotDeleted;
        public string BucketAlreadyExist;
        public string BucketIsFull;

        public string TaskNotFound;
        public string TaskOrPersonNotFound;

        public MessageService(MessageServiceBuilder builder)
        {

            PersonNotFound = builder.PersonNotFound;
            PersonNotDeleted = builder.PersonNotDeleted;

            BucketNotFound = builder.BucketNotFound;
            BucketNotDeleted = builder.BucketNotDeleted;
            BucketAlreadyExist = builder.BucketAlreadyExist;
            BucketIsFull = builder.BucketIsFull;

            TaskNotFound = builder.TaskNotFound;
            TaskOrPersonNotFound = builder.TaskOrPersonNotFound;

        }

    }
}
