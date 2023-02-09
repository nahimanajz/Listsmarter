using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = CSharp_intro_1.Repositories.Models.Task;

namespace CSharp_intro_1.Tasks.Repositories.Configurations
{
    public class TaskConfiguration: IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.ToTable("Task");
            builder.HasKey(x => x.Id);
            builder.Property(x=> x.Title)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(500);

            builder.HasOne(x => x.Person)
                .WithMany(x => x.Tasks)
                .HasForeignKey(x => x.Person.Id);

            builder.Ignore(x => x.Bucket);
            builder.Ignore(x => x.Person);


            builder.HasData(
                 new Task
                 {
                     Id = new Guid("d22bd8ba-27ca-4271-b9fb-f68b356f06f2"),
                     Title = "Development work",
                     Description = "custom software solution for x company",
                     Status = (int)Status.Open,

                 },
            new Task
            {
                Id = new Guid("d22bd8ba-27ca-4271-b9fb-f68b356f06f3"),
                Title = "Marketing work",
                Description = "promotion material for new software",
                Status = (int)Status.InProgress,

            });

        } 
    }
}
