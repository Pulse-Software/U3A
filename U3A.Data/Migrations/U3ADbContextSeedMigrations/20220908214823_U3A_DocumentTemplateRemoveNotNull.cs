using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    public partial class U3A_DocumentTemplateRemoveNotNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentTemplate_DocumentType_DocumentTypeID",
                table: "DocumentTemplate");

            migrationBuilder.AlterColumn<string>(
                name: "FromEmailAddress",
                table: "DocumentTemplate",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FromDisplayName",
                table: "DocumentTemplate",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "DocumentTypeID",
                table: "DocumentTemplate",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "8a66e81d-ee2e-4670-81bd-249b224a68eb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "eed1167d-a03e-4c63-9525-00866b6270ae");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "fa2f561c-ef62-4d03-aae2-341cbda9f1a1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "4df236a8-022f-430f-8568-92320430a1ec");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70494634-D7BE-4BE4-8106-031AAE2BC6DC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "070fbf18-ed04-4406-9801-ba3d8699923f", "AQAAAAEAACcQAAAAEL2JZi3l74FHIMP0XevsmtlkDAqZIXXAO7z7VLAG2QwjGEK1NVQqkwt7Kec1Sesx0A==", "82172567-f591-445e-b6d3-bd3a221e49f0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753F8F36-D2FF-438E-B5D1-7FF79E4628BD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7fe2a849-76b2-410d-b1c5-96d508d62912", "AQAAAAEAACcQAAAAEBbSC5W8m1+KNVMpU1B3vN5MwRY11whXR4/SahEQ9srBJPtyW1wSlc8VfNTDhHDr9g==", "76269935-8e44-4339-abc5-a042b35559e1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39f68e71-f0f4-42d5-a526-672c97745cbe", "AQAAAAEAACcQAAAAEGd5ugzcUfwU8ZiqDRc06r4eBPgP1Ya/hWdz7pYVpXq7UZwd2LQTXQScwBLMBeuyeA==", "881d9fa2-ed4a-43d5-ada0-6b86e596d75d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C5E9887D-9C4B-40F5-AB46-2232776005C5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d3cfc21-3f42-4dc9-a52a-02e5f383cfec", "AQAAAAEAACcQAAAAEKiXaTXlhWORz7YmqfipUGilDLtMYllH9VY9qXpA6IojAje8b+S2EMcnltRPD1zMZg==", "4faf6eb6-4f15-4d16-8fc0-879989f846e1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E7B47704-8DA0-4657-B42C-849C1C22A6D2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c46882fe-250b-43fb-9e6e-0cd95fedc505", "AQAAAAEAACcQAAAAEE0NzxcIS6NGyPGl8lhR++99IXCpKJEkBZC8AlUPEMtRCFW4zuD5j+cYFZ9pe+KYaw==", "69f7309b-4265-43cb-9293-bb3db85f3f16" });

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentTemplate_DocumentType_DocumentTypeID",
                table: "DocumentTemplate",
                column: "DocumentTypeID",
                principalTable: "DocumentType",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentTemplate_DocumentType_DocumentTypeID",
                table: "DocumentTemplate");

            migrationBuilder.AlterColumn<string>(
                name: "FromEmailAddress",
                table: "DocumentTemplate",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FromDisplayName",
                table: "DocumentTemplate",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DocumentTypeID",
                table: "DocumentTemplate",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "5a637265-d83b-40e3-a3ec-c2188bb7358b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "b6b1eb70-fc5a-435d-b02f-8e7355e493c5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "5c7fb366-bdf9-4f9f-aa11-2609596149c2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "5760b207-157b-4a76-a098-6ff566d01bc8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70494634-D7BE-4BE4-8106-031AAE2BC6DC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b6af0e50-c234-4821-8347-a9a132cae245", "AQAAAAEAACcQAAAAEDcA6kfLD//TApKD5wym04rdOltsjY+Z9biJqtls3cmlr7a5iWQk6LOj3JbNMHn3Tw==", "2c200dbc-c335-4ec5-aa72-e53bd5ef498d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753F8F36-D2FF-438E-B5D1-7FF79E4628BD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "deab335e-a31f-4922-887f-0bd3809fa326", "AQAAAAEAACcQAAAAEHhHWMuf5De3PenH2NA1SLphNEqOnEVscqO2xm1flEbU2X95QtRdWFkOI3Iia6qp1A==", "18c7a191-94b1-42ac-bcfc-052ec3d1a8fc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d95df8d7-6c55-4d75-85d6-2989dd36fb1a", "AQAAAAEAACcQAAAAEH36lWIuJs4mu5d2XBAW0srJ2XCNS0lFpSJSE7oS7LatrP64XFYOn03GoLN8FCTxMQ==", "a1f78fb2-d68f-4a49-9b5a-5963814b64b7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C5E9887D-9C4B-40F5-AB46-2232776005C5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12426115-e0a3-4fed-83aa-3128e126113d", "AQAAAAEAACcQAAAAEGz6L8hRfLAWHPC6/fqKClTwusZAudrPvNq0rOnh/LTD7cExU/tvascAAiaMbpp21Q==", "0df9208a-2275-48b8-b74f-c403d95efdc3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E7B47704-8DA0-4657-B42C-849C1C22A6D2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dee5c685-f4e5-41bb-a7ed-5453ac6739a1", "AQAAAAEAACcQAAAAEH6uqx7iW9bToEIp91bAWy/pJ/x6jih4lE3pj/67bnXbibLw3Lzr8XvVsGGUtghHpA==", "a23fabf2-16f3-4782-98e1-4a033b6c3854" });

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentTemplate_DocumentType_DocumentTypeID",
                table: "DocumentTemplate",
                column: "DocumentTypeID",
                principalTable: "DocumentType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
