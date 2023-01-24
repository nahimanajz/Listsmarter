

namespace CSharp_intro_1.Repositories.Models
{
    public class Person
    {
       public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Task> Tasks {get; set;}
    }
}
