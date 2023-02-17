using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U3A.Database.Migrations.U3ADbContextSeedMigrations
{
    public partial class U3A_Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttendClassStatus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendClassStatus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CourseParticpationType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseParticpationType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CourseType",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discontinued = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Occurrence",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occurrence", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConversionID = table.Column<int>(type: "int", nullable: false),
                    Discontinued = table.Column<bool>(type: "bit", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Postcode = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateJoined = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCeased = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    HomePhone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    ICEContact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ICEPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VaxCertificateViewed = table.Column<bool>(type: "bit", nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsLifeMember = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PublicHoliday",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicHoliday", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SystemSettings",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    U3AGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OfficeLocation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PostalAddress = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ABN = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    MembershipFee = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "Yearly Membership Fee"),
                    MailSurcharge = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "Yearly surcharge if requiring mail correspondance"),
                    RequireVaxCertificate = table.Column<bool>(type: "bit", nullable: false),
                    CurrentTermID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemSettings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Term",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    TermNumber = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false, comment: "The number of weeks a Term will last"),
                    EnrolmentStarts = table.Column<int>(type: "int", nullable: false, comment: "The number of weeks prior to StartDate that enrolment begins"),
                    EnrolmentEnds = table.Column<int>(type: "int", nullable: false, comment: "The number of weeks prior to StartDate that enrolment ends")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Term", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Venue",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discontinued = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaxNumber = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venue", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WeekDay",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDay = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekDay", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConversionID = table.Column<int>(type: "int", nullable: false),
                    Discontinued = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseParticipationTypeID = table.Column<int>(type: "int", nullable: true),
                    CourseFee = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "Once-only course enrolment fee"),
                    CourseFeeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassFee = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "Optional fee per class (eg. tea and coffee)"),
                    ClassFeeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "The time in hours each class is expeted to take"),
                    RequiredStudents = table.Column<int>(type: "int", nullable: false, comment: "The required number of students per class"),
                    MaximumStudents = table.Column<int>(type: "int", nullable: false, comment: "The maximum number of students per class"),
                    CourseTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Course_CourseParticpationType_CourseParticipationTypeID",
                        column: x => x.CourseParticipationTypeID,
                        principalTable: "CourseParticpationType",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Course_CourseType_CourseTypeID",
                        column: x => x.CourseTypeID,
                        principalTable: "CourseType",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfferedTerm1 = table.Column<bool>(type: "bit", nullable: false, comment: "Is the course offered in term 1?"),
                    OfferedTerm2 = table.Column<bool>(type: "bit", nullable: false, comment: "Is the course offered in term 2?"),
                    OfferedTerm3 = table.Column<bool>(type: "bit", nullable: false, comment: "Is the course offered in term 3?"),
                    OfferedTerm4 = table.Column<bool>(type: "bit", nullable: false, comment: "Is the course offered in term 4?"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OccurrenceID = table.Column<int>(type: "int", nullable: true),
                    Recurrence = table.Column<int>(type: "int", nullable: true),
                    OnDayID = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CourseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VenueID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeaderID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Class_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Class_Occurrence_OccurrenceID",
                        column: x => x.OccurrenceID,
                        principalTable: "Occurrence",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Class_Person_LeaderID",
                        column: x => x.LeaderID,
                        principalTable: "Person",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Class_Venue_VenueID",
                        column: x => x.VenueID,
                        principalTable: "Venue",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Class_WeekDay_OnDayID",
                        column: x => x.OnDayID,
                        principalTable: "WeekDay",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttendClass",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsAdHoc = table.Column<bool>(type: "bit", nullable: false),
                    TermID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttendClassStatusID = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateProcessed = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendClass", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AttendClass_AttendClassStatus_AttendClassStatusID",
                        column: x => x.AttendClassStatusID,
                        principalTable: "AttendClassStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendClass_Class_ClassID",
                        column: x => x.ClassID,
                        principalTable: "Class",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_AttendClass_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendClass_Term_TermID",
                        column: x => x.TermID,
                        principalTable: "Term",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CancelClass",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancelClass", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CancelClass_Class_ClassID",
                        column: x => x.ClassID,
                        principalTable: "Class",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrolment",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TermID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PersonID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsWaitlisted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrolment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Enrolment_Class_ClassID",
                        column: x => x.ClassID,
                        principalTable: "Class",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Enrolment_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrolment_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrolment_Term_TermID",
                        column: x => x.TermID,
                        principalTable: "Term",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "5e99f08e-4555-4998-834b-24786d24fc9a", "Security Administrator", "SECURITY ADMINISTRATOR" },
                    { "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0", "c31b46bb-928f-411c-9f18-c84f62106c1b", "Membership", "MEMBERSHIP" },
                    { "993C6378-61D4-4734-ADAE-D725F2A8CD94", "286cf813-1bc6-4385-a545-cc6ee2de93f7", "System Administrator", "SYSTEM ADMINISTRATOR" },
                    { "D4BA57AA-A379-4EE8-940E-57315575978A", "7cf128ad-45a3-499b-bf25-ca21678ce6eb", "Accounting", "ACCOUNTING" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "70494634-D7BE-4BE4-8106-031AAE2BC6DC", 0, "beb79513-2257-489f-9cb5-f008d61d55ee", "SysAdmin@U3A.com.au", true, false, null, "SYSADMIN@U3A.COM.AU", "SYSADMIN@U3A.COM.AU", "AQAAAAEAACcQAAAAEJ0s4p+MFiXURnb61SEH926OUy28Y5YrYqKjNCO/W5vSDTq1Ryd3Y5Cq9iotpROzfQ==", null, false, "075e13aa-edb9-43ba-99b7-c248848faed3", false, "SysAdmin@U3A.com.au" },
                    { "753F8F36-D2FF-438E-B5D1-7FF79E4628BD", 0, "34905761-59fd-4408-a261-20dfeaacd7d1", "security@U3A.com.au", true, false, null, "SECURITY@U3A.COM.AU", "SECURITY@U3A.COM.AU", "AQAAAAEAACcQAAAAEOe+NeYnOeM6CIUvG3rLuGXqrRsAWJ7BoXgKyvirFlq38T9v7lqCnEdkMEUOWSe+UA==", null, false, "1e02c8a0-ff0b-4b59-9126-385782db6632", false, "security@U3A.com.au" },
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, "a953037d-7a28-4857-abd7-136ac482ff88", "SuperAdmin@U3A.com.au", true, false, null, "SUPERADMIN@U3A.COM.AU", "SUPERADMIN@U3A.COM.AU", "AQAAAAEAACcQAAAAEGO9hnvP8x8fJPlDhs2gGYMhl9koCigXL2PPHidC9luB5nbMxW8fCFahxG/ZCA1OSw==", null, false, "d19a58d8-c599-4d04-b99b-06b42261f032", false, "SuperAdmin@U3A.com.au" },
                    { "C5E9887D-9C4B-40F5-AB46-2232776005C5", 0, "a59d689a-6000-4448-9560-1677fdf03a7d", "membership@U3A.com.au", true, false, null, "MEMBERSHIP@U3A.COM.AU", "MEMBERSHIP@U3A.COM.AU", "AQAAAAEAACcQAAAAEF5rf+n4Z9u7Fzv9PENdLMBwEmNkHidubJciJdNwx/0P8Jpa3E7j591z1e0OKw++fg==", null, false, "912b7ae5-442b-4ff3-a276-b479d3f4f1d5", false, "membership@U3A.com.au" },
                    { "E7B47704-8DA0-4657-B42C-849C1C22A6D2", 0, "eadf1573-36ec-4888-8f5e-bfe0564de98c", "accounts@U3A.com.au", true, false, null, "ACCOUNTS@U3A.COM.AU", "ACCOUNTS@U3A.COM.AU", "AQAAAAEAACcQAAAAEGI+D+snqXRY4uerus0kU6ypVzUHoLHJo7XNmQ0Iastb7pdBzCdt9zvnMUGVR3SeCw==", null, false, "15645d31-2d90-4ad3-81a0-abfbefbfc555", false, "accounts@U3A.com.au" }
                });

            migrationBuilder.InsertData(
                table: "AttendClassStatus",
                columns: new[] { "ID", "Status" },
                values: new object[,]
                {
                    { 0, "Present" },
                    { 1, "Absent without apology" },
                    { 2, "Absent with apology" }
                });

            migrationBuilder.InsertData(
                table: "CourseParticpationType",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 0, "Same participants in all classes" },
                    { 1, "Different participants in each class" }
                });

            migrationBuilder.InsertData(
                table: "Occurrence",
                columns: new[] { "ID", "Name", "ShortName" },
                values: new object[,]
                {
                    { 0, "Once Only", "Once" },
                    { 1, "Daily", "Daily" },
                    { 2, "Weekly", "Weekly" },
                    { 3, "Fortnightly", "F'nightly" },
                    { 4, "1st Week of Month", "Week 1" },
                    { 5, "2nd Week of Month", "Week 2" },
                    { 6, "3rd Week of Month", "Week 3" },
                    { 7, "Last Week of Month", "Last Week" }
                });

            migrationBuilder.InsertData(
                table: "WeekDay",
                columns: new[] { "ID", "Day", "ShortDay" },
                values: new object[,]
                {
                    { 0, "Sunday", "Sun" },
                    { 1, "Monday", "Mon" },
                    { 2, "Tuesday", "Tue" },
                    { 3, "Wednesday", "Wed" },
                    { 4, "Thursday", "Thu" },
                    { 5, "Friday", "Fri" },
                    { 6, "Saturday", "Sat" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "993C6378-61D4-4734-ADAE-D725F2A8CD94", "70494634-D7BE-4BE4-8106-031AAE2BC6DC" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "753F8F36-D2FF-438E-B5D1-7FF79E4628BD" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0", "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "993C6378-61D4-4734-ADAE-D725F2A8CD94", "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "D4BA57AA-A379-4EE8-940E-57315575978A", "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0", "C5E9887D-9C4B-40F5-AB46-2232776005C5" },
                    { "D4BA57AA-A379-4EE8-940E-57315575978A", "E7B47704-8DA0-4657-B42C-849C1C22A6D2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AttendClass_AttendClassStatusID",
                table: "AttendClass",
                column: "AttendClassStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_AttendClass_ClassID",
                table: "AttendClass",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_AttendClass_PersonID",
                table: "AttendClass",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_AttendClass_TermID_ClassID_Date",
                table: "AttendClass",
                columns: new[] { "TermID", "ClassID", "Date" });

            migrationBuilder.CreateIndex(
                name: "IX_CancelClass_ClassID",
                table: "CancelClass",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Class_CourseID",
                table: "Class",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Class_LeaderID",
                table: "Class",
                column: "LeaderID");

            migrationBuilder.CreateIndex(
                name: "IX_Class_OccurrenceID",
                table: "Class",
                column: "OccurrenceID");

            migrationBuilder.CreateIndex(
                name: "IX_Class_OnDayID",
                table: "Class",
                column: "OnDayID");

            migrationBuilder.CreateIndex(
                name: "IX_Class_VenueID",
                table: "Class",
                column: "VenueID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseParticipationTypeID",
                table: "Course",
                column: "CourseParticipationTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseTypeID",
                table: "Course",
                column: "CourseTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Discontinued_Name",
                table: "Course",
                columns: new[] { "Discontinued", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseType_Name",
                table: "CourseType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrolment_ClassID",
                table: "Enrolment",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolment_CourseID",
                table: "Enrolment",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolment_PersonID",
                table: "Enrolment",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolment_TermID",
                table: "Enrolment",
                column: "TermID");

            migrationBuilder.CreateIndex(
                name: "IX_Person_Discontinued_LastName_FirstName_Email",
                table: "Person",
                columns: new[] { "Discontinued", "LastName", "FirstName", "Email" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AttendClass");

            migrationBuilder.DropTable(
                name: "CancelClass");

            migrationBuilder.DropTable(
                name: "Enrolment");

            migrationBuilder.DropTable(
                name: "PublicHoliday");

            migrationBuilder.DropTable(
                name: "SystemSettings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AttendClassStatus");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Term");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Occurrence");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Venue");

            migrationBuilder.DropTable(
                name: "WeekDay");

            migrationBuilder.DropTable(
                name: "CourseParticpationType");

            migrationBuilder.DropTable(
                name: "CourseType");
        }
    }
}
