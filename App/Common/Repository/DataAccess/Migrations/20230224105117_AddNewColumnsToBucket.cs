using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSharp_intro_1.Common.Repository.DataAccess.Migrations
{
    public partial class AddNewColumnsToBucket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name:"Description",
                table:"Bucket",
                nullable:true
                );
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Bucket",
 
                defaultValue: "#964B00"
                );
            migrationBuilder.AddColumn<int>(
                name: "TotalTasks",
                table: "Bucket",
                nullable: false,
                defaultValue: 15
                );

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("Description", "Bucket");
            migrationBuilder.DropColumn("Color", "Bucket");
            migrationBuilder.DropColumn("TotalTasks", "Bucket");
        }
    }
}
