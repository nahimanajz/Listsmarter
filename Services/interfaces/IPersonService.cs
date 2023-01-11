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
        PersonDto Create(PersonDto personDto);
        PersonDto Update(PersonDto personDto);
        bool Delete(Guid id);
    }
}
