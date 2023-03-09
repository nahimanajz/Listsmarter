using AutoMapper;
using CSharp_intro_1.Models;
using CSharp_intro_1.Models.Validators;
using CSharp_intro_1.Services.interfaces;
using Microsoft.AspNetCore.Mvc;
using RestApis.Controllers.Models;
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
        private readonly string AppDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\buckets\\photos");

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

        [HttpPost]
        [Consumes("multipart/form-data")]
        [Route("image/upload")]
        public async Task<ActionResult> PostAsync(IFormFile file)
        {
            try
            {
                PhotoUpload fileContent = await SaveFileAsync(file);
                if (!string.IsNullOrEmpty(fileContent.FilePath))
                {
                    return await Task.FromResult(Ok(fileContent));
                }
                else
                {
                    return await Task.FromResult(BadRequest("Bad request"));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message));
            }
        }
        private async Task<PhotoUpload> SaveFileAsync(IFormFile bucketFile)
        {
            PhotoUpload file = new PhotoUpload();
            if (bucketFile != null)
            {
                if (!Directory.Exists(AppDirectory))
                    Directory.CreateDirectory(AppDirectory);
                var fileName = DateTime.Now.Ticks.ToString() + Path.GetExtension(bucketFile.FileName);
                var path = Path.Combine(AppDirectory, fileName);
                file.PhotoName= fileName;
                file.FilePath = path;

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await bucketFile.CopyToAsync(stream);
                }
                return file;
            }
            return file;
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
           var updatableBucket = _mapper.Map<BucketDto>(bucket);
           updatableBucket.Id = id;
           return await Task.FromResult(Ok(_service.Update(updatableBucket)));
        }
        
    }

}


