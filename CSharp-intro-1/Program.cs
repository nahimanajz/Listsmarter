using CSharp_intro_1;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Task = System.Threading.Tasks.Task;

class Program
{
    static Task Main(string[] args)
    {
        using IHost host = CreateHostBuilder(args).Build();
        return host.RunAsync();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args).ConfigureServices((_, services) =>
        {
            services.RegisterRepositories();
            services.RegisterServices();
            services.AddAutoMapper((config) =>
            {

            }, AppDomain.CurrentDomain.GetAssemblies());
        });


    }
}
