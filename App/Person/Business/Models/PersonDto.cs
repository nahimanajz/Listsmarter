

namespace CSharp_intro_1.Models
{
    public class PersonDto
    { 
       public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public List<TaskDto> Tasks { get; set; }
        public string Title { get; set; }
    }
}

