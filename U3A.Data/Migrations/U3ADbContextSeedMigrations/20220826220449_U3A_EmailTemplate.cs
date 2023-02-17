using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    public partial class U3A_EmailTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailTemplate",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FromEmailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FromDisplayName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplate", x => x.ID);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_EmailTemplate_Name",
                table: "EmailTemplate",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailTemplate");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "31894ea6-39fd-4c7a-873c-4a597193aa89");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "95383974-b2e4-4db1-b286-ac1836429a8f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "881b6787-7039-44fe-8d8f-e554563b5b2b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "eaa3382f-82b9-4be2-a819-f75002abe65c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70494634-D7BE-4BE4-8106-031AAE2BC6DC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2aa746f9-25c7-4af7-8cb1-4c00a16cc3ed", "AQAAAAEAACcQAAAAEOkac/jcDabU11Tb4G6vNPajcY92DwbYMB00wDeue1R8bhaZvIXlRpI+tHhVLn29Ug==", "a36d5bf8-ea8f-400a-bfeb-745d8fab082d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753F8F36-D2FF-438E-B5D1-7FF79E4628BD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f801905-4316-437f-b3b5-5d3be199d2b2", "AQAAAAEAACcQAAAAEOUfL9wvfyE7LHL1tFcBkuyuyPbr5DDddHeIaRLUSZ3+1SXrypPR0rkOGhvCBFc5UQ==", "338f51eb-3f9f-4081-975f-0da5672b3348" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e99465be-d805-4484-898f-cd18993df746", "AQAAAAEAACcQAAAAEOGKyw+tNqJwnQMgEMlrO8qPV59NcpUxz0bOTZ1oaFAnRGfTy4e41lGkfvnTdfpeHw==", "db86ebf2-d259-40fe-b323-4b858de6cc93" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C5E9887D-9C4B-40F5-AB46-2232776005C5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "97cf42a2-cb08-47e3-8685-9ee23d522883", "AQAAAAEAACcQAAAAEO6f3XHx8h+an/kmxruXr7LnHzIYG6YvUg4g6yPRe9sch09r7nk/H1DHlowbssrDDA==", "cbde1fa1-12bf-4551-91a9-db4aed7412c3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E7B47704-8DA0-4657-B42C-849C1C22A6D2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "796b6f93-77ad-46db-8315-9a8779b58157", "AQAAAAEAACcQAAAAEHlVBe0onWA6YpXiMY+AWK5BNRosJAZKTw01WGv4/A+qjvf0J7WXzpFJhPn2klmXVw==", "63eedf15-d22c-462d-8ccb-ab02cae85440" });
        }
    }
}
