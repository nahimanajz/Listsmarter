using CSharp_intro_1.Common.Repository;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories.Models;

namespace CSharp_intro_1.Repositories
{
    public interface IBucketRepository:IGenericRepository<Bucket, BucketDto>
    {
        bool CheckTitleExistence(String title);
        bool HasBucketTasks(Guid bucketId);

    }
}