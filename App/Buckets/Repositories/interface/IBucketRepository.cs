using CSharp_intro_1.Models;

namespace CSharp_intro_1.Repositories
{
    public interface IBucketRepository: IRepository<BucketDto>
    {
        bool CheckTitleExistence(String title);
    }
}