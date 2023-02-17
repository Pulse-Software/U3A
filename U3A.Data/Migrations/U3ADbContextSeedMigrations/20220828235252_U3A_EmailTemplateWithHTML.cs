using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    public partial class U3A_EmailTemplateWithHTML : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HTML",
                table: "EmailTemplate",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HTML",
                table: "EmailTemplate");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "a08ec0e3-2609-4f3f-a599-0858cc180032");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "4385c73b-9bbc-4139-9637-da2bd740fc52");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "0151d91d-32ee-4a9f-8487-1f8653d9a95e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "cbdc0104-c65c-452e-9505-128c77f04175");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70494634-D7BE-4BE4-8106-031AAE2BC6DC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ab81c4cd-294e-49a7-9138-6f1a85063af8", "AQAAAAEAACcQAAAAEEpmxGehl5CEnLphJNyUgEX2NbEdN2xt25ep9JmVXJ4u8cJgak9hdG03AERQ5SIPwg==", "1469471f-c3b6-41e1-a4e9-d7f1f3a80ce4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753F8F36-D2FF-438E-B5D1-7FF79E4628BD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6249583-cdb0-47d6-8c82-21720c7fc0e8", "AQAAAAEAACcQAAAAEM+VTx1HHHol5cz6E9uf040mp6zb6oJP7NJEIBj2WqCd/wIvXnAuEFznAdHqW/zVzA==", "c10f7c14-a14a-4885-becb-4c3f5da950f1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0f52862-77b6-4da3-ae32-41e9189e5183", "AQAAAAEAACcQAAAAEDHzSjXliEqM9lPkQBMg+a1aZ/R8O7seH+ilexKVEvigwp8TkkSFTB1aQcgjdKsdzw==", "57058eec-74a0-4020-930d-c296960e718a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C5E9887D-9C4B-40F5-AB46-2232776005C5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "865cbb82-4a54-4384-97f2-229be702e684", "AQAAAAEAACcQAAAAEPqa9X/u9AF8yh6c7FQCSwz9us5ywrliJ4r9gAewp2MLDRZuhclzbLk9+Kn/YRvOMQ==", "0d2b2202-cdc6-4632-9c97-ce6ee0dedb1f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E7B47704-8DA0-4657-B42C-849C1C22A6D2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b5b278f-eb3d-47da-8b8c-349d6893e31a", "AQAAAAEAACcQAAAAEDz3ewGXakwM9Zk1xLfdvYTtodANTBB+gVk+vfhO5+B8lvUj4UYXUi2lTIWhlgWO7Q==", "dfa2a1f3-cae2-4042-88ae-b53c49d7996f" });
        }
    }
}
