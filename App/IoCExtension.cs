
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;
using CSharp_intro_1.Services;
using CSharp_intro_1.Services.interfaces;
using CSharp_intro_1.Tasks.Business.Services;
using CSharp_intro_1.Tasks.Business.Services.Interfaces;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CSharp_intro_1
{
    public static class IoCExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IBucketService, BucketService>();
            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<TaskBuilder>();

            services.AddTransient<ITaskCreateService, TaskCreateService>();
            services.AddTransient<ITaskPersonBucketService, TaskBucketService>();
            services.AddTransient<ITaskPersonBucketService, TaskPersonService>();

        }
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRepository<PersonDto>, PersonRepository>();
            services.AddTransient<IBucketRepository, BucketRepository>();
            services.AddTransient<IRepository<TaskDto>, TaskRepository>();
            services.AddTransient<ITaskRepository, TaskRepository>();

        }

    }
}
