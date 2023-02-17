using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    public partial class U3A_PersonImportDateJoined : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsNewPerosn",
                table: "PersonImport",
                newName: "IsNewPerson");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateJoined",
                table: "PersonImport",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "4372a829-b75d-4ed6-8276-4590c1a7606b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "87d3010b-9322-436a-a62e-f4255fade2cd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "b1a896c8-bba0-4e69-ae68-253328f9b31e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "ccfd0d75-c9cc-41f2-93a8-2c728a7e3868");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70494634-D7BE-4BE4-8106-031AAE2BC6DC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e57334c-cf4c-4d88-bc10-63089c978074", "AQAAAAEAACcQAAAAEK2qXWvsTNYFyQRURfLo0sVbAtR7wWVRAAjknxgmsx4gfpdwfqehervJqI55re63Ow==", "12f34fde-2b92-4b55-944b-258d87b1ab9d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753F8F36-D2FF-438E-B5D1-7FF79E4628BD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e256b6ee-f2a4-48cb-b1f0-6a7f71f91adf", "AQAAAAEAACcQAAAAEO2EfIAvPyxN2n6uOUwTHQY1z9IALjf1EecgpsuChsLTSIvBM8qz3Eel4HzBjyGsTA==", "4ada61ac-1da1-45a8-a057-3948d001be0e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b1d3fce-e8f2-45e2-9885-db6d7e17e5df", "AQAAAAEAACcQAAAAEC6Tv4cn2VteZj1ekTp48mFfMHef4k4nL9FybFs3JJj/ymsJ6RblhKuODANGotCjkA==", "8ce658df-d855-4d6a-9f42-809c64901c4b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C5E9887D-9C4B-40F5-AB46-2232776005C5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b7643c52-b99e-44d8-abe6-dc1c2d6ecda4", "AQAAAAEAACcQAAAAEIEpnF6pjcrqmZG5qwYcD3cPQnw5g/6GA1z3e06O9xZjnBSMCGaqhs9VsPWbFDGMlw==", "4a9a95bd-8ff7-4bee-a732-9a6846438e86" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E7B47704-8DA0-4657-B42C-849C1C22A6D2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d385d23-ea8e-41a1-959a-4c84d6eee2a8", "AQAAAAEAACcQAAAAECdxib4BkbfQmf6l1MrTUHHqtBpsmog7YwEeN2DzaiAAUFhYjku0Eflo8csbmuF0pQ==", "8b226b9a-972c-4a5c-88ee-98419507a655" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateJoined",
                table: "PersonImport");

            migrationBuilder.RenameColumn(
                name: "IsNewPerson",
                table: "PersonImport",
                newName: "IsNewPerosn");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "44579b75-73e2-437e-8624-a9391289e062");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "67506096-e13f-4e57-9fa9-c5cc71664600");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "3ff92d5a-e52a-4735-b55c-78aea44def96");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "b6961609-a34b-4730-8f10-af0333fb2eda");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70494634-D7BE-4BE4-8106-031AAE2BC6DC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84d131b3-cfc8-4210-83ed-10a5e4e1e3a3", "AQAAAAEAACcQAAAAEBx+x+8iig2EpJudNExWjL4XKA9H4Sab/0xumMBWOxQzsP3QHIp5DB1oj/C8dOi0Lw==", "bf1074e6-2cf1-4527-bcd0-27a1330b5fa4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753F8F36-D2FF-438E-B5D1-7FF79E4628BD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b0b301b-e065-4eaa-b11c-d8b35c9d6e4c", "AQAAAAEAACcQAAAAELtTEv9295Db9GI8pZoq8NDI54YLaFqt/ILJG2++UszengnjtS+jXj3Iy5kcpRy4ig==", "005c7f71-ddf9-4ce0-81ab-20fb2e349746" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed11e8bb-7ddd-4007-936f-4cfa2936c88d", "AQAAAAEAACcQAAAAEEkoquFL5rEZrMxIECh12Q8zzc6Vla67ildOz5E9u3+Wd8L6mMWYQ2DWnaTI4eRvfg==", "dcf41fad-f1d7-4cdd-b593-8fed221e88a6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C5E9887D-9C4B-40F5-AB46-2232776005C5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd2647a5-5505-4455-8ed4-70c3757d403d", "AQAAAAEAACcQAAAAEMg4nZfiFLQRY0sgGiy9U2OWQ/psbf6/DBU5LvBLIxt0m4pfsZa7hFNeSBWHcFRIcg==", "8fa9a509-16e2-4a58-add1-975e6c37edcb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E7B47704-8DA0-4657-B42C-849C1C22A6D2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f7066fd-490f-4d3c-8933-b94f5bbfb634", "AQAAAAEAACcQAAAAEMkOztywuDG5GR4txz0KeLJQ5vQ6AfUHSn4LQ/BTg530M5oGAFr7RtBgpauGN0Jz7w==", "fb5124f8-14e1-4cba-bfd3-a7d4efa1784f" });
        }
    }
}
