using CSharp_intro_1.Models;
using CSharp_intro_1.Services;

namespace CSharp_intro_1
{
    public class BucketController
    {
        private readonly BucketService _service;


        public BucketController(BucketService service)
        {
            _service = service;
        }


        public List<BucketDto> GetAll()
        {

            return _service.GetAll();
        }
        public BucketDto GetById(Guid id)
        {

            return _service.GetById(id);
        }
        public void Create(BucketDto bucket)
        {
            _service.Create(bucket);
        }
        public void Delete(Guid id)
        {
            _service.Delete(id);
        }
        public void Update(BucketDto bucket)
        {
            _service.Update(bucket);
        }
    }
}