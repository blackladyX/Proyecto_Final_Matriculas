using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Matriculas.Web.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InicialDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinalDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseCost = table.Column<int>(type: "int", nullable: false),
                    DateInscripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Intensity = table.Column<int>(type: "int", nullable: false),
                    ClassSchedule = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Inscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentFullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdStudent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dateofbirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentCellPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherIdentification = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    TeacherFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dateofbirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherCellPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArtisticArea = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Inscriptions");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
