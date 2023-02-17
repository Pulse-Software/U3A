using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    public partial class U3A_AttendanceHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttendanceHistory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttendClassID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsAdHoc = table.Column<bool>(type: "bit", nullable: false),
                    year = table.Column<int>(type: "int", nullable: false),
                    Term = table.Column<int>(type: "int", nullable: false),
                    CourseType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Course = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Venue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVountary = table.Column<bool>(type: "bit", nullable: false),
                    LeaderLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeaderFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParticipantFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParticipantLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttendanceStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceHistory", x => x.ID);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceHistory_AttendClassID",
                table: "AttendanceHistory",
                column: "AttendClassID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendanceHistory");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "385883dc-123a-4c65-a9c5-89c383c2d728");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "1d4e8a59-1d23-4861-9ea6-74575e9bcabd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "d140c439-9b0a-48d0-bfc3-3727073bf791");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "0f3296ad-3654-4b52-b3d6-2bea4581b3d5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70494634-D7BE-4BE4-8106-031AAE2BC6DC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85094d30-af49-4e07-8408-8d4b7c4eaa19", "AQAAAAEAACcQAAAAEM4I3foWmWnVP6GkEOMH3tTD8EJ/yNcdNzohlTCAsvNefp3hzpc7/54FBfWn4xRN0w==", "be0d9640-4b9f-4e88-8747-f22d93f177dd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753F8F36-D2FF-438E-B5D1-7FF79E4628BD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4664b5b9-9538-42c3-9c6d-ac03153b29f1", "AQAAAAEAACcQAAAAEOU5rcsBs+fX/oLC0QACkQRPlEGKR531/wKSr/3x0hNGilq7D4okbmBB56tnpSlpPA==", "8235dc98-5810-434e-9bee-6c392a08b317" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3ffb31c-1bfc-45bd-acde-f0b59ec6d98e", "AQAAAAEAACcQAAAAEFpMp7+9cZsemF55fRFLSRq1i1jig/HR++sv8Oi41DY0/frhSCFVGA7lyjbqeQZBBw==", "43158abc-e3b3-4d6e-8845-0643e162df79" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C5E9887D-9C4B-40F5-AB46-2232776005C5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8694082-42a5-460c-80ef-4d8385466fb4", "AQAAAAEAACcQAAAAEMZ8xq/qi8ImILijrPDw1RYGMqAyCcryASIyv4cEaFJWpKsJ3ZiHAWeZcw0c+KTHIA==", "804b3767-5342-4811-8a80-327f98c157c5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E7B47704-8DA0-4657-B42C-849C1C22A6D2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f796695-01d8-4485-a076-f573b843b9a3", "AQAAAAEAACcQAAAAEKWf1mk9jce430dFwohj9/aeyE3ifsd+dzvX7mrkmW7mZ0631vP/9zK7uJ+QYLzZog==", "62c668ce-2fda-4dc1-b782-f0f6c9fa03de" });
        }
    }
}
