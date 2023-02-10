using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_intro_1.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSharp_intro_1.Tasks.Repositories.Configurations
{
    public class BucketConfiguration: IEntityTypeConfiguration<Bucket>
    {
      
        public void Configure(EntityTypeBuilder<Bucket> builder)
        {
            builder.ToTable("Bucket");
            builder.HasKey(X => X.Id);

            builder.Property(x=> x.Title)
            .IsRequired();
            builder.HasData(
                new Bucket
                {
                    Id= Guid.Parse("6B29FC40-CA47-1067-B31D-00DD010662DA"),
                    Title = "My DB Bucket",
                }
                );
        }

      
    }
}
