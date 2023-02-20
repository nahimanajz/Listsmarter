namespace CSharp_intro_1.Common.Business.ResponseMessages
{
    public class MessageServiceBuilder
    {
        public string BucketNotFound;
        public string BucketNotDeleted;
        public string BucketAlreadyExist;
        public string BucketIsFull;

        public MessageServiceBuilder BuildBucketNotFound()
        {
            BucketNotFound = ResponseMessages.BucketNotFound;
            return this;
        }
        public MessageServiceBuilder BuildBucketAlreadyExist()
        {
            BucketAlreadyExist = ResponseMessages.BucketAlreadyExist;
            return this;
        }
        public MessageServiceBuilder BuildBucketIsFull()
        {
            BucketIsFull = ResponseMessages.BucketIsFull;
            return this;
        }

        public MessageServiceBuilder BuildBucketHasTask()
        {
            BucketNotDeleted = ResponseMessages.BucketNotDeleted;
            return this;
        }
        public MessageService Build()
        {
            return new MessageService(this);
        }

    }
}
