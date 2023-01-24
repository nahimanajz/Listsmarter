namespace CSharp_intro_1.Models
{
    public class TaskDto
    {
       public Guid Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public StatusEnum Status {get; set;} 
        public PersonDto Assignee { get; set; }  
        public BucketDto Bucket { get; set; }
    }
}
