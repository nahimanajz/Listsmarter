
namespace CSharp_intro_1.Repositories.Models
{
    public class Bucket
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string?Color { get; set; }
        public string?Description { get; set; }
        public int?TotalTasks { get; set; }
        public string?PhotoName { get; set; }
        public List<Task> Tasks { get; set; } = new();

    }
}
