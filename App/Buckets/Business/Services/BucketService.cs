
using CSharp_intro_1.Common.Business.ResponseMessages;
using CSharp_intro_1.Common.Repository;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;
using CSharp_intro_1.Repositories.Models;
using CSharp_intro_1.Services.interfaces;

namespace CSharp_intro_1.Services
{
    public class BucketService : IBucketService
    {
        
        private readonly IBucketRepository _repo;
        MessageServiceBuilder builder = new MessageServiceBuilder();


        public BucketService( IBucketRepository repo)
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
                builder.BuildBucketNotFound().Build();
                var exceptionMessage = new MessageService(builder).BucketNotFound;
                throw new Exception(exceptionMessage);
                // TODO RE
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
                builder.BuildBucketHasTask().Build();
                var exceptionMessage = new MessageService(builder).BucketNotDeleted;
                throw new Exception(exceptionMessage);
            }
            _repo.Delete(id);

        }
        private bool CheckTitleExistence(string title)
        {
            if (_repo.CheckTitleExistence(title))
            {

                builder.BuildBucketAlreadyExist().Build();
                var exceptionMessage = new MessageService(builder).BucketAlreadyExist;
                throw new Exception(exceptionMessage);
            }
            return false;
        }
    }
}
