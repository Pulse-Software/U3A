using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    public partial class U3A_PersonCommunication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Communication",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Communication",
                table: "Person");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "bc95b753-3923-4f72-8edf-0fc9fd7b65b1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "4950ec95-5241-43c6-9263-09b056e36beb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "ac3754f9-111a-45b6-b2d8-2c207334f1d3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "822bbc25-abe2-4df9-addc-c29de047a068");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70494634-D7BE-4BE4-8106-031AAE2BC6DC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "61493c62-e137-4e69-bda0-1c01099ddb3e", "AQAAAAEAACcQAAAAENqB3STxQcUOfq8jb+XSQAEBD96hwEeWJHY+rUg2fH+cALHIADiX9eI9CPFaGgerIw==", "3fd2ff2a-fec4-46c7-bade-983be8327032" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753F8F36-D2FF-438E-B5D1-7FF79E4628BD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27568b41-cb8c-426c-8c6a-5338c7710910", "AQAAAAEAACcQAAAAEOmqzyXWV4bZ4bmTPYw1gThsxblXGL+PEblL+AhcN/ZvTqSwoB7nBAygQ334MJu6MA==", "57e3e9ba-b7dc-4eae-a21c-9238d7fb9387" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aab337ed-78b1-4d3b-b05e-822bba7da95b", "AQAAAAEAACcQAAAAEPIqAcI021wuaXgrp1PLWYpMQB+g/lQCdwwJQtApN04SSISZqX1xLDP/Q45BN5wI4Q==", "b48c76ba-c69b-4134-8cac-27e76ed8c5b8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C5E9887D-9C4B-40F5-AB46-2232776005C5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c56dce2-1b73-4209-bafc-112473e28f77", "AQAAAAEAACcQAAAAELc5f/9vbD3djd2IJ7RCqA6+1C56lJtb85tcENoCg5Tngz+rEDu/IWU8Ab3JPcl9Rg==", "2939cf29-7492-4de9-9da5-7e35cda7f308" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E7B47704-8DA0-4657-B42C-849C1C22A6D2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c10771e-e4a8-4b58-bef7-34a9b71b37a8", "AQAAAAEAACcQAAAAEKlgyvbNEurpLzSeWPRshzFPTlMsu5xHfUnvjJ0f5Nz/szz8YrJSZvUIhzjMPN84aA==", "aebf592e-a79d-4220-ae42-6b2ef6b7cf43" });
        }
    }
}
