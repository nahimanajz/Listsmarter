
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
            services.AddTransient<IService<PersonDto>, PersonService>();
            services.AddTransient<IService<BucketDto>, BucketService>();
            services.AddTransient<IService<TaskDto>, TaskService>();
        }
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRepository<PersonDto>, PersonRepository>();
            services.AddTransient<IRepository<BucketDto>, BucketRepository>();
            services.AddTransient<IRepository<TaskDto>, TaskRepository>();

        }
        public static void RegisterValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<PersonDto>, PersonDtoValidator>();
            services.AddScoped<IValidator<BucketDto>, BucketDtoValidator>();
            services.AddScoped<IValidator<TaskDto>, TaskValidator>();
        }
    }
}
