
using CSharp_intro_1.Models;
using CSharp_intro_1.Services;

namespace CSharp_intro_1
{
    public class PersonController
    {
        private readonly PersonService _service;
        public PersonController(PersonService service)
        {
            _service = service;
        }

        public List<PersonDto> GetAll() { 
           
            return _service.GetAll();
        }
        public PersonDto GetById(int id)
        {

            return _service.GetById(id); 
        }
        public void Create(PersonDto person)
        {
            _service.Create(person);
        }
        public void Delete(int id)
        {
            _service.Delete(id);
        }
        public void Update(PersonDto person)
        {
            _service.Update(person);
        }
       

    }
}
