using CSharp_intro_1.Models;
using CSharp_intro_1.Services;
using CSharp_intro_1.Services.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task = System.Threading.Tasks.Task;

namespace RestApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonService _service;
        public PersonController(PersonService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetPeople")]
        public async Task<ActionResult<List<PersonDto>>> GetAll()
        {

            return await Task.FromResult(_service.GetAll());
        }
        
        [HttpPost (Name ="CreatePerson")]
        public void Create(PersonDto person)
        {
             _service.Create(person);
        }
        [HttpDelete (Name="DeletePerson")]
        public void Delete(Guid id)
        {
            _service.Delete(id);
        }
        [HttpPut(Name = "UpdatePerson")]
        public void Update(PersonDto person)
        {
            _service.Update(person);
        }
        [HttpGet("{id}")]
        public PersonDto GetById(Guid id)
        {

            return _service.GetById(id);
        }

    }
}
