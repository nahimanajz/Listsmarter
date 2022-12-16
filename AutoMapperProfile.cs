
using System.Runtime.InteropServices;
using AutoMapper;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories.Models;
using Task = CSharp_intro_1.Models.Task;

namespace CSharp_intro_1 {
    public class AutoMapperProfile: Profile{
        public AutoMapperProfile()
        {
          
            CreateMap<Person, PersonDto>()
            .ForMember(personDto => personDto.FirstName, opt => opt.MapFrom( person=> person.FirstName))
            .ForMember(personDto => personDto.LastName, opt => opt.MapFrom( person=> person.LastName))
            .ReverseMap();
        
            
        }
    }
}