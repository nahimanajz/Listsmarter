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
                Id=Guid.Parse("9D2B0228-4D0D-4C23-8B49-01A698857709"),
                Title= "Washing stuff",
            },
            new Bucket
            {
                Id= Guid.Parse("9D3B0228-4D0D-4C23-8B49-01A698857709"),
                Title= "Meeting a friend",
            },
             new Bucket
            {
                Id= Guid.Parse("9C2B0228-4D0D-4C23-8B49-01A698857709"),
                Title= " Calling a friend",
            },
             new Bucket
            {
                Id= Guid.Parse("1D2B0228-4D0D-4C23-8B49-01A698851109"),
                Title= "Having a stuff",
            }

        };

        public List<BucketDto> GetAll()
        {
            return _mapper.Map<List<BucketDto>>(_buckets.ToList());

        }

        public BucketDto GetById(Guid id)
        {

            return _mapper.Map<BucketDto>(_buckets.FirstOrDefault(bucket => bucket.Id == id, null)); ;

        }

        public void Create(BucketDto bucket)
        {
           // _buckets.Add(new Bucket { Id = _buckets.Count + 1, Title = bucket.Title});
            _buckets.Add(_mapper.Map<Bucket>(bucket));
                        

        }

        public void Update(BucketDto bucket)
        {
            _buckets.Where(bucket => bucket.Id == bucket.Id).Select(bucket =>
            {
                bucket.Title = bucket.Title == null ? bucket.Title : bucket.Title;
                return bucket;
            }).ToList();


        }

        public void Delete(Guid bucketId)
        {
            var deleteRecord = _buckets.RemoveAll(bucket => bucket.Id == bucketId);
        }
    }
}
