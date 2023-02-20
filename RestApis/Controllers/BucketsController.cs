using AutoMapper;
using CSharp_intro_1.Models;
using CSharp_intro_1.Models.Validators;
using CSharp_intro_1.Services.interfaces;
using Microsoft.AspNetCore.Mvc;
using Task = System.Threading.Tasks.Task;

namespace RestApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BucketsController : ControllerBase
    {
        private readonly IBucketService _service;
        private readonly IMapper _mapper;
        private CreateBucketValidator _bucketValidator;


        public BucketsController(IBucketService service, IMapper mapper, CreateBucketValidator bucketValidator)
        {
            _service = service;
            _mapper = mapper;
            _bucketValidator = bucketValidator;
        }


        [HttpGet(Name = "Getbucket")]
        public async Task<ActionResult<List<BucketDto>>> GetAll()
        {
            return await Task.FromResult(_service.GetAll());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BucketDto>> GetById([FromRoute] Guid id)
        {
            return await Task.FromResult(Ok(_service.GetById(id)));
        }


        [HttpPost(Name = "CreateBucket")]
        public async Task<ActionResult<BucketDto>> Create([FromBody] CreateBucketDto bucket)
        {
            var result = _bucketValidator.Validate(bucket);
            if (result.IsValid)
            {
                var bucketDto = _mapper.Map<BucketDto>(bucket);
                return await Task.FromResult(Ok(_service.Create(bucketDto)));
            }
            throw new Exception($"Validations errors: {string.Join(",", result.Errors)}");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {

            _service.Delete(id);
            return await Task.FromResult(Ok("Bucket is deleted"));
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<BucketDto>> Update([FromRoute] Guid id, [FromBody] CreateBucketDto bucket)
        {
            var updatedBucket = new BucketDto
            {
                Id = id,
                Title = bucket.Title
            };
            return await Task.FromResult(Ok(_service.Update(updatedBucket)));
        }

    }

}


