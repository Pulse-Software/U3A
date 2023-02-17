using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    public partial class U3A_SendEmailAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "MailSurcharge",
                table: "SystemSettings",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                comment: "Yearly surcharge if requiring mail correspondence",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldComment: "Yearly surcharge if requiring mail correspondance");

            migrationBuilder.AddColumn<string>(
                name: "SendEmailAddesss",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Pro-forma reports are sent from here");

            migrationBuilder.AddColumn<string>(
                name: "SendEmailDisplayName",
                table: "SystemSettings",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "5e15337e-ffe2-47c3-ad35-43517e1d4a74");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "8747497a-8829-4c70-a30b-d3bcb839a207");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "cdc6d6fa-451d-4025-a2f2-0a763302a46f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "1906ffec-b633-498a-9618-997977633923");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7385ae0a-561b-4e5a-a09b-2816c2e9fc35", "AQAAAAEAACcQAAAAEGBANLryDYTDHSUmNC59OjMYAb25Pw6+vMUGTistHqrPlyeYRNEG5NwYbY2Vi8y1jg==", "6424207d-c82a-46de-9195-552a34429e7f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SendEmailAddesss",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "SendEmailDisplayName",
                table: "SystemSettings");

            migrationBuilder.AlterColumn<decimal>(
                name: "MailSurcharge",
                table: "SystemSettings",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                comment: "Yearly surcharge if requiring mail correspondance",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldComment: "Yearly surcharge if requiring mail correspondence");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "a00a2bfc-a3db-4cea-b537-fe112b292d57");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "915da503-dd07-422b-905b-fb19c8c2ae67");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "65ff159e-2eb4-42af-beb9-27a406dff761");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "2621a8da-0e5d-42f8-8247-68f0d42abebe");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9a23c74-5394-4308-b9da-b6ca06a22603", "AQAAAAEAACcQAAAAELVKSzxUl57d/Rvdt+mTagxe9n9q9ZIWtFs2Ias+PDxKqKWNZZMIYvptg0FJ5N+AIw==", "2ca473c4-d8ed-4fa6-acd3-adeda5f720a2" });
        }
    }
}
