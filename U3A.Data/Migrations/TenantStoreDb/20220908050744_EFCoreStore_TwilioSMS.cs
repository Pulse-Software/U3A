using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.TenantStoreDb
{
    public partial class EFCoreStore_TwilioSMS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TwilioAccountSID",
                table: "TenantInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwilioAuthToken",
                table: "TenantInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwilioPhoneNo",
                table: "TenantInfo",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TwilioAccountSID",
                table: "TenantInfo");

            migrationBuilder.DropColumn(
                name: "TwilioAuthToken",
                table: "TenantInfo");

            migrationBuilder.DropColumn(
                name: "TwilioPhoneNo",
                table: "TenantInfo");
        }
    }
}
