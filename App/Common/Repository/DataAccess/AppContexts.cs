using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_intro_1.People.Repositories.Configurations;
using CSharp_intro_1.People.Repositories.Modal;
using CSharp_intro_1.Repositories.Models;
using CSharp_intro_1.Tasks.Repositories.Configurations;
using Microsoft.EntityFrameworkCore;
using Task = CSharp_intro_1.Repositories.Models.Task;


namespace CSharp_intro_1.Common.Repository.DataAccess
{
    public class AppContexts : DbContext
    {
       //TODO: Capitalize instance variables
        
        public DbSet<Person> Persons { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Bucket> Buckets { get; set; } 

        public AppContexts(DbContextOptions<AppContexts> options):base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new BucketConfiguration());
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
        }
    }
}

