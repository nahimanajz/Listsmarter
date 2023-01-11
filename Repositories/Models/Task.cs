
using CSharp_intro_1.Repositories.Models;

namespace CSharp_intro_1.Repositories.Models
{
    public class Task
    {
       public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; } 
        public Guid Assignee { get; set; }
        public Guid Bucket { get; set; }
    }
}
