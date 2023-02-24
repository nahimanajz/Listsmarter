using AutoMapper;
using CSharp_intro_1.Common.Repository.DataAccess;
using CSharp_intro_1.DB;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories.Models;
using Microsoft.EntityFrameworkCore;

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
            return _mapper.Map<List<BucketDto>>(_context.Buckets);
        }

        public BucketDto GetById(Guid id)
        {
            return _mapper.Map<BucketDto>(_context.Buckets.FirstOrDefault(bucket => bucket.Id == id));
        }

        public BucketDto Create(BucketDto newBucket)
        {
            var bucket = _mapper.Map<Bucket>(newBucket);
            _context.Buckets.Add(bucket);
            _context.SaveChanges();
            return _mapper.Map<BucketDto>(bucket);
        }

        public BucketDto Update(BucketDto bucket)
        {
            var updatedBucket = _context.Buckets.First(registeredbucket => registeredbucket.Id == bucket.Id);

            _mapper.Map(bucket, updatedBucket);
            _context.SaveChanges();
            return _mapper.Map<BucketDto>(updatedBucket);
        }

        public void Delete(Guid bucketId)
        {
            var bucket = _context.Buckets.First(bucket => bucket.Id == bucketId);
            _context.Buckets.Remove(bucket);
            _context.SaveChanges();
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
