
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;
using CSharp_intro_1.Services.interfaces;
using CSharp_intro_1.Tasks.Business.Services.Interfaces;


namespace CSharp_intro_1.Services
{
    public class BucketService : IBucketService
    {
        private readonly IBucketRepository _repo;
        private readonly ITaskPersonBucketService _taskService;

        public BucketService(IBucketRepository repo, ITaskPersonBucketService taskService)
        {
            _repo = repo;
            _taskService = taskService;

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
                throw new Exception($"Bucket with {id} does not exist");
            }
            return bucket;
        }
        public BucketDto Update(BucketDto entity)
        {
            CheckBucketExistence(entity.Id);
            CheckTitleExistence(entity.Title);
            return _repo.Update(entity);
        }

        public void Delete(Guid id)
        {
            //TODO: THROW EXCEPTION WHEN TASK HAS ID
            CheckBucketExistence(id);
            if (!_taskService.HasTask(id))
            {
                _repo.Delete(id);
            }
        }

        private void CheckBucketExistence(Guid id)
        {
            GetById(id);
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
