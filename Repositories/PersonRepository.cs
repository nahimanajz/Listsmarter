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
    


        private List<PersonDto> _people = new List<PersonDto>
        {
            new PersonDto
            {
                Id=1,
                FirstName= "Nah",
                LastName="Jan..."

            },
            new PersonDto
            {
                Id=2,
                FirstName= "second person",
                LastName="Eld..."

            },
            new PersonDto
            {
                Id=3,
                FirstName= "Third",
                LastName="Ale..."

            }
        };
        
        public List<PersonDto> GetAll()
        {
            return _people;
        }

        public PersonDto GetById(int id)
        {
            var person = _people.First(p => p.Id == id);
            return person;

        }

        public void Create(PersonDto person)
        {
            _people.Add(person);

        }

        public void Update(PersonDto person)
        {
   
           _people.Where(p => p.Id == person.Id)
                .Select(w => {
                w.LastName = person.FirstName;
                w.LastName = person.LastName;
                return w;
                }).ToList();
         
        }

        public void Delete(int personId)
        {
            var deleteRecord = _people.RemoveAll(person => person.Id == personId);
        }


    }
  
}
