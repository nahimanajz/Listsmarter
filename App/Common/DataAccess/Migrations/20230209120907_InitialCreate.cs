using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSharp_intro_1.Common.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bucket",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bucket", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BucketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Task_Bucket_BucketId",
                        column: x => x.BucketId,
                        principalTable: "Bucket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Task_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bucket",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("2099c99b-cf1c-418c-ade4-4ef38cce2a38"), "My DB Bucket" },
                    { new Guid("7e0098e0-cd4b-4c0a-8f3e-be8335eab368"), "My DB second Bucket" }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("d12bd9ba-27ca-4271-b9fb-f68b356f06f3"), "Will", "Smith" },
                    { new Guid("d22bd9ba-27ca-4271-b9fb-f68b356f06f3"), "John", "Doe" }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "Id", "BucketId", "Description", "PersonId", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("d22bd8ba-27ca-4271-b9fb-f68b356f06f2"), new Guid("00000000-0000-0000-0000-000000000000"), "custom software solution for x company", new Guid("00000000-0000-0000-0000-000000000000"), 0, "Development work" },
                    { new Guid("d22bd8ba-27ca-4271-b9fb-f68b356f06f3"), new Guid("00000000-0000-0000-0000-000000000000"), "promotion material for new software", new Guid("00000000-0000-0000-0000-000000000000"), 1, "Marketing work" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Task_BucketId",
                table: "Task",
                column: "BucketId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_PersonId",
                table: "Task",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Bucket");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
