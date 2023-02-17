﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using U3A.Database;

#nullable disable

namespace U3A.Database.Migrations
{
    [DbContext(typeof(U3ADbContext))]
    partial class U3ADbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            ConcurrencyStamp = "5a789fb4-316f-463b-9836-25d8d068bbfd",
                            Name = "Security Administrator",
                            NormalizedName = "SECURITY ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "993C6378-61D4-4734-ADAE-D725F2A8CD94",
                            ConcurrencyStamp = "9fc48f02-3752-4652-8199-1f2f5707a17d",
                            Name = "System Administrator",
                            NormalizedName = "SYSTEM ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
                            ConcurrencyStamp = "5745d6cd-fff1-452b-b652-9ba093634234",
                            Name = "Membership",
                            NormalizedName = "MEMBERSHIP"
                        },
                        new
                        {
                            Id = "D4BA57AA-A379-4EE8-940E-57315575978A",
                            ConcurrencyStamp = "1f963e2d-90c4-498a-b61f-ce37f5089b62",
                            Name = "Accounting",
                            NormalizedName = "ACCOUNTING"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "14eb39d4-d983-4d1b-9164-4851cdca7682",
                            Email = "SuperAdmin@U3A.com.au",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "SUPERADMIN@U3A.COM.AU",
                            NormalizedUserName = "SUPERADMIN@U3A.COM.AU",
                            PasswordHash = "AQAAAAEAACcQAAAAEOZr6J/iKPA3UsGKjarg5Xlzlq+50B5j/ZwEsXZoKy3fVuHyxfSZMAbNWjO0/lBNhg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "c710382f-5343-495a-a081-3f7df64cc3d5",
                            TwoFactorEnabled = false,
                            UserName = "SuperAdmin@U3A.com.au"
                        },
                        new
                        {
                            Id = "753F8F36-D2FF-438E-B5D1-7FF79E4628BD",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1b0c5407-5b2d-495c-9aee-778a8d953aa2",
                            Email = "security@U3A.com.au",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "SECURITY@U3A.COM.AU",
                            NormalizedUserName = "SECURITY@U3A.COM.AU",
                            PasswordHash = "AQAAAAEAACcQAAAAEI49FQb2ZE2km2v1wUqKH56fSXtiZX9cJ7wbOz5TEqtyXXbRvfSdddtOU8crQeAP9g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "6503f958-f2d6-4504-bc0c-5386e2c9f1fc",
                            TwoFactorEnabled = false,
                            UserName = "security@U3A.com.au"
                        },
                        new
                        {
                            Id = "70494634-D7BE-4BE4-8106-031AAE2BC6DC",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "9e5667aa-a6a3-4939-9ff1-c9d1ca132213",
                            Email = "SysAdmin@U3A.com.au",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "SYSADMIN@U3A.COM.AU",
                            NormalizedUserName = "SYSADMIN@U3A.COM.AU",
                            PasswordHash = "AQAAAAEAACcQAAAAEBfXKWHup7NHT8Djg3Lw1uShKwvGvxKHw9vo/t+Q3joPfvLlHRUjLIDiqOSZXXv0IQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "bd5f773c-98f0-4ece-a51f-b08e6ce3dab1",
                            TwoFactorEnabled = false,
                            UserName = "SysAdmin@U3A.com.au"
                        },
                        new
                        {
                            Id = "E7B47704-8DA0-4657-B42C-849C1C22A6D2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "274854ed-be74-4594-9bab-16fe2d21232c",
                            Email = "accounts@U3A.com.au",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ACCOUNTS@U3A.COM.AU",
                            NormalizedUserName = "ACCOUNTS@U3A.COM.AU",
                            PasswordHash = "AQAAAAEAACcQAAAAEBD7L/nZRdSbzTZjnf1ntJMnv5BSYNgwIDCzG+mh8ObCe8377w0+XkHOQEqcAUTHgg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f8118250-9e17-4660-9dc0-0af16b983921",
                            TwoFactorEnabled = false,
                            UserName = "accounts@U3A.com.au"
                        },
                        new
                        {
                            Id = "C5E9887D-9C4B-40F5-AB46-2232776005C5",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "78a3eafd-9860-4cf0-95ee-c857adc66baa",
                            Email = "membership@U3A.com.au",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "MEMBERSHIP@U3A.COM.AU",
                            NormalizedUserName = "MEMBERSHIP@U3A.COM.AU",
                            PasswordHash = "AQAAAAEAACcQAAAAEOOlxFTv8YPXwA1oyWu4/kz0A5TEl6gKdhfwWBVk538JZISPw0PTYKFUGWARnfu9mQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "4510ce49-c197-496b-b52f-2eb2628b9b13",
                            TwoFactorEnabled = false,
                            UserName = "membership@U3A.com.au"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210"
                        },
                        new
                        {
                            UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            RoleId = "993C6378-61D4-4734-ADAE-D725F2A8CD94"
                        },
                        new
                        {
                            UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            RoleId = "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0"
                        },
                        new
                        {
                            UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            RoleId = "D4BA57AA-A379-4EE8-940E-57315575978A"
                        },
                        new
                        {
                            UserId = "70494634-D7BE-4BE4-8106-031AAE2BC6DC",
                            RoleId = "993C6378-61D4-4734-ADAE-D725F2A8CD94"
                        },
                        new
                        {
                            UserId = "E7B47704-8DA0-4657-B42C-849C1C22A6D2",
                            RoleId = "D4BA57AA-A379-4EE8-940E-57315575978A"
                        },
                        new
                        {
                            UserId = "C5E9887D-9C4B-40F5-AB46-2232776005C5",
                            RoleId = "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0"
                        },
                        new
                        {
                            UserId = "753F8F36-D2FF-438E-B5D1-7FF79E4628BD",
                            RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("U3A.Model.Class", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("OnDayID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("VenueID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.HasIndex("OnDayID");

                    b.HasIndex("VenueID");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("U3A.Model.Course", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ClassFee")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Optional fee per class (eg. tea and coffee)");

                    b.Property<string>("ClassFeeDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CoLeaderID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ConversionID")
                        .HasColumnType("int");

                    b.Property<decimal>("CourseFee")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Once-only course enrolment fee");

                    b.Property<string>("CourseFeeDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CourseParticipationTypeID")
                        .HasColumnType("int");

                    b.Property<Guid?>("CourseTypeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Discontinued")
                        .HasColumnType("bit");

                    b.Property<decimal>("Duration")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)")
                        .HasComment("The time in hours each class is expeted to take");

                    b.Property<bool>("ExerciseRiskFormReqd")
                        .HasColumnType("bit")
                        .HasComment("Is an exercise risk form is required for this course");

                    b.Property<bool>("GeneralRiskFormReqd")
                        .HasColumnType("bit")
                        .HasComment("Is an exercise risk form is required for this course");

                    b.Property<Guid?>("LeaderID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MaximumStudents")
                        .HasColumnType("int")
                        .HasComment("The maximum number of students per class");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("OfferedTerm1")
                        .HasColumnType("bit")
                        .HasComment("Is the course offered in term 1?");

                    b.Property<bool>("OfferedTerm2")
                        .HasColumnType("bit")
                        .HasComment("Is the course offered in term 2?");

                    b.Property<bool>("OfferedTerm3")
                        .HasColumnType("bit")
                        .HasComment("Is the course offered in term 3?");

                    b.Property<bool>("OfferedTerm4")
                        .HasColumnType("bit")
                        .HasComment("Is the course offered in term 4?");

                    b.Property<int>("RequiredStudents")
                        .HasColumnType("int")
                        .HasComment("The required number of students per class");

                    b.HasKey("ID");

                    b.HasIndex("CoLeaderID");

                    b.HasIndex("CourseParticipationTypeID");

                    b.HasIndex("CourseTypeID");

                    b.HasIndex("LeaderID");

                    b.HasIndex("Discontinued", "Name");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("U3A.Model.CourseParticipationType", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CourseParticpationType");

                    b.HasData(
                        new
                        {
                            ID = 0,
                            Name = "Same participants in all classes"
                        },
                        new
                        {
                            ID = 1,
                            Name = "Different participants in each class"
                        });
                });

            modelBuilder.Entity("U3A.Model.CourseType", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Discontinued")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("CourseType");
                });

            modelBuilder.Entity("U3A.Model.Enrolment", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClassID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsWaitlisted")
                        .HasColumnType("bit");

                    b.Property<Guid>("PersonID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TermID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("ClassID");

                    b.HasIndex("CourseID");

                    b.HasIndex("PersonID");

                    b.HasIndex("TermID");

                    b.ToTable("Enrolment");
                });

            modelBuilder.Entity("U3A.Model.Person", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ConversionID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCeased")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateJoined")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Discontinued")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomePhone")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("ICEContact")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ICEPhone")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsLifeMember")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Mobile")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<int>("Postcode")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("ID");

                    b.HasIndex("Discontinued", "LastName", "FirstName", "Email");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("U3A.Model.Term", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Duration")
                        .HasColumnType("int")
                        .HasComment("The number of weeks a Term will last");

                    b.Property<int>("EnrolmentEnds")
                        .HasColumnType("int")
                        .HasComment("The number of weeks prior to StartDate that enrolment ends");

                    b.Property<int>("EnrolmentStarts")
                        .HasColumnType("int")
                        .HasComment("The number of weeks prior to StartDate that enrolment begins");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TermNumber")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Term");
                });

            modelBuilder.Entity("U3A.Model.Venue", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Discontinued")
                        .HasColumnType("bit");

                    b.Property<int>("MaxNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Venue");
                });

            modelBuilder.Entity("U3A.Model.WeekDay", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("Day")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDay")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("WeekDay");

                    b.HasData(
                        new
                        {
                            ID = 0,
                            Day = "Sunday",
                            ShortDay = "Sun"
                        },
                        new
                        {
                            ID = 1,
                            Day = "Monday",
                            ShortDay = "Mon"
                        },
                        new
                        {
                            ID = 2,
                            Day = "Tuesday",
                            ShortDay = "Tue"
                        },
                        new
                        {
                            ID = 3,
                            Day = "Wednesday",
                            ShortDay = "Wed"
                        },
                        new
                        {
                            ID = 4,
                            Day = "Thursday",
                            ShortDay = "Thu"
                        },
                        new
                        {
                            ID = 5,
                            Day = "Friday",
                            ShortDay = "Fri"
                        },
                        new
                        {
                            ID = 6,
                            Day = "Saturday",
                            ShortDay = "Sat"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("U3A.Model.Class", b =>
                {
                    b.HasOne("U3A.Model.Course", "Course")
                        .WithMany("Classes")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("U3A.Model.WeekDay", "OnDay")
                        .WithMany("Classes")
                        .HasForeignKey("OnDayID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("U3A.Model.Venue", "Venue")
                        .WithMany("Classes")
                        .HasForeignKey("VenueID");

                    b.Navigation("Course");

                    b.Navigation("OnDay");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("U3A.Model.Course", b =>
                {
                    b.HasOne("U3A.Model.Person", "CoLeader")
                        .WithMany("CoLeaderOf")
                        .HasForeignKey("CoLeaderID");

                    b.HasOne("U3A.Model.CourseParticipationType", "CourseParticipationType")
                        .WithMany()
                        .HasForeignKey("CourseParticipationTypeID");

                    b.HasOne("U3A.Model.CourseType", "CourseType")
                        .WithMany("Courses")
                        .HasForeignKey("CourseTypeID");

                    b.HasOne("U3A.Model.Person", "Leader")
                        .WithMany("LeaderOf")
                        .HasForeignKey("LeaderID");

                    b.Navigation("CoLeader");

                    b.Navigation("CourseParticipationType");

                    b.Navigation("CourseType");

                    b.Navigation("Leader");
                });

            modelBuilder.Entity("U3A.Model.Enrolment", b =>
                {
                    b.HasOne("U3A.Model.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassID");

                    b.HasOne("U3A.Model.Course", "Course")
                        .WithMany("Enrolments")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("U3A.Model.Person", "Person")
                        .WithMany("Enrolments")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("U3A.Model.Term", "Term")
                        .WithMany("Enrolments")
                        .HasForeignKey("TermID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Course");

                    b.Navigation("Person");

                    b.Navigation("Term");
                });

            modelBuilder.Entity("U3A.Model.Course", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("Enrolments");
                });

            modelBuilder.Entity("U3A.Model.CourseType", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("U3A.Model.Person", b =>
                {
                    b.Navigation("CoLeaderOf");

                    b.Navigation("Enrolments");

                    b.Navigation("LeaderOf");
                });

            modelBuilder.Entity("U3A.Model.Term", b =>
                {
                    b.Navigation("Enrolments");
                });

            modelBuilder.Entity("U3A.Model.Venue", b =>
                {
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("U3A.Model.WeekDay", b =>
                {
                    b.Navigation("Classes");
                });
#pragma warning restore 612, 618
        }
    }
}