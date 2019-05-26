using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLaps.DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Corrals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    MaxElements = table.Column<int>(nullable: false),
                    StartBIBNumber = table.Column<int>(nullable: false),
                    CriteriaType = table.Column<int>(nullable: false),
                    MaxRaceTime = table.Column<int>(nullable: true),
                    MinRaceTime = table.Column<int>(nullable: true),
                    MaxAge = table.Column<int>(nullable: true),
                    MinAge = table.Column<int>(nullable: true),
                    Gender = table.Column<int>(nullable: true),
                    RunnerCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corrals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Runners",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RaceTime = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    CorralId = table.Column<int>(nullable: true),
                    CorralName = table.Column<string>(nullable: true),
                    BIBNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Runners", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Corrals");

            migrationBuilder.DropTable(
                name: "Runners");
        }
    }
}
