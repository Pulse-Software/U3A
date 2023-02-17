using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    public partial class U3A_AddnClassOccurence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Occurrence",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "Name", "ShortName" },
                values: new object[] { "4th Week of Month", "Week 4" });

            migrationBuilder.InsertData(
                table: "Occurrence",
                columns: new[] { "ID", "Name", "ShortName" },
                values: new object[,]
                {
                    { 8, "Last Week of Month", "Last Week" },
                    { 9, "Every 5 Weeks", "5 Weeks" },
                    { 10, "Every 6 Weeks", "6 Weeks" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Occurrence",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Occurrence",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Occurrence",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "421c91fc-da8b-435b-bcb1-478967d51aa4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "8a0d68f3-f1d2-4bbb-ae26-1f7de75a778c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "c64ab925-4da1-411f-b52a-daa1f32b96be");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "d8b3a3f5-5bed-49b0-9c56-99220767c659");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70494634-D7BE-4BE4-8106-031AAE2BC6DC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c31de912-d524-403e-b8cd-48202613f9c1", "AQAAAAEAACcQAAAAECyPAxLkmekf913gE3eQZna1Ig+lkoYOH4a6u1RHjtDqAFW2TM42ReoU+aLCFP24Pg==", "d5175263-b906-4006-b421-13fd4b755ecd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753F8F36-D2FF-438E-B5D1-7FF79E4628BD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a20533a-01e9-4ced-afdd-196119010041", "AQAAAAEAACcQAAAAELJvARCzGOHvGIkIglul9KTjTpdJ15G7hf3o1wJU9qwOBEDMTYcaMECAP2yT8UaEvQ==", "0b64e070-9a1f-4231-b091-d55aedd91b6f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "47293ced-4b08-4f2b-97fc-09f3796f1731", "AQAAAAEAACcQAAAAEB9d8Eo5SKybuzvrXijZquPk1Wq6JRVetOHTMbStzPO4aQduPwhKhmFfjY4hanhyjA==", "93c26502-6eeb-4871-89e2-cf5a7d1a162b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C5E9887D-9C4B-40F5-AB46-2232776005C5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "13be5ea4-bae4-4687-b2b2-fa04817d9ba2", "AQAAAAEAACcQAAAAEKqp+nXCafMoMtApGZO4esUObktRqsowktCxf5jl8Pw6OITLbuDHgz/r7czWCm05fQ==", "2a67d262-0dc5-408b-9135-7d9dafad581f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E7B47704-8DA0-4657-B42C-849C1C22A6D2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6921d1c3-e679-45eb-87a1-441f0a5b85c4", "AQAAAAEAACcQAAAAEIDM5SHMz5pVXZ/rG0PJZz+PV9cq1HillmQ9vV9MpfoTfDXRSwllaSxoBgAyBYRsOQ==", "310d6799-04d0-4b0a-b692-151d9fa68a72" });

            migrationBuilder.UpdateData(
                table: "Occurrence",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "Name", "ShortName" },
                values: new object[] { "Last Week of Month", "Last Week" });
        }
    }
}
