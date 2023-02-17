using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    public partial class U3A_SystemSettingsFinancialToPercent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EnrolmentEnds",
                table: "Term",
                type: "int",
                nullable: false,
                comment: "The number of weeks before/after to StartDate that enrolment ends",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The number of weeks prior to StartDate that enrolment ends");

            migrationBuilder.AddColumn<decimal>(
                name: "FinancialToMembershipFeePercent",
                table: "SystemSettings",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                comment: "The percent of Membership fess required to be paid before member is deemed financial and enrolement allowed.");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinancialToMembershipFeePercent",
                table: "SystemSettings");

            migrationBuilder.AlterColumn<int>(
                name: "EnrolmentEnds",
                table: "Term",
                type: "int",
                nullable: false,
                comment: "The number of weeks prior to StartDate that enrolment ends",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The number of weeks before/after to StartDate that enrolment ends");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "b9e35b44-0500-46a3-a646-646aaa818446");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "16a6d062-5f05-41d2-9e8b-e3870d9b3a97");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "d1b99aab-b3ad-44c8-9866-866f400cb3c1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "a65618b6-9f9a-4e77-996f-3d96890b7b7c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d79d95c9-7238-4e65-bad1-1473b5c17da5", "AQAAAAEAACcQAAAAEBF7imVgm7AtuIMxXhBG3m9T+4BeLT31K8g9yT3PLQ8/vW27viLE/LFVdUbPcrpWAw==", "61d3be22-c20c-470a-b7c8-c7e1028bb871" });
        }
    }
}
