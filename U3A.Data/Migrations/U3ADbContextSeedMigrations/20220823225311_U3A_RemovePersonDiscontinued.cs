using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    public partial class U3A_RemovePersonDiscontinued : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Person_Discontinued_LastName_FirstName_Email",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Discontinued",
                table: "Person");

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
                name: "IX_Person_LastName_FirstName_Email",
                table: "Person",
                columns: new[] { "LastName", "FirstName", "Email" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Person_LastName_FirstName_Email",
                table: "Person");

            migrationBuilder.AddColumn<bool>(
                name: "Discontinued",
                table: "Person",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "2b91a1f2-440e-42ca-96da-3aca2df621ce");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "8d2c0910-3b7e-40d0-ae19-94d5d48d5a78");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "e254e357-8f03-478a-a89b-fcffd429a244");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "b8b2df3a-0883-4713-b0d2-1f9cdb7b612b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70494634-D7BE-4BE4-8106-031AAE2BC6DC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3704e32f-127d-47ef-9e97-92e88816f962", "AQAAAAEAACcQAAAAEMSEmINbKZocWcf/zrPZb6APu3X/rHWkKS23wBfbzq2tB5CWaBb33c7rUL3ipsvbVA==", "31c8a1ef-9ec0-423a-ae50-a1801ae9719a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753F8F36-D2FF-438E-B5D1-7FF79E4628BD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3846adf3-4664-4051-9761-0c2f00c3b79d", "AQAAAAEAACcQAAAAEE+qBlu/Or9ClN7uCOBz67xMhoDVdnffKSV1tjFyLNXI4AQ1tHVsLx+dr3a4RdKNvQ==", "0e6fdb21-29f3-48ad-88db-46a96ca15562" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "790e039a-d94d-492b-a7b1-a45f3a0900ca", "AQAAAAEAACcQAAAAEO3Hwj8jYOTD3snR4TMHXxOB/MvME/bNvKrtBYGY5/JKTUzCI7mRN9sfn9Hnsb9+2A==", "5351af17-b349-441d-8c57-cb9a363a5c8c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C5E9887D-9C4B-40F5-AB46-2232776005C5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3966e30c-09a2-4f4e-a21d-f71c0f8ade14", "AQAAAAEAACcQAAAAEPN51N9DXD9jNpkzaWxd++kURNfaVjxRpDU4ciLdnk842otkpHRZdaIP/ZlqW0WGrA==", "fa5cec0b-855d-411f-976b-a8a43ef2177e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E7B47704-8DA0-4657-B42C-849C1C22A6D2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7fd08f1-928f-47ba-b1b8-53cd9b3c0624", "AQAAAAEAACcQAAAAEGc+XIzdVxCdA03vdDZnUVPIDCye/hQIVidLstMbhLZM6M+jXA9pHqvY0wZAEKJECA==", "c48ed0c1-cbe5-4c0e-9b67-d1ccbe374664" });

            migrationBuilder.CreateIndex(
                name: "IX_Person_Discontinued_LastName_FirstName_Email",
                table: "Person",
                columns: new[] { "Discontinued", "LastName", "FirstName", "Email" });
        }
    }
}
