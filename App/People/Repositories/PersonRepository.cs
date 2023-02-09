using AutoMapper;
using CSharp_intro_1.DB;
using CSharp_intro_1.Models;
using CSharp_intro_1.People.Repositories.Modal;
using CSharp_intro_1.Repositories.Models;

namespace CSharp_intro_1.Repositories
{
    public class PersonRepository : IRepository<PersonDto>
    {
        private readonly IMapper _mapper;

        public PersonRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
        public List<PersonDto> GetAll()
        {
            return _mapper.Map<List<PersonDto>>(TempDb.persons.ToList());

        }
        public PersonDto GetById(Guid id)
        {
            var person = TempDb.persons.FirstOrDefault(person => person.Id == id, null);
            var mappedData = _mapper.Map<PersonDto>(person);
            return mappedData;
        }
        public PersonDto Create(PersonDto newPerson)
        {
            TempDb.persons.Add(_mapper.Map<Person>(newPerson));
            return _mapper.Map<PersonDto>(newPerson);

        }
        public PersonDto Update(PersonDto person)
        {
            var upatedPerson = TempDb.persons.First(currentPerson => currentPerson.Id == person.Id);
            
            upatedPerson.FirstName = person.FirstName;
            upatedPerson.LastName = person.LastName;

            return _mapper.Map<PersonDto>(upatedPerson);

        }

        public void Delete(Guid personId)
        {
            TempDb.persons.RemoveAll(person => person.Id == personId);
        }
    }

}
