
namespace CSharp_intro_1.Models
{
    public class TaskDTto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status {get; set;} //TODO: Need check for accessibility
        public int Assignee { get; set; } // person id
        public int Bucket { get; set; } // bucket id
    }
}
