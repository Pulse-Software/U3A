using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    /// <inheritdoc />
    public partial class U3ADropout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SilentNumber",
                table: "Person",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Dropout",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TermID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PersonID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DropoutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnrolled = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsWaitlisted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dropout", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Dropout_Class_ClassID",
                        column: x => x.ClassID,
                        principalTable: "Class",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Dropout_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dropout_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dropout_Term_TermID",
                        column: x => x.TermID,
                        principalTable: "Term",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dropout_ClassID",
                table: "Dropout",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Dropout_CourseID",
                table: "Dropout",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Dropout_PersonID",
                table: "Dropout",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Dropout_TermID",
                table: "Dropout",
                column: "TermID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dropout");

            migrationBuilder.DropColumn(
                name: "SilentNumber",
                table: "Person");
        }
    }
}
