using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CSharp_intro_1.DB;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories.Models;


namespace CSharp_intro_1.Repositories
{
    public class BucketRepository : IRepository<BucketDto>
    {
        private readonly IMapper _mapper;

        public BucketRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
      
        

        public List<BucketDto> GetAll()
        {
            return _mapper.Map<List<BucketDto>>(TempDb.buckets.ToList());

        }

        public BucketDto GetById(Guid id)
        {

            return _mapper.Map<BucketDto>(TempDb.buckets.FirstOrDefault(bucket => bucket.Id == id, null)); ;

        }

        public BucketDto Create(BucketDto bucket)
        {
         
           // _buckets.Add(_mapper.Map<Bucket>(bucket));
            var mappedObject = _mapper.Map<Bucket>(bucket);
          TempDb.buckets.Add(mappedObject);
           return _mapper.Map<BucketDto>(mappedObject);

                        

        }

        public void Update(BucketDto bucket)
        {
            TempDb.buckets.Where(bkt => bkt.Id == bucket.Id).Select(bkt =>
            {
                bkt.Title = bucket.Title == null ? bkt.Title : bucket.Title;
                return bucket;
            }).ToList();


        }

        public void Delete(Guid bucketId)
        {
            var deleteRecord = TempDb.buckets.RemoveAll(bucket => bucket.Id == bucketId);
        }

        public void UpdateByStatus(int currentStatus, int newStatus)
        {
            throw new NotImplementedException();
        }
    }
}
