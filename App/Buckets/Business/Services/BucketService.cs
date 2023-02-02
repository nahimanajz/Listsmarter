
using CSharp_intro_1.Common.Business.ResponseMessages;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;
using CSharp_intro_1.Services.interfaces;

namespace CSharp_intro_1.Services
{
    public class BucketService : IBucketService
    {
        private readonly IBucketRepository _repo;
       

        public BucketService(IBucketRepository repo)
        {
            _repo = repo;
           
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
                throw new Exception(ResponseMessages.BucketNotFound);
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
            if (_repo.HasBucketTasks(id))
            {
                throw new Exception(ResponseMessages.BucketNotDeleted);
            }
            _repo.Delete(id);

        }
        private bool CheckTitleExistence(string title)
        {
            if (_repo.CheckTitleExistence(title))
            {
                throw new Exception(ResponseMessages.BucketAlreadyExist);
            }
            return false;
        }
    }
}
