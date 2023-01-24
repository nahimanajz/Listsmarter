using AutoMapper;
using CSharp_intro_1.Models;
using CSharp_intro_1.Models.Validators;
using CSharp_intro_1.Repositories.Models;
using CSharp_intro_1.Services;
using CSharp_intro_1.Services.interfaces;
using Microsoft.AspNetCore.Mvc;
using Task = System.Threading.Tasks.Task;

namespace RestApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BucketController : ControllerBase
    {
        private readonly IBucketService _service;
        private readonly IMapper _mapper;
        private CreateBucketValidator _bucketValidators;


        public BucketController(IBucketService service, IMapper mapper, CreateBucketValidator bucketValidators)
        {
            _service = service;
            _mapper = mapper;
            _bucketValidators = bucketValidators;
        }
        [HttpGet(Name = "Getbucket")]

        public async Task<ActionResult<List<BucketDto>>> GetAll()
        {

            return await Task.FromResult(_service.GetAll());
        }
        [HttpGet("bucket/{id}")]

        public async Task<ActionResult<BucketDto>> GetById([FromRoute] Guid id)
        {
            var bucket = _service.GetById(id);
            if (bucket == null)
            {
                return await Task.FromResult(NotFound("Bucket Not found"));
            }
            return await Task.FromResult(Ok(bucket));

        }
        [HttpPost(Name = "CreateBucket")]

        public async Task<ActionResult<BucketDto>> Create([FromBody] CreateBucketDto bucket)
        {
            var result = _bucketValidators.Validate(bucket);
            if (result.IsValid)
            {
                var bucketDto = _mapper.Map<BucketDto>(bucket);
                return await Task.FromResult(Ok(_service.Create(bucketDto)));
            }
            throw new Exception($"Validations errors: {string.Join(",", result.Errors)}");
        }

        [HttpDelete("bucket/{id}")]

        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {

            _service.Delete(id);
            return await Task.FromResult(Ok("Bucket is deleted"));

        }
        [HttpPut("bucket/{id:Guid}")]
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


