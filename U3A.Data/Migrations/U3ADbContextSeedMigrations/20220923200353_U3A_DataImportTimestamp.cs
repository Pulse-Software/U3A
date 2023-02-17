using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    public partial class U3A_DataImportTimestamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Timestamp",
                table: "PersonImport",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Mobile",
                table: "Person",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HomePhone",
                table: "Person",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DataImportTimestamp",
                table: "Person",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "06864543-2cd6-4f68-a876-7ae904e47eeb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "41228a58-b75c-4266-8406-22e6a53e05bf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "6bbdca39-a7f7-4d8b-a2e9-981e2af68530");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "1e50c81f-319f-45c7-afd4-7db62e67aea5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c9bdeeb-51f7-4442-b153-ad94d4dfb9a0", "AQAAAAEAACcQAAAAEB3egOOV/I3+W1Y1SDY8gUPY+52a+6s3uon4wuUvHSumkiIm8ERGYZlWfNurQJ4shg==", "f7ffe9ff-3efb-49af-a67c-681029414be8" });

            migrationBuilder.CreateIndex(
                name: "IX_PersonImport_Timestamp",
                table: "PersonImport",
                column: "Timestamp");

            migrationBuilder.CreateIndex(
                name: "IX_Person_ConversionID",
                table: "Person",
                column: "ConversionID");

            migrationBuilder.CreateIndex(
                name: "IX_Person_DataImportTimestamp",
                table: "Person",
                column: "DataImportTimestamp");

            migrationBuilder.CreateIndex(
                name: "IX_Person_PersonID",
                table: "Person",
                column: "PersonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PersonImport_Timestamp",
                table: "PersonImport");

            migrationBuilder.DropIndex(
                name: "IX_Person_ConversionID",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_DataImportTimestamp",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_PersonID",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "PersonImport");

            migrationBuilder.DropColumn(
                name: "DataImportTimestamp",
                table: "Person");

            migrationBuilder.AlterColumn<string>(
                name: "Mobile",
                table: "Person",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HomePhone",
                table: "Person",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "4921db65-5f30-484b-98b8-a94e6860d123");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "88e47630-238a-4aec-9088-8fe70e992593");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "fefe9125-9799-4670-8dd8-785fe6d0db98");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "10ab4c68-f129-4028-ab63-0d971d3c5bb1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dabf1795-bac6-448e-8905-ee6173ad6f44", "AQAAAAEAACcQAAAAEOx6yYIDYEMjms+M5dubAGuHodyqwOznp10e2lce/cvBbRz6y4ZqCgeG41QgOSULNg==", "141b0c48-9652-4319-8805-6416af7f5a72" });
        }
    }
}
