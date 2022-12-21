using CSharp_intro_1.Models;
using CSharp_intro_1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BucketController : ControllerBase
    {
        private readonly BucketService _service;


        public BucketController(BucketService service)
        {
            _service = service;
        }
        [HttpGet(Name = "Getbucket")]

        public List<BucketDto> GetAll()
        {

            return _service.GetAll();
        }
        [HttpGet("{id}")]

        public BucketDto GetById(Guid id)
        {

            return _service.GetById(id);
        }
        [HttpPost(Name = "CreateBucket")]

        public void Create(BucketDto bucket)
        {
            _service.Create(bucket);
        }
        [HttpDelete(Name = "DeleteBucket")]

        public void Delete(Guid id)
        {
            _service.Delete(id);
        }
        [HttpPut (Name = "UpdateBucket")]
        public void Update(BucketDto bucket)
        {
            _service.Update(bucket);
        }
    }
}
