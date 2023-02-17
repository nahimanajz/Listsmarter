using CSharp_intro_1.Models;

namespace CSharp_intro_1.Repositories
{
    public interface IBucketRepository
    {
        bool CheckTitleExistence(String title);
        bool HasBucketTasks(Guid bucketId);
       
    }
}