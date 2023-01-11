using CSharp_intro_1;
using CSharp_intro_1.Models;
using CSharp_intro_1.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Task = System.Threading.Tasks.Task;

class Program
{
    static Task Main(string[] args)
    {
        using IHost host = CreateHostBuilder(args).Build();
        var personController = new PersonController(host.Services.GetService<PersonService>());
        var bucketController = new BucketController(host.Services.GetService<BucketService>());
        var taskController = new TaskController(host.Services.GetService<TaskService>());


        personController.Create(new PersonDto
        {
            FirstName = "Felix",
            LastName = "Niyo",
        });


        bucketController.Create(new BucketDto
        {
            Title = " Calling a friend"
        });

        //TODO: Get bucket, and Get Person to fill bucket and assignee as an object
        taskController.Create(new TaskDto
        {
            Title = "Some given TASK",
            Description = "SOME OTHER CHANGED TASK",
            Status = (int)StatusEnum.Open,
            Assignee = personController.GetAll()[0].Id,
            Bucket = bucketController.GetAll()[0].Id
        });
        taskController.Create(new TaskDto
        {
            Title = "Second task",
            Description = "Second",
            Status = (int)StatusEnum.Open,
            Assignee = personController.GetAll()[0].Id,
            Bucket = bucketController.GetAll()[0].Id
        });
        var registeredTask = new TaskDto
        {
            Id = personController.GetAll()[0].Id,
            Title = "Third task",
            Description = "Third",
            Status = (int)StatusEnum.Open,

        };
        taskController.Update(registeredTask);

        var people = personController.GetAll();
        personController.Delete(people[0].Id);

        foreach (var person in people) System.Console.WriteLine($"ID=>{person.Id} Names=> {person.FullName} Total people:{people.Count}");


        return host.RunAsync();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args).ConfigureServices((_, services) =>
        {
            services.RegisterRepositories();
            services.RegisterServices();
            services.RegisterValidators();
            services.AddAutoMapper((config) =>
            {

            }, AppDomain.CurrentDomain.GetAssemblies());
        });


    }
}
// create new user
