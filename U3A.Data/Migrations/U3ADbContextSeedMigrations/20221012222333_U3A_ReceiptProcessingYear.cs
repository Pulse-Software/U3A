using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    public partial class U3A_ReceiptProcessingYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProcessingYear",
                table: "Receipt",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "c9f1fc68-02e0-4877-9477-c5ab390ef831");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "b9fe6cfb-fdbc-4b81-b350-1bef70bdc6a4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "13005e72-2dcb-4a7f-ad0a-bc9608e6f59c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "ef9f710d-31e1-4656-b8f0-14d487670d63");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "748f49d2-10d3-4a01-a402-594248729e4a", "AQAAAAEAACcQAAAAEKOPrc4LBy+1HX+83WwyOrh4rNffQghHdeYtiLg+CUrpBsBwMT20YCcieNOUfLx9XA==", "b5ab1cfb-fed8-4385-b098-d37de862b019" });

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_ProcessingYear",
                table: "Receipt",
                column: "ProcessingYear");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Receipt_ProcessingYear",
                table: "Receipt");

            migrationBuilder.DropColumn(
                name: "ProcessingYear",
                table: "Receipt");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "eea0a2da-4c16-4d2e-b149-042d8d1891d4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "dc3406ef-74c8-4f1e-898e-cb865a5581d5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "df1ea4a0-d0bf-4e11-adb2-b60f18a12ea7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "0691a5f1-b704-45ba-811a-a601d44e7550");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5cde6c27-e5b2-4e9e-b017-2ef5860ee357", "AQAAAAEAACcQAAAAEJtYY5UJj3uCC8bbuwpCpGakCV1Xv0Df0PY+HwjLRrg7bUO3jTrXr8u9Ti+fPjyycA==", "ccc59f7e-370e-4aab-acbf-d81e9562c675" });
        }
    }
}
