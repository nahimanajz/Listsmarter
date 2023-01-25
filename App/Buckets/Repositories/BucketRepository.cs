using AutoMapper;
using CSharp_intro_1.DB;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories.Models;


namespace CSharp_intro_1.Repositories
{
    public class BucketRepository : IBucketRepository
    {
        private readonly IMapper _mapper;

        public BucketRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<BucketDto> GetAll()
        {
            return _mapper.Map<List<BucketDto>>(TempDb.buckets);
        }

        public BucketDto GetById(Guid id)
        {

            return _mapper.Map<BucketDto>(TempDb.buckets.FirstOrDefault(bucket => bucket.Id == id, null));
        }

        public BucketDto Create(BucketDto newBucket)
        {
            TempDb.buckets.Add(_mapper.Map<Bucket>(newBucket));
            return _mapper.Map<BucketDto>(newBucket);
        }

        public BucketDto Update(BucketDto bucket)
        {
            var updatedBucket = TempDb.buckets.Where(registeredbucket => registeredbucket.Id == bucket.Id).Select(registeredbucket =>
             {
                 registeredbucket.Title = bucket.Title == null ? registeredbucket.Title : bucket.Title;
                 return bucket;
             }).ToList();

            return _mapper.Map<BucketDto>(updatedBucket);
        }

        public void Delete(Guid bucketId)
        {
            TempDb.buckets.RemoveAll(bucket => bucket.Id == bucketId);
        }
        public bool CheckTitleExistence(String title)
        {
            return TempDb.buckets.Any(bucket => bucket.Title.ToUpper() == title.ToUpper());
        }



    }
}
