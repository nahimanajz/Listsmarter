using CSharp_intro_1.Common.Repository;
using CSharp_intro_1.Models;

public interface ITaskRepository:IGenericRepository<Task, TaskDto>
{
    bool IsPersonExist(Guid personId);
    List<TaskDto> GetByBucketAndStatus(Guid bucketId, int status);

    int CountBucketTasks(Guid bucketId);

    bool HasPersonTasks(Guid personId);



}
