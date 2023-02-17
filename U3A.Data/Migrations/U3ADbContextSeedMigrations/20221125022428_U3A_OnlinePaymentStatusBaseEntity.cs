using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    /// <inheritdoc />
    public partial class U3AOnlinePaymentStatusBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OnlinePaymentStatus_PersonID_Status",
                table: "OnlinePaymentStatus");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "OnlinePaymentStatus",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "OnlinePaymentStatus",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "OnlinePaymentStatus",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OnlinePaymentStatus_PersonID_CreatedOn",
                table: "OnlinePaymentStatus",
                columns: new[] { "PersonID", "CreatedOn" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OnlinePaymentStatus_PersonID_CreatedOn",
                table: "OnlinePaymentStatus");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "OnlinePaymentStatus");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "OnlinePaymentStatus");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "OnlinePaymentStatus",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_OnlinePaymentStatus_PersonID_Status",
                table: "OnlinePaymentStatus",
                columns: new[] { "PersonID", "Status" });
        }
    }
}
