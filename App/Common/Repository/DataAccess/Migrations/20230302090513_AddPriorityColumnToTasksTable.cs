using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSharp_intro_1.Common.Repository.DataAccess.Migrations
{
    public partial class AddPriorityColumnToTasksTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Tasks");
        }
    }
}
