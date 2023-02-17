using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    /// <inheritdoc />
    public partial class U3AMembershipFees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinancialToMembershipFeePercent",
                table: "SystemSettings");

            migrationBuilder.AlterColumn<decimal>(
                name: "MembershipFee",
                table: "SystemSettings",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                comment: "Full Year Membership Fee",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldComment: "Yearly Membership Fee");

            migrationBuilder.AddColumn<decimal>(
                name: "MembershipFeeTerm2",
                table: "SystemSettings",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                comment: "Term 2 Membership Fee");

            migrationBuilder.AddColumn<decimal>(
                name: "MembershipFeeTerm3",
                table: "SystemSettings",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                comment: "Term 3 Year Membership Fee");

            migrationBuilder.AddColumn<decimal>(
                name: "MembershipFeeTerm4",
                table: "SystemSettings",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                comment: "Term 4 Year Membership Fee");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MembershipFeeTerm2",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "MembershipFeeTerm3",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "MembershipFeeTerm4",
                table: "SystemSettings");

            migrationBuilder.AlterColumn<decimal>(
                name: "MembershipFee",
                table: "SystemSettings",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                comment: "Yearly Membership Fee",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldComment: "Full Year Membership Fee");

            migrationBuilder.AddColumn<decimal>(
                name: "FinancialToMembershipFeePercent",
                table: "SystemSettings",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                comment: "The percent of Membership fess required to be paid before member is deemed financial and enrolement allowed.");
        }
    }
}
