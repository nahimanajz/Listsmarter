
using CSharp_intro_1.Models;
using CSharp_intro_1.Models.Validators;
using CSharp_intro_1.Repositories;
using CSharp_intro_1.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CSharp_intro_1
{
    public static class IoCExtension
    {
       public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<PersonService>();
            services.AddTransient<BucketService>();
            services.AddTransient<TaskService>();
        }
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRepository<PersonDto>, PersonRepository>();
            services.AddTransient<IRepository<BucketDto>, BucketRepository>();
            services.AddTransient<IRepository<TaskDto>, TaskRepository>();
            services.AddTransient<ITaskRepository, TaskRepository>();

        }
        
    }
}
