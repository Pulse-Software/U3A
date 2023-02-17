using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    /// <inheritdoc />
    public partial class U3ACourseFees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassFee",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CourseFee",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "CourseFeeDescription",
                table: "Course",
                newName: "CourseFeePerYearDescription");

            migrationBuilder.RenameColumn(
                name: "ClassFeeDescription",
                table: "Course",
                newName: "CourseFeePerTermDescription");

            migrationBuilder.AddColumn<decimal>(
                name: "CourseFeePerTerm",
                table: "Course",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                comment: "Optional fee per term)");

            migrationBuilder.AddColumn<decimal>(
                name: "CourseFeePerYear",
                table: "Course",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                comment: "Optional once-only course enrolment fee");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseFeePerTerm",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CourseFeePerYear",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "CourseFeePerYearDescription",
                table: "Course",
                newName: "CourseFeeDescription");

            migrationBuilder.RenameColumn(
                name: "CourseFeePerTermDescription",
                table: "Course",
                newName: "ClassFeeDescription");

            migrationBuilder.AddColumn<decimal>(
                name: "ClassFee",
                table: "Course",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                comment: "Optional fee per class (eg. tea and coffee)");

            migrationBuilder.AddColumn<decimal>(
                name: "CourseFee",
                table: "Course",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                comment: "Once-only course enrolment fee");
        }
    }
}
