using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    public partial class U3A_DocumentTemplateDocumentTypeID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentID",
                table: "DocumentTemplate");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocumentID",
                table: "DocumentTemplate",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "82f6cd28-bd42-400c-a307-bebfce6e2e38");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "28bc09d0-9c7e-41fb-b683-2d7aab1447a8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "3b38003a-7761-42bd-b537-07badda92a80");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "8fec3347-ef12-4d38-9918-98cdc4d15877");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70494634-D7BE-4BE4-8106-031AAE2BC6DC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "112c47fa-9494-4102-ba1b-dc7896508fc8", "AQAAAAEAACcQAAAAEHU3d038qA11iv2AFMAzHsjJqLz9a1TZKU9BmxIRg95I834vLCtrTuPXlOefnwMQNQ==", "bd3eb18e-0e19-4c94-8e26-49b901f04464" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753F8F36-D2FF-438E-B5D1-7FF79E4628BD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de99497c-6fc4-40cb-bbad-829305109e62", "AQAAAAEAACcQAAAAEHME9VwOQUOd0CvdY3D9ESiNvpqXT13po2Dzm9cjSmqXQn+zTe5Agsu3K4nBx/f77g==", "dece1797-4312-41b4-975f-b2433eee3e4a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46fed95b-6ef5-4662-a2c1-63d5e32f4660", "AQAAAAEAACcQAAAAELVRpxLG049IycPPHuyn1RaOPgDAPqHBE8K9qdrA1y7MtFXfP6UoDhkWL1VnyiGJOA==", "df864240-e7f0-4821-90dc-ca49b813f683" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C5E9887D-9C4B-40F5-AB46-2232776005C5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83b5c0ec-1418-4598-bca6-0a39981243ae", "AQAAAAEAACcQAAAAEMzTr5Na5z4GpCEaVSzn7aHH4gXg8h6t+xbAWciK1aAQAWyk+CkOZdKsAPbYkN/xgA==", "913e935f-850c-475d-8511-3ece4ddc9c0f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E7B47704-8DA0-4657-B42C-849C1C22A6D2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8fa921db-b2b1-407f-aa67-c5dd96b0ad43", "AQAAAAEAACcQAAAAEExY32i+pSa2mlR5wqEHLCy3aAEPfrl/DtjVmeadV+e7Ee4X0lc7cxso/mdxABM8Fw==", "fabe1cc3-e78e-45af-9216-abcad62651ac" });
        }
    }
}
