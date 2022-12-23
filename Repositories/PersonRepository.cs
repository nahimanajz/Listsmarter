﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CSharp_intro_1.DB;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories.Models;
using CSharp_intro_1.Services;
using Microsoft.AspNetCore.Mvc;
using Task = System.Threading.Tasks.Task;

namespace CSharp_intro_1.Repositories
{
    public class PersonRepository: IRepository<PersonDto>
    {
        private readonly IMapper _mapper;

        public PersonRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
    
       
        
        public  List<PersonDto> GetAll()
        {
            return _mapper.Map<List<PersonDto>>(TempDb.people.ToList());
            
        }

        public PersonDto GetById(Guid id)
        {
            var person = TempDb.people.FirstOrDefault(person => person.Id == id, null);
            var mappedData = _mapper.Map<PersonDto>(person);
            return mappedData;
        }

        public void Create(PersonDto person)
        {
            TempDb.people.Add(_mapper.Map<Person>(person));
      
        }

        public void Update(PersonDto person)
        {
            TempDb.people.Where(psn => psn.Id == person.Id).Select(psn =>
            {
                psn.FirstName = person.FirstName != null ? person.FirstName : psn.FirstName;
                psn.LastName = person.LastName != null ? person.LastName : psn.LastName;
                return psn;
            }).ToList();

         
        }

        public void Delete(Guid personId)
        {
    
            var deleteRecord = TempDb.people.RemoveAll(person => person.Id == personId);
        }

        public void UpdateByStatus(int currentStatus, int newStatus)
        {
            throw new NotImplementedException();
        }

       
    }
  
}
