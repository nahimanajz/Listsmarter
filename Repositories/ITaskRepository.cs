using CSharp_intro_1.Models;
public interface ITaskRepository 
    {
        void AssignTask(Guid taskId, Guid personId);
        List<TaskDto> GetByBucketAndStatus(Guid bucketId, int status);
        void UpdateByStatus(int currentStatus, int newStatus);
        

    }
