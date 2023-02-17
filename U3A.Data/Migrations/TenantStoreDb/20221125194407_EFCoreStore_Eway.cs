using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.TenantStoreDb
{
    /// <inheritdoc />
    public partial class EFCoreStoreEway : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EwayAPIKey",
                table: "TenantInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EwayPassword",
                table: "TenantInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UseEwayTestEnviroment",
                table: "TenantInfo",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "TenantInfo",
                keyColumn: "Id",
                keyValue: "9D36C579-9D45-4ACE-8260-7673DBF53572",
                columns: new[] { "EwayAPIKey", "EwayPassword", "UseEwayTestEnviroment" },
                values: new object[] { null, null, false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EwayAPIKey",
                table: "TenantInfo");

            migrationBuilder.DropColumn(
                name: "EwayPassword",
                table: "TenantInfo");

            migrationBuilder.DropColumn(
                name: "UseEwayTestEnviroment",
                table: "TenantInfo");
        }
    }
}
