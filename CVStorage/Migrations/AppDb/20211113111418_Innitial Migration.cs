using Microsoft.EntityFrameworkCore.Migrations;

namespace CVStorage.Migrations.AppDb
{
    public partial class InnitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    University = table.Column<string>(nullable: true),
                    SSC_GPA = table.Column<double>(nullable: false),
                    HSC_GPA = table.Column<double>(nullable: false),
                    Bachelor_CGPA = table.Column<double>(nullable: false),
                    Project = table.Column<string>(nullable: true),
                    Skills = table.Column<string>(nullable: true),
                    PhotoPath = table.Column<string>(nullable: true),
                    IsAccepted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
