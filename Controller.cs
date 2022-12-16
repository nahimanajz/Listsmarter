
using CSharp_intro_1.Models;
using CSharp_intro_1.Services;

namespace CSharp_intro_1
{
    public class Controller
    {
        private readonly IService<PersonDto> _service;
        

        public Controller(IService<PersonDto> service)
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
        //TODO:1 . expected to pass throught person service to get get all people for get all method defined in I service
        // TODO:2. ADD OTHER REMAINING Methods

    }
}
