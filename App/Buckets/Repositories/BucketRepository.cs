using AutoMapper;
using CSharp_intro_1.Common.Repository.DataAccess;
using CSharp_intro_1.DB;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories.Models;


namespace CSharp_intro_1.Repositories
{
    public class BucketRepository : IBucketRepository
    {
        private readonly IMapper _mapper;
        private readonly AppContexts _context;

        public BucketRepository(IMapper mapper, AppContexts contexts)
        {
            _mapper = mapper;
            _context = contexts;
        }
       
        public bool CheckTitleExistence(String title)
        {
            return _context.Buckets.Any(bucket => bucket.Title.ToUpper() == title.ToUpper());
        }

        public bool HasBucketTasks(Guid bucketId)
        {
            return _context.Tasks.Any(task => task.Bucket.Id == bucketId);

        }
    }
}
