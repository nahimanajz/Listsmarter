using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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
        private List<Bucket> _buckets = new List<Bucket>
        {
            new Bucket
            {
                Id=1,
                Title= "Washing stuff",
            },
            new Bucket
            {
                Id=2,
                Title= "Meeting a friend",
            },
             new Bucket
            {
                Id=3,
                Title= " Calling a friend",
            },
             new Bucket
            {
                Id=4,
                Title= "Having a stuff",
            }

        };

        public List<BucketDto> GetAll()
        {
            return _mapper.Map<List<BucketDto>>(_buckets.ToList());

        }

        public BucketDto GetById(int id)
        {

            return _mapper.Map<BucketDto>(_buckets.FirstOrDefault(bucket => bucket.Id == id, null)); ;

        }

        public void Create(BucketDto bucket)
        {
            _buckets.Add(new Bucket { Id = _buckets.Count + 1, Title = bucket.Title});

        }

        public void Update(BucketDto bucket)
        {
            _buckets.Where(bucket => bucket.Id == bucket.Id).Select(bucket =>
            {
                bucket.Title = bucket.Title == null ? bucket.Title : bucket.Title;
                return bucket;
            }).ToList();


        }

        public void Delete(int bucketId)
        {
            var deleteRecord = _buckets.RemoveAll(bucket => bucket.Id == bucketId);
        }
    }
}
