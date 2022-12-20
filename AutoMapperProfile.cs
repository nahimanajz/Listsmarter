
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
            .ForMember(personDto => personDto.FullName, opt => opt.MapFrom( person=> person.FirstName +" "+person.LastName));

            CreateMap<PersonDto, Person>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id == Guid.Empty ? Guid.NewGuid() : src.Id));
               
            
            CreateMap<Bucket, BucketDto>();
            //.ForMember(bucketDto => bucketDto.Title, opt => opt.MapFrom( bucket=> bucket.Title));

             CreateMap<BucketDto, Bucket>()
            //.ForMember(bucketDto => bucketDto.Title, opt => opt.MapFrom( bucket=> bucket.Title))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id == Guid.Empty ? Guid.NewGuid() : src.Id));



            CreateMap<Task, TaskDto>()
           .ForMember(taskDto => taskDto.Title, opt => opt.MapFrom(task => task.Title));

            CreateMap<TaskDto, Task>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id == Guid.Empty ? Guid.NewGuid() : src.Id));
          
          

        }
    }
}