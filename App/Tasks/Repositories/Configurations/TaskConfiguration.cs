using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = CSharp_intro_1.Repositories.Models.Task;

namespace CSharp_intro_1.Tasks.Repositories.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.ToTable("Task");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(500);

            builder.HasOne(x => x.Person)
               .WithMany(c => c.Tasks)
                .HasForeignKey(x => x.PersonId);

            builder.HasOne(x => x.Bucket)
               .WithMany(c => c.Tasks)
                .HasForeignKey(x => x.BucketId);


            builder.HasData(
                 new Task
                 {
                     Id = Guid.Parse("d42bd8ba-27ca-4271-b9fb-f68b356f06f2"),
                     Title = "Development work",
                     Description = "custom software solution for x company",
                     Status = (int)Status.Open,
                     BucketId = Guid.Parse("6B29FC40-CA47-1067-B31D-00DD010662DA"),
                     PersonId = Guid.Parse("d22bd9ba-27ca-4271-b9fb-f68b356f06f3")

                 },
            new Task
            {
                Id = Guid.Parse("d21bd8ba-27ca-4271-b9fb-f68b356f06f3"),
                Title = "Marketing work",
                Description = "promotion material for new software",
                Status = (int)Status.InProgress,
                BucketId = Guid.Parse("6B29FC40-CA47-1067-B31D-00DD010662DA"),
                PersonId = Guid.Parse("d22bd9ba-27ca-4271-b9fb-f68b356f06f3")

            });

        }
    }
}
