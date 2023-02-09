using AutoMapper;
using CSharp_intro_1.Common.Repository.DataAccess;
using CSharp_intro_1.DB;
using CSharp_intro_1.Models;
using CSharp_intro_1.People.Repositories.Modal;
using CSharp_intro_1.Repositories.Models;

namespace CSharp_intro_1.Repositories
{
    public class PersonRepository : IRepository<PersonDto>
    {
        private readonly IMapper _mapper;
        private readonly AppContexts _context;

        public PersonRepository(IMapper mapper, AppContexts context)
        {
            _mapper = mapper;
            _context = context;
        }
        public List<PersonDto> GetAll()
        {
            return _mapper.Map<List<PersonDto>>(_context.persons.ToList());

        }
        public PersonDto GetById(Guid id)
        {
            var person = _context.persons.FirstOrDefault(person => person.Id == id, null);
            var mappedData = _mapper.Map<PersonDto>(person);
            return mappedData;
        }
        public PersonDto Create(PersonDto newPerson)
        {
            _context.persons.Add(_mapper.Map<Person>(newPerson));
            return _mapper.Map<PersonDto>(newPerson);

        }
        public PersonDto Update(PersonDto person)
        {
            var upatedPerson = _context.persons.First(currentPerson => currentPerson.Id == person.Id);
            
            upatedPerson.FirstName = person.FirstName;
            upatedPerson.LastName = person.LastName;

            return _mapper.Map<PersonDto>(upatedPerson);

        }

        public void Delete(Guid personId)
        {
            var person = _context.persons.First(person => person.Id == personId);
            _context.persons.Remove(person);
            _context.SaveChanges();
        }
    }

}
