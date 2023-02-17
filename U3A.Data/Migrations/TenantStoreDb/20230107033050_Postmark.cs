using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.TenantStoreDb
{
    /// <inheritdoc />
    public partial class Postmark : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PostmarkAPIKey",
                table: "TenantInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostmarkSandboxAPIKey",
                table: "TenantInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UsePostmarkTestEnviroment",
                table: "TenantInfo",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "TenantInfo",
                keyColumn: "Id",
                keyValue: "9D36C579-9D45-4ACE-8260-7673DBF53572",
                columns: new[] { "PostmarkAPIKey", "PostmarkSandboxAPIKey", "UsePostmarkTestEnviroment" },
                values: new object[] { null, null, false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostmarkAPIKey",
                table: "TenantInfo");

            migrationBuilder.DropColumn(
                name: "PostmarkSandboxAPIKey",
                table: "TenantInfo");

            migrationBuilder.DropColumn(
                name: "UsePostmarkTestEnviroment",
                table: "TenantInfo");
        }
    }
}
