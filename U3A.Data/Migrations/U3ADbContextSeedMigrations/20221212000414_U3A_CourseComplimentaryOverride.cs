using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    /// <inheritdoc />
    public partial class U3ACourseComplimentaryOverride : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "OverrideComplimentaryPerTermFee",
                table: "Course",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Overrides the System Settings complimentary status for term fees");

            migrationBuilder.AddColumn<bool>(
                name: "OverrideComplimentaryPerYearFee",
                table: "Course",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Overrides the System Settings complimentary status for year fees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OverrideComplimentaryPerTermFee",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "OverrideComplimentaryPerYearFee",
                table: "Course");
        }
    }
}
