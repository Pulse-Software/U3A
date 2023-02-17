using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    public partial class U3A_RemoveASPNETSecurityFromDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "993C6378-61D4-4734-ADAE-D725F2A8CD94", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "D4BA57AA-A379-4EE8-940E-57315575978A", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "5021861c-98d4-4eb6-ab52-473d0a4e0328", "Security Administrator", "SECURITY ADMINISTRATOR" },
                    { "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0", "aca53ee9-ace4-4961-bd05-71eb31f10067", "Membership", "MEMBERSHIP" },
                    { "993C6378-61D4-4734-ADAE-D725F2A8CD94", "88f105bc-b96c-4c73-bed3-b2341d6adc32", "System Administrator", "SYSTEM ADMINISTRATOR" },
                    { "D4BA57AA-A379-4EE8-940E-57315575978A", "41766857-2f55-4699-b5c1-90858cd7851e", "Accounting", "ACCOUNTING" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, "a260c7dd-2a24-45d4-b526-0dd9e33887d4", "SuperAdmin@U3A.com.au", true, false, null, "SUPERADMIN@U3A.COM.AU", "SUPERADMIN@U3A.COM.AU", "AQAAAAEAACcQAAAAEP9LgnLIs/9/AJZmr94S21hx5SfjTkR+LBO7EBwsC4HaY79k2+S9JJrY+T+oX1xT1g==", null, false, "2b651cb3-a424-4eb6-9a40-e44d48082857", false, "SuperAdmin@U3A.com.au" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0", "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "993C6378-61D4-4734-ADAE-D725F2A8CD94", "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "D4BA57AA-A379-4EE8-940E-57315575978A", "8e445865-a24d-4543-a6c6-9443d048cdb9" }
                });
        }
    }
}
