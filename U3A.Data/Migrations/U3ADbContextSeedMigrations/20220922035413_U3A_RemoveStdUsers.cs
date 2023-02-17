using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    public partial class U3A_RemoveStdUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "993C6378-61D4-4734-ADAE-D725F2A8CD94", "70494634-D7BE-4BE4-8106-031AAE2BC6DC" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "753F8F36-D2FF-438E-B5D1-7FF79E4628BD" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0", "C5E9887D-9C4B-40F5-AB46-2232776005C5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "D4BA57AA-A379-4EE8-940E-57315575978A", "E7B47704-8DA0-4657-B42C-849C1C22A6D2" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70494634-D7BE-4BE4-8106-031AAE2BC6DC");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753F8F36-D2FF-438E-B5D1-7FF79E4628BD");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C5E9887D-9C4B-40F5-AB46-2232776005C5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E7B47704-8DA0-4657-B42C-849C1C22A6D2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "4921db65-5f30-484b-98b8-a94e6860d123");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "88e47630-238a-4aec-9088-8fe70e992593");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "fefe9125-9799-4670-8dd8-785fe6d0db98");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "10ab4c68-f129-4028-ab63-0d971d3c5bb1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dabf1795-bac6-448e-8905-ee6173ad6f44", "AQAAAAEAACcQAAAAEOx6yYIDYEMjms+M5dubAGuHodyqwOznp10e2lce/cvBbRz6y4ZqCgeG41QgOSULNg==", "141b0c48-9652-4319-8805-6416af7f5a72" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ad7f8be-bcde-435a-abae-19ac87443e33", "AQAAAAEAACcQAAAAEAGLYewELP5y4pZC+oDBh75gUcVDlcEfIMTuoytM5X/sxtCvRu5qVjv9X+YiuYnNGQ==", "80a2331c-e075-47e0-a968-b04b49a3df2c" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "70494634-D7BE-4BE4-8106-031AAE2BC6DC", 0, "f56e73b7-ebfe-4ff6-89e2-26bb2a20df78", "SysAdmin@U3A.com.au", true, false, null, "SYSADMIN@U3A.COM.AU", "SYSADMIN@U3A.COM.AU", "AQAAAAEAACcQAAAAEJGE52wmoCyrdm5ktA6jxFTb1otezDG9sivjpaOou3dO7C4CH10m2TZrYHRjcj8qjg==", null, false, "8d086b70-9f6c-4aad-89aa-8a7dd8b18d34", false, "SysAdmin@U3A.com.au" },
                    { "753F8F36-D2FF-438E-B5D1-7FF79E4628BD", 0, "b73c45ef-1062-40ef-b793-9eb66b4d44e7", "security@U3A.com.au", true, false, null, "SECURITY@U3A.COM.AU", "SECURITY@U3A.COM.AU", "AQAAAAEAACcQAAAAEL1p5XrLuN3sqYL8QogUu5zTcmg/HHbMx9TMX2FQMdIFpxsjEb9qJqVGzSD3P4IHXA==", null, false, "8709de9a-1995-4f7e-8709-20aa77854aff", false, "security@U3A.com.au" },
                    { "C5E9887D-9C4B-40F5-AB46-2232776005C5", 0, "e3804033-6c3f-46c9-92fa-ef68d128f8cc", "membership@U3A.com.au", true, false, null, "MEMBERSHIP@U3A.COM.AU", "MEMBERSHIP@U3A.COM.AU", "AQAAAAEAACcQAAAAEDKx9Lx5M0BBvRfl/SO07pnKTqkXG0uY/y11Hlxs4YFM6Lm67P6366ZgxWRR0V9WtA==", null, false, "8f534a73-dfe2-46ff-af19-3729be420b61", false, "membership@U3A.com.au" },
                    { "E7B47704-8DA0-4657-B42C-849C1C22A6D2", 0, "5c8b3a4f-affc-49d5-9657-2906ef26a45c", "accounts@U3A.com.au", true, false, null, "ACCOUNTS@U3A.COM.AU", "ACCOUNTS@U3A.COM.AU", "AQAAAAEAACcQAAAAEHG10AoTRb+gXQuvqP3tLihYRH2rIetJWBqByEL9eEZm/XDXi0pR7WEjEB5LV3pYPQ==", null, false, "f401db60-4ea6-42af-a832-d5495ff7f866", false, "accounts@U3A.com.au" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "993C6378-61D4-4734-ADAE-D725F2A8CD94", "70494634-D7BE-4BE4-8106-031AAE2BC6DC" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "753F8F36-D2FF-438E-B5D1-7FF79E4628BD" },
                    { "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0", "C5E9887D-9C4B-40F5-AB46-2232776005C5" },
                    { "D4BA57AA-A379-4EE8-940E-57315575978A", "E7B47704-8DA0-4657-B42C-849C1C22A6D2" }
                });
        }
    }
}
