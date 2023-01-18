
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;
using CSharp_intro_1.Services.interfaces;
using FluentValidation;
using Microsoft.Extensions.Hosting;

namespace CSharp_intro_1.Services
{
    public class BucketService : IBucketService
    {
        private readonly IRepository<BucketDto> _repo;
        //private readonly ITaskService _taskService;
        //private readonly PersonService _personService;

        public BucketService(IRepository<BucketDto> repo)/*, ITaskService taskService*/
        {
            _repo = repo;
            //_taskService = taskService;
        }
        public BucketDto Create(BucketDto entity)
        {
            var isBucketExist = _repo.GetAll().Any(bucket => bucket.Title == entity.Title);
            if (!isBucketExist)
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
            return _repo.GetById(id);

        }
        public BucketDto Update(BucketDto entity)
        {
            var isBucketExist = _repo.GetAll().Any(bucket => bucket.Title == entity.Title);
            if (!isBucketExist)
            {
                return _repo.Update(entity);
            }
            throw new Exception($"{entity.Title} is already exist please try different title");
        }
        public void Delete(Guid id)
        {
            /*

            bool isBucketEmpty = _taskService.GetAll().Any<TaskDto>(task => task.Bucket.Id == id);
            if (!isBucketEmpty)
            {
                _repo.Delete(id);
            }
            else
            {
                throw new("Bucket has some tasks yet you can not delete it");

            }
            */
        }

        public BucketDto GetByStatus(int status)
        {
            throw new NotImplementedException();
        }


    }
}
