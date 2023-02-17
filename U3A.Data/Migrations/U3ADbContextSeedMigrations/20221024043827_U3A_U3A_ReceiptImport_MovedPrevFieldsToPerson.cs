using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    public partial class U3A_U3A_ReceiptImport_MovedPrevFieldsToPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreviousDateJoined",
                table: "Receipt");

            migrationBuilder.DropColumn(
                name: "PreviousFinancialTo",
                table: "Receipt");

            migrationBuilder.AddColumn<DateTime>(
                name: "PreviousDateJoined",
                table: "Person",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PreviousFinancialTo",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "5021861c-98d4-4eb6-ab52-473d0a4e0328");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "aca53ee9-ace4-4961-bd05-71eb31f10067");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "88f105bc-b96c-4c73-bed3-b2341d6adc32");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "41766857-2f55-4699-b5c1-90858cd7851e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a260c7dd-2a24-45d4-b526-0dd9e33887d4", "AQAAAAEAACcQAAAAEP9LgnLIs/9/AJZmr94S21hx5SfjTkR+LBO7EBwsC4HaY79k2+S9JJrY+T+oX1xT1g==", "2b651cb3-a424-4eb6-9a40-e44d48082857" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreviousDateJoined",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "PreviousFinancialTo",
                table: "Person");

            migrationBuilder.AddColumn<DateTime>(
                name: "PreviousDateJoined",
                table: "Receipt",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PreviousFinancialTo",
                table: "Receipt",
                type: "int",
                nullable: true);

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
        }
    }
}
