using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    /// <inheritdoc />
    public partial class U3AAdditionalLeaders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Leader2ID",
                table: "Class",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Leader3ID",
                table: "Class",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Class_Leader2ID",
                table: "Class",
                column: "Leader2ID");

            migrationBuilder.CreateIndex(
                name: "IX_Class_Leader3ID",
                table: "Class",
                column: "Leader3ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Class_Person_Leader2ID",
                table: "Class",
                column: "Leader2ID",
                principalTable: "Person",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Class_Person_Leader3ID",
                table: "Class",
                column: "Leader3ID",
                principalTable: "Person",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Class_Person_Leader2ID",
                table: "Class");

            migrationBuilder.DropForeignKey(
                name: "FK_Class_Person_Leader3ID",
                table: "Class");

            migrationBuilder.DropIndex(
                name: "IX_Class_Leader2ID",
                table: "Class");

            migrationBuilder.DropIndex(
                name: "IX_Class_Leader3ID",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "Leader2ID",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "Leader3ID",
                table: "Class");
        }
    }
}
