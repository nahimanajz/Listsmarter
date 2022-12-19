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
        
        //TODO: Get bucket, and Get Person to fill bucket and assignee as an object
        taskController.Create(new TaskDto {
            Title = "SOME CHANGED TASK",
                Description = "SOME OTHER CHANGED TASK",
                Status = (int) StatusEnum.Open,
                Assignee = new PersonDto{Id =1, FirstName="Nahi..", LastName="Nah.."},
                Bucket =  new BucketDto{Id =1, Title="Doing something new"}
        });
       /* foreach(var person in personController.GetAll())  Console.WriteLine(person.FullName);
        foreach(var bucket in bucketController.GetAll()) Console.WriteLine($"BUCKET TITLE: {bucket.Title}");
        foreach(var task in taskController.GetAll()) Console.WriteLine($"Task : {task.Title}=> {task.Assignee.FirstName}");
        */
       
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