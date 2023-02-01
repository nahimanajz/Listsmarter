
using CSharp_intro_1.Buckets.Business.Validations;
using CSharp_intro_1.Common.Business.Services;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;
using CSharp_intro_1.Services.interfaces;
using CSharp_intro_1.Tasks.Business.Services.Interfaces;


namespace CSharp_intro_1.Services
{
    public class BucketService : IBucketService
    {
        private readonly IBucketRepository _repo;
        private readonly IBucketValidationService _bucketValidationService;

        public BucketService(IBucketRepository repo, IBucketValidationService bucketValidationService)
        {
            _repo = repo;
            _bucketValidationService = bucketValidationService;
        }

        public BucketDto Create(BucketDto entity)
        {
            CheckTitleExistence(entity.Title);
            return _repo.Create(entity);
        }
        public List<BucketDto> GetAll()
        {
            return _repo.GetAll();
        }
        public BucketDto GetById(Guid id)
        {
            var bucket = _repo.GetById(id);
            if (bucket == null)
            {
                MessageServiceBuilder builder = new MessageServiceBuilder();
                MessageService message = builder.BuildBucketNotFound($"Bucket with  this {id} Id is not exist").build();
                // throw new Exception(message);
            }
            return bucket;
        }
        public BucketDto Update(BucketDto entity)
        {
            GetById(entity.Id);
            CheckTitleExistence(entity.Title);
            return _repo.Update(entity);
        }

        public void Delete(Guid id)
        {

            GetById(id);
            if (_bucketValidationService.HasBucketTasks(id))
            {
                throw new Exception("Bucket can not be deleted due some task(s) assigned to it ");
            }
            _repo.Delete(id);

        }
        private bool CheckTitleExistence(string title)
        {
            if (_repo.CheckTitleExistence(title))
            {
                throw new Exception($"Bucket called {title} is already exist please try different title");
            }
            return false;
        }
    }
}
