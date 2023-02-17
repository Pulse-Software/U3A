using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    public partial class U3A_DocumentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailTemplate");

            migrationBuilder.CreateTable(
                name: "DocumentType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEmail = table.Column<bool>(type: "bit", nullable: false),
                    IsSMS = table.Column<bool>(type: "bit", nullable: false),
                    IsPostal = table.Column<bool>(type: "bit", nullable: false),
                    IsEnrolmentSubDocument = table.Column<bool>(type: "bit", nullable: false),
                    IsREceiptSubDocument = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTemplate",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentID = table.Column<int>(type: "int", nullable: false),
                    DocumentTypeID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FromEmailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FromDisplayName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    HTML = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTemplate", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DocumentTemplate_DocumentType_DocumentTypeID",
                        column: x => x.DocumentTypeID,
                        principalTable: "DocumentType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "2c8fe1e6-296f-465d-959d-28df5137593c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "68559f96-cc51-4edd-9bd1-5fed5bbee397");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "b7fa34fe-934f-427d-bc1e-7a56116fa233");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "f1017795-524a-4162-be90-254ea752e9b0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70494634-D7BE-4BE4-8106-031AAE2BC6DC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c754ad7b-90d7-411f-8327-ec773cfc311e", "AQAAAAEAACcQAAAAEEmENoPq9Pcfg42qcv3phKWgpKtxl4XDOnH1VhZvyZ24rF5G+4PMLoElbeMX5E0sxg==", "5e303100-7790-479f-ad20-1c2c7f2f3dd6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753F8F36-D2FF-438E-B5D1-7FF79E4628BD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad56d999-a73e-4115-aee6-3a55949b1ca6", "AQAAAAEAACcQAAAAECSNruCkHUGLrj1YMjbftIcgMvn2ydLS/FHkFyl3vWA7iz1ChHcbU02fM0bztaLC2A==", "87ff8471-4f80-4248-940a-e5bdc2c72c41" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85cd1667-880b-4ed6-ad20-df41627eacd9", "AQAAAAEAACcQAAAAEGvn95lY9siuRgPdrR7QYUZY1YKTSjrh60siWI7Yr+FYhCdmAVthxA0t+D1qUZXYpQ==", "181b0a48-f021-4999-8a4c-38e13e5c5932" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C5E9887D-9C4B-40F5-AB46-2232776005C5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3597fb52-cb71-4476-bd15-964e5f94f402", "AQAAAAEAACcQAAAAEAIR+LArVrttVPCOkFvO34xbYpb/GFeLRs2tQzNmYmDzRNX+WgAuxfBQ6qgoikC09g==", "8b907f96-8a7a-4a46-a8e5-2c8ad18309ec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E7B47704-8DA0-4657-B42C-849C1C22A6D2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2b7e78e-cfc6-48b9-a1e1-4bc7e2696c8c", "AQAAAAEAACcQAAAAEGRzg+rUAAm5LldTQIc88sd+Tt1sHjam5L1KZbnOuT3YR8MwgYMoRE8gyNk1pBPnBw==", "81676ee4-7920-43e6-87db-ee90c83ccb1e" });

            migrationBuilder.InsertData(
                table: "DocumentType",
                columns: new[] { "ID", "IsEmail", "IsEnrolmentSubDocument", "IsPostal", "IsREceiptSubDocument", "IsSMS", "Name" },
                values: new object[,]
                {
                    { 0, true, false, false, false, false, "Email" },
                    { 1, false, false, true, false, false, "Postal" },
                    { 2, false, false, false, false, true, "SMS" },
                    { 3, false, true, false, false, false, "EnrolmentSubdoc" },
                    { 4, false, false, false, true, false, "ReceiptSubdoc" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTemplate_DocumentTypeID",
                table: "DocumentTemplate",
                column: "DocumentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTemplate_Name",
                table: "DocumentTemplate",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentTemplate");

            migrationBuilder.DropTable(
                name: "DocumentType");

            migrationBuilder.CreateTable(
                name: "EmailTemplate",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FromDisplayName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FromEmailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HTML = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplate", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "a5ce351a-91b4-4efd-bcb0-ef201f3e86a0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "388a34fa-b02b-4f01-9c0c-df1bc481b2bf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "981c6603-3f51-4248-8544-efecb1ce6c97");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "84f3f994-d84e-4153-9b23-079bb15bafff");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70494634-D7BE-4BE4-8106-031AAE2BC6DC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f9a2743-3faf-453d-824e-c7deb9020c90", "AQAAAAEAACcQAAAAEAh/R6BGP5n10kCi3sfyAd98MBLvH6Dj8A+6NcsJmJeN4ZBG0J2cIr9CagOzBqHRYA==", "b3a99d43-a7ab-4544-920b-3f6125d98eb7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753F8F36-D2FF-438E-B5D1-7FF79E4628BD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96578c46-e7b8-46b9-80a2-7e0359be5bb0", "AQAAAAEAACcQAAAAEGscZ+A86JZOGi0DCa1yz91GlcQ+3sDdAJG4G7wgPBOBMRUMoR3KhfV+PnhQYbbDvA==", "d0febdb2-e532-436b-bc2e-46df2c73c03d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e1953f17-8fee-4c66-8ad0-c76d17990369", "AQAAAAEAACcQAAAAEKJpybh6ckm+j3XthS2Gja3bqVJH037pVCFVYUk+7AHoKN3Sn94TfbfNwPuQoCcyig==", "d6d2fcd1-d734-478e-ae52-2abf71b0c10a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C5E9887D-9C4B-40F5-AB46-2232776005C5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "624978bc-98c0-488e-ad8b-2e2f07994817", "AQAAAAEAACcQAAAAEDRWaecp0n6StAuzQBj6tri5NuhuIPVAwryLAmthW+8yqR8Y5j0uurJIzPdChfw8MA==", "2e65b48e-8b7a-4c55-a8f4-8018b463463e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E7B47704-8DA0-4657-B42C-849C1C22A6D2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a9251f3c-af38-429d-bd48-ccce3ccea154", "AQAAAAEAACcQAAAAEOhhdn/Xvo4NLjXmHA/0z2JZocOAimGFg+osCf4Vl9Zdrsjfq+/jEbTUqSLMAy65DQ==", "a4cfd4b6-811d-49ed-86e1-4ce82ee313ef" });

            migrationBuilder.CreateIndex(
                name: "IX_EmailTemplate_Name",
                table: "EmailTemplate",
                column: "Name",
                unique: true);
        }
    }
}
