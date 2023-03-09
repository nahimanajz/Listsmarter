using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSharp_intro_1.Common.Repository.DataAccess.Migrations
{
    public partial class AddBucketPhotoToBucketTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
              migrationBuilder.AddColumn<string>(
               name: "PhotoName",
               table: "Bucket",
               nullable: true
               );
            }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        migrationBuilder.DropColumn("PhotoName", "Bucket");
    }
    }
}
