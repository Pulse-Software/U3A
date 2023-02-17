using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    public partial class U3A_EmailHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailHistory",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Service = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailHistory", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "1486ad5c-3f8e-4dce-bc05-a6d5cec9d71e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "91f275eb-a7df-47d6-947a-9b3cdca536eb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "5cc26270-3ecf-4def-9695-2fb62447cf0a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "dbff9755-c888-4c48-8be0-f4334b270c5e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70494634-D7BE-4BE4-8106-031AAE2BC6DC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a1e3266-1fc9-4d4b-a8e5-c82942323d42", "AQAAAAEAACcQAAAAECMUEBWOAWt8Z7Mkq3KPd5UHrQ08IrgN+JtteiN2QarOmrwPLn+TJi30bK/K1HgbnQ==", "71084143-7714-4a83-8248-cf2de27ced36" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753F8F36-D2FF-438E-B5D1-7FF79E4628BD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce634ff6-2904-46df-925d-5123c03f4691", "AQAAAAEAACcQAAAAEJ2IMRvhHb8r5mxOT5/AawI8lDNIVS4bXh4Gv2IvO3PhaKpFLHArmdRIhkGPejI7Dg==", "f1bba8f0-05bc-4088-8870-48fdf1fc3f43" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0e7061cb-487e-4e89-827b-9412cb8a7396", "AQAAAAEAACcQAAAAEGeiIgGUhbQlDAYeAg9DhZJpG4O90IrwG7CDTRhGYViMMhDEHOrJjhCTph9c/UT0OA==", "42fa9bc8-db9e-4e34-bcf6-aabee662fa74" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C5E9887D-9C4B-40F5-AB46-2232776005C5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a4a0ce2e-e667-4c3a-b078-8a6573c589e5", "AQAAAAEAACcQAAAAEJ7Mws/RyutGCPjAMmK0Gp5cTJ4EJQMogNhM5fe8LQKN37aUWVEOaosLJRQA1r7bxA==", "a4169d48-3ccd-4e5d-94b2-d314cb2df03b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E7B47704-8DA0-4657-B42C-849C1C22A6D2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "744e133a-26fb-4db2-b9a3-93b837dc5893", "AQAAAAEAACcQAAAAEB7WtEGlEGZWxFRp5UKskzgFmuA3iiPe4TIdj8pBR81+AUyh8sJ5SaBsDogj1npPpA==", "06c73ab2-a1c0-4415-9cab-60725fc7deae" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailHistory");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "316af0a0-14f8-4b5b-81b5-67d0cb5280a5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "c5ee4a5b-cc30-4ec1-a099-38a4c311059d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "4d9a3196-f573-4ad3-a0a2-96ef60be3901");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "55b71d75-f5da-41a1-94ee-143a45bcca48");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70494634-D7BE-4BE4-8106-031AAE2BC6DC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a4664a8e-172d-4504-964b-bcd40f241858", "AQAAAAEAACcQAAAAEPGRYlPuP19SW7gE7GL76z2VtKkudMbZUOXGRfQDX9g4NYvw6DWzmFuVeBgRQOrKpw==", "e13b1257-f589-44ea-a371-a0db928ce467" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753F8F36-D2FF-438E-B5D1-7FF79E4628BD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99a65332-f135-4960-b891-1f38dea7b351", "AQAAAAEAACcQAAAAEFTXi31wqCMML0YmM9prZ42Gf3gXmCOts9cr/+k7wDC0RwT/BJtjTAb+NeZ6eWJOtg==", "4da48a06-b145-45e2-854d-02707e86e242" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e119c2b2-d490-4603-b220-56ce94cf9dcc", "AQAAAAEAACcQAAAAEGhzu86PQFmhRRsXc6bCIEpdHMgUB1HVi97ZG76b+3qtd4lBIByraQ4R//chvwJEBQ==", "8f39e509-6bf3-401d-be08-a31761f1510f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C5E9887D-9C4B-40F5-AB46-2232776005C5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a50a1503-03bc-456d-934c-c37b3fff0dde", "AQAAAAEAACcQAAAAECbQDd98WHyb88ZLz302r/aLdYfIu/XqOMBMmxR2ivATWUshHpQTX1QX9ELfD/My2Q==", "64aac121-6f83-4862-aa16-5e8f8d79ed6e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E7B47704-8DA0-4657-B42C-849C1C22A6D2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "03049e13-26a8-403e-b245-12a7920dcc7a", "AQAAAAEAACcQAAAAECcgjFoMnOPpUW0vyA6A1ik26yh0S8MLkCDVFHht6C6RnUXCoP4nkuU8pUQ3D451Zw==", "141fed1d-e3fb-42f1-a0e5-a321e3ca67a8" });
        }
    }
}
