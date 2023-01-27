using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;

public interface ITaskRepository : IRepository<TaskDto>
    {
        void AssignTask(Guid taskId, Guid personId);
        List<TaskDto> GetByBucketAndStatus(Guid bucketId, int status);
        void UpdateByStatus(int currentStatus, int newStatus);
        

    }
