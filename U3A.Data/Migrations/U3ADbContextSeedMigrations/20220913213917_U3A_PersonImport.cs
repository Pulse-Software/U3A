using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    public partial class U3A_PersonImport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SMSOptOut",
                table: "Person",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "PersonImport",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postcode = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SMSOptOut = table.Column<bool>(type: "bit", nullable: false),
                    ICEContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ICEPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VaxCertificateViewed = table.Column<bool>(type: "bit", nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Communication = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsNewPerosn = table.Column<bool>(type: "bit", nullable: false),
                    CourseChoice01 = table.Column<int>(type: "int", nullable: false),
                    CourseChoice02 = table.Column<int>(type: "int", nullable: false),
                    CourseChoice03 = table.Column<int>(type: "int", nullable: false),
                    CourseChoice04 = table.Column<int>(type: "int", nullable: false),
                    CourseChoice05 = table.Column<int>(type: "int", nullable: false),
                    CourseChoice06 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonImport", x => x.ID);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonImport");

            migrationBuilder.DropColumn(
                name: "SMSOptOut",
                table: "Person");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "8a66e81d-ee2e-4670-81bd-249b224a68eb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "eed1167d-a03e-4c63-9525-00866b6270ae");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "fa2f561c-ef62-4d03-aae2-341cbda9f1a1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "4df236a8-022f-430f-8568-92320430a1ec");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70494634-D7BE-4BE4-8106-031AAE2BC6DC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "070fbf18-ed04-4406-9801-ba3d8699923f", "AQAAAAEAACcQAAAAEL2JZi3l74FHIMP0XevsmtlkDAqZIXXAO7z7VLAG2QwjGEK1NVQqkwt7Kec1Sesx0A==", "82172567-f591-445e-b6d3-bd3a221e49f0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753F8F36-D2FF-438E-B5D1-7FF79E4628BD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7fe2a849-76b2-410d-b1c5-96d508d62912", "AQAAAAEAACcQAAAAEBbSC5W8m1+KNVMpU1B3vN5MwRY11whXR4/SahEQ9srBJPtyW1wSlc8VfNTDhHDr9g==", "76269935-8e44-4339-abc5-a042b35559e1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39f68e71-f0f4-42d5-a526-672c97745cbe", "AQAAAAEAACcQAAAAEGd5ugzcUfwU8ZiqDRc06r4eBPgP1Ya/hWdz7pYVpXq7UZwd2LQTXQScwBLMBeuyeA==", "881d9fa2-ed4a-43d5-ada0-6b86e596d75d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C5E9887D-9C4B-40F5-AB46-2232776005C5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d3cfc21-3f42-4dc9-a52a-02e5f383cfec", "AQAAAAEAACcQAAAAEKiXaTXlhWORz7YmqfipUGilDLtMYllH9VY9qXpA6IojAje8b+S2EMcnltRPD1zMZg==", "4faf6eb6-4f15-4d16-8fc0-879989f846e1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E7B47704-8DA0-4657-B42C-849C1C22A6D2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c46882fe-250b-43fb-9e6e-0cd95fedc505", "AQAAAAEAACcQAAAAEE0NzxcIS6NGyPGl8lhR++99IXCpKJEkBZC8AlUPEMtRCFW4zuD5j+cYFZ9pe+KYaw==", "69f7309b-4265-43cb-9293-bb3db85f3f16" });
        }
    }
}
