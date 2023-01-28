using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;

public interface ITaskRepository : IRepository<TaskDto>
    {
        void AssignTask(Guid taskId, Guid personId); // //TODO: change return type to task dto
        List<TaskDto> GetByBucketAndStatus(Guid bucketId, int status);
        void UpdateByStatus(int currentStatus, int newStatus); //TODO: change return type to task dto
        
        int CountBucketTasks(Guid bucketId);
        bool HasBucketTasks(Guid bucketId);
        bool HasPersonTasks(Guid personId);

        

    }
