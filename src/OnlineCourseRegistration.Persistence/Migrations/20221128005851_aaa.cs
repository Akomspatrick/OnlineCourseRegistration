using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineCourseRegistration.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class aaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NameLastName = table.Column<string>(name: "Name_LastName", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "CourseRegistrationForms",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    semester = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    session = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    minPossibleTotalUnit = table.Column<int>(type: "int", nullable: false),
                    maxPossibleTotalUnit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseRegistrationForms", x => new { x.StudentId, x.session, x.semester });
                    table.ForeignKey(
                        name: "FK_CourseRegistrationForms_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    CourseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    semester = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    session = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CampId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => new { x.StudentId, x.semester, x.session, x.CourseId });
                    table.ForeignKey(
                        name: "FK_Courses_CourseRegistrationForms_StudentId_session_semester",
                        columns: x => new { x.StudentId, x.session, x.semester },
                        principalTable: "CourseRegistrationForms",
                        principalColumns: new[] { "StudentId", "session", "semester" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "FirstName", "Name_LastName" },
                values: new object[,]
                {
                    { "1", "SpaghettO1", "Spaghetti1" },
                    { "11", "Spaghett11", "Spaghetti11" }
                });

            migrationBuilder.InsertData(
                table: "CourseRegistrationForms",
                columns: new[] { "StudentId", "semester", "session", "maxPossibleTotalUnit", "minPossibleTotalUnit" },
                values: new object[,]
                {
                    { "1", "1", "1", 2, 2 },
                    { "1", "2", "1", 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "StudentId", "semester", "session", "CampId", "FacId" },
                values: new object[,]
                {
                    { "111", "1", "1", "1", "d", "s" },
                    { "113", "1", "1", "1", "d", "s" },
                    { "114", "1", "1", "1", "d", "s" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_StudentId_session_semester",
                table: "Courses",
                columns: new[] { "StudentId", "session", "semester" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "CourseRegistrationForms");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
