using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    public partial class U3A_CourseYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 2022);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "f75e29a2-3d86-4c05-a5cd-f576b132157d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "54ac1e16-8e87-445e-af83-8be267967b32");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "78636cd2-60df-4b74-ab75-3080d2ddcd5e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "53a86cc7-aa61-48d7-affa-76bdbe23dab7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70494634-D7BE-4BE4-8106-031AAE2BC6DC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b81895c-810d-4cdc-ac5e-22febe8e25e4", "AQAAAAEAACcQAAAAEOhNvj1IH3ZMOTVWT9dvCluVShOesMJCqS8sQ1O2Y2QHDlW51BLtDTldYegiQ1CWMQ==", "499b944c-7f7e-42bf-90fe-a119f6a071c5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753F8F36-D2FF-438E-B5D1-7FF79E4628BD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "436c9401-9ab4-43e6-8f86-934ea8702bb5", "AQAAAAEAACcQAAAAEKpOjzXNrRSOxmcZ1K6sgJ/s9HGH2eDFd8HYidi4I2RRmay/TWCnHnlCHcMOPEjVug==", "46d72a96-2ca9-4a0c-a3cd-b11d7c9704d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d77dfb9-c362-4596-8e76-7280aa461e61", "AQAAAAEAACcQAAAAEDLe3U3LVr4QwEoAxkIS0xdH0II1hy/8AmqcHABuKrqIjuO81tOw+JQomhSzVh3Ytw==", "3017c3bf-ab00-4f7c-8c33-c0744b1ad31a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C5E9887D-9C4B-40F5-AB46-2232776005C5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ee95922-19d0-40bb-a751-ebf25030d01c", "AQAAAAEAACcQAAAAEJfbFE7paFIfnyIVTfWXBIzbCrhjcJOdd3bA/FdbbRNO05KeeXfcuFEY/JEDdyW4VQ==", "439a1160-20e7-49e3-8fdf-acf2c029ba5f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E7B47704-8DA0-4657-B42C-849C1C22A6D2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "334ef438-252d-4321-9673-6017d97f4d4f", "AQAAAAEAACcQAAAAEEUWRrdo39zq626BbOIorUn76xB0keYwYp/UbIQXX2j5Vhj1yCU1wVsIMIj5KUNqZg==", "3bd47073-0609-4c5e-a474-77844eeaba22" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "Course");

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
    }
}
