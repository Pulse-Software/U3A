using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    public partial class U3A_SettingsMail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Timezone",
                table: "SystemSettings");

            migrationBuilder.AddColumn<double>(
                name: "MailLabelBottomMargin",
                table: "SystemSettings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MailLabelHeight",
                table: "SystemSettings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MailLabelLeftMargin",
                table: "SystemSettings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MailLabelRightMargin",
                table: "SystemSettings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MailLabelTopMargin",
                table: "SystemSettings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MailLabelWidth",
                table: "SystemSettings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MailLabelBottomMargin",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "MailLabelHeight",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "MailLabelLeftMargin",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "MailLabelRightMargin",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "MailLabelTopMargin",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "MailLabelWidth",
                table: "SystemSettings");

            migrationBuilder.AddColumn<string>(
                name: "Timezone",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
