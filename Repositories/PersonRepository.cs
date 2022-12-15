using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories.Models;


namespace CSharp_intro_1.Repositories
{
    public class PersonRepository: IRepository<Person>
    {
        private readonly IMapper _mapper;

        public PersonRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public PersonRepository()
        {
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
        
        public List<Person> GetAll()
        {
            return _people;
        }

        public Person GetById(int id)
        {
            var person = _people.First(p => p.Id == id);
            return person;

        }

        public Person Create(Person entity)
        {
            throw new NotImplementedException();
        }

        public Person Update(Person entity)
        {
            throw new NotImplementedException();
        }

        public Person Delete(int entity)
        {
            throw new NotImplementedException();
        }
    }

  
}
