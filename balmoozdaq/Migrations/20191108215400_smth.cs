using Microsoft.EntityFrameworkCore.Migrations;

namespace balmoozdaq.Migrations
{
    public partial class smth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(nullable: true),
                    UserSurname = table.Column<string>(nullable: true),
                    UserLogin = table.Column<string>(nullable: true),
                    UserPassword = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EducationCenters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EduCenterName = table.Column<string>(nullable: true),
                    EduCenterDesc = table.Column<string>(nullable: true),
                    EduCenterPhone = table.Column<string>(nullable: true),
                    EduCenterAddress = table.Column<string>(nullable: true),
                    EduCenterImgUrl = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationCenters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationCenters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CenterCourses",
                columns: table => new
                {
                    EduCenterId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    CenterCourseDesc = table.Column<string>(nullable: true),
                    EducationCenterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CenterCourses", x => new { x.EduCenterId, x.CourseId, x.UserId });
                    table.UniqueConstraint("AK_CenterCourses_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CenterCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CenterCourses_EducationCenters_EduCenterId",
                        column: x => x.EduCenterId,
                        principalTable: "EducationCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CenterCourses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeekDays",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DayName = table.Column<string>(nullable: true),
                    CenterCourseEduCenterId = table.Column<int>(nullable: true),
                    CenterCourseCourseId = table.Column<int>(nullable: true),
                    CenterCourseUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeekDays_CenterCourses_CenterCourseEduCenterId_CenterCourseCourseId_CenterCourseUserId",
                        columns: x => new { x.CenterCourseEduCenterId, x.CenterCourseCourseId, x.CenterCourseUserId },
                        principalTable: "CenterCourses",
                        principalColumns: new[] { "EduCenterId", "CourseId", "UserId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseTimes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseStartTime = table.Column<string>(nullable: true),
                    CourseEndTime = table.Column<string>(nullable: true),
                    WeekDayId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseTimes_WeekDays_WeekDayId",
                        column: x => x.WeekDayId,
                        principalTable: "WeekDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CenterCourses_CourseId",
                table: "CenterCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CenterCourses_UserId",
                table: "CenterCourses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTimes_WeekDayId",
                table: "CourseTimes",
                column: "WeekDayId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationCenters_UserId",
                table: "EducationCenters",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_WeekDays_CenterCourseEduCenterId_CenterCourseCourseId_CenterCourseUserId",
                table: "WeekDays",
                columns: new[] { "CenterCourseEduCenterId", "CenterCourseCourseId", "CenterCourseUserId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseTimes");

            migrationBuilder.DropTable(
                name: "WeekDays");

            migrationBuilder.DropTable(
                name: "CenterCourses");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "EducationCenters");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
