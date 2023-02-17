

using CSharp_intro_1.Common.Business.Models.Abstractions;

namespace CSharp_intro_1.Models
{
    public class BucketDto:IIdentityDto
    {
       public Guid Id { get; set; }
        public string Title { get; set; }
    
       
    }
}
