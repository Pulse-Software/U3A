using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    public partial class U3A_DefaultTerm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDefaultTerm",
                table: "Term",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "The number of weeks prior to StartDate that enrolment ends");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefaultTerm",
                table: "Term");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "f9455188-4710-4564-ae14-e6bdf27c9c9e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "be2b7085-aa1d-456b-bc37-229522deb0c2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "8a5f9fb7-b790-4c53-a4bf-abb8080a395a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "4cb97ff4-e3d8-49da-bb6e-377fe83f4ad1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70494634-D7BE-4BE4-8106-031AAE2BC6DC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a30f14c1-91e9-4ab3-8d61-f7ea6aaa958a", "AQAAAAEAACcQAAAAEIfL9Hq+pYcl4MHmRslyUYeEr1FVOy8Dmq0v1UmcdGcuen7KHEHTnxkGHHFpVn+XaQ==", "c7da4ef2-b0d2-426b-9bab-3673e1c7c8c4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753F8F36-D2FF-438E-B5D1-7FF79E4628BD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f3865d54-35a4-49ee-824a-2965d0d2df29", "AQAAAAEAACcQAAAAEFibcqdtPtPSuBSidRhDoMtXkvU9hg/Lm3H/Be83MTjEZb+Zh4tRMJcC+eQH+XHfuw==", "47ff5717-a3f8-4997-9aff-8ecd511f31fa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c12972e2-ea17-49e6-b2bb-b36d2cf2e143", "AQAAAAEAACcQAAAAEGepLlP/Z3e1iolA13OrIcz8PQb19dGRytqSZT9k6ibyU1Tj6Bhs76QyyJM7lFcJ1Q==", "318df5cf-5850-4b8f-9ed6-2ff32707df78" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C5E9887D-9C4B-40F5-AB46-2232776005C5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8cbf4169-99fe-44a3-9766-d11c4c3d24a8", "AQAAAAEAACcQAAAAEEacPDrGc05sedkenjZcVig8tX1lAMJ48amYAH4xp8sB5nPK8IIP0x6SzckPCNz3aQ==", "574142da-cd85-4e74-945a-5fe2bd394289" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E7B47704-8DA0-4657-B42C-849C1C22A6D2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "715565ac-04c9-4f24-9cd8-3d9a5ced72ab", "AQAAAAEAACcQAAAAEMAGYM2JLdbRTl5YPVv9pAKAoSZVOavd1bFsoT1kZ3jFefUnnwnaH1UpXOymanee5A==", "479c6946-088f-4457-b1bf-57fea7e35f41" });
        }
    }
}
