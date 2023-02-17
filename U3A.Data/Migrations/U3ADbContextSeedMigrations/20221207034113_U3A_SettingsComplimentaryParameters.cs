using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    /// <inheritdoc />
    public partial class U3ASettingsComplimentaryParameters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IncludeCourseFeePerTermInComplimentary",
                table: "SystemSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IncludeCourseFeePerYearInComplimentary",
                table: "SystemSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IncludeMailSurchargeInComplimentary",
                table: "SystemSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IncludeMembershipFeeInComplimentary",
                table: "SystemSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LeaderMaxComplimentaryCourses",
                table: "SystemSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IncludeCourseFeePerTermInComplimentary",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "IncludeCourseFeePerYearInComplimentary",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "IncludeMailSurchargeInComplimentary",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "IncludeMembershipFeeInComplimentary",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "LeaderMaxComplimentaryCourses",
                table: "SystemSettings");
        }
    }
}
