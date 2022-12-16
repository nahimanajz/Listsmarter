
using CSharp_intro_1.Repositories.Models;

namespace CSharp_intro_1.Models
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status {get; set;} 
        public PersonDto Assignee { get; set; } 
        public Bucket Bucket { get; set; }
    }
}
