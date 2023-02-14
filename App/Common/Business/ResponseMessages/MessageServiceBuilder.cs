namespace CSharp_intro_1.Common.Business.ResponseMessages
{
    public class MessageServiceBuilder
    {
        public string PersonNotFound;
        public string PersonNotDeleted;

        public string BucketNotFound;
        public string BucketNotDeleted;
        public string BucketAlreadyExist;
        public string BucketIsFull;

        public string TaskNotFound;       
        public string TaskOrPersonNotFound;

        public MessageServiceBuilder BuildPersonNotFound()
        {
            PersonNotFound ="Person Not Found";
            return this;
        }
        public MessageServiceBuilder BuildBucketNotFound()
        {
            BucketNotFound = "Bucket is not Found";
            return this;
        }
        public MessageServiceBuilder BuildBucketAlreadyExist()
        {
            BucketAlreadyExist = "Bucket called  is already exist please try different title";
            return this;
        }
        public MessageServiceBuilder BuildBucketIsFull()
        {
            BucketAlreadyExist = "Bucket is full";
            return this;
        }
        public MessageServiceBuilder BuildTaskNotFound()
        {
            TaskNotFound = "Task is not exist";
            return this;
        }
        public MessageServiceBuilder BuildTaskOrPersonNotFound()
        {
            TaskOrPersonNotFound = "Invalid person or task id";
            return this;
        }
        public MessageServiceBuilder BuildPersonHasTask()
        {
            PersonNotDeleted = "Person cannot be deleted due to some assigned tasks";
            return this;
        }
        public MessageServiceBuilder BuildBucketHasTask()
        {
            BucketNotDeleted = "Bucket can not be deleted due some task(s) assigned to it ";
            return this;
        }
        public MessageService Build()
        {
            return new MessageService(this);
        }

    }
}
