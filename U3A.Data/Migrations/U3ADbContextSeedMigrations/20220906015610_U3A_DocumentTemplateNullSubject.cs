using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    public partial class U3A_DocumentTemplateNullSubject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "DocumentTemplate",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "DocumentTemplate",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

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
        }
    }
}
