
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
            .ForMember(personDto => personDto.FullName, opt => opt.MapFrom( person=> person.FirstName +" "+person.LastName))
            .ReverseMap();
            
            CreateMap<Bucket, BucketDto>()
            .ForMember(bucketDto => bucketDto.Title, opt => opt.MapFrom( bucket=> bucket.Title))
            .ReverseMap();

            CreateMap<Task, TaskDto>()
           .ForMember(taskDto => taskDto.Title, opt => opt.MapFrom(task => task.Title))
          
           .ReverseMap();


        }
    }
}