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
        public List<BucketDto> GetAll()
        {
            return _mapper.Map<List<BucketDto>>(_context.buckets);
        }

        public BucketDto GetById(Guid id)
        {
            return _mapper.Map<BucketDto>(_context.buckets.FirstOrDefault(bucket => bucket.Id == id, null));
        }

        public BucketDto Create(BucketDto newBucket)
        {
            _context.buckets.Add(_mapper.Map<Bucket>(newBucket));
            return _mapper.Map<BucketDto>(newBucket);
        }

        public BucketDto Update(BucketDto bucket)
        {
            var updatedBucket = _context.buckets.First(registeredbucket => registeredbucket.Id == bucket.Id);

            updatedBucket.Title = bucket.Title;

            return _mapper.Map<BucketDto>(updatedBucket);
        }

        public void Delete(Guid bucketId)
        {
            var bucket = _context.buckets.First(bucket => bucket.Id == bucketId);
            _context.buckets.Remove(bucket);
            _context.SaveChanges();
        }
        public bool CheckTitleExistence(String title)
        {
            return _context.buckets.Any(bucket => bucket.Title.ToUpper() == title.ToUpper());
        }

        public bool HasBucketTasks(Guid bucketId)
        {
            return _context.tasks.Any(task => task.Bucket.Id == bucketId);

        }
    }
}
