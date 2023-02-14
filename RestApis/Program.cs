using CSharp_intro_1;
using CSharp_intro_1.Common.Repository.DataAccess;
using CSharp_intro_1.Models.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterServices();
builder.Services.RegisterRepositories();

builder.Services.AddControllers();
   

builder.Services.AddValidatorsFromAssemblyContaining<CreateTaskValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateBucketValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreatePersonValidator>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

builder.Services.AddDbContext<AppContexts>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

object value = builder.Services.AddAutoMapper((config) =>
{
}, AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();


