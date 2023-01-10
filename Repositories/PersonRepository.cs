
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
        public PersonDto Create(PersonDto person)
        {
            TempDb.people.Add(_mapper.Map<Person>(person));
            var createdPerson = TempDb.people.LastOrDefault(p => p.Id == person.Id, null);
            return _mapper.Map<PersonDto>(createdPerson);

        }
        public PersonDto Update(PersonDto person)
        {
            var upatedPerson = TempDb.people.Where(psn => psn.Id == person.Id).Select(psn =>
             {
                 psn.FirstName = person.FirstName != null ? person.FirstName : psn.FirstName;
                 psn.LastName = person.LastName != null ? person.LastName : psn.LastName;
                 return psn;
             }).ToList();
            return _mapper.Map<PersonDto>(upatedPerson);

        }

        public void Delete(Guid personId)
        {

            var deleteRecord = TempDb.people.RemoveAll(person => person.Id == personId);
        }
    }

}
