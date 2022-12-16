using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories.Models;


namespace CSharp_intro_1.Repositories
{
    public class PersonRepository: IRepository<PersonDto>
    {
        private readonly IMapper _mapper;

        public PersonRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
    


        private List<Person> _people = new List<Person>
        {
            new Person
            {
                Id=1,
                FirstName= "Nah",
                LastName="Jan..."

            },
            new Person
            {
                Id=2,
                FirstName= "second person",
                LastName="Eld..."

            },
            new Person
            {
                Id=3,
                FirstName= "Third",
                LastName="Ale..."

            }
        };
        
        public List<PersonDto> GetAll()
        {
            return _mapper.Map<List<PersonDto>>(_people.ToList());
            
        }

        public PersonDto GetById(int id)
        {
         
            return _mapper.Map<PersonDto>(_people.FirstOrDefault(person => person.Id == id, null)); ;

        }

        public void Create(PersonDto person)
        {
            var newPerson = new Person
            {
                Id = _people.Count + 1,
                FirstName = person.FirstName,
                LastName = person.LastName
            };
            _people.Add(newPerson);
      
        }

        public void Update(PersonDto person)
        {
            _people.Where(person => person.Id == person.Id).Select(person =>
            {
                person.FirstName = person.FirstName == null ? person.FirstName : person.FirstName;
                person.LastName = person.LastName == null ? person.LastName : person.LastName;
                return person;
            }).ToList();

         
        }

        public void Delete(int personId)
        {
            var deleteRecord = _people.RemoveAll(person => person.Id == personId);
        }


    }
  
}
