using AutoMapper;
using CSharp_intro_1.Models;

namespace RestApis
{
    public class ApiMapperValidations : Profile
    {
        public ApiMapperValidations()
        {
            CreateMap<CreatePersonDto, PersonDto>()
            .ReverseMap();
            CreateMap<CreateBucketDto, BucketDto>()
            .ReverseMap();
            CreateMap<CreateTaskDto, TaskDto>()
            .ForPath(dest => dest.Bucket.Id, opt => opt.MapFrom(src => src.Bucket))
            .ForPath(dest => dest.Person.Id, opt => opt.MapFrom(src => src.Person))
            .ReverseMap();


        }
    }
}
