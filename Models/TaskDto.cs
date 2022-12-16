
using CSharp_intro_1.Repositories.Models;

namespace CSharp_intro_1.Models
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status {get; set;} //TODO: Has to be changed to enum
        public PersonDto Assignee { get; set; } 
        public BucketDto Bucket { get; set; }
    }
}
