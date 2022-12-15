
using CSharp_intro_1.Repositories.Models;

namespace CSharp_intro_1.Models
{
    public class TaskDTto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status {get; set;} //TODO: Need check for accessibility
        public IList<Person> Assignee { get; set; } // person id
       // public IList<Bucket> Buckets { get; set; } // bucket id
    }
}
