

using CSharp_intro_1.Common.Business.Models.Abstractions;

namespace CSharp_intro_1.Models
{
    public class PersonDto : IIdentityDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }


    }
}

