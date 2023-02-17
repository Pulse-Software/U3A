using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    public partial class U3A_PersonImportIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "PersonImport",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "PersonImport",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "ca1c4543-1dd5-495b-a197-dec78d8622e3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "2f683dd2-4a0b-47ce-9008-942cce9ce01a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "1ff94ef3-99b0-43fb-8fba-6c59293da8d7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "620f0895-c8a1-491f-bc90-2ed4c8ad0e54");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70494634-D7BE-4BE4-8106-031AAE2BC6DC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e45fd82-fba0-4104-bf5d-82ab7b220e46", "AQAAAAEAACcQAAAAELdLHZj7Ct1uWVIGV5KKFmIbQHQK//4rwQFhRNSiar45psa0PhqOZy9HQtKw5yHhWg==", "643fa36f-5f62-46b8-b83a-da6c93710a5d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753F8F36-D2FF-438E-B5D1-7FF79E4628BD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "763045c2-1f18-42a3-9fe0-e1d535b24267", "AQAAAAEAACcQAAAAEE2jxiDwQRr5xY85uXRvBfkA1Ukz1PmfbaCqXmyYiP79Oqh2OhZomGZFWosD4dV6aw==", "2ef63b9f-9f79-468c-b845-5441ac7abf8c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a775cd1-0856-4252-bc9d-d795865aafbf", "AQAAAAEAACcQAAAAEEyNgVHotIW2hqhXxte7uOAm8a4dO5bjYB9xItCT3EcOavoKWmHjsWwruGgPoCWYlQ==", "3173e774-f19b-476b-92e3-3f2c4bb0a585" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C5E9887D-9C4B-40F5-AB46-2232776005C5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "13810a89-e8dd-49c0-8411-27be732b9356", "AQAAAAEAACcQAAAAEAlmrn6wE/sTMfWVCUhEQLrp1BUNe3m3j1QzR31+LugaQTEO5r/W6p5Ahf8HNVpIcA==", "512da8ca-2a9d-4783-a27c-10a2860aa932" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E7B47704-8DA0-4657-B42C-849C1C22A6D2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aeb10266-8321-4765-aaff-299cdc376381", "AQAAAAEAACcQAAAAEL8F9h2mgZyOLkoLLcrJlVIgdRymI18gh/0y8oe+hzpIdbxI+BitgGsUhwmhdEzXJQ==", "45fc8c3f-a75a-490a-99cf-d5ae3aaf338b" });

            migrationBuilder.CreateIndex(
                name: "IX_PersonImport_LastName_FirstName_IsNewPerson",
                table: "PersonImport",
                columns: new[] { "LastName", "FirstName", "IsNewPerson" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PersonImport_LastName_FirstName_IsNewPerson",
                table: "PersonImport");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "PersonImport",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "PersonImport",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
    }
}
