using AutoMapper;
using CSharp_intro_1.Models;
using CSharp_intro_1.People.Repositories.Modal;
using CSharp_intro_1.Repositories.Models;
using Task = CSharp_intro_1.Repositories.Models.Task;

namespace CSharp_intro_1
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Person, PersonDto>()
                .ForMember(personDto => personDto.FullName, opt => opt.MapFrom(person => person.FirstName + " " + person.LastName));

            CreateMap<PersonDto, Person>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Bucket, BucketDto>();
            CreateMap<BucketDto, Bucket>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Task, TaskDto>()
                .ForMember(taskDto => taskDto.Title, opt => opt.MapFrom(task => task.Title));

            CreateMap<TaskDto, Task>()
                .ForMember(dest => dest.PersonId, opt => opt.MapFrom(src => src.Person.Id))
                .ForMember(dest => dest.BucketId, opt => opt.MapFrom(src => src.Bucket.Id))

                .ForMember(dest => dest.Bucket, opt => opt.Ignore())
                .ForMember(dest => dest.Person, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());


        }
    }
}