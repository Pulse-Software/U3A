using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    public partial class U3A_PersonBaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Person",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Person",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "42e4d7e3-4327-424d-b21a-bba6dc6b6949");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "ee125e7e-7e66-4156-8d66-9377a1d00fc8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "7636ffb8-5ea9-47c6-860b-63116d7b9b7c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "5909be24-7cff-4474-b55c-978f9d9e4e30");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70494634-D7BE-4BE4-8106-031AAE2BC6DC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d4f136a-8bac-43f9-9067-56f7b3b6124c", "AQAAAAEAACcQAAAAEHqdkQdC/B6W/Vt7fDv/RLFTaTZ2hdodh6LPWVoF6DZrXhQDypYU5tgcJHUGrLFd7g==", "b4b0fd81-b301-46f3-addb-4ca796ec540c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753F8F36-D2FF-438E-B5D1-7FF79E4628BD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22222943-4a06-404b-b156-208f2f7ceb50", "AQAAAAEAACcQAAAAEP/PV4H2rGlA2mqMV8kEPUz6XRTTE3YJX4EGBRJ62T9sokXfdT1OLyNSNAnzrq5Dmg==", "d5856d26-368a-4b1e-ac5f-717f32718d1b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce64007e-0394-4ad4-a87d-78ba0d4fafb9", "AQAAAAEAACcQAAAAEJd4uSCwOmAkRq/5exkrK/acVdANZrl8Ozuj2D76sTuiazaVJ7ZSbKMI0+8vo/LR0Q==", "14be1ccd-e772-43e1-a724-83fe12081a8f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C5E9887D-9C4B-40F5-AB46-2232776005C5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6814fd21-6343-463a-9ed8-f146e2a7191c", "AQAAAAEAACcQAAAAEApPA9A15GOLm+uMl72Y94ia6AcmwUSsZORPq1DS1c4TJMlLW6pae2YQhN8nN8H/aw==", "978354d9-5927-4f75-b8c7-9b074650a2ab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E7B47704-8DA0-4657-B42C-849C1C22A6D2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3201f57f-d5b6-4239-8448-29ecb248286e", "AQAAAAEAACcQAAAAEHhcH8v+91L0GcDnll9YYFTCZGAIxZ/+f6LlSf3Z3KNp/cIsW7NF6az4I4EDp/lbWw==", "d1ee5aa8-9a5a-4fc5-a0c4-d2b9b322c579" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Person");

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
    }
}
