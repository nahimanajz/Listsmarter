
namespace CSharp_intro_1.Repositories.Models
{
    internal class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        private StatusEnum Status { get; set; } 
        public int Assignee { get; set; }
        public int Bucket { get; set; }
    }
}
