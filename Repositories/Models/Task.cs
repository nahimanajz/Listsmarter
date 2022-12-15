
namespace CSharp_intro_1.Models
{
    internal class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public StatusEnum Status { get; set; } 
        public IList<PersonDto> Assignee { get; set; }
        public IList<BucketDto> Bucket { get; set; }
    }
}
