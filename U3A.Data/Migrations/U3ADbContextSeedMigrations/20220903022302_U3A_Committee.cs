using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    public partial class U3A_Committee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVoluntaryActivity",
                table: "CourseType");

            migrationBuilder.DropColumn(
                name: "IsVountary",
                table: "AttendanceHistory");

            migrationBuilder.AddColumn<string>(
                name: "CommitteePositions",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VolunteerActivities",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Committee",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PersonID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Committee", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Committee_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "ID");
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "82882251-9fdf-46bf-bee6-1c5454cdb49b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "f06bb9d7-446e-415a-871e-12f46c1bd428");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "a0546e2c-035d-4c90-9042-fe9371a42c97");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "3422237c-b3b1-4d46-bed5-c2c880b5817a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70494634-D7BE-4BE4-8106-031AAE2BC6DC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60261de8-08cf-43d7-97d1-264bbe9674a3", "AQAAAAEAACcQAAAAEJQ1CC7sHRi1u7S0pAxw5OlpvgrpNRjQ1trOp5c6CNFI60vhuD4tuxWAV6/fEKfnUQ==", "a1b0ddcd-cfc5-4642-a453-d0d194ba6936" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753F8F36-D2FF-438E-B5D1-7FF79E4628BD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f6e657a-23d3-4702-b998-30e7e3e54f43", "AQAAAAEAACcQAAAAEItCxO6Q/tkjGxFH3NC6IlmDNEm6JojOX7fUnyLGr9bzenqQjc6pqHiY4ZtfnVVhWw==", "0f5f6b5e-abbf-4e6d-99bb-1eaedd2f186b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8454b7b-6a51-4ac8-b75f-d8a72a31a6fc", "AQAAAAEAACcQAAAAEF3nu9SyID7yYA2AfQRmis2YER6iPvDThyMNBGbgNvMppHbv3/JS921rhXdbZVM05A==", "9a6af015-a2ee-4c1d-9ec9-4e38cafd3117" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C5E9887D-9C4B-40F5-AB46-2232776005C5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0bd01588-ee35-43d3-b376-9a8484abd716", "AQAAAAEAACcQAAAAELdEmxT/fNuEmTcv7icUhvNAszRPGu804URpbWQj0t3DjpMP1YzYM+aa3LsTyNNGgQ==", "05675c39-4ef9-45d6-b2ba-2f8115ab7542" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E7B47704-8DA0-4657-B42C-849C1C22A6D2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "28364fcd-8f49-42b5-92e7-4c2a94e2c237", "AQAAAAEAACcQAAAAEH49deQ7uI0ZzFpRxo3DkKQLL3fHY7PRFhy38AXlrQFseSfX0B28OTb/ZWe/No5+1Q==", "5f9bbf89-fd8f-4445-80c2-f651d6b4caea" });

            migrationBuilder.CreateIndex(
                name: "IX_Committee_PersonID",
                table: "Committee",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Committee_Position_PersonID",
                table: "Committee",
                columns: new[] { "Position", "PersonID" },
                unique: true,
                filter: "[PersonID] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Committee");

            migrationBuilder.DropColumn(
                name: "CommitteePositions",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "VolunteerActivities",
                table: "SystemSettings");

            migrationBuilder.AddColumn<bool>(
                name: "IsVoluntaryActivity",
                table: "CourseType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVountary",
                table: "AttendanceHistory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "025942d4-57b4-45a8-9099-bc49f50bcf10");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "20a54808-0571-4379-96ba-7a56ecb6de2f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "656a0651-2fe0-49b4-ac1d-0ae7d3b9bbb7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "a95d4e0f-5ba9-45be-bec4-76fe6ea79025");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70494634-D7BE-4BE4-8106-031AAE2BC6DC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c240895-1d79-497a-9b20-f45ac1204bda", "AQAAAAEAACcQAAAAEINf0O5prmxBlir7jutFKfuaZwg+FQW4q/elnUSpJ619n7Hz4Wx14pxLVTlz2p+YIQ==", "aac4ee2a-6ee2-4070-820e-2b4012e6a80b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753F8F36-D2FF-438E-B5D1-7FF79E4628BD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6163f2ab-1481-4cfa-8db9-31929b4c7e7e", "AQAAAAEAACcQAAAAELr6nsi+qpUZ43BqvysEaNk/GMe5XtV+Xoi49yWPGbtr0MmEHP9+WqrSavAfPPGAIQ==", "65d61306-0142-4475-8ced-30d381b7a00c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9def96d-29c9-40e6-b49f-a50b9c26724e", "AQAAAAEAACcQAAAAEMCtVIosCl6NXrYwtIoEipOWkHFdqjeVwnRawmHSNrJrBjpqlADjTC3Dy7PHZvZrVQ==", "386f54e4-bcb8-4be0-bfa9-96f8602818d9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C5E9887D-9C4B-40F5-AB46-2232776005C5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2fca7756-63dd-4175-920d-ed23cf8c8daa", "AQAAAAEAACcQAAAAEON+qvdiKY0KW+hNijYHDKoWBGh4hbekaolC64ciKeL83b19ieUIKc20Whik9qLAmQ==", "71b9020b-9994-4d88-a99a-54d002a5a1ab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E7B47704-8DA0-4657-B42C-849C1C22A6D2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a1cab68-2470-45b7-b4cc-616219391af4", "AQAAAAEAACcQAAAAEDWXWDusSaNOWIZ6dlAjiJfjtHMcdoDQLNpeDeMSMYFdtxWtfVR4Yno0T8mKpp2SpA==", "518bc317-187d-4da1-9294-7e7211da42d0" });
        }
    }
}
