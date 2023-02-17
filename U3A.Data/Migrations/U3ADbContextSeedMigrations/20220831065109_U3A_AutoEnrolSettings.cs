using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    public partial class U3A_AutoEnrolSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AutoEnrolNewParticipantPercent",
                table: "SystemSettings",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "AutoEnrolRemainderMethod",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "b67dc99b-1a0c-4b81-a718-c0d0edff864b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "6194fe6c-bc03-45ab-8fc9-a5122e71450b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "28f41a02-3eb2-410b-8ae5-2e9cc89acdc7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "d7b0f8a4-c048-42dc-9a4d-3c7722a7411c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70494634-D7BE-4BE4-8106-031AAE2BC6DC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60b1d713-13da-4dce-b395-ddfd59e9b5b5", "AQAAAAEAACcQAAAAEIFd9ZJ3lksPMP80MZfjFr7kyOKtcUQdI9JII7aoGUELcvsbhoOfgjQJVIAnYhnpsA==", "cc88c17c-4844-49ae-a625-ddf32e65ea09" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753F8F36-D2FF-438E-B5D1-7FF79E4628BD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75eb5f55-14ed-4f9f-ad07-e7ef144ed5ad", "AQAAAAEAACcQAAAAEF01aN7jPvPKX3Xh17yK7MSjgY+Mf5j2zjsL+wVA8pZh25lbv7z67q3csws0YktvGw==", "88e4ac97-e73b-400f-bbba-c9c604abe876" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3fa64b5a-d462-4ea7-9d3f-64be76c89874", "AQAAAAEAACcQAAAAELxT30A3ce1i/m6CEkwDx7+/uk7Or0R+irbf8pRzsbXFZ2pgzo6p9GHrgU0nNBQGcg==", "2105f348-653d-4032-ab05-a13a98dc6d41" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C5E9887D-9C4B-40F5-AB46-2232776005C5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ca55301-7f84-4816-af96-82a623ca0f77", "AQAAAAEAACcQAAAAEK2YbWDFlkT1z6fn8zxsOcLfftNVvkIE7KRUYN5tiLDLecnVfRvNOAjY2+cBufX4Ow==", "0b3a1543-31f9-46b4-9745-b8c607659d8b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E7B47704-8DA0-4657-B42C-849C1C22A6D2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0404daa-e328-4d66-9c4e-c38d19befed3", "AQAAAAEAACcQAAAAEI5LqpJcj3ehKNm8CwsiSHeyHXcKD3sfj8SxELaJ2X8Tui6U4v+dpXX13VZOHHQ2Eg==", "5cf0091c-a693-48c4-8c1e-de2ec3b55ba1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutoEnrolNewParticipantPercent",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "AutoEnrolRemainderMethod",
                table: "SystemSettings");

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
    }
}
