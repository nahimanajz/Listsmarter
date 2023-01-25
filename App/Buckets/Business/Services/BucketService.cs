
using System.Reflection.Metadata;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;
using CSharp_intro_1.Services.interfaces;
using CSharp_intro_1.Tasks.Business.Services.Interfaces;
using FluentValidation;
using Microsoft.Extensions.Hosting;

namespace CSharp_intro_1.Services
{
    public class BucketService : IBucketService
    {
        private readonly IRepository<BucketDto> _repo;
        private readonly ITaskPersonBucketService _taskService;


        public BucketService(IRepository<BucketDto> repo, ITaskPersonBucketService taskService)
        {
            _repo = repo;
            _taskService = taskService;

        }
        public BucketDto Create(BucketDto entity)
        {
            var CheckBucketExistence = _repo.GetAll().Any(bucket => bucket.Title.ToLower() == entity.Title.ToLower());
            if (!CheckBucketExistence)
            {
                return _repo.Create(entity);
            }
            throw new Exception($"{entity.Title} is already exist please try different title");
        }
        public List<BucketDto> GetAll()
        {
            return _repo.GetAll();
        }
        public BucketDto GetById(Guid id)
        {
             var bucket = _repo.GetById(id);
            if(bucket ==null ){
                throw new Exception($"Bucket with {id} does not exist");
            }
            return bucket;
            

        }
        public BucketDto Update(BucketDto entity)
        {
            CheckBucketExistence(entity.Id);
            var isTitleExist = _repo.GetAll().Any(bucket => bucket.Title.ToLower() == entity.Title.ToLower());
            if (!isTitleExist)
            {

                return _repo.Update(entity);
            }
            throw new Exception($"{entity.Title} is already exist please try different title");
        }

        public void Delete(Guid id)
        {
            CheckBucketExistence(id);
            if (!_taskService.HasTask(id))
            {
                _repo.Delete(id);
            }
        }

        private void CheckBucketExistence(Guid id)
        {
            if (GetById(id) == null)
            {
                throw new Exception("Bucket does not exist");
            }
        }
    }
}
