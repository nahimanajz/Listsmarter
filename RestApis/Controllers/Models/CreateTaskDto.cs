namespace CSharp_intro_1.Models
{
    public class CreateTaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; } 
        public Guid Person { get; set; }
        public Guid Bucket { get; set; }
        public int Priority { get; set; }

    }
}
