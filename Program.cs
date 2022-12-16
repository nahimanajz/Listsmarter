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
        var personController = new PersonController(host.Services.GetService<IService<PersonDto>>());
        var bucketController = new BucketController(host.Services.GetService<IService<BucketDto>>());
        var taskController = new BucketController(host.Services.GetService<IService<TaskDto>>());

        foreach(var person in personController.GetAll())  Console.WriteLine(person.FullName);
        foreach(var bucket in bucketController.GetAll()) Console.WriteLine($"BUCKET TITLE: {bucket.Title}");
        //foreach(var task in taskController.GetAll()) Console.WriteLine($"BUCKET TITLE: {bucket.Title}");
        
       
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