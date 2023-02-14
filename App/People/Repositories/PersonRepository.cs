using System.Net.Sockets;
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
            return _mapper.Map<List<PersonDto>>(_context.Persons.ToList());

        }
        public PersonDto GetById(Guid id)
        {
            var person = _context.Persons.FirstOrDefault(person => person.Id == id);
            return _mapper.Map<PersonDto>(person);
        }
        public PersonDto Create(PersonDto newPerson)
        {
            var person = _mapper.Map<Person>(newPerson);
            _context.Persons.Add(person);
            _context.SaveChanges();
            return _mapper.Map<PersonDto>(person);

        }
        public PersonDto Update(PersonDto person)
        {
            var upatedPerson = _context.Persons.First(currentPerson => currentPerson.Id == person.Id);
            _mapper.Map(person, upatedPerson);

            _context.SaveChanges();

            return _mapper.Map<PersonDto>(upatedPerson);

        }

        public void Delete(Guid personId)
        {
            var person = _context.Persons.First(person => person.Id == personId);
            _context.Persons.Remove(person);
            _context.SaveChanges();
        }
    }

}
