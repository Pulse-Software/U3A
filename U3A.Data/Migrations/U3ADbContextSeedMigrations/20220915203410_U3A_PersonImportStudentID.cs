using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    public partial class U3A_PersonImportStudentID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrentStudentID",
                table: "PersonImport",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "c23abc15-cf81-4304-961d-310e08f011b2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "c8471077-d449-4781-b691-f3b29783119f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "fadcae80-85fc-4743-a70a-a74ba96d87a6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "68da9343-8dfe-423c-9987-e8b8e792bfe5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70494634-D7BE-4BE4-8106-031AAE2BC6DC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6d005cc-4718-446b-a359-9203d5311a21", "AQAAAAEAACcQAAAAEN80Jm7eBhuYGDp4QEpyzCcW/BzL96CiZ+iYaXFLsVB8aBy8GtnfNUXLBD3s0sKLAw==", "b12e0443-4398-4328-8be5-b07e4c0ea223" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753F8F36-D2FF-438E-B5D1-7FF79E4628BD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12221abc-dc73-4db6-a63f-726f6ae5071c", "AQAAAAEAACcQAAAAEDjN88BzjW+lx0SseZb7HuR3uDqn9gDP4OAwKb6W+A9ZN1gSGbnXG63rscrUb7XuFw==", "eb1ac9d4-3751-4235-88ef-97b522731b85" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c980c1a-bdc7-4d60-87fd-7e145c49eb7c", "AQAAAAEAACcQAAAAELQxVt84Z4HyodZhRdwgM1Kv2x/AyskmZb5BWHzK1jLr82ndS2bCwNlMHYkOL+FsGw==", "9f6fbbc5-b709-4d54-9baa-546bdda594b8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C5E9887D-9C4B-40F5-AB46-2232776005C5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c34e292a-449c-4621-b0c7-f9698d29b768", "AQAAAAEAACcQAAAAEBsbt5L7fLL6tCreeE4mVwsPdVq47FIfJ9Wm50hdrLbacu/nZRWEV8EVK3/NurTSXQ==", "aaefda20-4b18-44e5-9627-6acc9c085e5a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E7B47704-8DA0-4657-B42C-849C1C22A6D2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "219cc141-1d81-487b-a5ec-e336c8e5ff54", "AQAAAAEAACcQAAAAEOJz6WPV2TgpxwZr9BPwfoEt5inUdNsBRatMcVIi0N167mPrVXnGwwjphXY9j5i4sg==", "6874da9d-5eb6-433e-8777-8b0de2b519fc" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentStudentID",
                table: "PersonImport");

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
        }
    }
}
