using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSharp_intro_1.Common.Repository.DataAccess.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bucket",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewId()"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bucket", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewId()"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewId()"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BucketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Bucket_BucketId",
                        column: x => x.BucketId,
                        principalTable: "Bucket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bucket",
                columns: new[] { "Id", "Title" },
                values: new object[] { new Guid("6b29fc40-ca47-1067-b31d-00dd010662da"), "My DB Bucket" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { new Guid("d12bd9ba-27ca-4271-b9fb-f68b356f06f3"), "Will", "Smith" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { new Guid("d22bd9ba-27ca-4271-b9fb-f68b356f06f3"), "John", "Doe" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BucketId", "Description", "PersonId", "Status", "Title" },
                values: new object[] { new Guid("d21bd8ba-27ca-4271-b9fb-f68b356f06f3"), new Guid("6b29fc40-ca47-1067-b31d-00dd010662da"), "promotion material for new software", new Guid("d22bd9ba-27ca-4271-b9fb-f68b356f06f3"), 1, "Marketing work" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BucketId", "Description", "PersonId", "Status", "Title" },
                values: new object[] { new Guid("d42bd8ba-27ca-4271-b9fb-f68b356f06f2"), new Guid("6b29fc40-ca47-1067-b31d-00dd010662da"), "custom software solution for x company", new Guid("d22bd9ba-27ca-4271-b9fb-f68b356f06f3"), 0, "Development work" });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BucketId",
                table: "Tasks",
                column: "BucketId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_PersonId",
                table: "Tasks",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Bucket");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
