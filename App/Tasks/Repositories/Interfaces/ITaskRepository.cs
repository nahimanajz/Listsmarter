using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;

public interface ITaskRepository : IRepository<TaskDto>
    {
        bool IsPersonExist(Guid personId); 
        List<TaskDto> GetByBucketAndStatus(Guid bucketId, int status);
        List<TaskDto> GetBucketTasks(Guid bucketId);
       
        int CountBucketTasks(Guid bucketId);
        
        bool HasPersonTasks(Guid personId);

        

    }
