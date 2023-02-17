using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    public partial class U3A_CourseTypeChnage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVoluntaryActivity",
                table: "CourseType",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVoluntaryActivity",
                table: "CourseType");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "5e99f08e-4555-4998-834b-24786d24fc9a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "c31b46bb-928f-411c-9f18-c84f62106c1b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "286cf813-1bc6-4385-a545-cc6ee2de93f7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "7cf128ad-45a3-499b-bf25-ca21678ce6eb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70494634-D7BE-4BE4-8106-031AAE2BC6DC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "beb79513-2257-489f-9cb5-f008d61d55ee", "AQAAAAEAACcQAAAAEJ0s4p+MFiXURnb61SEH926OUy28Y5YrYqKjNCO/W5vSDTq1Ryd3Y5Cq9iotpROzfQ==", "075e13aa-edb9-43ba-99b7-c248848faed3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753F8F36-D2FF-438E-B5D1-7FF79E4628BD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "34905761-59fd-4408-a261-20dfeaacd7d1", "AQAAAAEAACcQAAAAEOe+NeYnOeM6CIUvG3rLuGXqrRsAWJ7BoXgKyvirFlq38T9v7lqCnEdkMEUOWSe+UA==", "1e02c8a0-ff0b-4b59-9126-385782db6632" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a953037d-7a28-4857-abd7-136ac482ff88", "AQAAAAEAACcQAAAAEGO9hnvP8x8fJPlDhs2gGYMhl9koCigXL2PPHidC9luB5nbMxW8fCFahxG/ZCA1OSw==", "d19a58d8-c599-4d04-b99b-06b42261f032" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C5E9887D-9C4B-40F5-AB46-2232776005C5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a59d689a-6000-4448-9560-1677fdf03a7d", "AQAAAAEAACcQAAAAEF5rf+n4Z9u7Fzv9PENdLMBwEmNkHidubJciJdNwx/0P8Jpa3E7j591z1e0OKw++fg==", "912b7ae5-442b-4ff3-a276-b479d3f4f1d5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E7B47704-8DA0-4657-B42C-849C1C22A6D2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eadf1573-36ec-4888-8f5e-bfe0564de98c", "AQAAAAEAACcQAAAAEGI+D+snqXRY4uerus0kU6ypVzUHoLHJo7XNmQ0Iastb7pdBzCdt9zvnMUGVR3SeCw==", "15645d31-2d90-4ad3-81a0-abfbefbfc555" });
        }
    }
}
