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
                Id=Guid.Parse("84c5e37c-23a6-41cb-b023-a1ed089f728e"),
                FirstName= "Nah",
                LastName="Jan..."

            },
            new Person
            {
                Id= Guid.Parse("9D2B0228-4D0D-4C23-8B49-01A698851109")
,
                FirstName= "second person",
                LastName="Eld..."

            },
            new Person
            {
                Id= Guid.Parse("9D2B0728-4D0D-4C43-8B49-01A698857709"),
                FirstName= "Third",
                LastName="Ale..."

            }
        };
        
        public List<PersonDto> GetAll()
        {
            return _mapper.Map<List<PersonDto>>(_people.ToList());
            
        }

        public PersonDto GetById(Guid id)
        {
         
            return _mapper.Map<PersonDto>(_people.FirstOrDefault(person => person.Id == id, null)); ;

        }

        public void Create(PersonDto person)
        {
          
            _people.Add(_mapper.Map<Person>(person));
      
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

        public void Delete(Guid personId)
        {
            var deleteRecord = _people.RemoveAll(person => person.Id == personId);
        }


    }
  
}
