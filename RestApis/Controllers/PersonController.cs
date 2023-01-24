using AutoMapper;
using CSharp_intro_1.Models;
using CSharp_intro_1.Models.Validators;
using CSharp_intro_1.Services;
using CSharp_intro_1.Services.interfaces;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Task = System.Threading.Tasks.Task;

namespace RestApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _service;
        private readonly IMapper _mapper;
        private CreatePersonValidator _createPersonValidator;
        public PersonController(IPersonService service, IMapper mapper,CreatePersonValidator createPersonValidator )
        {
            _service = service;
            _mapper= mapper;
            _createPersonValidator = createPersonValidator;
        }

        [HttpGet(Name = "GetPeople")]
        public async Task<ActionResult<List<PersonDto>>> GetAll()
        {
            return await Task.FromResult(_service.GetAll());
        }

        [HttpGet("person/{id}")]
        public async Task<ActionResult<PersonDto>> GetById([FromRoute] Guid id)
        {
            var person = _service.GetById(id);
            if (person == null)
            {
                return await Task.FromResult(NotFound("Person Not found"));
            }
            return await Task.FromResult(person);
        }

        [HttpPost(Name = "CreatePerson")]
        public async Task<ActionResult<PersonDto>> Create([FromBody] CreatePersonDto person)
        {

            var result = _createPersonValidator.Validate(person);
            if(result.IsValid)
            {
                var personDto = _mapper.Map<PersonDto>(person);
                return await Task.FromResult(Ok(_service.Create(personDto)));
            }
            throw new Exception($"Validations errors: {string.Join(",", result.Errors)}");

        

        }

        [HttpDelete("person/{id:Guid}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
        
            _service.Delete(id);
            return await Task.FromResult(Ok("Person is deleted"));


        }
        [HttpPut("person/{id:Guid}")]
        public async Task<ActionResult<PersonDto>> Update([FromRoute] Guid id, [FromBody] CreatePersonDto person)
        {
            var updatedPerson = new PersonDto
            {
                Id = id,
                FirstName = person.FirstName,
                LastName = person.LastName,
            };
            return await Task.FromResult(Ok(_service.Update(updatedPerson)));
        }

    }
}
