using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    public partial class U3A_RemoveCourseDiscontinued : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Course_Discontinued_Name",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "Discontinued",
                table: "Course");

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

            migrationBuilder.CreateIndex(
                name: "IX_Course_Name",
                table: "Course",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Course_Name",
                table: "Course");

            migrationBuilder.AddColumn<bool>(
                name: "Discontinued",
                table: "Course",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "77c176f0-81be-46ad-b4fd-d0448e070dd7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "b2983e2d-a64a-4c2f-8155-bc0a26096bdc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "37623109-1bf1-4148-a389-42e515f8c081");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "b83c56dd-79eb-4cc4-adca-1fda9d57a25c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70494634-D7BE-4BE4-8106-031AAE2BC6DC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a27924d-c095-436b-8182-6d2e4477b2c6", "AQAAAAEAACcQAAAAEB6wWVQCLKA7Cb54R47WJcSSm3QzpfwlOQ0K+VpllaK9w6SEybkv0xv7MAdsQNlrdQ==", "4729e77e-3e66-409c-9c55-e03ab03802be" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753F8F36-D2FF-438E-B5D1-7FF79E4628BD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8a0ea0c-0ee5-4e7c-80c1-08071b90d232", "AQAAAAEAACcQAAAAEBgcekD3vucx8ZOPIiwdxapaFuIceUmIbHn3akVv8ALbYyQsYnwEXEvHxEJjUFod2A==", "708e8bd0-7f00-4afd-91af-a8d4b7063609" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79accddd-d43e-4057-a615-4874f62c710e", "AQAAAAEAACcQAAAAEE4XK1Xf6v29DP7qpGmBFTrpbyZBOMQx/laJEvbQWl9YiX+A44zYW6BmkXmNM6Sbhw==", "6474f2f2-da34-4686-9445-47f67d95cb22" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C5E9887D-9C4B-40F5-AB46-2232776005C5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a020d5f-7df8-4dd5-b26c-058d8981b2d3", "AQAAAAEAACcQAAAAEGsdkKPZT4crMFuIDfh9l0LuwtIMnjithfJWiEZC3sbHlSnjParfxs3ULhA/767yvQ==", "41080c3d-7175-4d0e-b557-641757be35f4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E7B47704-8DA0-4657-B42C-849C1C22A6D2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c19424c-c51f-4244-88d1-55cc12ae0eef", "AQAAAAEAACcQAAAAEF8Evk9g7MYspt3iDbVpEp7tplB7duCE5ArgqEhn5pfIsARaDJaNtzJSer7nG21wsA==", "e2799b55-9f3f-4848-ad7f-daba315a4358" });

            migrationBuilder.CreateIndex(
                name: "IX_Course_Discontinued_Name",
                table: "Course",
                columns: new[] { "Discontinued", "Name" });
        }
    }
}
