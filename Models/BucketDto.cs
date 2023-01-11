

namespace CSharp_intro_1.Models
{
    public class BucketDto
    {
       public Guid Id { get; set; }
        public string Title { get; set; }
        public List<TaskDto> Tasks { get; set; }
    }
}
