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
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _service;
        private readonly IMapper _mapper;
        private CreatePersonValidator _createPersonValidator;
        public PersonsController(IPersonService service, IMapper mapper,CreatePersonValidator createPersonValidator )
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

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDto>> GetById([FromRoute] Guid id)
        {
            return await Task.FromResult(_service.GetById(id));
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

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
        
            _service.Delete(id);
            return await Task.FromResult(Ok("Person is deleted"));


        }
        [HttpPut("{id:Guid}")]
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
