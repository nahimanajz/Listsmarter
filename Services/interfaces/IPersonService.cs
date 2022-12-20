using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_intro_1.Models;

namespace CSharp_intro_1.Services.interfaces
{
    public interface IPersonService
    {
        List<PersonDto> GetAll();
        PersonDto GetById(Guid id);
        void Create(PersonDto personDto);
        void Update(PersonDto personDto);
        void Delete(Guid id);
    }
}
