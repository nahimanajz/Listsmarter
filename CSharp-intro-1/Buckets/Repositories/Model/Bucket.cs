
namespace CSharp_intro_1.Repositories.Models
{
    public class Bucket
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
       
        public List<Task> Tasks { get; set; }

    }
}
