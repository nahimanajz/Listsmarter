using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;

public interface ITaskRepository : IRepository<TaskDto>
    {
        TaskDto AssignTask(Guid taskId, Guid personId); 
        List<TaskDto> GetByBucketAndStatus(Guid bucketId, int status);
        TaskDto UpdateByStatus(Guid taskId, int currentStatus, int newStatus); 
        int CountBucketTasks(Guid bucketId);
        bool HasBucketTasks(Guid bucketId);
        bool HasPersonTasks(Guid personId);

        

    }
