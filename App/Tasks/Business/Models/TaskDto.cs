using CSharp_intro_1.Common.Business.Models.Abstractions;

namespace CSharp_intro_1.Models
{


    public class TaskDto : IIdentityDto
    {
       public Guid Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public Status Status {get; set;} 
        public PersonDto Person { get; set; }  
        public BucketDto Bucket { get; set; }
    }
}
