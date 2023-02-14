using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_intro_1.Common.Business.ResponseMessages
{
    public class MessageService
    {

        public string BucketNotFound;
        public string BucketNotDeleted;
        public string BucketAlreadyExist;
        public string BucketIsFull;

        public MessageService(MessageServiceBuilder builder)
        {
            BucketNotFound = builder.BucketNotFound;
            BucketNotDeleted = builder.BucketNotDeleted;
            BucketAlreadyExist = builder.BucketAlreadyExist;
            BucketIsFull = builder.BucketIsFull;
        }

    }
}
