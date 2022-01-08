using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RabbitMQCalculator.UseCases.Shared.Database.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calculations",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstNumber = table.Column<double>(type: "double precision", nullable: false),
                    SecondNumber = table.Column<double>(type: "double precision", nullable: false),
                    Operator = table.Column<char>(type: "character(1)", nullable: false),
                    Result = table.Column<double>(type: "double precision", nullable: false),
                    Error = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculations", x => x.Guid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calculations");
        }
    }
}
