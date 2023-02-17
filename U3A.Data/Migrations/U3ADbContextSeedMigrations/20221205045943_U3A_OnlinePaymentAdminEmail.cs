using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    /// <inheritdoc />
    public partial class U3AOnlinePaymentAdminEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdminEmail",
                table: "OnlinePaymentStatus",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OnlinePaymentStatus_AdminEmail_CreatedOn",
                table: "OnlinePaymentStatus",
                columns: new[] { "AdminEmail", "CreatedOn" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OnlinePaymentStatus_AdminEmail_CreatedOn",
                table: "OnlinePaymentStatus");

            migrationBuilder.DropColumn(
                name: "AdminEmail",
                table: "OnlinePaymentStatus");
        }
    }
}
