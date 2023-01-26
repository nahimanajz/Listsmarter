
using CSharp_intro_1.Repositories.Models;
using Task = CSharp_intro_1.Repositories.Models.Task;

namespace CSharp_intro_1.DB
{
    public class TempDb
    {
        public static List<Person> persons = new() { new Person { Id = Guid.Parse("8D2B0228-5D0D-4C23-9B49-01A698851109"), FirstName = "Nahimana", LastName = "Janvier" } };
        public static List<Bucket> buckets = new() { new Bucket { Id= Guid.Parse("8D2B0328-5D0D-AC23-9B49-01Ab98851109"), Title="My amazing bucket"} };
        public static List<Task> tasks = new()
        {
            new Task() {
                Id= Guid.Parse("8D2B0128-5D0D-4C23-9B49-02A698852109"),
                Title = "Some given TASK",
                Description = "SOME OTHER CHANGED TASK",
                Status = (int) Status.Open,
                Assignee = persons.First(),
                Bucket = buckets.First(),
            
        }
        
        };
    }
}
