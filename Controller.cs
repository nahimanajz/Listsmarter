
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
        //TODO:1 . expected to pass throught person service to get get all people for get all method defined in I service
        // TODO:2. ADD OTHER REMAINING Methods

    }
}
