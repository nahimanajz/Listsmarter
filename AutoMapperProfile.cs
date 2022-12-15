
using AutoMapper;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories.Models;

namespace CSharp_intro_1 {
    public class AutoMapperProfile: Profile{
        public AutoMapperProfile()
        {
            CreateMap<PersonDto, Person>()
            .ForMember(dest => dest.FirstName, source => source.Ignore())
            .ReverseMap();
            CreateMap<PersonDto, Person>()
           .ForMember(dest => dest.FirstName, source => source.Ignore())
           .ReverseMap();
        }
    }
}