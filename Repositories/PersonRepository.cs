
using AutoMapper;
using CSharp_intro_1.DB;
using CSharp_intro_1.Models;
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
            return _mapper.Map<List<PersonDto>>(TempDb.people.ToList());

        }
        public PersonDto GetById(Guid id)
        {
            var person = TempDb.people.FirstOrDefault(person => person.Id == id, null);
            var mappedData = _mapper.Map<PersonDto>(person);
            return mappedData;
        }
        public PersonDto Create(PersonDto newPerson)
        {
            TempDb.people.Add(_mapper.Map<Person>(newPerson));
            return _mapper.Map<PersonDto>(TempDb.people.Last());

        }
        public PersonDto Update(PersonDto person)
        {
            var upatedPerson = TempDb.people.Where(currentPerson => currentPerson.Id == person.Id).Select(currentPerson =>
             {
                 currentPerson.FirstName = person.FirstName != null ? person.FirstName : currentPerson.FirstName;
                 currentPerson.LastName = person.LastName != null ? person.LastName : currentPerson.LastName;
                 return currentPerson;
             }).ToList();
            return GetById(person.Id);

        }

        public void Delete(Guid personId)
        {
            var deleteRecord = TempDb.people.RemoveAll(person => person.Id == personId);
        }
    }

}
