using CSharp_intro_1.Common.Business.Middleware;
using CSharp_intro_1.Common.Repository;
using CSharp_intro_1.Models;
using CSharp_intro_1.People.Repositories.Modal;
using CSharp_intro_1.Repositories;
using CSharp_intro_1.Repositories.Models;
using CSharp_intro_1.Services;
using CSharp_intro_1.Services.interfaces;
using CSharp_intro_1.Tasks.Business.Services;
using CSharp_intro_1.Tasks.Business.Services.Interfaces;
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
            services.AddTransient<ITaskCreateService, TaskCreateService>();
            services.AddTransient<IAssignTaskService, AssignTaskService>();



        }
        public static void RegisterRepositories(this IServiceCollection services)
        {

            services.AddTransient<IBucketRepository, BucketRepository>();
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<IGenericRepository<Bucket, BucketDto>, GenericRepository<Bucket, BucketDto>>();
            services.AddTransient<IGenericRepository<Person, PersonDto>, GenericRepository<Person, PersonDto>>();


        }
        public static void RegisterMiddlewares(this IServiceCollection service)
        {
            service.AddTransient<ExceptionHandlingMiddleware>();
        }
       

    }
}
