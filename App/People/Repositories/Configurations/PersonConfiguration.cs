using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_intro_1.People.Repositories.Modal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSharp_intro_1.People.Repositories.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons");
            builder.HasKey(X => X.Id);
             builder.Property(x => x.Id)
                .HasDefaultValueSql("NewId()");
           

            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.HasData(
                new Person
                {
                    Id= Guid.Parse("d22bd9ba-27ca-4271-b9fb-f68b356f06f3"),
                    FirstName = "John",
                    LastName="Doe"
                },
                 new Person
                 {
                     Id = Guid.Parse("d12bd9ba-27ca-4271-b9fb-f68b356f06f3"),
                     FirstName = "Will",
                     LastName = "Smith"
                 }

                );
        }
    }
}
