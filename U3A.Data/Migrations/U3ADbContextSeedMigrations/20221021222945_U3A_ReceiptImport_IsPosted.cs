using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    public partial class U3A_ReceiptImport_IsPosted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOnFile",
                table: "ReceiptDataImport",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Receipt",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "4c6e28e8-0448-4759-964b-6fa36e217715");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "01d0eb5f-d35f-4b3e-9dad-925e0f0c4efb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "cc1b6d31-dfc9-4031-8cf8-38bfbcee15ad");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "cf22e000-6f20-4565-bc45-ac7ba9f5fcec");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5b923da-e355-485b-8936-e6f52646e474", "AQAAAAEAACcQAAAAEKFlvzFu7HIgZycG3q6e6YNBHA0oz88MGpdcSx4alqiPpet6jqXRWizfwte5jwfNow==", "eda15259-35ed-4e41-aad6-faeff3a7d4f5" });

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_Date_Description",
                table: "Receipt",
                columns: new[] { "Date", "Description" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Receipt_Date_Description",
                table: "Receipt");

            migrationBuilder.DropColumn(
                name: "IsOnFile",
                table: "ReceiptDataImport");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Receipt",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
    }
}
