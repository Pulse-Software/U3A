using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    public partial class U3A_AddedDateEnrolled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnrolled",
                table: "Enrolment",
                type: "datetime2",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateEnrolled",
                table: "Enrolment");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "b67dc99b-1a0c-4b81-a718-c0d0edff864b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                column: "ConcurrencyStamp",
                value: "6194fe6c-bc03-45ab-8fc9-a5122e71450b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                column: "ConcurrencyStamp",
                value: "28f41a02-3eb2-410b-8ae5-2e9cc89acdc7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4BA57AA-A379-4EE8-940E-57315575978A",
                column: "ConcurrencyStamp",
                value: "d7b0f8a4-c048-42dc-9a4d-3c7722a7411c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70494634-D7BE-4BE4-8106-031AAE2BC6DC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60b1d713-13da-4dce-b395-ddfd59e9b5b5", "AQAAAAEAACcQAAAAEIFd9ZJ3lksPMP80MZfjFr7kyOKtcUQdI9JII7aoGUELcvsbhoOfgjQJVIAnYhnpsA==", "cc88c17c-4844-49ae-a625-ddf32e65ea09" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753F8F36-D2FF-438E-B5D1-7FF79E4628BD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75eb5f55-14ed-4f9f-ad07-e7ef144ed5ad", "AQAAAAEAACcQAAAAEF01aN7jPvPKX3Xh17yK7MSjgY+Mf5j2zjsL+wVA8pZh25lbv7z67q3csws0YktvGw==", "88e4ac97-e73b-400f-bbba-c9c604abe876" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3fa64b5a-d462-4ea7-9d3f-64be76c89874", "AQAAAAEAACcQAAAAELxT30A3ce1i/m6CEkwDx7+/uk7Or0R+irbf8pRzsbXFZ2pgzo6p9GHrgU0nNBQGcg==", "2105f348-653d-4032-ab05-a13a98dc6d41" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C5E9887D-9C4B-40F5-AB46-2232776005C5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ca55301-7f84-4816-af96-82a623ca0f77", "AQAAAAEAACcQAAAAEK2YbWDFlkT1z6fn8zxsOcLfftNVvkIE7KRUYN5tiLDLecnVfRvNOAjY2+cBufX4Ow==", "0b3a1543-31f9-46b4-9745-b8c607659d8b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E7B47704-8DA0-4657-B42C-849C1C22A6D2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0404daa-e328-4d66-9c4e-c38d19befed3", "AQAAAAEAACcQAAAAEI5LqpJcj3ehKNm8CwsiSHeyHXcKD3sfj8SxELaJ2X8Tui6U4v+dpXX13VZOHHQ2Eg==", "5cf0091c-a693-48c4-8c1e-de2ec3b55ba1" });
        }
    }
}
