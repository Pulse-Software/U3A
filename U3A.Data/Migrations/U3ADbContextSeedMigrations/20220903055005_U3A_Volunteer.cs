using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    public partial class U3A_Volunteer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Volunteer",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Activity = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PersonID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Volunteer_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Volunteer_Activity_PersonID",
                table: "Volunteer",
                columns: new[] { "Activity", "PersonID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Volunteer_PersonID",
                table: "Volunteer",
                column: "PersonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Volunteer");

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
        }
    }
}
