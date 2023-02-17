using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    public partial class U3A_Receipt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Receipt",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Identifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FinancialTo = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipt", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Receipt_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptDataImport",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Identifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FinancialTo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptDataImport", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ReceiptDataImport_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "ID");
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "fb327b01-2af7-4464-a813-7ff35a48b5c3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "30b17a86-8b77-4b72-87d1-331407c1fbe3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "926f9eb8-bc84-468c-992c-b55fc0b0dd18");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "0f164173-381f-4fff-813e-c3dd5e6b2ebb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "63d3147e-838b-4ba2-a761-63576e38804f", "AQAAAAEAACcQAAAAEBAmnECsMD1pWgLZ1b5uLIH1xOaO145QeA68J0004+YAuRy0KMfYhk3Q5+M0Fap+0Q==", "2cf27827-4226-42a9-a906-8493509afe45" });

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_PersonID",
                table: "Receipt",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptDataImport_PersonID",
                table: "ReceiptDataImport",
                column: "PersonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Receipt");

            migrationBuilder.DropTable(
                name: "ReceiptDataImport");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "f98f514b-2177-47a0-9615-09bd87d5d194");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "aee330dd-4e39-4644-bfe6-c51cf50cae8b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "ceedca3f-2ca8-4683-8f96-edf80af686f2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "f58eb73c-b436-4ed2-b4da-7264ae631e5b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f1718a9f-06f3-4f41-bc6a-830358fbacad", "AQAAAAEAACcQAAAAEPd0m/5fbUN6mWMPLw3cexgWmBk9eonw2UaqgGG0son9ca8BWOCkwbIgnHbV/ZX4qQ==", "2e28ac41-39e5-476a-bb09-3d290f287c3f" });
        }
    }
}
