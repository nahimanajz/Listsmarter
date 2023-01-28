
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;
using CSharp_intro_1.Services.interfaces;
using CSharp_intro_1.Tasks.Business.Services.Interfaces;


namespace CSharp_intro_1.Services
{
    public class BucketService : IBucketService
    {
        private readonly IBucketRepository _repo;
        private readonly ITaskService _taskService;

        public BucketService(IBucketRepository repo, ITaskService taskService)
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
                throw new Exception($"Bucket with  this {id} Id is not exist");
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
            if (!_taskService.HasBucketTasks(id))
            {
                _repo.Delete(id);
            }
            else
            {
                throw new Exception("Bucket cannot be deleted due to some assigned tasks");
            }
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
