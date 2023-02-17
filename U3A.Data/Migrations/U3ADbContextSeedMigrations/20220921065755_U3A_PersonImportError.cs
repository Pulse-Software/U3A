using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    public partial class U3A_PersonImportError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Course_Name",
                table: "Course");

            migrationBuilder.CreateTable(
                name: "PersonImportError",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Filename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImportDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Course = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Error = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonImportError", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "4d90d435-6b8b-402d-b2d1-ff9016d9a54f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "212f26b5-c066-4547-a4ce-6d59741bc301");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "ee039d1e-4519-4a24-bc6e-1418ac13c529");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "cb2908ad-f7c4-4740-80b7-938b2fb86f94");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70494634-D7BE-4BE4-8106-031AAE2BC6DC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f56e73b7-ebfe-4ff6-89e2-26bb2a20df78", "AQAAAAEAACcQAAAAEJGE52wmoCyrdm5ktA6jxFTb1otezDG9sivjpaOou3dO7C4CH10m2TZrYHRjcj8qjg==", "8d086b70-9f6c-4aad-89aa-8a7dd8b18d34" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753F8F36-D2FF-438E-B5D1-7FF79E4628BD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b73c45ef-1062-40ef-b793-9eb66b4d44e7", "AQAAAAEAACcQAAAAEL1p5XrLuN3sqYL8QogUu5zTcmg/HHbMx9TMX2FQMdIFpxsjEb9qJqVGzSD3P4IHXA==", "8709de9a-1995-4f7e-8709-20aa77854aff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ad7f8be-bcde-435a-abae-19ac87443e33", "AQAAAAEAACcQAAAAEAGLYewELP5y4pZC+oDBh75gUcVDlcEfIMTuoytM5X/sxtCvRu5qVjv9X+YiuYnNGQ==", "80a2331c-e075-47e0-a968-b04b49a3df2c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C5E9887D-9C4B-40F5-AB46-2232776005C5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3804033-6c3f-46c9-92fa-ef68d128f8cc", "AQAAAAEAACcQAAAAEDKx9Lx5M0BBvRfl/SO07pnKTqkXG0uY/y11Hlxs4YFM6Lm67P6366ZgxWRR0V9WtA==", "8f534a73-dfe2-46ff-af19-3729be420b61" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E7B47704-8DA0-4657-B42C-849C1C22A6D2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c8b3a4f-affc-49d5-9657-2906ef26a45c", "AQAAAAEAACcQAAAAEHG10AoTRb+gXQuvqP3tLihYRH2rIetJWBqByEL9eEZm/XDXi0pR7WEjEB5LV3pYPQ==", "f401db60-4ea6-42af-a832-d5495ff7f866" });

            migrationBuilder.CreateIndex(
                name: "IX_Course_Year_Name",
                table: "Course",
                columns: new[] { "Year", "Name" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonImportError");

            migrationBuilder.DropIndex(
                name: "IX_Course_Year_Name",
                table: "Course");

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

            migrationBuilder.CreateIndex(
                name: "IX_Course_Name",
                table: "Course",
                column: "Name");
        }
    }
}
