IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE TABLE [AttendClassStatus] (
        [ID] int NOT NULL,
        [Status] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_AttendClassStatus] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE TABLE [CourseParticpationType] (
        [ID] int NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_CourseParticpationType] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE TABLE [CourseType] (
        [ID] uniqueidentifier NOT NULL,
        [Discontinued] bit NOT NULL,
        [Name] nvarchar(50) NOT NULL,
        [Comment] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_CourseType] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE TABLE [Occurrence] (
        [ID] int NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [ShortName] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Occurrence] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE TABLE [Person] (
        [ID] uniqueidentifier NOT NULL,
        [PersonID] int NOT NULL IDENTITY,
        [ConversionID] int NOT NULL,
        [Discontinued] bit NOT NULL,
        [FirstName] nvarchar(50) NOT NULL,
        [LastName] nvarchar(50) NOT NULL,
        [Address] nvarchar(50) NOT NULL,
        [City] nvarchar(50) NOT NULL,
        [State] nvarchar(3) NOT NULL,
        [Postcode] int NOT NULL,
        [Gender] nvarchar(max) NOT NULL,
        [BirthDate] datetime2 NULL,
        [DateJoined] datetime2 NULL,
        [DateCeased] datetime2 NULL,
        [Email] nvarchar(256) NULL,
        [HomePhone] nvarchar(16) NULL,
        [Mobile] nvarchar(16) NULL,
        [ICEContact] nvarchar(50) NULL,
        [ICEPhone] nvarchar(50) NULL,
        [VaxCertificateViewed] bit NOT NULL,
        [Occupation] nvarchar(max) NULL,
        [IsLifeMember] bit NOT NULL,
        CONSTRAINT [PK_Person] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE TABLE [PublicHoliday] (
        [ID] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Date] datetime2 NOT NULL,
        CONSTRAINT [PK_PublicHoliday] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE TABLE [SystemSettings] (
        [ID] uniqueidentifier NOT NULL,
        [U3AGroup] nvarchar(50) NOT NULL,
        [OfficeLocation] nvarchar(50) NULL,
        [PostalAddress] nvarchar(256) NOT NULL,
        [StreetAddress] nvarchar(256) NOT NULL,
        [ABN] nvarchar(15) NOT NULL,
        [Email] nvarchar(256) NULL,
        [Website] nvarchar(256) NULL,
        [Phone] nvarchar(16) NULL,
        [MembershipFee] decimal(18,2) NOT NULL,
        [MailSurcharge] decimal(18,2) NOT NULL,
        [RequireVaxCertificate] bit NOT NULL,
        [CurrentTermID] uniqueidentifier NULL,
        CONSTRAINT [PK_SystemSettings] PRIMARY KEY ([ID])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Yearly Membership Fee';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SystemSettings', 'COLUMN', N'MembershipFee';
    SET @description = N'Yearly surcharge if requiring mail correspondance';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SystemSettings', 'COLUMN', N'MailSurcharge';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE TABLE [Term] (
        [ID] uniqueidentifier NOT NULL,
        [Year] int NOT NULL,
        [TermNumber] int NOT NULL,
        [StartDate] datetime2 NOT NULL,
        [Duration] int NOT NULL,
        [EnrolmentStarts] int NOT NULL,
        [EnrolmentEnds] int NOT NULL,
        CONSTRAINT [PK_Term] PRIMARY KEY ([ID])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'The number of weeks a Term will last';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Term', 'COLUMN', N'Duration';
    SET @description = N'The number of weeks prior to StartDate that enrolment begins';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Term', 'COLUMN', N'EnrolmentStarts';
    SET @description = N'The number of weeks prior to StartDate that enrolment ends';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Term', 'COLUMN', N'EnrolmentEnds';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE TABLE [Venue] (
        [ID] uniqueidentifier NOT NULL,
        [Discontinued] bit NOT NULL,
        [Name] nvarchar(50) NOT NULL,
        [MaxNumber] int NOT NULL,
        [Address] nvarchar(100) NOT NULL,
        [Comment] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Venue] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE TABLE [WeekDay] (
        [ID] int NOT NULL,
        [Day] nvarchar(max) NOT NULL,
        [ShortDay] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_WeekDay] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE TABLE [Course] (
        [ID] uniqueidentifier NOT NULL,
        [ConversionID] int NOT NULL,
        [Discontinued] bit NOT NULL,
        [Name] nvarchar(50) NOT NULL,
        [Description] nvarchar(max) NULL,
        [CourseParticipationTypeID] int NULL,
        [CourseFee] decimal(18,2) NOT NULL,
        [CourseFeeDescription] nvarchar(max) NULL,
        [ClassFee] decimal(18,2) NOT NULL,
        [ClassFeeDescription] nvarchar(max) NULL,
        [Duration] decimal(18,2) NOT NULL,
        [RequiredStudents] int NOT NULL,
        [MaximumStudents] int NOT NULL,
        [CourseTypeID] uniqueidentifier NULL,
        CONSTRAINT [PK_Course] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_Course_CourseParticpationType_CourseParticipationTypeID] FOREIGN KEY ([CourseParticipationTypeID]) REFERENCES [CourseParticpationType] ([ID]),
        CONSTRAINT [FK_Course_CourseType_CourseTypeID] FOREIGN KEY ([CourseTypeID]) REFERENCES [CourseType] ([ID])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Once-only course enrolment fee';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'CourseFee';
    SET @description = N'Optional fee per class (eg. tea and coffee)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'ClassFee';
    SET @description = N'The time in hours each class is expeted to take';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'Duration';
    SET @description = N'The required number of students per class';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'RequiredStudents';
    SET @description = N'The maximum number of students per class';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'MaximumStudents';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE TABLE [Class] (
        [ID] uniqueidentifier NOT NULL,
        [OfferedTerm1] bit NOT NULL,
        [OfferedTerm2] bit NOT NULL,
        [OfferedTerm3] bit NOT NULL,
        [OfferedTerm4] bit NOT NULL,
        [StartDate] datetime2 NULL,
        [OccurrenceID] int NULL,
        [Recurrence] int NULL,
        [OnDayID] int NOT NULL,
        [StartTime] datetime2 NOT NULL,
        [CourseID] uniqueidentifier NOT NULL,
        [VenueID] uniqueidentifier NOT NULL,
        [LeaderID] uniqueidentifier NULL,
        CONSTRAINT [PK_Class] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_Class_Course_CourseID] FOREIGN KEY ([CourseID]) REFERENCES [Course] ([ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_Class_Occurrence_OccurrenceID] FOREIGN KEY ([OccurrenceID]) REFERENCES [Occurrence] ([ID]),
        CONSTRAINT [FK_Class_Person_LeaderID] FOREIGN KEY ([LeaderID]) REFERENCES [Person] ([ID]),
        CONSTRAINT [FK_Class_Venue_VenueID] FOREIGN KEY ([VenueID]) REFERENCES [Venue] ([ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_Class_WeekDay_OnDayID] FOREIGN KEY ([OnDayID]) REFERENCES [WeekDay] ([ID]) ON DELETE CASCADE
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Is the course offered in term 1?';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Class', 'COLUMN', N'OfferedTerm1';
    SET @description = N'Is the course offered in term 2?';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Class', 'COLUMN', N'OfferedTerm2';
    SET @description = N'Is the course offered in term 3?';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Class', 'COLUMN', N'OfferedTerm3';
    SET @description = N'Is the course offered in term 4?';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Class', 'COLUMN', N'OfferedTerm4';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE TABLE [AttendClass] (
        [ID] uniqueidentifier NOT NULL,
        [IsAdHoc] bit NOT NULL,
        [TermID] uniqueidentifier NOT NULL,
        [ClassID] uniqueidentifier NULL,
        [Date] datetime2 NOT NULL,
        [PersonID] uniqueidentifier NOT NULL,
        [AttendClassStatusID] int NOT NULL,
        [Comment] nvarchar(max) NOT NULL,
        [DateProcessed] datetime2 NULL,
        CONSTRAINT [PK_AttendClass] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_AttendClass_AttendClassStatus_AttendClassStatusID] FOREIGN KEY ([AttendClassStatusID]) REFERENCES [AttendClassStatus] ([ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_AttendClass_Class_ClassID] FOREIGN KEY ([ClassID]) REFERENCES [Class] ([ID]),
        CONSTRAINT [FK_AttendClass_Person_PersonID] FOREIGN KEY ([PersonID]) REFERENCES [Person] ([ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_AttendClass_Term_TermID] FOREIGN KEY ([TermID]) REFERENCES [Term] ([ID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE TABLE [CancelClass] (
        [ID] uniqueidentifier NOT NULL,
        [ClassID] uniqueidentifier NOT NULL,
        [StartDate] datetime2 NOT NULL,
        [EndDate] datetime2 NOT NULL,
        [Reason] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_CancelClass] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_CancelClass_Class_ClassID] FOREIGN KEY ([ClassID]) REFERENCES [Class] ([ID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE TABLE [Enrolment] (
        [ID] uniqueidentifier NOT NULL,
        [TermID] uniqueidentifier NOT NULL,
        [CourseID] uniqueidentifier NOT NULL,
        [ClassID] uniqueidentifier NULL,
        [PersonID] uniqueidentifier NOT NULL,
        [Created] datetime2 NOT NULL,
        [IsWaitlisted] bit NOT NULL,
        CONSTRAINT [PK_Enrolment] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_Enrolment_Class_ClassID] FOREIGN KEY ([ClassID]) REFERENCES [Class] ([ID]),
        CONSTRAINT [FK_Enrolment_Course_CourseID] FOREIGN KEY ([CourseID]) REFERENCES [Course] ([ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_Enrolment_Person_PersonID] FOREIGN KEY ([PersonID]) REFERENCES [Person] ([ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_Enrolment_Term_TermID] FOREIGN KEY ([TermID]) REFERENCES [Term] ([ID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] ON;
    EXEC(N'INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
    VALUES (N''2c5e174e-3b0e-446f-86af-483d56fd7210'', N''5e99f08e-4555-4998-834b-24786d24fc9a'', N''Security Administrator'', N''SECURITY ADMINISTRATOR''),
    (N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'', N''c31b46bb-928f-411c-9f18-c84f62106c1b'', N''Membership'', N''MEMBERSHIP''),
    (N''993C6378-61D4-4734-ADAE-D725F2A8CD94'', N''286cf813-1bc6-4385-a545-cc6ee2de93f7'', N''System Administrator'', N''SYSTEM ADMINISTRATOR''),
    (N''D4BA57AA-A379-4EE8-940E-57315575978A'', N''7cf128ad-45a3-499b-bf25-ca21678ce6eb'', N''Accounting'', N''ACCOUNTING'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] ON;
    EXEC(N'INSERT INTO [AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName])
    VALUES (N''70494634-D7BE-4BE4-8106-031AAE2BC6DC'', 0, N''beb79513-2257-489f-9cb5-f008d61d55ee'', N''SysAdmin@U3A.com.au'', CAST(1 AS bit), CAST(0 AS bit), NULL, N''SYSADMIN@U3A.COM.AU'', N''SYSADMIN@U3A.COM.AU'', N''AQAAAAEAACcQAAAAEJ0s4p+MFiXURnb61SEH926OUy28Y5YrYqKjNCO/W5vSDTq1Ryd3Y5Cq9iotpROzfQ=='', NULL, CAST(0 AS bit), N''075e13aa-edb9-43ba-99b7-c248848faed3'', CAST(0 AS bit), N''SysAdmin@U3A.com.au''),
    (N''753F8F36-D2FF-438E-B5D1-7FF79E4628BD'', 0, N''34905761-59fd-4408-a261-20dfeaacd7d1'', N''security@U3A.com.au'', CAST(1 AS bit), CAST(0 AS bit), NULL, N''SECURITY@U3A.COM.AU'', N''SECURITY@U3A.COM.AU'', N''AQAAAAEAACcQAAAAEOe+NeYnOeM6CIUvG3rLuGXqrRsAWJ7BoXgKyvirFlq38T9v7lqCnEdkMEUOWSe+UA=='', NULL, CAST(0 AS bit), N''1e02c8a0-ff0b-4b59-9126-385782db6632'', CAST(0 AS bit), N''security@U3A.com.au''),
    (N''8e445865-a24d-4543-a6c6-9443d048cdb9'', 0, N''a953037d-7a28-4857-abd7-136ac482ff88'', N''SuperAdmin@U3A.com.au'', CAST(1 AS bit), CAST(0 AS bit), NULL, N''SUPERADMIN@U3A.COM.AU'', N''SUPERADMIN@U3A.COM.AU'', N''AQAAAAEAACcQAAAAEGO9hnvP8x8fJPlDhs2gGYMhl9koCigXL2PPHidC9luB5nbMxW8fCFahxG/ZCA1OSw=='', NULL, CAST(0 AS bit), N''d19a58d8-c599-4d04-b99b-06b42261f032'', CAST(0 AS bit), N''SuperAdmin@U3A.com.au''),
    (N''C5E9887D-9C4B-40F5-AB46-2232776005C5'', 0, N''a59d689a-6000-4448-9560-1677fdf03a7d'', N''membership@U3A.com.au'', CAST(1 AS bit), CAST(0 AS bit), NULL, N''MEMBERSHIP@U3A.COM.AU'', N''MEMBERSHIP@U3A.COM.AU'', N''AQAAAAEAACcQAAAAEF5rf+n4Z9u7Fzv9PENdLMBwEmNkHidubJciJdNwx/0P8Jpa3E7j591z1e0OKw++fg=='', NULL, CAST(0 AS bit), N''912b7ae5-442b-4ff3-a276-b479d3f4f1d5'', CAST(0 AS bit), N''membership@U3A.com.au''),
    (N''E7B47704-8DA0-4657-B42C-849C1C22A6D2'', 0, N''eadf1573-36ec-4888-8f5e-bfe0564de98c'', N''accounts@U3A.com.au'', CAST(1 AS bit), CAST(0 AS bit), NULL, N''ACCOUNTS@U3A.COM.AU'', N''ACCOUNTS@U3A.COM.AU'', N''AQAAAAEAACcQAAAAEGI+D+snqXRY4uerus0kU6ypVzUHoLHJo7XNmQ0Iastb7pdBzCdt9zvnMUGVR3SeCw=='', NULL, CAST(0 AS bit), N''15645d31-2d90-4ad3-81a0-abfbefbfc555'', CAST(0 AS bit), N''accounts@U3A.com.au'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Status') AND [object_id] = OBJECT_ID(N'[AttendClassStatus]'))
        SET IDENTITY_INSERT [AttendClassStatus] ON;
    EXEC(N'INSERT INTO [AttendClassStatus] ([ID], [Status])
    VALUES (0, N''Present''),
    (1, N''Absent without apology''),
    (2, N''Absent with apology'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Status') AND [object_id] = OBJECT_ID(N'[AttendClassStatus]'))
        SET IDENTITY_INSERT [AttendClassStatus] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Name') AND [object_id] = OBJECT_ID(N'[CourseParticpationType]'))
        SET IDENTITY_INSERT [CourseParticpationType] ON;
    EXEC(N'INSERT INTO [CourseParticpationType] ([ID], [Name])
    VALUES (0, N''Same participants in all classes''),
    (1, N''Different participants in each class'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Name') AND [object_id] = OBJECT_ID(N'[CourseParticpationType]'))
        SET IDENTITY_INSERT [CourseParticpationType] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Name', N'ShortName') AND [object_id] = OBJECT_ID(N'[Occurrence]'))
        SET IDENTITY_INSERT [Occurrence] ON;
    EXEC(N'INSERT INTO [Occurrence] ([ID], [Name], [ShortName])
    VALUES (0, N''Once Only'', N''Once''),
    (1, N''Daily'', N''Daily''),
    (2, N''Weekly'', N''Weekly''),
    (3, N''Fortnightly'', N''F''''nightly''),
    (4, N''1st Week of Month'', N''Week 1''),
    (5, N''2nd Week of Month'', N''Week 2''),
    (6, N''3rd Week of Month'', N''Week 3''),
    (7, N''Last Week of Month'', N''Last Week'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Name', N'ShortName') AND [object_id] = OBJECT_ID(N'[Occurrence]'))
        SET IDENTITY_INSERT [Occurrence] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Day', N'ShortDay') AND [object_id] = OBJECT_ID(N'[WeekDay]'))
        SET IDENTITY_INSERT [WeekDay] ON;
    EXEC(N'INSERT INTO [WeekDay] ([ID], [Day], [ShortDay])
    VALUES (0, N''Sunday'', N''Sun''),
    (1, N''Monday'', N''Mon''),
    (2, N''Tuesday'', N''Tue''),
    (3, N''Wednesday'', N''Wed''),
    (4, N''Thursday'', N''Thu''),
    (5, N''Friday'', N''Fri''),
    (6, N''Saturday'', N''Sat'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Day', N'ShortDay') AND [object_id] = OBJECT_ID(N'[WeekDay]'))
        SET IDENTITY_INSERT [WeekDay] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
        SET IDENTITY_INSERT [AspNetUserRoles] ON;
    EXEC(N'INSERT INTO [AspNetUserRoles] ([RoleId], [UserId])
    VALUES (N''993C6378-61D4-4734-ADAE-D725F2A8CD94'', N''70494634-D7BE-4BE4-8106-031AAE2BC6DC''),
    (N''2c5e174e-3b0e-446f-86af-483d56fd7210'', N''753F8F36-D2FF-438E-B5D1-7FF79E4628BD''),
    (N''2c5e174e-3b0e-446f-86af-483d56fd7210'', N''8e445865-a24d-4543-a6c6-9443d048cdb9''),
    (N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'', N''8e445865-a24d-4543-a6c6-9443d048cdb9''),
    (N''993C6378-61D4-4734-ADAE-D725F2A8CD94'', N''8e445865-a24d-4543-a6c6-9443d048cdb9''),
    (N''D4BA57AA-A379-4EE8-940E-57315575978A'', N''8e445865-a24d-4543-a6c6-9443d048cdb9''),
    (N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'', N''C5E9887D-9C4B-40F5-AB46-2232776005C5''),
    (N''D4BA57AA-A379-4EE8-940E-57315575978A'', N''E7B47704-8DA0-4657-B42C-849C1C22A6D2'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
        SET IDENTITY_INSERT [AspNetUserRoles] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE INDEX [IX_AttendClass_AttendClassStatusID] ON [AttendClass] ([AttendClassStatusID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE INDEX [IX_AttendClass_ClassID] ON [AttendClass] ([ClassID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE INDEX [IX_AttendClass_PersonID] ON [AttendClass] ([PersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE INDEX [IX_AttendClass_TermID_ClassID_Date] ON [AttendClass] ([TermID], [ClassID], [Date]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE INDEX [IX_CancelClass_ClassID] ON [CancelClass] ([ClassID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE INDEX [IX_Class_CourseID] ON [Class] ([CourseID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE INDEX [IX_Class_LeaderID] ON [Class] ([LeaderID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE INDEX [IX_Class_OccurrenceID] ON [Class] ([OccurrenceID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE INDEX [IX_Class_OnDayID] ON [Class] ([OnDayID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE INDEX [IX_Class_VenueID] ON [Class] ([VenueID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE INDEX [IX_Course_CourseParticipationTypeID] ON [Course] ([CourseParticipationTypeID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE INDEX [IX_Course_CourseTypeID] ON [Course] ([CourseTypeID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE INDEX [IX_Course_Discontinued_Name] ON [Course] ([Discontinued], [Name]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE UNIQUE INDEX [IX_CourseType_Name] ON [CourseType] ([Name]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE INDEX [IX_Enrolment_ClassID] ON [Enrolment] ([ClassID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE INDEX [IX_Enrolment_CourseID] ON [Enrolment] ([CourseID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE INDEX [IX_Enrolment_PersonID] ON [Enrolment] ([PersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE INDEX [IX_Enrolment_TermID] ON [Enrolment] ([TermID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    CREATE INDEX [IX_Person_Discontinued_LastName_FirstName_Email] ON [Person] ([Discontinued], [LastName], [FirstName], [Email]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220813052441_U3A_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220813052441_U3A_Initial', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220818092843_U3A_CourseTypeChnage')
BEGIN
    ALTER TABLE [CourseType] ADD [IsVoluntaryActivity] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220818092843_U3A_CourseTypeChnage')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''385883dc-123a-4c65-a9c5-89c383c2d728''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220818092843_U3A_CourseTypeChnage')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''1d4e8a59-1d23-4861-9ea6-74575e9bcabd''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220818092843_U3A_CourseTypeChnage')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''d140c439-9b0a-48d0-bfc3-3727073bf791''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220818092843_U3A_CourseTypeChnage')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''0f3296ad-3654-4b52-b3d6-2bea4581b3d5''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220818092843_U3A_CourseTypeChnage')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''85094d30-af49-4e07-8408-8d4b7c4eaa19'', [PasswordHash] = N''AQAAAAEAACcQAAAAEM4I3foWmWnVP6GkEOMH3tTD8EJ/yNcdNzohlTCAsvNefp3hzpc7/54FBfWn4xRN0w=='', [SecurityStamp] = N''be0d9640-4b9f-4e88-8747-f22d93f177dd''
    WHERE [Id] = N''70494634-D7BE-4BE4-8106-031AAE2BC6DC'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220818092843_U3A_CourseTypeChnage')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''4664b5b9-9538-42c3-9c6d-ac03153b29f1'', [PasswordHash] = N''AQAAAAEAACcQAAAAEOU5rcsBs+fX/oLC0QACkQRPlEGKR531/wKSr/3x0hNGilq7D4okbmBB56tnpSlpPA=='', [SecurityStamp] = N''8235dc98-5810-434e-9bee-6c392a08b317''
    WHERE [Id] = N''753F8F36-D2FF-438E-B5D1-7FF79E4628BD'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220818092843_U3A_CourseTypeChnage')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''d3ffb31c-1bfc-45bd-acde-f0b59ec6d98e'', [PasswordHash] = N''AQAAAAEAACcQAAAAEFpMp7+9cZsemF55fRFLSRq1i1jig/HR++sv8Oi41DY0/frhSCFVGA7lyjbqeQZBBw=='', [SecurityStamp] = N''43158abc-e3b3-4d6e-8845-0643e162df79''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220818092843_U3A_CourseTypeChnage')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''b8694082-42a5-460c-80ef-4d8385466fb4'', [PasswordHash] = N''AQAAAAEAACcQAAAAEMZ8xq/qi8ImILijrPDw1RYGMqAyCcryASIyv4cEaFJWpKsJ3ZiHAWeZcw0c+KTHIA=='', [SecurityStamp] = N''804b3767-5342-4811-8a80-327f98c157c5''
    WHERE [Id] = N''C5E9887D-9C4B-40F5-AB46-2232776005C5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220818092843_U3A_CourseTypeChnage')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''2f796695-01d8-4485-a076-f573b843b9a3'', [PasswordHash] = N''AQAAAAEAACcQAAAAEKWf1mk9jce430dFwohj9/aeyE3ifsd+dzvX7mrkmW7mZ0631vP/9zK7uJ+QYLzZog=='', [SecurityStamp] = N''62c668ce-2fda-4dc1-b782-f0f6c9fa03de''
    WHERE [Id] = N''E7B47704-8DA0-4657-B42C-849C1C22A6D2'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220818092843_U3A_CourseTypeChnage')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220818092843_U3A_CourseTypeChnage', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220819053920_U3A_AttendanceHistory')
BEGIN
    CREATE TABLE [AttendanceHistory] (
        [ID] int NOT NULL IDENTITY,
        [AttendClassID] uniqueidentifier NOT NULL,
        [IsAdHoc] bit NOT NULL,
        [year] int NOT NULL,
        [Term] int NOT NULL,
        [CourseType] nvarchar(max) NOT NULL,
        [Course] nvarchar(max) NOT NULL,
        [Venue] nvarchar(max) NOT NULL,
        [IsVountary] bit NOT NULL,
        [LeaderLastName] nvarchar(max) NOT NULL,
        [LeaderFirstName] nvarchar(max) NOT NULL,
        [Date] datetime2 NOT NULL,
        [ParticipantFirstName] nvarchar(max) NOT NULL,
        [ParticipantLastName] nvarchar(max) NOT NULL,
        [AttendanceStatus] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_AttendanceHistory] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220819053920_U3A_AttendanceHistory')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''f9455188-4710-4564-ae14-e6bdf27c9c9e''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220819053920_U3A_AttendanceHistory')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''be2b7085-aa1d-456b-bc37-229522deb0c2''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220819053920_U3A_AttendanceHistory')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''8a5f9fb7-b790-4c53-a4bf-abb8080a395a''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220819053920_U3A_AttendanceHistory')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''4cb97ff4-e3d8-49da-bb6e-377fe83f4ad1''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220819053920_U3A_AttendanceHistory')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''a30f14c1-91e9-4ab3-8d61-f7ea6aaa958a'', [PasswordHash] = N''AQAAAAEAACcQAAAAEIfL9Hq+pYcl4MHmRslyUYeEr1FVOy8Dmq0v1UmcdGcuen7KHEHTnxkGHHFpVn+XaQ=='', [SecurityStamp] = N''c7da4ef2-b0d2-426b-9bab-3673e1c7c8c4''
    WHERE [Id] = N''70494634-D7BE-4BE4-8106-031AAE2BC6DC'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220819053920_U3A_AttendanceHistory')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''f3865d54-35a4-49ee-824a-2965d0d2df29'', [PasswordHash] = N''AQAAAAEAACcQAAAAEFibcqdtPtPSuBSidRhDoMtXkvU9hg/Lm3H/Be83MTjEZb+Zh4tRMJcC+eQH+XHfuw=='', [SecurityStamp] = N''47ff5717-a3f8-4997-9aff-8ecd511f31fa''
    WHERE [Id] = N''753F8F36-D2FF-438E-B5D1-7FF79E4628BD'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220819053920_U3A_AttendanceHistory')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''c12972e2-ea17-49e6-b2bb-b36d2cf2e143'', [PasswordHash] = N''AQAAAAEAACcQAAAAEGepLlP/Z3e1iolA13OrIcz8PQb19dGRytqSZT9k6ibyU1Tj6Bhs76QyyJM7lFcJ1Q=='', [SecurityStamp] = N''318df5cf-5850-4b8f-9ed6-2ff32707df78''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220819053920_U3A_AttendanceHistory')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''8cbf4169-99fe-44a3-9766-d11c4c3d24a8'', [PasswordHash] = N''AQAAAAEAACcQAAAAEEacPDrGc05sedkenjZcVig8tX1lAMJ48amYAH4xp8sB5nPK8IIP0x6SzckPCNz3aQ=='', [SecurityStamp] = N''574142da-cd85-4e74-945a-5fe2bd394289''
    WHERE [Id] = N''C5E9887D-9C4B-40F5-AB46-2232776005C5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220819053920_U3A_AttendanceHistory')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''715565ac-04c9-4f24-9cd8-3d9a5ced72ab'', [PasswordHash] = N''AQAAAAEAACcQAAAAEMAGYM2JLdbRTl5YPVv9pAKAoSZVOavd1bFsoT1kZ3jFefUnnwnaH1UpXOymanee5A=='', [SecurityStamp] = N''479c6946-088f-4457-b1bf-57fea7e35f41''
    WHERE [Id] = N''E7B47704-8DA0-4657-B42C-849C1C22A6D2'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220819053920_U3A_AttendanceHistory')
BEGIN
    CREATE INDEX [IX_AttendanceHistory_AttendClassID] ON [AttendanceHistory] ([AttendClassID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220819053920_U3A_AttendanceHistory')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220819053920_U3A_AttendanceHistory', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220821064729_U3A_DefaultTerm')
BEGIN
    ALTER TABLE [Term] ADD [IsDefaultTerm] bit NOT NULL DEFAULT CAST(0 AS bit);
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'The number of weeks prior to StartDate that enrolment ends';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Term', 'COLUMN', N'IsDefaultTerm';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220821064729_U3A_DefaultTerm')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''bc95b753-3923-4f72-8edf-0fc9fd7b65b1''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220821064729_U3A_DefaultTerm')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''4950ec95-5241-43c6-9263-09b056e36beb''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220821064729_U3A_DefaultTerm')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''ac3754f9-111a-45b6-b2d8-2c207334f1d3''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220821064729_U3A_DefaultTerm')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''822bbc25-abe2-4df9-addc-c29de047a068''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220821064729_U3A_DefaultTerm')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''61493c62-e137-4e69-bda0-1c01099ddb3e'', [PasswordHash] = N''AQAAAAEAACcQAAAAENqB3STxQcUOfq8jb+XSQAEBD96hwEeWJHY+rUg2fH+cALHIADiX9eI9CPFaGgerIw=='', [SecurityStamp] = N''3fd2ff2a-fec4-46c7-bade-983be8327032''
    WHERE [Id] = N''70494634-D7BE-4BE4-8106-031AAE2BC6DC'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220821064729_U3A_DefaultTerm')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''27568b41-cb8c-426c-8c6a-5338c7710910'', [PasswordHash] = N''AQAAAAEAACcQAAAAEOmqzyXWV4bZ4bmTPYw1gThsxblXGL+PEblL+AhcN/ZvTqSwoB7nBAygQ334MJu6MA=='', [SecurityStamp] = N''57e3e9ba-b7dc-4eae-a21c-9238d7fb9387''
    WHERE [Id] = N''753F8F36-D2FF-438E-B5D1-7FF79E4628BD'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220821064729_U3A_DefaultTerm')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''aab337ed-78b1-4d3b-b05e-822bba7da95b'', [PasswordHash] = N''AQAAAAEAACcQAAAAEPIqAcI021wuaXgrp1PLWYpMQB+g/lQCdwwJQtApN04SSISZqX1xLDP/Q45BN5wI4Q=='', [SecurityStamp] = N''b48c76ba-c69b-4134-8cac-27e76ed8c5b8''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220821064729_U3A_DefaultTerm')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''5c56dce2-1b73-4209-bafc-112473e28f77'', [PasswordHash] = N''AQAAAAEAACcQAAAAELc5f/9vbD3djd2IJ7RCqA6+1C56lJtb85tcENoCg5Tngz+rEDu/IWU8Ab3JPcl9Rg=='', [SecurityStamp] = N''2939cf29-7492-4de9-9da5-7e35cda7f308''
    WHERE [Id] = N''C5E9887D-9C4B-40F5-AB46-2232776005C5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220821064729_U3A_DefaultTerm')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''1c10771e-e4a8-4b58-bef7-34a9b71b37a8'', [PasswordHash] = N''AQAAAAEAACcQAAAAEKlgyvbNEurpLzSeWPRshzFPTlMsu5xHfUnvjJ0f5Nz/szz8YrJSZvUIhzjMPN84aA=='', [SecurityStamp] = N''aebf592e-a79d-4220-ae42-6b2ef6b7cf43''
    WHERE [Id] = N''E7B47704-8DA0-4657-B42C-849C1C22A6D2'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220821064729_U3A_DefaultTerm')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220821064729_U3A_DefaultTerm', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220823005347_U3A_PersonCommunication')
BEGIN
    ALTER TABLE [Person] ADD [Communication] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220823005347_U3A_PersonCommunication')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''421c91fc-da8b-435b-bcb1-478967d51aa4''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220823005347_U3A_PersonCommunication')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''8a0d68f3-f1d2-4bbb-ae26-1f7de75a778c''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220823005347_U3A_PersonCommunication')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''c64ab925-4da1-411f-b52a-daa1f32b96be''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220823005347_U3A_PersonCommunication')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''d8b3a3f5-5bed-49b0-9c56-99220767c659''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220823005347_U3A_PersonCommunication')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''c31de912-d524-403e-b8cd-48202613f9c1'', [PasswordHash] = N''AQAAAAEAACcQAAAAECyPAxLkmekf913gE3eQZna1Ig+lkoYOH4a6u1RHjtDqAFW2TM42ReoU+aLCFP24Pg=='', [SecurityStamp] = N''d5175263-b906-4006-b421-13fd4b755ecd''
    WHERE [Id] = N''70494634-D7BE-4BE4-8106-031AAE2BC6DC'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220823005347_U3A_PersonCommunication')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''4a20533a-01e9-4ced-afdd-196119010041'', [PasswordHash] = N''AQAAAAEAACcQAAAAELJvARCzGOHvGIkIglul9KTjTpdJ15G7hf3o1wJU9qwOBEDMTYcaMECAP2yT8UaEvQ=='', [SecurityStamp] = N''0b64e070-9a1f-4231-b091-d55aedd91b6f''
    WHERE [Id] = N''753F8F36-D2FF-438E-B5D1-7FF79E4628BD'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220823005347_U3A_PersonCommunication')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''47293ced-4b08-4f2b-97fc-09f3796f1731'', [PasswordHash] = N''AQAAAAEAACcQAAAAEB9d8Eo5SKybuzvrXijZquPk1Wq6JRVetOHTMbStzPO4aQduPwhKhmFfjY4hanhyjA=='', [SecurityStamp] = N''93c26502-6eeb-4871-89e2-cf5a7d1a162b''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220823005347_U3A_PersonCommunication')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''13be5ea4-bae4-4687-b2b2-fa04817d9ba2'', [PasswordHash] = N''AQAAAAEAACcQAAAAEKqp+nXCafMoMtApGZO4esUObktRqsowktCxf5jl8Pw6OITLbuDHgz/r7czWCm05fQ=='', [SecurityStamp] = N''2a67d262-0dc5-408b-9135-7d9dafad581f''
    WHERE [Id] = N''C5E9887D-9C4B-40F5-AB46-2232776005C5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220823005347_U3A_PersonCommunication')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''6921d1c3-e679-45eb-87a1-441f0a5b85c4'', [PasswordHash] = N''AQAAAAEAACcQAAAAEIDM5SHMz5pVXZ/rG0PJZz+PV9cq1HillmQ9vV9MpfoTfDXRSwllaSxoBgAyBYRsOQ=='', [SecurityStamp] = N''310d6799-04d0-4b0a-b692-151d9fa68a72''
    WHERE [Id] = N''E7B47704-8DA0-4657-B42C-849C1C22A6D2'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220823005347_U3A_PersonCommunication')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220823005347_U3A_PersonCommunication', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220823064735_U3A_AddnClassOccurence')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''2b91a1f2-440e-42ca-96da-3aca2df621ce''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220823064735_U3A_AddnClassOccurence')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''8d2c0910-3b7e-40d0-ae19-94d5d48d5a78''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220823064735_U3A_AddnClassOccurence')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''e254e357-8f03-478a-a89b-fcffd429a244''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220823064735_U3A_AddnClassOccurence')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''b8b2df3a-0883-4713-b0d2-1f9cdb7b612b''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220823064735_U3A_AddnClassOccurence')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''3704e32f-127d-47ef-9e97-92e88816f962'', [PasswordHash] = N''AQAAAAEAACcQAAAAEMSEmINbKZocWcf/zrPZb6APu3X/rHWkKS23wBfbzq2tB5CWaBb33c7rUL3ipsvbVA=='', [SecurityStamp] = N''31c8a1ef-9ec0-423a-ae50-a1801ae9719a''
    WHERE [Id] = N''70494634-D7BE-4BE4-8106-031AAE2BC6DC'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220823064735_U3A_AddnClassOccurence')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''3846adf3-4664-4051-9761-0c2f00c3b79d'', [PasswordHash] = N''AQAAAAEAACcQAAAAEE+qBlu/Or9ClN7uCOBz67xMhoDVdnffKSV1tjFyLNXI4AQ1tHVsLx+dr3a4RdKNvQ=='', [SecurityStamp] = N''0e6fdb21-29f3-48ad-88db-46a96ca15562''
    WHERE [Id] = N''753F8F36-D2FF-438E-B5D1-7FF79E4628BD'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220823064735_U3A_AddnClassOccurence')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''790e039a-d94d-492b-a7b1-a45f3a0900ca'', [PasswordHash] = N''AQAAAAEAACcQAAAAEO3Hwj8jYOTD3snR4TMHXxOB/MvME/bNvKrtBYGY5/JKTUzCI7mRN9sfn9Hnsb9+2A=='', [SecurityStamp] = N''5351af17-b349-441d-8c57-cb9a363a5c8c''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220823064735_U3A_AddnClassOccurence')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''3966e30c-09a2-4f4e-a21d-f71c0f8ade14'', [PasswordHash] = N''AQAAAAEAACcQAAAAEPN51N9DXD9jNpkzaWxd++kURNfaVjxRpDU4ciLdnk842otkpHRZdaIP/ZlqW0WGrA=='', [SecurityStamp] = N''fa5cec0b-855d-411f-976b-a8a43ef2177e''
    WHERE [Id] = N''C5E9887D-9C4B-40F5-AB46-2232776005C5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220823064735_U3A_AddnClassOccurence')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''e7fd08f1-928f-47ba-b1b8-53cd9b3c0624'', [PasswordHash] = N''AQAAAAEAACcQAAAAEGc+XIzdVxCdA03vdDZnUVPIDCye/hQIVidLstMbhLZM6M+jXA9pHqvY0wZAEKJECA=='', [SecurityStamp] = N''c48ed0c1-cbe5-4c0e-9b67-d1ccbe374664''
    WHERE [Id] = N''E7B47704-8DA0-4657-B42C-849C1C22A6D2'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220823064735_U3A_AddnClassOccurence')
BEGIN
    EXEC(N'UPDATE [Occurrence] SET [Name] = N''4th Week of Month'', [ShortName] = N''Week 4''
    WHERE [ID] = 7;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220823064735_U3A_AddnClassOccurence')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Name', N'ShortName') AND [object_id] = OBJECT_ID(N'[Occurrence]'))
        SET IDENTITY_INSERT [Occurrence] ON;
    EXEC(N'INSERT INTO [Occurrence] ([ID], [Name], [ShortName])
    VALUES (8, N''Last Week of Month'', N''Last Week''),
    (9, N''Every 5 Weeks'', N''5 Weeks''),
    (10, N''Every 6 Weeks'', N''6 Weeks'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Name', N'ShortName') AND [object_id] = OBJECT_ID(N'[Occurrence]'))
        SET IDENTITY_INSERT [Occurrence] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220823064735_U3A_AddnClassOccurence')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220823064735_U3A_AddnClassOccurence', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220823225311_U3A_RemovePersonDiscontinued')
BEGIN
    DROP INDEX [IX_Person_Discontinued_LastName_FirstName_Email] ON [Person];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220823225311_U3A_RemovePersonDiscontinued')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Person]') AND [c].[name] = N'Discontinued');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Person] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Person] DROP COLUMN [Discontinued];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220823225311_U3A_RemovePersonDiscontinued')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''77c176f0-81be-46ad-b4fd-d0448e070dd7''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220823225311_U3A_RemovePersonDiscontinued')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''b2983e2d-a64a-4c2f-8155-bc0a26096bdc''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220823225311_U3A_RemovePersonDiscontinued')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''37623109-1bf1-4148-a389-42e515f8c081''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220823225311_U3A_RemovePersonDiscontinued')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''b83c56dd-79eb-4cc4-adca-1fda9d57a25c''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220823225311_U3A_RemovePersonDiscontinued')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''3a27924d-c095-436b-8182-6d2e4477b2c6'', [PasswordHash] = N''AQAAAAEAACcQAAAAEB6wWVQCLKA7Cb54R47WJcSSm3QzpfwlOQ0K+VpllaK9w6SEybkv0xv7MAdsQNlrdQ=='', [SecurityStamp] = N''4729e77e-3e66-409c-9c55-e03ab03802be''
    WHERE [Id] = N''70494634-D7BE-4BE4-8106-031AAE2BC6DC'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220823225311_U3A_RemovePersonDiscontinued')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''e8a0ea0c-0ee5-4e7c-80c1-08071b90d232'', [PasswordHash] = N''AQAAAAEAACcQAAAAEBgcekD3vucx8ZOPIiwdxapaFuIceUmIbHn3akVv8ALbYyQsYnwEXEvHxEJjUFod2A=='', [SecurityStamp] = N''708e8bd0-7f00-4afd-91af-a8d4b7063609''
    WHERE [Id] = N''753F8F36-D2FF-438E-B5D1-7FF79E4628BD'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220823225311_U3A_RemovePersonDiscontinued')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''79accddd-d43e-4057-a615-4874f62c710e'', [PasswordHash] = N''AQAAAAEAACcQAAAAEE4XK1Xf6v29DP7qpGmBFTrpbyZBOMQx/laJEvbQWl9YiX+A44zYW6BmkXmNM6Sbhw=='', [SecurityStamp] = N''6474f2f2-da34-4686-9445-47f67d95cb22''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220823225311_U3A_RemovePersonDiscontinued')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''3a020d5f-7df8-4dd5-b26c-058d8981b2d3'', [PasswordHash] = N''AQAAAAEAACcQAAAAEGsdkKPZT4crMFuIDfh9l0LuwtIMnjithfJWiEZC3sbHlSnjParfxs3ULhA/767yvQ=='', [SecurityStamp] = N''41080c3d-7175-4d0e-b557-641757be35f4''
    WHERE [Id] = N''C5E9887D-9C4B-40F5-AB46-2232776005C5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220823225311_U3A_RemovePersonDiscontinued')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''8c19424c-c51f-4244-88d1-55cc12ae0eef'', [PasswordHash] = N''AQAAAAEAACcQAAAAEF8Evk9g7MYspt3iDbVpEp7tplB7duCE5ArgqEhn5pfIsARaDJaNtzJSer7nG21wsA=='', [SecurityStamp] = N''e2799b55-9f3f-4848-ad7f-daba315a4358''
    WHERE [Id] = N''E7B47704-8DA0-4657-B42C-849C1C22A6D2'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220823225311_U3A_RemovePersonDiscontinued')
BEGIN
    CREATE INDEX [IX_Person_LastName_FirstName_Email] ON [Person] ([LastName], [FirstName], [Email]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220823225311_U3A_RemovePersonDiscontinued')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220823225311_U3A_RemovePersonDiscontinued', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220824000648_U3A_RemoveCourseDiscontinued')
BEGIN
    DROP INDEX [IX_Course_Discontinued_Name] ON [Course];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220824000648_U3A_RemoveCourseDiscontinued')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Course]') AND [c].[name] = N'Discontinued');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Course] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Course] DROP COLUMN [Discontinued];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220824000648_U3A_RemoveCourseDiscontinued')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''31894ea6-39fd-4c7a-873c-4a597193aa89''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220824000648_U3A_RemoveCourseDiscontinued')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''95383974-b2e4-4db1-b286-ac1836429a8f''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220824000648_U3A_RemoveCourseDiscontinued')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''881b6787-7039-44fe-8d8f-e554563b5b2b''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220824000648_U3A_RemoveCourseDiscontinued')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''eaa3382f-82b9-4be2-a819-f75002abe65c''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220824000648_U3A_RemoveCourseDiscontinued')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''2aa746f9-25c7-4af7-8cb1-4c00a16cc3ed'', [PasswordHash] = N''AQAAAAEAACcQAAAAEOkac/jcDabU11Tb4G6vNPajcY92DwbYMB00wDeue1R8bhaZvIXlRpI+tHhVLn29Ug=='', [SecurityStamp] = N''a36d5bf8-ea8f-400a-bfeb-745d8fab082d''
    WHERE [Id] = N''70494634-D7BE-4BE4-8106-031AAE2BC6DC'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220824000648_U3A_RemoveCourseDiscontinued')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''0f801905-4316-437f-b3b5-5d3be199d2b2'', [PasswordHash] = N''AQAAAAEAACcQAAAAEOUfL9wvfyE7LHL1tFcBkuyuyPbr5DDddHeIaRLUSZ3+1SXrypPR0rkOGhvCBFc5UQ=='', [SecurityStamp] = N''338f51eb-3f9f-4081-975f-0da5672b3348''
    WHERE [Id] = N''753F8F36-D2FF-438E-B5D1-7FF79E4628BD'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220824000648_U3A_RemoveCourseDiscontinued')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''e99465be-d805-4484-898f-cd18993df746'', [PasswordHash] = N''AQAAAAEAACcQAAAAEOGKyw+tNqJwnQMgEMlrO8qPV59NcpUxz0bOTZ1oaFAnRGfTy4e41lGkfvnTdfpeHw=='', [SecurityStamp] = N''db86ebf2-d259-40fe-b323-4b858de6cc93''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220824000648_U3A_RemoveCourseDiscontinued')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''97cf42a2-cb08-47e3-8685-9ee23d522883'', [PasswordHash] = N''AQAAAAEAACcQAAAAEO6f3XHx8h+an/kmxruXr7LnHzIYG6YvUg4g6yPRe9sch09r7nk/H1DHlowbssrDDA=='', [SecurityStamp] = N''cbde1fa1-12bf-4551-91a9-db4aed7412c3''
    WHERE [Id] = N''C5E9887D-9C4B-40F5-AB46-2232776005C5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220824000648_U3A_RemoveCourseDiscontinued')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''796b6f93-77ad-46db-8315-9a8779b58157'', [PasswordHash] = N''AQAAAAEAACcQAAAAEHlVBe0onWA6YpXiMY+AWK5BNRosJAZKTw01WGv4/A+qjvf0J7WXzpFJhPn2klmXVw=='', [SecurityStamp] = N''63eedf15-d22c-462d-8ccb-ab02cae85440''
    WHERE [Id] = N''E7B47704-8DA0-4657-B42C-849C1C22A6D2'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220824000648_U3A_RemoveCourseDiscontinued')
BEGIN
    CREATE INDEX [IX_Course_Name] ON [Course] ([Name]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220824000648_U3A_RemoveCourseDiscontinued')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220824000648_U3A_RemoveCourseDiscontinued', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220826220449_U3A_EmailTemplate')
BEGIN
    CREATE TABLE [EmailTemplate] (
        [ID] uniqueidentifier NOT NULL,
        [Name] nvarchar(50) NOT NULL,
        [Subject] nvarchar(50) NOT NULL,
        [FromEmailAddress] nvarchar(50) NOT NULL,
        [FromDisplayName] nvarchar(50) NOT NULL,
        [Content] varbinary(max) NOT NULL,
        CONSTRAINT [PK_EmailTemplate] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220826220449_U3A_EmailTemplate')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''a08ec0e3-2609-4f3f-a599-0858cc180032''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220826220449_U3A_EmailTemplate')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''4385c73b-9bbc-4139-9637-da2bd740fc52''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220826220449_U3A_EmailTemplate')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''0151d91d-32ee-4a9f-8487-1f8653d9a95e''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220826220449_U3A_EmailTemplate')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''cbdc0104-c65c-452e-9505-128c77f04175''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220826220449_U3A_EmailTemplate')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''ab81c4cd-294e-49a7-9138-6f1a85063af8'', [PasswordHash] = N''AQAAAAEAACcQAAAAEEpmxGehl5CEnLphJNyUgEX2NbEdN2xt25ep9JmVXJ4u8cJgak9hdG03AERQ5SIPwg=='', [SecurityStamp] = N''1469471f-c3b6-41e1-a4e9-d7f1f3a80ce4''
    WHERE [Id] = N''70494634-D7BE-4BE4-8106-031AAE2BC6DC'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220826220449_U3A_EmailTemplate')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''f6249583-cdb0-47d6-8c82-21720c7fc0e8'', [PasswordHash] = N''AQAAAAEAACcQAAAAEM+VTx1HHHol5cz6E9uf040mp6zb6oJP7NJEIBj2WqCd/wIvXnAuEFznAdHqW/zVzA=='', [SecurityStamp] = N''c10f7c14-a14a-4885-becb-4c3f5da950f1''
    WHERE [Id] = N''753F8F36-D2FF-438E-B5D1-7FF79E4628BD'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220826220449_U3A_EmailTemplate')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''a0f52862-77b6-4da3-ae32-41e9189e5183'', [PasswordHash] = N''AQAAAAEAACcQAAAAEDHzSjXliEqM9lPkQBMg+a1aZ/R8O7seH+ilexKVEvigwp8TkkSFTB1aQcgjdKsdzw=='', [SecurityStamp] = N''57058eec-74a0-4020-930d-c296960e718a''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220826220449_U3A_EmailTemplate')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''865cbb82-4a54-4384-97f2-229be702e684'', [PasswordHash] = N''AQAAAAEAACcQAAAAEPqa9X/u9AF8yh6c7FQCSwz9us5ywrliJ4r9gAewp2MLDRZuhclzbLk9+Kn/YRvOMQ=='', [SecurityStamp] = N''0d2b2202-cdc6-4632-9c97-ce6ee0dedb1f''
    WHERE [Id] = N''C5E9887D-9C4B-40F5-AB46-2232776005C5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220826220449_U3A_EmailTemplate')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''1b5b278f-eb3d-47da-8b8c-349d6893e31a'', [PasswordHash] = N''AQAAAAEAACcQAAAAEDz3ewGXakwM9Zk1xLfdvYTtodANTBB+gVk+vfhO5+B8lvUj4UYXUi2lTIWhlgWO7Q=='', [SecurityStamp] = N''dfa2a1f3-cae2-4042-88ae-b53c49d7996f''
    WHERE [Id] = N''E7B47704-8DA0-4657-B42C-849C1C22A6D2'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220826220449_U3A_EmailTemplate')
BEGIN
    CREATE UNIQUE INDEX [IX_EmailTemplate_Name] ON [EmailTemplate] ([Name]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220826220449_U3A_EmailTemplate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220826220449_U3A_EmailTemplate', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220828235252_U3A_EmailTemplateWithHTML')
BEGIN
    ALTER TABLE [EmailTemplate] ADD [HTML] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220828235252_U3A_EmailTemplateWithHTML')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''316af0a0-14f8-4b5b-81b5-67d0cb5280a5''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220828235252_U3A_EmailTemplateWithHTML')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''c5ee4a5b-cc30-4ec1-a099-38a4c311059d''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220828235252_U3A_EmailTemplateWithHTML')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''4d9a3196-f573-4ad3-a0a2-96ef60be3901''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220828235252_U3A_EmailTemplateWithHTML')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''55b71d75-f5da-41a1-94ee-143a45bcca48''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220828235252_U3A_EmailTemplateWithHTML')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''a4664a8e-172d-4504-964b-bcd40f241858'', [PasswordHash] = N''AQAAAAEAACcQAAAAEPGRYlPuP19SW7gE7GL76z2VtKkudMbZUOXGRfQDX9g4NYvw6DWzmFuVeBgRQOrKpw=='', [SecurityStamp] = N''e13b1257-f589-44ea-a371-a0db928ce467''
    WHERE [Id] = N''70494634-D7BE-4BE4-8106-031AAE2BC6DC'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220828235252_U3A_EmailTemplateWithHTML')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''99a65332-f135-4960-b891-1f38dea7b351'', [PasswordHash] = N''AQAAAAEAACcQAAAAEFTXi31wqCMML0YmM9prZ42Gf3gXmCOts9cr/+k7wDC0RwT/BJtjTAb+NeZ6eWJOtg=='', [SecurityStamp] = N''4da48a06-b145-45e2-854d-02707e86e242''
    WHERE [Id] = N''753F8F36-D2FF-438E-B5D1-7FF79E4628BD'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220828235252_U3A_EmailTemplateWithHTML')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''e119c2b2-d490-4603-b220-56ce94cf9dcc'', [PasswordHash] = N''AQAAAAEAACcQAAAAEGhzu86PQFmhRRsXc6bCIEpdHMgUB1HVi97ZG76b+3qtd4lBIByraQ4R//chvwJEBQ=='', [SecurityStamp] = N''8f39e509-6bf3-401d-be08-a31761f1510f''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220828235252_U3A_EmailTemplateWithHTML')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''a50a1503-03bc-456d-934c-c37b3fff0dde'', [PasswordHash] = N''AQAAAAEAACcQAAAAECbQDd98WHyb88ZLz302r/aLdYfIu/XqOMBMmxR2ivATWUshHpQTX1QX9ELfD/My2Q=='', [SecurityStamp] = N''64aac121-6f83-4862-aa16-5e8f8d79ed6e''
    WHERE [Id] = N''C5E9887D-9C4B-40F5-AB46-2232776005C5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220828235252_U3A_EmailTemplateWithHTML')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''03049e13-26a8-403e-b245-12a7920dcc7a'', [PasswordHash] = N''AQAAAAEAACcQAAAAECcgjFoMnOPpUW0vyA6A1ik26yh0S8MLkCDVFHht6C6RnUXCoP4nkuU8pUQ3D451Zw=='', [SecurityStamp] = N''141fed1d-e3fb-42f1-a0e5-a321e3ca67a8''
    WHERE [Id] = N''E7B47704-8DA0-4657-B42C-849C1C22A6D2'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220828235252_U3A_EmailTemplateWithHTML')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220828235252_U3A_EmailTemplateWithHTML', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220831001431_U3A_EmailHistory')
BEGIN
    CREATE TABLE [EmailHistory] (
        [ID] uniqueidentifier NOT NULL,
        [Service] nvarchar(max) NOT NULL,
        [Sent] datetime2 NOT NULL,
        [From] nvarchar(max) NOT NULL,
        [To] nvarchar(max) NOT NULL,
        [Subject] nvarchar(max) NOT NULL,
        [Status] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_EmailHistory] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220831001431_U3A_EmailHistory')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''1486ad5c-3f8e-4dce-bc05-a6d5cec9d71e''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220831001431_U3A_EmailHistory')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''91f275eb-a7df-47d6-947a-9b3cdca536eb''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220831001431_U3A_EmailHistory')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''5cc26270-3ecf-4def-9695-2fb62447cf0a''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220831001431_U3A_EmailHistory')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''dbff9755-c888-4c48-8be0-f4334b270c5e''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220831001431_U3A_EmailHistory')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''0a1e3266-1fc9-4d4b-a8e5-c82942323d42'', [PasswordHash] = N''AQAAAAEAACcQAAAAECMUEBWOAWt8Z7Mkq3KPd5UHrQ08IrgN+JtteiN2QarOmrwPLn+TJi30bK/K1HgbnQ=='', [SecurityStamp] = N''71084143-7714-4a83-8248-cf2de27ced36''
    WHERE [Id] = N''70494634-D7BE-4BE4-8106-031AAE2BC6DC'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220831001431_U3A_EmailHistory')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''ce634ff6-2904-46df-925d-5123c03f4691'', [PasswordHash] = N''AQAAAAEAACcQAAAAEJ2IMRvhHb8r5mxOT5/AawI8lDNIVS4bXh4Gv2IvO3PhaKpFLHArmdRIhkGPejI7Dg=='', [SecurityStamp] = N''f1bba8f0-05bc-4088-8870-48fdf1fc3f43''
    WHERE [Id] = N''753F8F36-D2FF-438E-B5D1-7FF79E4628BD'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220831001431_U3A_EmailHistory')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''0e7061cb-487e-4e89-827b-9412cb8a7396'', [PasswordHash] = N''AQAAAAEAACcQAAAAEGeiIgGUhbQlDAYeAg9DhZJpG4O90IrwG7CDTRhGYViMMhDEHOrJjhCTph9c/UT0OA=='', [SecurityStamp] = N''42fa9bc8-db9e-4e34-bcf6-aabee662fa74''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220831001431_U3A_EmailHistory')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''a4a0ce2e-e667-4c3a-b078-8a6573c589e5'', [PasswordHash] = N''AQAAAAEAACcQAAAAEJ7Mws/RyutGCPjAMmK0Gp5cTJ4EJQMogNhM5fe8LQKN37aUWVEOaosLJRQA1r7bxA=='', [SecurityStamp] = N''a4169d48-3ccd-4e5d-94b2-d314cb2df03b''
    WHERE [Id] = N''C5E9887D-9C4B-40F5-AB46-2232776005C5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220831001431_U3A_EmailHistory')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''744e133a-26fb-4db2-b9a3-93b837dc5893'', [PasswordHash] = N''AQAAAAEAACcQAAAAEB7WtEGlEGZWxFRp5UKskzgFmuA3iiPe4TIdj8pBR81+AUyh8sJ5SaBsDogj1npPpA=='', [SecurityStamp] = N''06c73ab2-a1c0-4415-9cab-60725fc7deae''
    WHERE [Id] = N''E7B47704-8DA0-4657-B42C-849C1C22A6D2'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220831001431_U3A_EmailHistory')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220831001431_U3A_EmailHistory', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220831065109_U3A_AutoEnrolSettings')
BEGIN
    ALTER TABLE [SystemSettings] ADD [AutoEnrolNewParticipantPercent] decimal(18,2) NOT NULL DEFAULT 0.0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220831065109_U3A_AutoEnrolSettings')
BEGIN
    ALTER TABLE [SystemSettings] ADD [AutoEnrolRemainderMethod] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220831065109_U3A_AutoEnrolSettings')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''b67dc99b-1a0c-4b81-a718-c0d0edff864b''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220831065109_U3A_AutoEnrolSettings')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''6194fe6c-bc03-45ab-8fc9-a5122e71450b''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220831065109_U3A_AutoEnrolSettings')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''28f41a02-3eb2-410b-8ae5-2e9cc89acdc7''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220831065109_U3A_AutoEnrolSettings')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''d7b0f8a4-c048-42dc-9a4d-3c7722a7411c''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220831065109_U3A_AutoEnrolSettings')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''60b1d713-13da-4dce-b395-ddfd59e9b5b5'', [PasswordHash] = N''AQAAAAEAACcQAAAAEIFd9ZJ3lksPMP80MZfjFr7kyOKtcUQdI9JII7aoGUELcvsbhoOfgjQJVIAnYhnpsA=='', [SecurityStamp] = N''cc88c17c-4844-49ae-a625-ddf32e65ea09''
    WHERE [Id] = N''70494634-D7BE-4BE4-8106-031AAE2BC6DC'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220831065109_U3A_AutoEnrolSettings')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''75eb5f55-14ed-4f9f-ad07-e7ef144ed5ad'', [PasswordHash] = N''AQAAAAEAACcQAAAAEF01aN7jPvPKX3Xh17yK7MSjgY+Mf5j2zjsL+wVA8pZh25lbv7z67q3csws0YktvGw=='', [SecurityStamp] = N''88e4ac97-e73b-400f-bbba-c9c604abe876''
    WHERE [Id] = N''753F8F36-D2FF-438E-B5D1-7FF79E4628BD'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220831065109_U3A_AutoEnrolSettings')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''3fa64b5a-d462-4ea7-9d3f-64be76c89874'', [PasswordHash] = N''AQAAAAEAACcQAAAAELxT30A3ce1i/m6CEkwDx7+/uk7Or0R+irbf8pRzsbXFZ2pgzo6p9GHrgU0nNBQGcg=='', [SecurityStamp] = N''2105f348-653d-4032-ab05-a13a98dc6d41''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220831065109_U3A_AutoEnrolSettings')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''1ca55301-7f84-4816-af96-82a623ca0f77'', [PasswordHash] = N''AQAAAAEAACcQAAAAEK2YbWDFlkT1z6fn8zxsOcLfftNVvkIE7KRUYN5tiLDLecnVfRvNOAjY2+cBufX4Ow=='', [SecurityStamp] = N''0b3a1543-31f9-46b4-9745-b8c607659d8b''
    WHERE [Id] = N''C5E9887D-9C4B-40F5-AB46-2232776005C5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220831065109_U3A_AutoEnrolSettings')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''b0404daa-e328-4d66-9c4e-c38d19befed3'', [PasswordHash] = N''AQAAAAEAACcQAAAAEI5LqpJcj3ehKNm8CwsiSHeyHXcKD3sfj8SxELaJ2X8Tui6U4v+dpXX13VZOHHQ2Eg=='', [SecurityStamp] = N''5cf0091c-a693-48c4-8c1e-de2ec3b55ba1''
    WHERE [Id] = N''E7B47704-8DA0-4657-B42C-849C1C22A6D2'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220831065109_U3A_AutoEnrolSettings')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220831065109_U3A_AutoEnrolSettings', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220901020153_U3A_AddedDateEnrolled')
BEGIN
    ALTER TABLE [Enrolment] ADD [DateEnrolled] datetime2 NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220901020153_U3A_AddedDateEnrolled')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''025942d4-57b4-45a8-9099-bc49f50bcf10''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220901020153_U3A_AddedDateEnrolled')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''20a54808-0571-4379-96ba-7a56ecb6de2f''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220901020153_U3A_AddedDateEnrolled')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''656a0651-2fe0-49b4-ac1d-0ae7d3b9bbb7''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220901020153_U3A_AddedDateEnrolled')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''a95d4e0f-5ba9-45be-bec4-76fe6ea79025''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220901020153_U3A_AddedDateEnrolled')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''6c240895-1d79-497a-9b20-f45ac1204bda'', [PasswordHash] = N''AQAAAAEAACcQAAAAEINf0O5prmxBlir7jutFKfuaZwg+FQW4q/elnUSpJ619n7Hz4Wx14pxLVTlz2p+YIQ=='', [SecurityStamp] = N''aac4ee2a-6ee2-4070-820e-2b4012e6a80b''
    WHERE [Id] = N''70494634-D7BE-4BE4-8106-031AAE2BC6DC'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220901020153_U3A_AddedDateEnrolled')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''6163f2ab-1481-4cfa-8db9-31929b4c7e7e'', [PasswordHash] = N''AQAAAAEAACcQAAAAELr6nsi+qpUZ43BqvysEaNk/GMe5XtV+Xoi49yWPGbtr0MmEHP9+WqrSavAfPPGAIQ=='', [SecurityStamp] = N''65d61306-0142-4475-8ced-30d381b7a00c''
    WHERE [Id] = N''753F8F36-D2FF-438E-B5D1-7FF79E4628BD'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220901020153_U3A_AddedDateEnrolled')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''b9def96d-29c9-40e6-b49f-a50b9c26724e'', [PasswordHash] = N''AQAAAAEAACcQAAAAEMCtVIosCl6NXrYwtIoEipOWkHFdqjeVwnRawmHSNrJrBjpqlADjTC3Dy7PHZvZrVQ=='', [SecurityStamp] = N''386f54e4-bcb8-4be0-bfa9-96f8602818d9''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220901020153_U3A_AddedDateEnrolled')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''2fca7756-63dd-4175-920d-ed23cf8c8daa'', [PasswordHash] = N''AQAAAAEAACcQAAAAEON+qvdiKY0KW+hNijYHDKoWBGh4hbekaolC64ciKeL83b19ieUIKc20Whik9qLAmQ=='', [SecurityStamp] = N''71b9020b-9994-4d88-a99a-54d002a5a1ab''
    WHERE [Id] = N''C5E9887D-9C4B-40F5-AB46-2232776005C5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220901020153_U3A_AddedDateEnrolled')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''5a1cab68-2470-45b7-b4cc-616219391af4'', [PasswordHash] = N''AQAAAAEAACcQAAAAEDWXWDusSaNOWIZ6dlAjiJfjtHMcdoDQLNpeDeMSMYFdtxWtfVR4Yno0T8mKpp2SpA=='', [SecurityStamp] = N''518bc317-187d-4da1-9294-7e7211da42d0''
    WHERE [Id] = N''E7B47704-8DA0-4657-B42C-849C1C22A6D2'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220901020153_U3A_AddedDateEnrolled')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220901020153_U3A_AddedDateEnrolled', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220903022302_U3A_Committee')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CourseType]') AND [c].[name] = N'IsVoluntaryActivity');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [CourseType] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [CourseType] DROP COLUMN [IsVoluntaryActivity];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220903022302_U3A_Committee')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AttendanceHistory]') AND [c].[name] = N'IsVountary');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [AttendanceHistory] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [AttendanceHistory] DROP COLUMN [IsVountary];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220903022302_U3A_Committee')
BEGIN
    ALTER TABLE [SystemSettings] ADD [CommitteePositions] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220903022302_U3A_Committee')
BEGIN
    ALTER TABLE [SystemSettings] ADD [VolunteerActivities] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220903022302_U3A_Committee')
BEGIN
    CREATE TABLE [Committee] (
        [ID] uniqueidentifier NOT NULL,
        [Position] nvarchar(450) NOT NULL,
        [PersonID] uniqueidentifier NULL,
        CONSTRAINT [PK_Committee] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_Committee_Person_PersonID] FOREIGN KEY ([PersonID]) REFERENCES [Person] ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220903022302_U3A_Committee')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''82882251-9fdf-46bf-bee6-1c5454cdb49b''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220903022302_U3A_Committee')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''f06bb9d7-446e-415a-871e-12f46c1bd428''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220903022302_U3A_Committee')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''a0546e2c-035d-4c90-9042-fe9371a42c97''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220903022302_U3A_Committee')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''3422237c-b3b1-4d46-bed5-c2c880b5817a''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220903022302_U3A_Committee')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''60261de8-08cf-43d7-97d1-264bbe9674a3'', [PasswordHash] = N''AQAAAAEAACcQAAAAEJQ1CC7sHRi1u7S0pAxw5OlpvgrpNRjQ1trOp5c6CNFI60vhuD4tuxWAV6/fEKfnUQ=='', [SecurityStamp] = N''a1b0ddcd-cfc5-4642-a453-d0d194ba6936''
    WHERE [Id] = N''70494634-D7BE-4BE4-8106-031AAE2BC6DC'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220903022302_U3A_Committee')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''0f6e657a-23d3-4702-b998-30e7e3e54f43'', [PasswordHash] = N''AQAAAAEAACcQAAAAEItCxO6Q/tkjGxFH3NC6IlmDNEm6JojOX7fUnyLGr9bzenqQjc6pqHiY4ZtfnVVhWw=='', [SecurityStamp] = N''0f5f6b5e-abbf-4e6d-99bb-1eaedd2f186b''
    WHERE [Id] = N''753F8F36-D2FF-438E-B5D1-7FF79E4628BD'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220903022302_U3A_Committee')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''c8454b7b-6a51-4ac8-b75f-d8a72a31a6fc'', [PasswordHash] = N''AQAAAAEAACcQAAAAEF3nu9SyID7yYA2AfQRmis2YER6iPvDThyMNBGbgNvMppHbv3/JS921rhXdbZVM05A=='', [SecurityStamp] = N''9a6af015-a2ee-4c1d-9ec9-4e38cafd3117''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220903022302_U3A_Committee')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''0bd01588-ee35-43d3-b376-9a8484abd716'', [PasswordHash] = N''AQAAAAEAACcQAAAAELdEmxT/fNuEmTcv7icUhvNAszRPGu804URpbWQj0t3DjpMP1YzYM+aa3LsTyNNGgQ=='', [SecurityStamp] = N''05675c39-4ef9-45d6-b2ba-2f8115ab7542''
    WHERE [Id] = N''C5E9887D-9C4B-40F5-AB46-2232776005C5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220903022302_U3A_Committee')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''28364fcd-8f49-42b5-92e7-4c2a94e2c237'', [PasswordHash] = N''AQAAAAEAACcQAAAAEH49deQ7uI0ZzFpRxo3DkKQLL3fHY7PRFhy38AXlrQFseSfX0B28OTb/ZWe/No5+1Q=='', [SecurityStamp] = N''5f9bbf89-fd8f-4445-80c2-f651d6b4caea''
    WHERE [Id] = N''E7B47704-8DA0-4657-B42C-849C1C22A6D2'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220903022302_U3A_Committee')
BEGIN
    CREATE INDEX [IX_Committee_PersonID] ON [Committee] ([PersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220903022302_U3A_Committee')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [IX_Committee_Position_PersonID] ON [Committee] ([Position], [PersonID]) WHERE [PersonID] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220903022302_U3A_Committee')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220903022302_U3A_Committee', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220903055005_U3A_Volunteer')
BEGIN
    CREATE TABLE [Volunteer] (
        [ID] uniqueidentifier NOT NULL,
        [Activity] nvarchar(450) NOT NULL,
        [PersonID] uniqueidentifier NOT NULL,
        [Comment] nvarchar(max) NULL,
        CONSTRAINT [PK_Volunteer] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_Volunteer_Person_PersonID] FOREIGN KEY ([PersonID]) REFERENCES [Person] ([ID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220903055005_U3A_Volunteer')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''a5ce351a-91b4-4efd-bcb0-ef201f3e86a0''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220903055005_U3A_Volunteer')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''388a34fa-b02b-4f01-9c0c-df1bc481b2bf''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220903055005_U3A_Volunteer')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''981c6603-3f51-4248-8544-efecb1ce6c97''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220903055005_U3A_Volunteer')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''84f3f994-d84e-4153-9b23-079bb15bafff''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220903055005_U3A_Volunteer')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''6f9a2743-3faf-453d-824e-c7deb9020c90'', [PasswordHash] = N''AQAAAAEAACcQAAAAEAh/R6BGP5n10kCi3sfyAd98MBLvH6Dj8A+6NcsJmJeN4ZBG0J2cIr9CagOzBqHRYA=='', [SecurityStamp] = N''b3a99d43-a7ab-4544-920b-3f6125d98eb7''
    WHERE [Id] = N''70494634-D7BE-4BE4-8106-031AAE2BC6DC'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220903055005_U3A_Volunteer')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''96578c46-e7b8-46b9-80a2-7e0359be5bb0'', [PasswordHash] = N''AQAAAAEAACcQAAAAEGscZ+A86JZOGi0DCa1yz91GlcQ+3sDdAJG4G7wgPBOBMRUMoR3KhfV+PnhQYbbDvA=='', [SecurityStamp] = N''d0febdb2-e532-436b-bc2e-46df2c73c03d''
    WHERE [Id] = N''753F8F36-D2FF-438E-B5D1-7FF79E4628BD'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220903055005_U3A_Volunteer')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''e1953f17-8fee-4c66-8ad0-c76d17990369'', [PasswordHash] = N''AQAAAAEAACcQAAAAEKJpybh6ckm+j3XthS2Gja3bqVJH037pVCFVYUk+7AHoKN3Sn94TfbfNwPuQoCcyig=='', [SecurityStamp] = N''d6d2fcd1-d734-478e-ae52-2abf71b0c10a''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220903055005_U3A_Volunteer')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''624978bc-98c0-488e-ad8b-2e2f07994817'', [PasswordHash] = N''AQAAAAEAACcQAAAAEDRWaecp0n6StAuzQBj6tri5NuhuIPVAwryLAmthW+8yqR8Y5j0uurJIzPdChfw8MA=='', [SecurityStamp] = N''2e65b48e-8b7a-4c55-a8f4-8018b463463e''
    WHERE [Id] = N''C5E9887D-9C4B-40F5-AB46-2232776005C5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220903055005_U3A_Volunteer')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''a9251f3c-af38-429d-bd48-ccce3ccea154'', [PasswordHash] = N''AQAAAAEAACcQAAAAEOhhdn/Xvo4NLjXmHA/0z2JZocOAimGFg+osCf4Vl9Zdrsjfq+/jEbTUqSLMAy65DQ=='', [SecurityStamp] = N''a4cfd4b6-811d-49ed-86e1-4ce82ee313ef''
    WHERE [Id] = N''E7B47704-8DA0-4657-B42C-849C1C22A6D2'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220903055005_U3A_Volunteer')
BEGIN
    CREATE UNIQUE INDEX [IX_Volunteer_Activity_PersonID] ON [Volunteer] ([Activity], [PersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220903055005_U3A_Volunteer')
BEGIN
    CREATE INDEX [IX_Volunteer_PersonID] ON [Volunteer] ([PersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220903055005_U3A_Volunteer')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220903055005_U3A_Volunteer', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220905230015_U3A_DocumentType')
BEGIN
    DROP TABLE [EmailTemplate];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220905230015_U3A_DocumentType')
BEGIN
    CREATE TABLE [DocumentType] (
        [ID] int NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [IsEmail] bit NOT NULL,
        [IsSMS] bit NOT NULL,
        [IsPostal] bit NOT NULL,
        [IsEnrolmentSubDocument] bit NOT NULL,
        [IsREceiptSubDocument] bit NOT NULL,
        CONSTRAINT [PK_DocumentType] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220905230015_U3A_DocumentType')
BEGIN
    CREATE TABLE [DocumentTemplate] (
        [ID] uniqueidentifier NOT NULL,
        [DocumentID] int NOT NULL,
        [DocumentTypeID] int NOT NULL,
        [Name] nvarchar(50) NOT NULL,
        [Subject] nvarchar(50) NOT NULL,
        [FromEmailAddress] nvarchar(50) NOT NULL,
        [FromDisplayName] nvarchar(50) NOT NULL,
        [Content] varbinary(max) NOT NULL,
        [HTML] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_DocumentTemplate] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_DocumentTemplate_DocumentType_DocumentTypeID] FOREIGN KEY ([DocumentTypeID]) REFERENCES [DocumentType] ([ID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220905230015_U3A_DocumentType')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''2c8fe1e6-296f-465d-959d-28df5137593c''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220905230015_U3A_DocumentType')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''68559f96-cc51-4edd-9bd1-5fed5bbee397''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220905230015_U3A_DocumentType')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''b7fa34fe-934f-427d-bc1e-7a56116fa233''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220905230015_U3A_DocumentType')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''f1017795-524a-4162-be90-254ea752e9b0''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220905230015_U3A_DocumentType')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''c754ad7b-90d7-411f-8327-ec773cfc311e'', [PasswordHash] = N''AQAAAAEAACcQAAAAEEmENoPq9Pcfg42qcv3phKWgpKtxl4XDOnH1VhZvyZ24rF5G+4PMLoElbeMX5E0sxg=='', [SecurityStamp] = N''5e303100-7790-479f-ad20-1c2c7f2f3dd6''
    WHERE [Id] = N''70494634-D7BE-4BE4-8106-031AAE2BC6DC'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220905230015_U3A_DocumentType')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''ad56d999-a73e-4115-aee6-3a55949b1ca6'', [PasswordHash] = N''AQAAAAEAACcQAAAAECSNruCkHUGLrj1YMjbftIcgMvn2ydLS/FHkFyl3vWA7iz1ChHcbU02fM0bztaLC2A=='', [SecurityStamp] = N''87ff8471-4f80-4248-940a-e5bdc2c72c41''
    WHERE [Id] = N''753F8F36-D2FF-438E-B5D1-7FF79E4628BD'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220905230015_U3A_DocumentType')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''85cd1667-880b-4ed6-ad20-df41627eacd9'', [PasswordHash] = N''AQAAAAEAACcQAAAAEGvn95lY9siuRgPdrR7QYUZY1YKTSjrh60siWI7Yr+FYhCdmAVthxA0t+D1qUZXYpQ=='', [SecurityStamp] = N''181b0a48-f021-4999-8a4c-38e13e5c5932''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220905230015_U3A_DocumentType')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''3597fb52-cb71-4476-bd15-964e5f94f402'', [PasswordHash] = N''AQAAAAEAACcQAAAAEAIR+LArVrttVPCOkFvO34xbYpb/GFeLRs2tQzNmYmDzRNX+WgAuxfBQ6qgoikC09g=='', [SecurityStamp] = N''8b907f96-8a7a-4a46-a8e5-2c8ad18309ec''
    WHERE [Id] = N''C5E9887D-9C4B-40F5-AB46-2232776005C5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220905230015_U3A_DocumentType')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''b2b7e78e-cfc6-48b9-a1e1-4bc7e2696c8c'', [PasswordHash] = N''AQAAAAEAACcQAAAAEGRzg+rUAAm5LldTQIc88sd+Tt1sHjam5L1KZbnOuT3YR8MwgYMoRE8gyNk1pBPnBw=='', [SecurityStamp] = N''81676ee4-7920-43e6-87db-ee90c83ccb1e''
    WHERE [Id] = N''E7B47704-8DA0-4657-B42C-849C1C22A6D2'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220905230015_U3A_DocumentType')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'IsEmail', N'IsEnrolmentSubDocument', N'IsPostal', N'IsREceiptSubDocument', N'IsSMS', N'Name') AND [object_id] = OBJECT_ID(N'[DocumentType]'))
        SET IDENTITY_INSERT [DocumentType] ON;
    EXEC(N'INSERT INTO [DocumentType] ([ID], [IsEmail], [IsEnrolmentSubDocument], [IsPostal], [IsREceiptSubDocument], [IsSMS], [Name])
    VALUES (0, CAST(1 AS bit), CAST(0 AS bit), CAST(0 AS bit), CAST(0 AS bit), CAST(0 AS bit), N''Email''),
    (1, CAST(0 AS bit), CAST(0 AS bit), CAST(1 AS bit), CAST(0 AS bit), CAST(0 AS bit), N''Postal''),
    (2, CAST(0 AS bit), CAST(0 AS bit), CAST(0 AS bit), CAST(0 AS bit), CAST(1 AS bit), N''SMS''),
    (3, CAST(0 AS bit), CAST(1 AS bit), CAST(0 AS bit), CAST(0 AS bit), CAST(0 AS bit), N''EnrolmentSubdoc''),
    (4, CAST(0 AS bit), CAST(0 AS bit), CAST(0 AS bit), CAST(1 AS bit), CAST(0 AS bit), N''ReceiptSubdoc'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'IsEmail', N'IsEnrolmentSubDocument', N'IsPostal', N'IsREceiptSubDocument', N'IsSMS', N'Name') AND [object_id] = OBJECT_ID(N'[DocumentType]'))
        SET IDENTITY_INSERT [DocumentType] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220905230015_U3A_DocumentType')
BEGIN
    CREATE INDEX [IX_DocumentTemplate_DocumentTypeID] ON [DocumentTemplate] ([DocumentTypeID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220905230015_U3A_DocumentType')
BEGIN
    CREATE UNIQUE INDEX [IX_DocumentTemplate_Name] ON [DocumentTemplate] ([Name]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220905230015_U3A_DocumentType')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220905230015_U3A_DocumentType', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220906015610_U3A_DocumentTemplateNullSubject')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DocumentTemplate]') AND [c].[name] = N'Subject');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [DocumentTemplate] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [DocumentTemplate] ALTER COLUMN [Subject] nvarchar(50) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220906015610_U3A_DocumentTemplateNullSubject')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''82f6cd28-bd42-400c-a307-bebfce6e2e38''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220906015610_U3A_DocumentTemplateNullSubject')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''28bc09d0-9c7e-41fb-b683-2d7aab1447a8''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220906015610_U3A_DocumentTemplateNullSubject')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''3b38003a-7761-42bd-b537-07badda92a80''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220906015610_U3A_DocumentTemplateNullSubject')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''8fec3347-ef12-4d38-9918-98cdc4d15877''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220906015610_U3A_DocumentTemplateNullSubject')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''112c47fa-9494-4102-ba1b-dc7896508fc8'', [PasswordHash] = N''AQAAAAEAACcQAAAAEHU3d038qA11iv2AFMAzHsjJqLz9a1TZKU9BmxIRg95I834vLCtrTuPXlOefnwMQNQ=='', [SecurityStamp] = N''bd3eb18e-0e19-4c94-8e26-49b901f04464''
    WHERE [Id] = N''70494634-D7BE-4BE4-8106-031AAE2BC6DC'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220906015610_U3A_DocumentTemplateNullSubject')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''de99497c-6fc4-40cb-bbad-829305109e62'', [PasswordHash] = N''AQAAAAEAACcQAAAAEHME9VwOQUOd0CvdY3D9ESiNvpqXT13po2Dzm9cjSmqXQn+zTe5Agsu3K4nBx/f77g=='', [SecurityStamp] = N''dece1797-4312-41b4-975f-b2433eee3e4a''
    WHERE [Id] = N''753F8F36-D2FF-438E-B5D1-7FF79E4628BD'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220906015610_U3A_DocumentTemplateNullSubject')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''46fed95b-6ef5-4662-a2c1-63d5e32f4660'', [PasswordHash] = N''AQAAAAEAACcQAAAAELVRpxLG049IycPPHuyn1RaOPgDAPqHBE8K9qdrA1y7MtFXfP6UoDhkWL1VnyiGJOA=='', [SecurityStamp] = N''df864240-e7f0-4821-90dc-ca49b813f683''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220906015610_U3A_DocumentTemplateNullSubject')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''83b5c0ec-1418-4598-bca6-0a39981243ae'', [PasswordHash] = N''AQAAAAEAACcQAAAAEMzTr5Na5z4GpCEaVSzn7aHH4gXg8h6t+xbAWciK1aAQAWyk+CkOZdKsAPbYkN/xgA=='', [SecurityStamp] = N''913e935f-850c-475d-8511-3ece4ddc9c0f''
    WHERE [Id] = N''C5E9887D-9C4B-40F5-AB46-2232776005C5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220906015610_U3A_DocumentTemplateNullSubject')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''8fa921db-b2b1-407f-aa67-c5dd96b0ad43'', [PasswordHash] = N''AQAAAAEAACcQAAAAEExY32i+pSa2mlR5wqEHLCy3aAEPfrl/DtjVmeadV+e7Ee4X0lc7cxso/mdxABM8Fw=='', [SecurityStamp] = N''fabe1cc3-e78e-45af-9216-abcad62651ac''
    WHERE [Id] = N''E7B47704-8DA0-4657-B42C-849C1C22A6D2'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220906015610_U3A_DocumentTemplateNullSubject')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220906015610_U3A_DocumentTemplateNullSubject', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220907063013_U3A_DocumentTemplateDocumentTypeID')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DocumentTemplate]') AND [c].[name] = N'DocumentID');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [DocumentTemplate] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [DocumentTemplate] DROP COLUMN [DocumentID];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220907063013_U3A_DocumentTemplateDocumentTypeID')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''5a637265-d83b-40e3-a3ec-c2188bb7358b''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220907063013_U3A_DocumentTemplateDocumentTypeID')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''b6b1eb70-fc5a-435d-b02f-8e7355e493c5''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220907063013_U3A_DocumentTemplateDocumentTypeID')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''5c7fb366-bdf9-4f9f-aa11-2609596149c2''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220907063013_U3A_DocumentTemplateDocumentTypeID')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''5760b207-157b-4a76-a098-6ff566d01bc8''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220907063013_U3A_DocumentTemplateDocumentTypeID')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''b6af0e50-c234-4821-8347-a9a132cae245'', [PasswordHash] = N''AQAAAAEAACcQAAAAEDcA6kfLD//TApKD5wym04rdOltsjY+Z9biJqtls3cmlr7a5iWQk6LOj3JbNMHn3Tw=='', [SecurityStamp] = N''2c200dbc-c335-4ec5-aa72-e53bd5ef498d''
    WHERE [Id] = N''70494634-D7BE-4BE4-8106-031AAE2BC6DC'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220907063013_U3A_DocumentTemplateDocumentTypeID')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''deab335e-a31f-4922-887f-0bd3809fa326'', [PasswordHash] = N''AQAAAAEAACcQAAAAEHhHWMuf5De3PenH2NA1SLphNEqOnEVscqO2xm1flEbU2X95QtRdWFkOI3Iia6qp1A=='', [SecurityStamp] = N''18c7a191-94b1-42ac-bcfc-052ec3d1a8fc''
    WHERE [Id] = N''753F8F36-D2FF-438E-B5D1-7FF79E4628BD'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220907063013_U3A_DocumentTemplateDocumentTypeID')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''d95df8d7-6c55-4d75-85d6-2989dd36fb1a'', [PasswordHash] = N''AQAAAAEAACcQAAAAEH36lWIuJs4mu5d2XBAW0srJ2XCNS0lFpSJSE7oS7LatrP64XFYOn03GoLN8FCTxMQ=='', [SecurityStamp] = N''a1f78fb2-d68f-4a49-9b5a-5963814b64b7''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220907063013_U3A_DocumentTemplateDocumentTypeID')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''12426115-e0a3-4fed-83aa-3128e126113d'', [PasswordHash] = N''AQAAAAEAACcQAAAAEGz6L8hRfLAWHPC6/fqKClTwusZAudrPvNq0rOnh/LTD7cExU/tvascAAiaMbpp21Q=='', [SecurityStamp] = N''0df9208a-2275-48b8-b74f-c403d95efdc3''
    WHERE [Id] = N''C5E9887D-9C4B-40F5-AB46-2232776005C5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220907063013_U3A_DocumentTemplateDocumentTypeID')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''dee5c685-f4e5-41bb-a7ed-5453ac6739a1'', [PasswordHash] = N''AQAAAAEAACcQAAAAEH6uqx7iW9bToEIp91bAWy/pJ/x6jih4lE3pj/67bnXbibLw3Lzr8XvVsGGUtghHpA=='', [SecurityStamp] = N''a23fabf2-16f3-4782-98e1-4a033b6c3854''
    WHERE [Id] = N''E7B47704-8DA0-4657-B42C-849C1C22A6D2'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220907063013_U3A_DocumentTemplateDocumentTypeID')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220907063013_U3A_DocumentTemplateDocumentTypeID', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220908214823_U3A_DocumentTemplateRemoveNotNull')
BEGIN
    ALTER TABLE [DocumentTemplate] DROP CONSTRAINT [FK_DocumentTemplate_DocumentType_DocumentTypeID];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220908214823_U3A_DocumentTemplateRemoveNotNull')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DocumentTemplate]') AND [c].[name] = N'FromEmailAddress');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [DocumentTemplate] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [DocumentTemplate] ALTER COLUMN [FromEmailAddress] nvarchar(50) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220908214823_U3A_DocumentTemplateRemoveNotNull')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DocumentTemplate]') AND [c].[name] = N'FromDisplayName');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [DocumentTemplate] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [DocumentTemplate] ALTER COLUMN [FromDisplayName] nvarchar(50) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220908214823_U3A_DocumentTemplateRemoveNotNull')
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DocumentTemplate]') AND [c].[name] = N'DocumentTypeID');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [DocumentTemplate] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [DocumentTemplate] ALTER COLUMN [DocumentTypeID] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220908214823_U3A_DocumentTemplateRemoveNotNull')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''8a66e81d-ee2e-4670-81bd-249b224a68eb''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220908214823_U3A_DocumentTemplateRemoveNotNull')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''eed1167d-a03e-4c63-9525-00866b6270ae''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220908214823_U3A_DocumentTemplateRemoveNotNull')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''fa2f561c-ef62-4d03-aae2-341cbda9f1a1''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220908214823_U3A_DocumentTemplateRemoveNotNull')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''4df236a8-022f-430f-8568-92320430a1ec''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220908214823_U3A_DocumentTemplateRemoveNotNull')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''070fbf18-ed04-4406-9801-ba3d8699923f'', [PasswordHash] = N''AQAAAAEAACcQAAAAEL2JZi3l74FHIMP0XevsmtlkDAqZIXXAO7z7VLAG2QwjGEK1NVQqkwt7Kec1Sesx0A=='', [SecurityStamp] = N''82172567-f591-445e-b6d3-bd3a221e49f0''
    WHERE [Id] = N''70494634-D7BE-4BE4-8106-031AAE2BC6DC'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220908214823_U3A_DocumentTemplateRemoveNotNull')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''7fe2a849-76b2-410d-b1c5-96d508d62912'', [PasswordHash] = N''AQAAAAEAACcQAAAAEBbSC5W8m1+KNVMpU1B3vN5MwRY11whXR4/SahEQ9srBJPtyW1wSlc8VfNTDhHDr9g=='', [SecurityStamp] = N''76269935-8e44-4339-abc5-a042b35559e1''
    WHERE [Id] = N''753F8F36-D2FF-438E-B5D1-7FF79E4628BD'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220908214823_U3A_DocumentTemplateRemoveNotNull')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''39f68e71-f0f4-42d5-a526-672c97745cbe'', [PasswordHash] = N''AQAAAAEAACcQAAAAEGd5ugzcUfwU8ZiqDRc06r4eBPgP1Ya/hWdz7pYVpXq7UZwd2LQTXQScwBLMBeuyeA=='', [SecurityStamp] = N''881d9fa2-ed4a-43d5-ada0-6b86e596d75d''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220908214823_U3A_DocumentTemplateRemoveNotNull')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''7d3cfc21-3f42-4dc9-a52a-02e5f383cfec'', [PasswordHash] = N''AQAAAAEAACcQAAAAEKiXaTXlhWORz7YmqfipUGilDLtMYllH9VY9qXpA6IojAje8b+S2EMcnltRPD1zMZg=='', [SecurityStamp] = N''4faf6eb6-4f15-4d16-8fc0-879989f846e1''
    WHERE [Id] = N''C5E9887D-9C4B-40F5-AB46-2232776005C5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220908214823_U3A_DocumentTemplateRemoveNotNull')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''c46882fe-250b-43fb-9e6e-0cd95fedc505'', [PasswordHash] = N''AQAAAAEAACcQAAAAEE0NzxcIS6NGyPGl8lhR++99IXCpKJEkBZC8AlUPEMtRCFW4zuD5j+cYFZ9pe+KYaw=='', [SecurityStamp] = N''69f7309b-4265-43cb-9293-bb3db85f3f16''
    WHERE [Id] = N''E7B47704-8DA0-4657-B42C-849C1C22A6D2'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220908214823_U3A_DocumentTemplateRemoveNotNull')
BEGIN
    ALTER TABLE [DocumentTemplate] ADD CONSTRAINT [FK_DocumentTemplate_DocumentType_DocumentTypeID] FOREIGN KEY ([DocumentTypeID]) REFERENCES [DocumentType] ([ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220908214823_U3A_DocumentTemplateRemoveNotNull')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220908214823_U3A_DocumentTemplateRemoveNotNull', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913213917_U3A_PersonImport')
BEGIN
    ALTER TABLE [Person] ADD [SMSOptOut] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913213917_U3A_PersonImport')
BEGIN
    CREATE TABLE [PersonImport] (
        [ID] uniqueidentifier NOT NULL,
        [FirstName] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        [Address] nvarchar(max) NOT NULL,
        [City] nvarchar(max) NOT NULL,
        [State] nvarchar(max) NOT NULL,
        [Postcode] int NOT NULL,
        [Gender] nvarchar(max) NOT NULL,
        [BirthDate] datetime2 NULL,
        [Email] nvarchar(max) NULL,
        [HomePhone] nvarchar(max) NULL,
        [Mobile] nvarchar(max) NULL,
        [SMSOptOut] bit NOT NULL,
        [ICEContact] nvarchar(max) NULL,
        [ICEPhone] nvarchar(max) NULL,
        [VaxCertificateViewed] bit NOT NULL,
        [Occupation] nvarchar(max) NULL,
        [Communication] nvarchar(max) NOT NULL,
        [IsNewPerosn] bit NOT NULL,
        [CourseChoice01] int NOT NULL,
        [CourseChoice02] int NOT NULL,
        [CourseChoice03] int NOT NULL,
        [CourseChoice04] int NOT NULL,
        [CourseChoice05] int NOT NULL,
        [CourseChoice06] int NOT NULL,
        CONSTRAINT [PK_PersonImport] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913213917_U3A_PersonImport')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''44579b75-73e2-437e-8624-a9391289e062''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913213917_U3A_PersonImport')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''67506096-e13f-4e57-9fa9-c5cc71664600''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913213917_U3A_PersonImport')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''3ff92d5a-e52a-4735-b55c-78aea44def96''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913213917_U3A_PersonImport')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''b6961609-a34b-4730-8f10-af0333fb2eda''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913213917_U3A_PersonImport')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''84d131b3-cfc8-4210-83ed-10a5e4e1e3a3'', [PasswordHash] = N''AQAAAAEAACcQAAAAEBx+x+8iig2EpJudNExWjL4XKA9H4Sab/0xumMBWOxQzsP3QHIp5DB1oj/C8dOi0Lw=='', [SecurityStamp] = N''bf1074e6-2cf1-4527-bcd0-27a1330b5fa4''
    WHERE [Id] = N''70494634-D7BE-4BE4-8106-031AAE2BC6DC'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913213917_U3A_PersonImport')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''4b0b301b-e065-4eaa-b11c-d8b35c9d6e4c'', [PasswordHash] = N''AQAAAAEAACcQAAAAELtTEv9295Db9GI8pZoq8NDI54YLaFqt/ILJG2++UszengnjtS+jXj3Iy5kcpRy4ig=='', [SecurityStamp] = N''005c7f71-ddf9-4ce0-81ab-20fb2e349746''
    WHERE [Id] = N''753F8F36-D2FF-438E-B5D1-7FF79E4628BD'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913213917_U3A_PersonImport')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''ed11e8bb-7ddd-4007-936f-4cfa2936c88d'', [PasswordHash] = N''AQAAAAEAACcQAAAAEEkoquFL5rEZrMxIECh12Q8zzc6Vla67ildOz5E9u3+Wd8L6mMWYQ2DWnaTI4eRvfg=='', [SecurityStamp] = N''dcf41fad-f1d7-4cdd-b593-8fed221e88a6''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913213917_U3A_PersonImport')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''dd2647a5-5505-4455-8ed4-70c3757d403d'', [PasswordHash] = N''AQAAAAEAACcQAAAAEMg4nZfiFLQRY0sgGiy9U2OWQ/psbf6/DBU5LvBLIxt0m4pfsZa7hFNeSBWHcFRIcg=='', [SecurityStamp] = N''8fa9a509-16e2-4a58-add1-975e6c37edcb''
    WHERE [Id] = N''C5E9887D-9C4B-40F5-AB46-2232776005C5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913213917_U3A_PersonImport')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''5f7066fd-490f-4d3c-8933-b94f5bbfb634'', [PasswordHash] = N''AQAAAAEAACcQAAAAEMkOztywuDG5GR4txz0KeLJQ5vQ6AfUHSn4LQ/BTg530M5oGAFr7RtBgpauGN0Jz7w=='', [SecurityStamp] = N''fb5124f8-14e1-4cba-bfd3-a7d4efa1784f''
    WHERE [Id] = N''E7B47704-8DA0-4657-B42C-849C1C22A6D2'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913213917_U3A_PersonImport')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220913213917_U3A_PersonImport', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914080048_U3A_PersonImportDateJoined')
BEGIN
    EXEC sp_rename N'[PersonImport].[IsNewPerosn]', N'IsNewPerson', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914080048_U3A_PersonImportDateJoined')
BEGIN
    ALTER TABLE [PersonImport] ADD [DateJoined] datetime2 NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914080048_U3A_PersonImportDateJoined')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''4372a829-b75d-4ed6-8276-4590c1a7606b''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914080048_U3A_PersonImportDateJoined')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''87d3010b-9322-436a-a62e-f4255fade2cd''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914080048_U3A_PersonImportDateJoined')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''b1a896c8-bba0-4e69-ae68-253328f9b31e''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914080048_U3A_PersonImportDateJoined')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''ccfd0d75-c9cc-41f2-93a8-2c728a7e3868''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914080048_U3A_PersonImportDateJoined')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''2e57334c-cf4c-4d88-bc10-63089c978074'', [PasswordHash] = N''AQAAAAEAACcQAAAAEK2qXWvsTNYFyQRURfLo0sVbAtR7wWVRAAjknxgmsx4gfpdwfqehervJqI55re63Ow=='', [SecurityStamp] = N''12f34fde-2b92-4b55-944b-258d87b1ab9d''
    WHERE [Id] = N''70494634-D7BE-4BE4-8106-031AAE2BC6DC'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914080048_U3A_PersonImportDateJoined')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''e256b6ee-f2a4-48cb-b1f0-6a7f71f91adf'', [PasswordHash] = N''AQAAAAEAACcQAAAAEO2EfIAvPyxN2n6uOUwTHQY1z9IALjf1EecgpsuChsLTSIvBM8qz3Eel4HzBjyGsTA=='', [SecurityStamp] = N''4ada61ac-1da1-45a8-a057-3948d001be0e''
    WHERE [Id] = N''753F8F36-D2FF-438E-B5D1-7FF79E4628BD'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914080048_U3A_PersonImportDateJoined')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''1b1d3fce-e8f2-45e2-9885-db6d7e17e5df'', [PasswordHash] = N''AQAAAAEAACcQAAAAEC6Tv4cn2VteZj1ekTp48mFfMHef4k4nL9FybFs3JJj/ymsJ6RblhKuODANGotCjkA=='', [SecurityStamp] = N''8ce658df-d855-4d6a-9f42-809c64901c4b''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914080048_U3A_PersonImportDateJoined')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''b7643c52-b99e-44d8-abe6-dc1c2d6ecda4'', [PasswordHash] = N''AQAAAAEAACcQAAAAEIEpnF6pjcrqmZG5qwYcD3cPQnw5g/6GA1z3e06O9xZjnBSMCGaqhs9VsPWbFDGMlw=='', [SecurityStamp] = N''4a9a95bd-8ff7-4bee-a732-9a6846438e86''
    WHERE [Id] = N''C5E9887D-9C4B-40F5-AB46-2232776005C5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914080048_U3A_PersonImportDateJoined')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''6d385d23-ea8e-41a1-959a-4c84d6eee2a8'', [PasswordHash] = N''AQAAAAEAACcQAAAAECdxib4BkbfQmf6l1MrTUHHqtBpsmog7YwEeN2DzaiAAUFhYjku0Eflo8csbmuF0pQ=='', [SecurityStamp] = N''8b226b9a-972c-4a5c-88ee-98419507a655''
    WHERE [Id] = N''E7B47704-8DA0-4657-B42C-849C1C22A6D2'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914080048_U3A_PersonImportDateJoined')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220914080048_U3A_PersonImportDateJoined', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914224221_U3A_PersonImportIndex')
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PersonImport]') AND [c].[name] = N'LastName');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [PersonImport] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [PersonImport] ALTER COLUMN [LastName] nvarchar(450) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914224221_U3A_PersonImportIndex')
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PersonImport]') AND [c].[name] = N'FirstName');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [PersonImport] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [PersonImport] ALTER COLUMN [FirstName] nvarchar(450) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914224221_U3A_PersonImportIndex')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''ca1c4543-1dd5-495b-a197-dec78d8622e3''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914224221_U3A_PersonImportIndex')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''2f683dd2-4a0b-47ce-9008-942cce9ce01a''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914224221_U3A_PersonImportIndex')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''1ff94ef3-99b0-43fb-8fba-6c59293da8d7''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914224221_U3A_PersonImportIndex')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''620f0895-c8a1-491f-bc90-2ed4c8ad0e54''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914224221_U3A_PersonImportIndex')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''5e45fd82-fba0-4104-bf5d-82ab7b220e46'', [PasswordHash] = N''AQAAAAEAACcQAAAAELdLHZj7Ct1uWVIGV5KKFmIbQHQK//4rwQFhRNSiar45psa0PhqOZy9HQtKw5yHhWg=='', [SecurityStamp] = N''643fa36f-5f62-46b8-b83a-da6c93710a5d''
    WHERE [Id] = N''70494634-D7BE-4BE4-8106-031AAE2BC6DC'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914224221_U3A_PersonImportIndex')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''763045c2-1f18-42a3-9fe0-e1d535b24267'', [PasswordHash] = N''AQAAAAEAACcQAAAAEE2jxiDwQRr5xY85uXRvBfkA1Ukz1PmfbaCqXmyYiP79Oqh2OhZomGZFWosD4dV6aw=='', [SecurityStamp] = N''2ef63b9f-9f79-468c-b845-5441ac7abf8c''
    WHERE [Id] = N''753F8F36-D2FF-438E-B5D1-7FF79E4628BD'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914224221_U3A_PersonImportIndex')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''9a775cd1-0856-4252-bc9d-d795865aafbf'', [PasswordHash] = N''AQAAAAEAACcQAAAAEEyNgVHotIW2hqhXxte7uOAm8a4dO5bjYB9xItCT3EcOavoKWmHjsWwruGgPoCWYlQ=='', [SecurityStamp] = N''3173e774-f19b-476b-92e3-3f2c4bb0a585''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914224221_U3A_PersonImportIndex')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''13810a89-e8dd-49c0-8411-27be732b9356'', [PasswordHash] = N''AQAAAAEAACcQAAAAEAlmrn6wE/sTMfWVCUhEQLrp1BUNe3m3j1QzR31+LugaQTEO5r/W6p5Ahf8HNVpIcA=='', [SecurityStamp] = N''512da8ca-2a9d-4783-a27c-10a2860aa932''
    WHERE [Id] = N''C5E9887D-9C4B-40F5-AB46-2232776005C5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914224221_U3A_PersonImportIndex')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''aeb10266-8321-4765-aaff-299cdc376381'', [PasswordHash] = N''AQAAAAEAACcQAAAAEL8F9h2mgZyOLkoLLcrJlVIgdRymI18gh/0y8oe+hzpIdbxI+BitgGsUhwmhdEzXJQ=='', [SecurityStamp] = N''45fc8c3f-a75a-490a-99cf-d5ae3aaf338b''
    WHERE [Id] = N''E7B47704-8DA0-4657-B42C-849C1C22A6D2'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914224221_U3A_PersonImportIndex')
BEGIN
    CREATE INDEX [IX_PersonImport_LastName_FirstName_IsNewPerson] ON [PersonImport] ([LastName], [FirstName], [IsNewPerson]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914224221_U3A_PersonImportIndex')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220914224221_U3A_PersonImportIndex', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220915203410_U3A_PersonImportStudentID')
BEGIN
    ALTER TABLE [PersonImport] ADD [CurrentStudentID] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220915203410_U3A_PersonImportStudentID')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''c23abc15-cf81-4304-961d-310e08f011b2''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220915203410_U3A_PersonImportStudentID')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''c8471077-d449-4781-b691-f3b29783119f''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220915203410_U3A_PersonImportStudentID')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''fadcae80-85fc-4743-a70a-a74ba96d87a6''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220915203410_U3A_PersonImportStudentID')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''68da9343-8dfe-423c-9987-e8b8e792bfe5''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220915203410_U3A_PersonImportStudentID')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''f6d005cc-4718-446b-a359-9203d5311a21'', [PasswordHash] = N''AQAAAAEAACcQAAAAEN80Jm7eBhuYGDp4QEpyzCcW/BzL96CiZ+iYaXFLsVB8aBy8GtnfNUXLBD3s0sKLAw=='', [SecurityStamp] = N''b12e0443-4398-4328-8be5-b07e4c0ea223''
    WHERE [Id] = N''70494634-D7BE-4BE4-8106-031AAE2BC6DC'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220915203410_U3A_PersonImportStudentID')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''12221abc-dc73-4db6-a63f-726f6ae5071c'', [PasswordHash] = N''AQAAAAEAACcQAAAAEDjN88BzjW+lx0SseZb7HuR3uDqn9gDP4OAwKb6W+A9ZN1gSGbnXG63rscrUb7XuFw=='', [SecurityStamp] = N''eb1ac9d4-3751-4235-88ef-97b522731b85''
    WHERE [Id] = N''753F8F36-D2FF-438E-B5D1-7FF79E4628BD'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220915203410_U3A_PersonImportStudentID')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''9c980c1a-bdc7-4d60-87fd-7e145c49eb7c'', [PasswordHash] = N''AQAAAAEAACcQAAAAELQxVt84Z4HyodZhRdwgM1Kv2x/AyskmZb5BWHzK1jLr82ndS2bCwNlMHYkOL+FsGw=='', [SecurityStamp] = N''9f6fbbc5-b709-4d54-9baa-546bdda594b8''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220915203410_U3A_PersonImportStudentID')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''c34e292a-449c-4621-b0c7-f9698d29b768'', [PasswordHash] = N''AQAAAAEAACcQAAAAEBsbt5L7fLL6tCreeE4mVwsPdVq47FIfJ9Wm50hdrLbacu/nZRWEV8EVK3/NurTSXQ=='', [SecurityStamp] = N''aaefda20-4b18-44e5-9627-6acc9c085e5a''
    WHERE [Id] = N''C5E9887D-9C4B-40F5-AB46-2232776005C5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220915203410_U3A_PersonImportStudentID')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''219cc141-1d81-487b-a5ec-e336c8e5ff54'', [PasswordHash] = N''AQAAAAEAACcQAAAAEOJz6WPV2TgpxwZr9BPwfoEt5inUdNsBRatMcVIi0N167mPrVXnGwwjphXY9j5i4sg=='', [SecurityStamp] = N''6874da9d-5eb6-433e-8777-8b0de2b519fc''
    WHERE [Id] = N''E7B47704-8DA0-4657-B42C-849C1C22A6D2'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220915203410_U3A_PersonImportStudentID')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220915203410_U3A_PersonImportStudentID', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220916052700_U3A_PersonBaseEntity')
BEGIN
    ALTER TABLE [Person] ADD [CreatedOn] datetime2 NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220916052700_U3A_PersonBaseEntity')
BEGIN
    ALTER TABLE [Person] ADD [UpdatedOn] datetime2 NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220916052700_U3A_PersonBaseEntity')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''42e4d7e3-4327-424d-b21a-bba6dc6b6949''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220916052700_U3A_PersonBaseEntity')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''ee125e7e-7e66-4156-8d66-9377a1d00fc8''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220916052700_U3A_PersonBaseEntity')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''7636ffb8-5ea9-47c6-860b-63116d7b9b7c''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220916052700_U3A_PersonBaseEntity')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''5909be24-7cff-4474-b55c-978f9d9e4e30''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220916052700_U3A_PersonBaseEntity')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''7d4f136a-8bac-43f9-9067-56f7b3b6124c'', [PasswordHash] = N''AQAAAAEAACcQAAAAEHqdkQdC/B6W/Vt7fDv/RLFTaTZ2hdodh6LPWVoF6DZrXhQDypYU5tgcJHUGrLFd7g=='', [SecurityStamp] = N''b4b0fd81-b301-46f3-addb-4ca796ec540c''
    WHERE [Id] = N''70494634-D7BE-4BE4-8106-031AAE2BC6DC'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220916052700_U3A_PersonBaseEntity')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''22222943-4a06-404b-b156-208f2f7ceb50'', [PasswordHash] = N''AQAAAAEAACcQAAAAEP/PV4H2rGlA2mqMV8kEPUz6XRTTE3YJX4EGBRJ62T9sokXfdT1OLyNSNAnzrq5Dmg=='', [SecurityStamp] = N''d5856d26-368a-4b1e-ac5f-717f32718d1b''
    WHERE [Id] = N''753F8F36-D2FF-438E-B5D1-7FF79E4628BD'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220916052700_U3A_PersonBaseEntity')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''ce64007e-0394-4ad4-a87d-78ba0d4fafb9'', [PasswordHash] = N''AQAAAAEAACcQAAAAEJd4uSCwOmAkRq/5exkrK/acVdANZrl8Ozuj2D76sTuiazaVJ7ZSbKMI0+8vo/LR0Q=='', [SecurityStamp] = N''14be1ccd-e772-43e1-a724-83fe12081a8f''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220916052700_U3A_PersonBaseEntity')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''6814fd21-6343-463a-9ed8-f146e2a7191c'', [PasswordHash] = N''AQAAAAEAACcQAAAAEApPA9A15GOLm+uMl72Y94ia6AcmwUSsZORPq1DS1c4TJMlLW6pae2YQhN8nN8H/aw=='', [SecurityStamp] = N''978354d9-5927-4f75-b8c7-9b074650a2ab''
    WHERE [Id] = N''C5E9887D-9C4B-40F5-AB46-2232776005C5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220916052700_U3A_PersonBaseEntity')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''3201f57f-d5b6-4239-8448-29ecb248286e'', [PasswordHash] = N''AQAAAAEAACcQAAAAEHhcH8v+91L0GcDnll9YYFTCZGAIxZ/+f6LlSf3Z3KNp/cIsW7NF6az4I4EDp/lbWw=='', [SecurityStamp] = N''d1ee5aa8-9a5a-4fc5-a0c4-d2b9b322c579''
    WHERE [Id] = N''E7B47704-8DA0-4657-B42C-849C1C22A6D2'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220916052700_U3A_PersonBaseEntity')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220916052700_U3A_PersonBaseEntity', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220918085306_U3A_CourseYear')
BEGIN
    ALTER TABLE [Course] ADD [Year] int NOT NULL DEFAULT 2022;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220918085306_U3A_CourseYear')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''f75e29a2-3d86-4c05-a5cd-f576b132157d''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220918085306_U3A_CourseYear')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''54ac1e16-8e87-445e-af83-8be267967b32''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220918085306_U3A_CourseYear')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''78636cd2-60df-4b74-ab75-3080d2ddcd5e''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220918085306_U3A_CourseYear')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''53a86cc7-aa61-48d7-affa-76bdbe23dab7''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220918085306_U3A_CourseYear')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''9b81895c-810d-4cdc-ac5e-22febe8e25e4'', [PasswordHash] = N''AQAAAAEAACcQAAAAEOhNvj1IH3ZMOTVWT9dvCluVShOesMJCqS8sQ1O2Y2QHDlW51BLtDTldYegiQ1CWMQ=='', [SecurityStamp] = N''499b944c-7f7e-42bf-90fe-a119f6a071c5''
    WHERE [Id] = N''70494634-D7BE-4BE4-8106-031AAE2BC6DC'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220918085306_U3A_CourseYear')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''436c9401-9ab4-43e6-8f86-934ea8702bb5'', [PasswordHash] = N''AQAAAAEAACcQAAAAEKpOjzXNrRSOxmcZ1K6sgJ/s9HGH2eDFd8HYidi4I2RRmay/TWCnHnlCHcMOPEjVug=='', [SecurityStamp] = N''46d72a96-2ca9-4a0c-a3cd-b11d7c9704d3''
    WHERE [Id] = N''753F8F36-D2FF-438E-B5D1-7FF79E4628BD'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220918085306_U3A_CourseYear')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''8d77dfb9-c362-4596-8e76-7280aa461e61'', [PasswordHash] = N''AQAAAAEAACcQAAAAEDLe3U3LVr4QwEoAxkIS0xdH0II1hy/8AmqcHABuKrqIjuO81tOw+JQomhSzVh3Ytw=='', [SecurityStamp] = N''3017c3bf-ab00-4f7c-8c33-c0744b1ad31a''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220918085306_U3A_CourseYear')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''1ee95922-19d0-40bb-a751-ebf25030d01c'', [PasswordHash] = N''AQAAAAEAACcQAAAAEJfbFE7paFIfnyIVTfWXBIzbCrhjcJOdd3bA/FdbbRNO05KeeXfcuFEY/JEDdyW4VQ=='', [SecurityStamp] = N''439a1160-20e7-49e3-8fdf-acf2c029ba5f''
    WHERE [Id] = N''C5E9887D-9C4B-40F5-AB46-2232776005C5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220918085306_U3A_CourseYear')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''334ef438-252d-4321-9673-6017d97f4d4f'', [PasswordHash] = N''AQAAAAEAACcQAAAAEEUWRrdo39zq626BbOIorUn76xB0keYwYp/UbIQXX2j5Vhj1yCU1wVsIMIj5KUNqZg=='', [SecurityStamp] = N''3bd47073-0609-4c5e-a474-77844eeaba22''
    WHERE [Id] = N''E7B47704-8DA0-4657-B42C-849C1C22A6D2'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220918085306_U3A_CourseYear')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220918085306_U3A_CourseYear', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220921065755_U3A_PersonImportError')
BEGIN
    DROP INDEX [IX_Course_Name] ON [Course];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220921065755_U3A_PersonImportError')
BEGIN
    CREATE TABLE [PersonImportError] (
        [ID] uniqueidentifier NOT NULL,
        [Filename] nvarchar(max) NOT NULL,
        [ImportDate] datetime2 NOT NULL,
        [LineNumber] int NOT NULL,
        [LastName] nvarchar(max) NULL,
        [FirstName] nvarchar(max) NULL,
        [Course] nvarchar(max) NULL,
        [Error] nvarchar(max) NULL,
        CONSTRAINT [PK_PersonImportError] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220921065755_U3A_PersonImportError')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''4d90d435-6b8b-402d-b2d1-ff9016d9a54f''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220921065755_U3A_PersonImportError')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''212f26b5-c066-4547-a4ce-6d59741bc301''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220921065755_U3A_PersonImportError')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''ee039d1e-4519-4a24-bc6e-1418ac13c529''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220921065755_U3A_PersonImportError')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''cb2908ad-f7c4-4740-80b7-938b2fb86f94''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220921065755_U3A_PersonImportError')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''f56e73b7-ebfe-4ff6-89e2-26bb2a20df78'', [PasswordHash] = N''AQAAAAEAACcQAAAAEJGE52wmoCyrdm5ktA6jxFTb1otezDG9sivjpaOou3dO7C4CH10m2TZrYHRjcj8qjg=='', [SecurityStamp] = N''8d086b70-9f6c-4aad-89aa-8a7dd8b18d34''
    WHERE [Id] = N''70494634-D7BE-4BE4-8106-031AAE2BC6DC'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220921065755_U3A_PersonImportError')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''b73c45ef-1062-40ef-b793-9eb66b4d44e7'', [PasswordHash] = N''AQAAAAEAACcQAAAAEL1p5XrLuN3sqYL8QogUu5zTcmg/HHbMx9TMX2FQMdIFpxsjEb9qJqVGzSD3P4IHXA=='', [SecurityStamp] = N''8709de9a-1995-4f7e-8709-20aa77854aff''
    WHERE [Id] = N''753F8F36-D2FF-438E-B5D1-7FF79E4628BD'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220921065755_U3A_PersonImportError')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''0ad7f8be-bcde-435a-abae-19ac87443e33'', [PasswordHash] = N''AQAAAAEAACcQAAAAEAGLYewELP5y4pZC+oDBh75gUcVDlcEfIMTuoytM5X/sxtCvRu5qVjv9X+YiuYnNGQ=='', [SecurityStamp] = N''80a2331c-e075-47e0-a968-b04b49a3df2c''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220921065755_U3A_PersonImportError')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''e3804033-6c3f-46c9-92fa-ef68d128f8cc'', [PasswordHash] = N''AQAAAAEAACcQAAAAEDKx9Lx5M0BBvRfl/SO07pnKTqkXG0uY/y11Hlxs4YFM6Lm67P6366ZgxWRR0V9WtA=='', [SecurityStamp] = N''8f534a73-dfe2-46ff-af19-3729be420b61''
    WHERE [Id] = N''C5E9887D-9C4B-40F5-AB46-2232776005C5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220921065755_U3A_PersonImportError')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''5c8b3a4f-affc-49d5-9657-2906ef26a45c'', [PasswordHash] = N''AQAAAAEAACcQAAAAEHG10AoTRb+gXQuvqP3tLihYRH2rIetJWBqByEL9eEZm/XDXi0pR7WEjEB5LV3pYPQ=='', [SecurityStamp] = N''f401db60-4ea6-42af-a832-d5495ff7f866''
    WHERE [Id] = N''E7B47704-8DA0-4657-B42C-849C1C22A6D2'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220921065755_U3A_PersonImportError')
BEGIN
    CREATE INDEX [IX_Course_Year_Name] ON [Course] ([Year], [Name]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220921065755_U3A_PersonImportError')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220921065755_U3A_PersonImportError', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220922035413_U3A_RemoveStdUsers')
BEGIN
    EXEC(N'DELETE FROM [AspNetUserRoles]
    WHERE [RoleId] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'' AND [UserId] = N''70494634-D7BE-4BE4-8106-031AAE2BC6DC'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220922035413_U3A_RemoveStdUsers')
BEGIN
    EXEC(N'DELETE FROM [AspNetUserRoles]
    WHERE [RoleId] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'' AND [UserId] = N''753F8F36-D2FF-438E-B5D1-7FF79E4628BD'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220922035413_U3A_RemoveStdUsers')
BEGIN
    EXEC(N'DELETE FROM [AspNetUserRoles]
    WHERE [RoleId] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'' AND [UserId] = N''C5E9887D-9C4B-40F5-AB46-2232776005C5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220922035413_U3A_RemoveStdUsers')
BEGIN
    EXEC(N'DELETE FROM [AspNetUserRoles]
    WHERE [RoleId] = N''D4BA57AA-A379-4EE8-940E-57315575978A'' AND [UserId] = N''E7B47704-8DA0-4657-B42C-849C1C22A6D2'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220922035413_U3A_RemoveStdUsers')
BEGIN
    EXEC(N'DELETE FROM [AspNetUsers]
    WHERE [Id] = N''70494634-D7BE-4BE4-8106-031AAE2BC6DC'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220922035413_U3A_RemoveStdUsers')
BEGIN
    EXEC(N'DELETE FROM [AspNetUsers]
    WHERE [Id] = N''753F8F36-D2FF-438E-B5D1-7FF79E4628BD'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220922035413_U3A_RemoveStdUsers')
BEGIN
    EXEC(N'DELETE FROM [AspNetUsers]
    WHERE [Id] = N''C5E9887D-9C4B-40F5-AB46-2232776005C5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220922035413_U3A_RemoveStdUsers')
BEGIN
    EXEC(N'DELETE FROM [AspNetUsers]
    WHERE [Id] = N''E7B47704-8DA0-4657-B42C-849C1C22A6D2'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220922035413_U3A_RemoveStdUsers')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''4921db65-5f30-484b-98b8-a94e6860d123''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220922035413_U3A_RemoveStdUsers')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''88e47630-238a-4aec-9088-8fe70e992593''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220922035413_U3A_RemoveStdUsers')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''fefe9125-9799-4670-8dd8-785fe6d0db98''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220922035413_U3A_RemoveStdUsers')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''10ab4c68-f129-4028-ab63-0d971d3c5bb1''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220922035413_U3A_RemoveStdUsers')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''dabf1795-bac6-448e-8905-ee6173ad6f44'', [PasswordHash] = N''AQAAAAEAACcQAAAAEOx6yYIDYEMjms+M5dubAGuHodyqwOznp10e2lce/cvBbRz6y4ZqCgeG41QgOSULNg=='', [SecurityStamp] = N''141b0c48-9652-4319-8805-6416af7f5a72''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220922035413_U3A_RemoveStdUsers')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220922035413_U3A_RemoveStdUsers', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220923200353_U3A_DataImportTimestamp')
BEGIN
    ALTER TABLE [PersonImport] ADD [Timestamp] nvarchar(450) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220923200353_U3A_DataImportTimestamp')
BEGIN
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Person]') AND [c].[name] = N'Mobile');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [Person] DROP CONSTRAINT [' + @var11 + '];');
    ALTER TABLE [Person] ALTER COLUMN [Mobile] nvarchar(20) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220923200353_U3A_DataImportTimestamp')
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Person]') AND [c].[name] = N'HomePhone');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [Person] DROP CONSTRAINT [' + @var12 + '];');
    ALTER TABLE [Person] ALTER COLUMN [HomePhone] nvarchar(20) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220923200353_U3A_DataImportTimestamp')
BEGIN
    ALTER TABLE [Person] ADD [DataImportTimestamp] nvarchar(450) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220923200353_U3A_DataImportTimestamp')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''06864543-2cd6-4f68-a876-7ae904e47eeb''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220923200353_U3A_DataImportTimestamp')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''41228a58-b75c-4266-8406-22e6a53e05bf''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220923200353_U3A_DataImportTimestamp')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''6bbdca39-a7f7-4d8b-a2e9-981e2af68530''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220923200353_U3A_DataImportTimestamp')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''1e50c81f-319f-45c7-afd4-7db62e67aea5''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220923200353_U3A_DataImportTimestamp')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''7c9bdeeb-51f7-4442-b153-ad94d4dfb9a0'', [PasswordHash] = N''AQAAAAEAACcQAAAAEB3egOOV/I3+W1Y1SDY8gUPY+52a+6s3uon4wuUvHSumkiIm8ERGYZlWfNurQJ4shg=='', [SecurityStamp] = N''f7ffe9ff-3efb-49af-a67c-681029414be8''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220923200353_U3A_DataImportTimestamp')
BEGIN
    CREATE INDEX [IX_PersonImport_Timestamp] ON [PersonImport] ([Timestamp]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220923200353_U3A_DataImportTimestamp')
BEGIN
    CREATE INDEX [IX_Person_ConversionID] ON [Person] ([ConversionID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220923200353_U3A_DataImportTimestamp')
BEGIN
    CREATE INDEX [IX_Person_DataImportTimestamp] ON [Person] ([DataImportTimestamp]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220923200353_U3A_DataImportTimestamp')
BEGIN
    CREATE INDEX [IX_Person_PersonID] ON [Person] ([PersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220923200353_U3A_DataImportTimestamp')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220923200353_U3A_DataImportTimestamp', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220923212556_U3A_DataImportFileDetails')
BEGIN
    ALTER TABLE [PersonImport] ADD [Filename] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220923212556_U3A_DataImportFileDetails')
BEGIN
    ALTER TABLE [PersonImport] ADD [Linenumber] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220923212556_U3A_DataImportFileDetails')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''9a845da7-7371-411f-aabc-60a62704c33b''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220923212556_U3A_DataImportFileDetails')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''10eaa0ac-eae1-4fc0-be17-71db148fc475''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220923212556_U3A_DataImportFileDetails')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''1d7de06d-1635-4b60-863e-566f6b9f5638''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220923212556_U3A_DataImportFileDetails')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''e785aac9-43c3-4aff-bfc1-58cabbfa2034''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220923212556_U3A_DataImportFileDetails')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''26ccae9e-eeec-48b7-9c1a-d4c9b5b071ca'', [PasswordHash] = N''AQAAAAEAACcQAAAAEMcqSE9LmC3c8KuHkFyf8NR2OigIAJduWT/ubULyCGCKOBDLLYVjkZ5vCHIwn+q0KA=='', [SecurityStamp] = N''fe494df6-5fc1-489e-b496-5b091f459719''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220923212556_U3A_DataImportFileDetails')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220923212556_U3A_DataImportFileDetails', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220924075231_U3A_PersonFinancialTo')
BEGIN
    ALTER TABLE [Person] ADD [FinancialTo] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220924075231_U3A_PersonFinancialTo')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''cf433dbc-7aee-4e98-b5dd-9dfccb8773da''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220924075231_U3A_PersonFinancialTo')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''fc1f8127-f5eb-4f3f-a009-c987f5f9b879''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220924075231_U3A_PersonFinancialTo')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''3cd2df13-b7c2-4781-a45b-e669cf3f07a2''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220924075231_U3A_PersonFinancialTo')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''8871ad0e-9a4c-4a06-b1c8-ede04f0ff925''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220924075231_U3A_PersonFinancialTo')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''eb3d3b25-c624-4363-a6b9-70d7c4f0e71b'', [PasswordHash] = N''AQAAAAEAACcQAAAAEOzriTRAAVyDzeaZlHFKTTuPsH3O/DI3PMGgivWnW9sY1t/oh2Yhj3mpZvHUXnHctw=='', [SecurityStamp] = N''8c040275-4852-4238-a867-bd7d1889f154''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220924075231_U3A_PersonFinancialTo')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220924075231_U3A_PersonFinancialTo', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220925101028_U3A_PersonImportHasPaid')
BEGIN
    ALTER TABLE [PersonImport] ADD [HasPaid] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220925101028_U3A_PersonImportHasPaid')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''909254b7-c3f5-4b01-b09d-bff1c83f1ef9''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220925101028_U3A_PersonImportHasPaid')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''6efe5c77-dad3-4a81-89d0-8888ec1ddf72''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220925101028_U3A_PersonImportHasPaid')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''7bb3cbe9-8245-451f-a29e-3f74d6d69190''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220925101028_U3A_PersonImportHasPaid')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''3c08153b-7d32-478e-bf2c-8c306380d231''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220925101028_U3A_PersonImportHasPaid')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''00c334aa-bb07-4ddf-91e5-e1e2f0b7a86d'', [PasswordHash] = N''AQAAAAEAACcQAAAAEJoET2X6dy0fZhtGRh8mDDqfMz1L69mq77FQ/PChwngHafGcX53oYM8zGiNqv/yXeg=='', [SecurityStamp] = N''5af3667c-06e0-4ea6-99f3-f1abfdc6cc10''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220925101028_U3A_PersonImportHasPaid')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220925101028_U3A_PersonImportHasPaid', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220925105903_U3A_PersonImportDateJoinedDeleted')
BEGIN
    DECLARE @var13 sysname;
    SELECT @var13 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PersonImport]') AND [c].[name] = N'DateJoined');
    IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [PersonImport] DROP CONSTRAINT [' + @var13 + '];');
    ALTER TABLE [PersonImport] DROP COLUMN [DateJoined];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220925105903_U3A_PersonImportDateJoinedDeleted')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''cd505a7a-6e27-41a0-abb3-24b92f2befdf''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220925105903_U3A_PersonImportDateJoinedDeleted')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''a09333f2-3f51-4723-95a6-cb31507dbd8a''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220925105903_U3A_PersonImportDateJoinedDeleted')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''52f5cf58-c8f0-4b8b-9eba-64dbf99bcc5c''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220925105903_U3A_PersonImportDateJoinedDeleted')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''d5a23666-e35d-43de-9dd0-91386c0492a5''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220925105903_U3A_PersonImportDateJoinedDeleted')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''a3a684b5-03a1-4cee-a09d-c9c79f6668c9'', [PasswordHash] = N''AQAAAAEAACcQAAAAEFs6SOtYJwSL5WIOF0LU0C/yCPC7OJNXrWdMqc8pSF7DWciaVdo0ucXvLQGe9WeOzQ=='', [SecurityStamp] = N''38668c3d-4a3b-4c5f-98b1-974845b2db55''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220925105903_U3A_PersonImportDateJoinedDeleted')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220925105903_U3A_PersonImportDateJoinedDeleted', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220927010121_U3A_PersonImportHasPaidDeleted')
BEGIN
    DECLARE @var14 sysname;
    SELECT @var14 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PersonImport]') AND [c].[name] = N'HasPaid');
    IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [PersonImport] DROP CONSTRAINT [' + @var14 + '];');
    ALTER TABLE [PersonImport] DROP COLUMN [HasPaid];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220927010121_U3A_PersonImportHasPaidDeleted')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''f98f514b-2177-47a0-9615-09bd87d5d194''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220927010121_U3A_PersonImportHasPaidDeleted')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''aee330dd-4e39-4644-bfe6-c51cf50cae8b''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220927010121_U3A_PersonImportHasPaidDeleted')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''ceedca3f-2ca8-4683-8f96-edf80af686f2''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220927010121_U3A_PersonImportHasPaidDeleted')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''f58eb73c-b436-4ed2-b4da-7264ae631e5b''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220927010121_U3A_PersonImportHasPaidDeleted')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''f1718a9f-06f3-4f41-bc6a-830358fbacad'', [PasswordHash] = N''AQAAAAEAACcQAAAAEPd0m/5fbUN6mWMPLw3cexgWmBk9eonw2UaqgGG0son9ca8BWOCkwbIgnHbV/ZX4qQ=='', [SecurityStamp] = N''2e28ac41-39e5-476a-bb09-3d290f287c3f''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220927010121_U3A_PersonImportHasPaidDeleted')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220927010121_U3A_PersonImportHasPaidDeleted', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220927041713_U3A_Receipt')
BEGIN
    CREATE TABLE [Receipt] (
        [ID] uniqueidentifier NOT NULL,
        [Date] datetime2 NOT NULL,
        [Amount] decimal(18,2) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [Identifier] nvarchar(max) NULL,
        [PersonID] uniqueidentifier NOT NULL,
        [FinancialTo] int NULL,
        [CreatedOn] datetime2 NULL,
        [UpdatedOn] datetime2 NULL,
        CONSTRAINT [PK_Receipt] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_Receipt_Person_PersonID] FOREIGN KEY ([PersonID]) REFERENCES [Person] ([ID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220927041713_U3A_Receipt')
BEGIN
    CREATE TABLE [ReceiptDataImport] (
        [ID] uniqueidentifier NOT NULL,
        [Date] datetime2 NOT NULL,
        [Amount] decimal(18,2) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [Identifier] nvarchar(max) NULL,
        [PersonID] uniqueidentifier NULL,
        [FinancialTo] int NULL,
        CONSTRAINT [PK_ReceiptDataImport] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_ReceiptDataImport_Person_PersonID] FOREIGN KEY ([PersonID]) REFERENCES [Person] ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220927041713_U3A_Receipt')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''fb327b01-2af7-4464-a813-7ff35a48b5c3''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220927041713_U3A_Receipt')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''30b17a86-8b77-4b72-87d1-331407c1fbe3''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220927041713_U3A_Receipt')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''926f9eb8-bc84-468c-992c-b55fc0b0dd18''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220927041713_U3A_Receipt')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''0f164173-381f-4fff-813e-c3dd5e6b2ebb''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220927041713_U3A_Receipt')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''63d3147e-838b-4ba2-a761-63576e38804f'', [PasswordHash] = N''AQAAAAEAACcQAAAAEBAmnECsMD1pWgLZ1b5uLIH1xOaO145QeA68J0004+YAuRy0KMfYhk3Q5+M0Fap+0Q=='', [SecurityStamp] = N''2cf27827-4226-42a9-a906-8493509afe45''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220927041713_U3A_Receipt')
BEGIN
    CREATE INDEX [IX_Receipt_PersonID] ON [Receipt] ([PersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220927041713_U3A_Receipt')
BEGIN
    CREATE INDEX [IX_ReceiptDataImport_PersonID] ON [ReceiptDataImport] ([PersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220927041713_U3A_Receipt')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220927041713_U3A_Receipt', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220928051816_U3A_ReceiptDateJoined')
BEGIN
    DECLARE @var15 sysname;
    SELECT @var15 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Receipt]') AND [c].[name] = N'FinancialTo');
    IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [Receipt] DROP CONSTRAINT [' + @var15 + '];');
    UPDATE [Receipt] SET [FinancialTo] = 0 WHERE [FinancialTo] IS NULL;
    ALTER TABLE [Receipt] ALTER COLUMN [FinancialTo] int NOT NULL;
    ALTER TABLE [Receipt] ADD DEFAULT 0 FOR [FinancialTo];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220928051816_U3A_ReceiptDateJoined')
BEGIN
    ALTER TABLE [Receipt] ADD [DateJoined] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220928051816_U3A_ReceiptDateJoined')
BEGIN
    ALTER TABLE [Receipt] ADD [PreviousDateJoined] datetime2 NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220928051816_U3A_ReceiptDateJoined')
BEGIN
    ALTER TABLE [Receipt] ADD [PreviousFinancialTo] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220928051816_U3A_ReceiptDateJoined')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''2d76085f-c2ab-40f3-9118-13d9afb1c02f''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220928051816_U3A_ReceiptDateJoined')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''de1186e2-4f47-45e0-afa2-7d3a17b1710b''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220928051816_U3A_ReceiptDateJoined')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''59c55889-5c0e-4c65-bae4-1702a0c91097''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220928051816_U3A_ReceiptDateJoined')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''5c65f782-a961-4d78-a7cf-fddb49c4c39d''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220928051816_U3A_ReceiptDateJoined')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''96416509-7367-4cc1-ab3e-24bb96f15662'', [PasswordHash] = N''AQAAAAEAACcQAAAAEBE8qnrFlAF4k63tsIY5dY8yqr7TfhvSKJxHemFM4LoGD8nIwGjVbjJEMYd1/W/Grw=='', [SecurityStamp] = N''a67381f5-3f16-4a98-8e0b-5dd6e877ef71''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220928051816_U3A_ReceiptDateJoined')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220928051816_U3A_ReceiptDateJoined', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221009022810_U3A_ReceiptDataImportCascadeDelete')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''b9e35b44-0500-46a3-a646-646aaa818446''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221009022810_U3A_ReceiptDataImportCascadeDelete')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''16a6d062-5f05-41d2-9e8b-e3870d9b3a97''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221009022810_U3A_ReceiptDataImportCascadeDelete')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''d1b99aab-b3ad-44c8-9866-866f400cb3c1''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221009022810_U3A_ReceiptDataImportCascadeDelete')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''a65618b6-9f9a-4e77-996f-3d96890b7b7c''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221009022810_U3A_ReceiptDataImportCascadeDelete')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''d79d95c9-7238-4e65-bad1-1473b5c17da5'', [PasswordHash] = N''AQAAAAEAACcQAAAAEBF7imVgm7AtuIMxXhBG3m9T+4BeLT31K8g9yT3PLQ8/vW27viLE/LFVdUbPcrpWAw=='', [SecurityStamp] = N''61d3be22-c20c-470a-b7c8-c7e1028bb871''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221009022810_U3A_ReceiptDataImportCascadeDelete')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221009022810_U3A_ReceiptDataImportCascadeDelete', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221012210535_U3A_SystemSettingsFinancialToPercent')
BEGIN
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    EXEC sp_dropextendedproperty 'MS_Description', 'SCHEMA', @defaultSchema, 'TABLE', N'Term', 'COLUMN', N'EnrolmentEnds';
    SET @description = N'The number of weeks before/after to StartDate that enrolment ends';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Term', 'COLUMN', N'EnrolmentEnds';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221012210535_U3A_SystemSettingsFinancialToPercent')
BEGIN
    ALTER TABLE [SystemSettings] ADD [FinancialToMembershipFeePercent] decimal(18,2) NOT NULL DEFAULT 0.0;
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'The percent of Membership fess required to be paid before member is deemed financial and enrolement allowed.';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SystemSettings', 'COLUMN', N'FinancialToMembershipFeePercent';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221012210535_U3A_SystemSettingsFinancialToPercent')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''eea0a2da-4c16-4d2e-b149-042d8d1891d4''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221012210535_U3A_SystemSettingsFinancialToPercent')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''dc3406ef-74c8-4f1e-898e-cb865a5581d5''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221012210535_U3A_SystemSettingsFinancialToPercent')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''df1ea4a0-d0bf-4e11-adb2-b60f18a12ea7''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221012210535_U3A_SystemSettingsFinancialToPercent')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''0691a5f1-b704-45ba-811a-a601d44e7550''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221012210535_U3A_SystemSettingsFinancialToPercent')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''5cde6c27-e5b2-4e9e-b017-2ef5860ee357'', [PasswordHash] = N''AQAAAAEAACcQAAAAEJtYY5UJj3uCC8bbuwpCpGakCV1Xv0Df0PY+HwjLRrg7bUO3jTrXr8u9Ti+fPjyycA=='', [SecurityStamp] = N''ccc59f7e-370e-4aab-acbf-d81e9562c675''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221012210535_U3A_SystemSettingsFinancialToPercent')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221012210535_U3A_SystemSettingsFinancialToPercent', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221012222333_U3A_ReceiptProcessingYear')
BEGIN
    ALTER TABLE [Receipt] ADD [ProcessingYear] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221012222333_U3A_ReceiptProcessingYear')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''c9f1fc68-02e0-4877-9477-c5ab390ef831''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221012222333_U3A_ReceiptProcessingYear')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''b9fe6cfb-fdbc-4b81-b350-1bef70bdc6a4''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221012222333_U3A_ReceiptProcessingYear')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''13005e72-2dcb-4a7f-ad0a-bc9608e6f59c''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221012222333_U3A_ReceiptProcessingYear')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''ef9f710d-31e1-4656-b8f0-14d487670d63''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221012222333_U3A_ReceiptProcessingYear')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''748f49d2-10d3-4a01-a402-594248729e4a'', [PasswordHash] = N''AQAAAAEAACcQAAAAEKOPrc4LBy+1HX+83WwyOrh4rNffQghHdeYtiLg+CUrpBsBwMT20YCcieNOUfLx9XA=='', [SecurityStamp] = N''b5ab1cfb-fed8-4385-b098-d37de862b019''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221012222333_U3A_ReceiptProcessingYear')
BEGIN
    CREATE INDEX [IX_Receipt_ProcessingYear] ON [Receipt] ([ProcessingYear]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221012222333_U3A_ReceiptProcessingYear')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221012222333_U3A_ReceiptProcessingYear', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221013052730_U3A_SendMail')
BEGIN
    CREATE TABLE [SendMail] (
        [ID] uniqueidentifier NOT NULL,
        [DocumentName] nvarchar(max) NOT NULL,
        [PersonID] uniqueidentifier NOT NULL,
        [RecordKey] uniqueidentifier NOT NULL,
        [Status] nvarchar(max) NOT NULL,
        [CreatedOn] datetime2 NULL,
        [UpdatedOn] datetime2 NULL,
        CONSTRAINT [PK_SendMail] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_SendMail_Person_PersonID] FOREIGN KEY ([PersonID]) REFERENCES [Person] ([ID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221013052730_U3A_SendMail')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''a00a2bfc-a3db-4cea-b537-fe112b292d57''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221013052730_U3A_SendMail')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''915da503-dd07-422b-905b-fb19c8c2ae67''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221013052730_U3A_SendMail')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''65ff159e-2eb4-42af-beb9-27a406dff761''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221013052730_U3A_SendMail')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''2621a8da-0e5d-42f8-8247-68f0d42abebe''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221013052730_U3A_SendMail')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''c9a23c74-5394-4308-b9da-b6ca06a22603'', [PasswordHash] = N''AQAAAAEAACcQAAAAELVKSzxUl57d/Rvdt+mTagxe9n9q9ZIWtFs2Ias+PDxKqKWNZZMIYvptg0FJ5N+AIw=='', [SecurityStamp] = N''2ca473c4-d8ed-4fa6-acd3-adeda5f720a2''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221013052730_U3A_SendMail')
BEGIN
    CREATE INDEX [IX_SendMail_PersonID] ON [SendMail] ([PersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221013052730_U3A_SendMail')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221013052730_U3A_SendMail', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221020193948_U3A_SendEmailAddress')
BEGIN
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    EXEC sp_dropextendedproperty 'MS_Description', 'SCHEMA', @defaultSchema, 'TABLE', N'SystemSettings', 'COLUMN', N'MailSurcharge';
    SET @description = N'Yearly surcharge if requiring mail correspondence';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SystemSettings', 'COLUMN', N'MailSurcharge';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221020193948_U3A_SendEmailAddress')
BEGIN
    ALTER TABLE [SystemSettings] ADD [SendEmailAddesss] nvarchar(max) NOT NULL DEFAULT N'';
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Pro-forma reports are sent from here';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SystemSettings', 'COLUMN', N'SendEmailAddesss';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221020193948_U3A_SendEmailAddress')
BEGIN
    ALTER TABLE [SystemSettings] ADD [SendEmailDisplayName] nvarchar(256) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221020193948_U3A_SendEmailAddress')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''5e15337e-ffe2-47c3-ad35-43517e1d4a74''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221020193948_U3A_SendEmailAddress')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''8747497a-8829-4c70-a30b-d3bcb839a207''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221020193948_U3A_SendEmailAddress')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''cdc6d6fa-451d-4025-a2f2-0a763302a46f''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221020193948_U3A_SendEmailAddress')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''1906ffec-b633-498a-9618-997977633923''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221020193948_U3A_SendEmailAddress')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''7385ae0a-561b-4e5a-a09b-2816c2e9fc35'', [PasswordHash] = N''AQAAAAEAACcQAAAAEGBANLryDYTDHSUmNC59OjMYAb25Pw6+vMUGTistHqrPlyeYRNEG5NwYbY2Vi8y1jg=='', [SecurityStamp] = N''6424207d-c82a-46de-9195-552a34429e7f''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221020193948_U3A_SendEmailAddress')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221020193948_U3A_SendEmailAddress', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221021222945_U3A_ReceiptImport_IsPosted')
BEGIN
    ALTER TABLE [ReceiptDataImport] ADD [IsOnFile] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221021222945_U3A_ReceiptImport_IsPosted')
BEGIN
    DECLARE @var16 sysname;
    SELECT @var16 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Receipt]') AND [c].[name] = N'Description');
    IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [Receipt] DROP CONSTRAINT [' + @var16 + '];');
    ALTER TABLE [Receipt] ALTER COLUMN [Description] nvarchar(450) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221021222945_U3A_ReceiptImport_IsPosted')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''4c6e28e8-0448-4759-964b-6fa36e217715''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221021222945_U3A_ReceiptImport_IsPosted')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''01d0eb5f-d35f-4b3e-9dad-925e0f0c4efb''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221021222945_U3A_ReceiptImport_IsPosted')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''cc1b6d31-dfc9-4031-8cf8-38bfbcee15ad''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221021222945_U3A_ReceiptImport_IsPosted')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''cf22e000-6f20-4565-bc45-ac7ba9f5fcec''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221021222945_U3A_ReceiptImport_IsPosted')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''d5b923da-e355-485b-8936-e6f52646e474'', [PasswordHash] = N''AQAAAAEAACcQAAAAEKFlvzFu7HIgZycG3q6e6YNBHA0oz88MGpdcSx4alqiPpet6jqXRWizfwte5jwfNow=='', [SecurityStamp] = N''eda15259-35ed-4e41-aad6-faeff3a7d4f5''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221021222945_U3A_ReceiptImport_IsPosted')
BEGIN
    CREATE INDEX [IX_Receipt_Date_Description] ON [Receipt] ([Date], [Description]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221021222945_U3A_ReceiptImport_IsPosted')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221021222945_U3A_ReceiptImport_IsPosted', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221024043827_U3A_U3A_ReceiptImport_MovedPrevFieldsToPerson')
BEGIN
    DECLARE @var17 sysname;
    SELECT @var17 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Receipt]') AND [c].[name] = N'PreviousDateJoined');
    IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [Receipt] DROP CONSTRAINT [' + @var17 + '];');
    ALTER TABLE [Receipt] DROP COLUMN [PreviousDateJoined];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221024043827_U3A_U3A_ReceiptImport_MovedPrevFieldsToPerson')
BEGIN
    DECLARE @var18 sysname;
    SELECT @var18 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Receipt]') AND [c].[name] = N'PreviousFinancialTo');
    IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [Receipt] DROP CONSTRAINT [' + @var18 + '];');
    ALTER TABLE [Receipt] DROP COLUMN [PreviousFinancialTo];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221024043827_U3A_U3A_ReceiptImport_MovedPrevFieldsToPerson')
BEGIN
    ALTER TABLE [Person] ADD [PreviousDateJoined] datetime2 NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221024043827_U3A_U3A_ReceiptImport_MovedPrevFieldsToPerson')
BEGIN
    ALTER TABLE [Person] ADD [PreviousFinancialTo] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221024043827_U3A_U3A_ReceiptImport_MovedPrevFieldsToPerson')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''5021861c-98d4-4eb6-ab52-473d0a4e0328''
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221024043827_U3A_U3A_ReceiptImport_MovedPrevFieldsToPerson')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''aca53ee9-ace4-4961-bd05-71eb31f10067''
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221024043827_U3A_U3A_ReceiptImport_MovedPrevFieldsToPerson')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''88f105bc-b96c-4c73-bed3-b2341d6adc32''
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221024043827_U3A_U3A_ReceiptImport_MovedPrevFieldsToPerson')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''41766857-2f55-4699-b5c1-90858cd7851e''
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221024043827_U3A_U3A_ReceiptImport_MovedPrevFieldsToPerson')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''a260c7dd-2a24-45d4-b526-0dd9e33887d4'', [PasswordHash] = N''AQAAAAEAACcQAAAAEP9LgnLIs/9/AJZmr94S21hx5SfjTkR+LBO7EBwsC4HaY79k2+S9JJrY+T+oX1xT1g=='', [SecurityStamp] = N''2b651cb3-a424-4eb6-9a40-e44d48082857''
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221024043827_U3A_U3A_ReceiptImport_MovedPrevFieldsToPerson')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221024043827_U3A_U3A_ReceiptImport_MovedPrevFieldsToPerson', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221027051426_U3A_RemoveASPNETSecurityFromDbContext')
BEGIN
    EXEC(N'DELETE FROM [AspNetUserRoles]
    WHERE [RoleId] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'' AND [UserId] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221027051426_U3A_RemoveASPNETSecurityFromDbContext')
BEGIN
    EXEC(N'DELETE FROM [AspNetUserRoles]
    WHERE [RoleId] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'' AND [UserId] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221027051426_U3A_RemoveASPNETSecurityFromDbContext')
BEGIN
    EXEC(N'DELETE FROM [AspNetUserRoles]
    WHERE [RoleId] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'' AND [UserId] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221027051426_U3A_RemoveASPNETSecurityFromDbContext')
BEGIN
    EXEC(N'DELETE FROM [AspNetUserRoles]
    WHERE [RoleId] = N''D4BA57AA-A379-4EE8-940E-57315575978A'' AND [UserId] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221027051426_U3A_RemoveASPNETSecurityFromDbContext')
BEGIN
    EXEC(N'DELETE FROM [AspNetRoles]
    WHERE [Id] = N''2c5e174e-3b0e-446f-86af-483d56fd7210'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221027051426_U3A_RemoveASPNETSecurityFromDbContext')
BEGIN
    EXEC(N'DELETE FROM [AspNetRoles]
    WHERE [Id] = N''68C1B727-5571-47F4-AAE8-8DC85AB3AEE0'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221027051426_U3A_RemoveASPNETSecurityFromDbContext')
BEGIN
    EXEC(N'DELETE FROM [AspNetRoles]
    WHERE [Id] = N''993C6378-61D4-4734-ADAE-D725F2A8CD94'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221027051426_U3A_RemoveASPNETSecurityFromDbContext')
BEGIN
    EXEC(N'DELETE FROM [AspNetRoles]
    WHERE [Id] = N''D4BA57AA-A379-4EE8-940E-57315575978A'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221027051426_U3A_RemoveASPNETSecurityFromDbContext')
BEGIN
    EXEC(N'DELETE FROM [AspNetUsers]
    WHERE [Id] = N''8e445865-a24d-4543-a6c6-9443d048cdb9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221027051426_U3A_RemoveASPNETSecurityFromDbContext')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221027051426_U3A_RemoveASPNETSecurityFromDbContext', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221102222245_U3A_SettingsLastReceiptDate')
BEGIN
    ALTER TABLE [SystemSettings] ADD [LastCashReceiptDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221102222245_U3A_SettingsLastReceiptDate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221102222245_U3A_SettingsLastReceiptDate', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110041029_U3A_PersonRequireICE')
BEGIN
    DECLARE @var19 sysname;
    SELECT @var19 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Person]') AND [c].[name] = N'ICEPhone');
    IF @var19 IS NOT NULL EXEC(N'ALTER TABLE [Person] DROP CONSTRAINT [' + @var19 + '];');
    UPDATE [Person] SET [ICEPhone] = N'' WHERE [ICEPhone] IS NULL;
    ALTER TABLE [Person] ALTER COLUMN [ICEPhone] nvarchar(50) NOT NULL;
    ALTER TABLE [Person] ADD DEFAULT N'' FOR [ICEPhone];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110041029_U3A_PersonRequireICE')
BEGIN
    DECLARE @var20 sysname;
    SELECT @var20 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Person]') AND [c].[name] = N'ICEContact');
    IF @var20 IS NOT NULL EXEC(N'ALTER TABLE [Person] DROP CONSTRAINT [' + @var20 + '];');
    UPDATE [Person] SET [ICEContact] = N'' WHERE [ICEContact] IS NULL;
    ALTER TABLE [Person] ALTER COLUMN [ICEContact] nvarchar(50) NOT NULL;
    ALTER TABLE [Person] ADD DEFAULT N'' FOR [ICEContact];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110041029_U3A_PersonRequireICE')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221110041029_U3A_PersonRequireICE', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110042556_U3A_PersonRequireICE1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221110042556_U3A_PersonRequireICE1', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221111012843_U3A_SettingsTimezone')
BEGIN
    ALTER TABLE [SystemSettings] ADD [Timezone] nvarchar(max) NOT NULL DEFAULT N'Australia/NSW';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221111012843_U3A_SettingsTimezone')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221111012843_U3A_SettingsTimezone', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221111185359_U3A_SettingsMail')
BEGIN
    DECLARE @var21 sysname;
    SELECT @var21 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[SystemSettings]') AND [c].[name] = N'Timezone');
    IF @var21 IS NOT NULL EXEC(N'ALTER TABLE [SystemSettings] DROP CONSTRAINT [' + @var21 + '];');
    ALTER TABLE [SystemSettings] DROP COLUMN [Timezone];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221111185359_U3A_SettingsMail')
BEGIN
    ALTER TABLE [SystemSettings] ADD [MailLabelBottomMargin] float NOT NULL DEFAULT 0.0E0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221111185359_U3A_SettingsMail')
BEGIN
    ALTER TABLE [SystemSettings] ADD [MailLabelHeight] float NOT NULL DEFAULT 0.0E0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221111185359_U3A_SettingsMail')
BEGIN
    ALTER TABLE [SystemSettings] ADD [MailLabelLeftMargin] float NOT NULL DEFAULT 0.0E0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221111185359_U3A_SettingsMail')
BEGIN
    ALTER TABLE [SystemSettings] ADD [MailLabelRightMargin] float NOT NULL DEFAULT 0.0E0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221111185359_U3A_SettingsMail')
BEGIN
    ALTER TABLE [SystemSettings] ADD [MailLabelTopMargin] float NOT NULL DEFAULT 0.0E0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221111185359_U3A_SettingsMail')
BEGIN
    ALTER TABLE [SystemSettings] ADD [MailLabelWidth] float NOT NULL DEFAULT 0.0E0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221111185359_U3A_SettingsMail')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221111185359_U3A_SettingsMail', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221114233010_U3A_SettingsBank')
BEGIN
    ALTER TABLE [SystemSettings] ADD [BankAccountNo] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221114233010_U3A_SettingsBank')
BEGIN
    ALTER TABLE [SystemSettings] ADD [BankBSB] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221114233010_U3A_SettingsBank')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221114233010_U3A_SettingsBank', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221118015841_U3A_OnlinePaymentStatus')
BEGIN
    CREATE TABLE [OnlinePaymentStatus] (
        [ID] uniqueidentifier NOT NULL,
        [PersonID] uniqueidentifier NOT NULL,
        [AccessCode] nvarchar(max) NOT NULL,
        [Status] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_OnlinePaymentStatus] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221118015841_U3A_OnlinePaymentStatus')
BEGIN
    CREATE INDEX [IX_OnlinePaymentStatus_PersonID_Status] ON [OnlinePaymentStatus] ([PersonID], [Status]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221118015841_U3A_OnlinePaymentStatus')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221118015841_U3A_OnlinePaymentStatus', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221121001317_U3A_SettingsUTCOffset')
BEGIN
    ALTER TABLE [SystemSettings] ADD [UTCOffset] int NOT NULL DEFAULT 10;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221121001317_U3A_SettingsUTCOffset')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221121001317_U3A_SettingsUTCOffset', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221125022428_U3A_OnlinePaymentStatusBaseEntity')
BEGIN
    DROP INDEX [IX_OnlinePaymentStatus_PersonID_Status] ON [OnlinePaymentStatus];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221125022428_U3A_OnlinePaymentStatusBaseEntity')
BEGIN
    DECLARE @var22 sysname;
    SELECT @var22 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[OnlinePaymentStatus]') AND [c].[name] = N'Status');
    IF @var22 IS NOT NULL EXEC(N'ALTER TABLE [OnlinePaymentStatus] DROP CONSTRAINT [' + @var22 + '];');
    ALTER TABLE [OnlinePaymentStatus] ALTER COLUMN [Status] nvarchar(max) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221125022428_U3A_OnlinePaymentStatusBaseEntity')
BEGIN
    ALTER TABLE [OnlinePaymentStatus] ADD [CreatedOn] datetime2 NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221125022428_U3A_OnlinePaymentStatusBaseEntity')
BEGIN
    ALTER TABLE [OnlinePaymentStatus] ADD [UpdatedOn] datetime2 NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221125022428_U3A_OnlinePaymentStatusBaseEntity')
BEGIN
    CREATE INDEX [IX_OnlinePaymentStatus_PersonID_CreatedOn] ON [OnlinePaymentStatus] ([PersonID], [CreatedOn]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221125022428_U3A_OnlinePaymentStatusBaseEntity')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221125022428_U3A_OnlinePaymentStatusBaseEntity', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127222455_U3A_VenueNewcastleDetail')
BEGIN
    ALTER TABLE [Venue] ADD [AccessDetail] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127222455_U3A_VenueNewcastleDetail')
BEGIN
    ALTER TABLE [Venue] ADD [Coordinator] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127222455_U3A_VenueNewcastleDetail')
BEGIN
    ALTER TABLE [Venue] ADD [Email] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127222455_U3A_VenueNewcastleDetail')
BEGIN
    ALTER TABLE [Venue] ADD [Equipment] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127222455_U3A_VenueNewcastleDetail')
BEGIN
    ALTER TABLE [Venue] ADD [KeyCode] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127222455_U3A_VenueNewcastleDetail')
BEGIN
    ALTER TABLE [Venue] ADD [Phone] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127222455_U3A_VenueNewcastleDetail')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221127222455_U3A_VenueNewcastleDetail', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127224003_U3A_VenueMaxLength')
BEGIN
    DECLARE @var23 sysname;
    SELECT @var23 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Venue]') AND [c].[name] = N'Name');
    IF @var23 IS NOT NULL EXEC(N'ALTER TABLE [Venue] DROP CONSTRAINT [' + @var23 + '];');
    ALTER TABLE [Venue] ALTER COLUMN [Name] nvarchar(max) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127224003_U3A_VenueMaxLength')
BEGIN
    DECLARE @var24 sysname;
    SELECT @var24 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Venue]') AND [c].[name] = N'Address');
    IF @var24 IS NOT NULL EXEC(N'ALTER TABLE [Venue] DROP CONSTRAINT [' + @var24 + '];');
    ALTER TABLE [Venue] ALTER COLUMN [Address] nvarchar(max) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127224003_U3A_VenueMaxLength')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221127224003_U3A_VenueMaxLength', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127224348_U3A_VenueKeyCodeNull')
BEGIN
    DECLARE @var25 sysname;
    SELECT @var25 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Venue]') AND [c].[name] = N'KeyCode');
    IF @var25 IS NOT NULL EXEC(N'ALTER TABLE [Venue] DROP CONSTRAINT [' + @var25 + '];');
    ALTER TABLE [Venue] ALTER COLUMN [KeyCode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221127224348_U3A_VenueKeyCodeNull')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221127224348_U3A_VenueKeyCodeNull', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221128004831_U3A_CourseNameLength')
BEGIN
    DROP INDEX [IX_Course_Year_Name] ON [Course];
    DECLARE @var26 sysname;
    SELECT @var26 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Course]') AND [c].[name] = N'Name');
    IF @var26 IS NOT NULL EXEC(N'ALTER TABLE [Course] DROP CONSTRAINT [' + @var26 + '];');
    ALTER TABLE [Course] ALTER COLUMN [Name] nvarchar(100) NOT NULL;
    CREATE INDEX [IX_Course_Year_Name] ON [Course] ([Year], [Name]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221128004831_U3A_CourseNameLength')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221128004831_U3A_CourseNameLength', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221203035427_U3A_MembershipFees')
BEGIN
    DECLARE @var27 sysname;
    SELECT @var27 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[SystemSettings]') AND [c].[name] = N'FinancialToMembershipFeePercent');
    IF @var27 IS NOT NULL EXEC(N'ALTER TABLE [SystemSettings] DROP CONSTRAINT [' + @var27 + '];');
    ALTER TABLE [SystemSettings] DROP COLUMN [FinancialToMembershipFeePercent];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221203035427_U3A_MembershipFees')
BEGIN
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    EXEC sp_dropextendedproperty 'MS_Description', 'SCHEMA', @defaultSchema, 'TABLE', N'SystemSettings', 'COLUMN', N'MembershipFee';
    SET @description = N'Full Year Membership Fee';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SystemSettings', 'COLUMN', N'MembershipFee';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221203035427_U3A_MembershipFees')
BEGIN
    ALTER TABLE [SystemSettings] ADD [MembershipFeeTerm2] decimal(18,2) NOT NULL DEFAULT 0.0;
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Term 2 Membership Fee';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SystemSettings', 'COLUMN', N'MembershipFeeTerm2';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221203035427_U3A_MembershipFees')
BEGIN
    ALTER TABLE [SystemSettings] ADD [MembershipFeeTerm3] decimal(18,2) NOT NULL DEFAULT 0.0;
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Term 3 Year Membership Fee';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SystemSettings', 'COLUMN', N'MembershipFeeTerm3';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221203035427_U3A_MembershipFees')
BEGIN
    ALTER TABLE [SystemSettings] ADD [MembershipFeeTerm4] decimal(18,2) NOT NULL DEFAULT 0.0;
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Term 4 Year Membership Fee';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SystemSettings', 'COLUMN', N'MembershipFeeTerm4';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221203035427_U3A_MembershipFees')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221203035427_U3A_MembershipFees', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221205045943_U3A_OnlinePaymentAdminEmail')
BEGIN
    ALTER TABLE [OnlinePaymentStatus] ADD [AdminEmail] nvarchar(450) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221205045943_U3A_OnlinePaymentAdminEmail')
BEGIN
    CREATE INDEX [IX_OnlinePaymentStatus_AdminEmail_CreatedOn] ON [OnlinePaymentStatus] ([AdminEmail], [CreatedOn]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221205045943_U3A_OnlinePaymentAdminEmail')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221205045943_U3A_OnlinePaymentAdminEmail', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221206215029_U3A_BaseEntityUser')
BEGIN
    ALTER TABLE [SendMail] ADD [User] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221206215029_U3A_BaseEntityUser')
BEGIN
    ALTER TABLE [Receipt] ADD [User] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221206215029_U3A_BaseEntityUser')
BEGIN
    ALTER TABLE [Person] ADD [User] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221206215029_U3A_BaseEntityUser')
BEGIN
    ALTER TABLE [OnlinePaymentStatus] ADD [User] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221206215029_U3A_BaseEntityUser')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221206215029_U3A_BaseEntityUser', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207034113_U3A_SettingsComplimentaryParameters')
BEGIN
    ALTER TABLE [SystemSettings] ADD [IncludeCourseFeePerTermInComplimentary] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207034113_U3A_SettingsComplimentaryParameters')
BEGIN
    ALTER TABLE [SystemSettings] ADD [IncludeCourseFeePerYearInComplimentary] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207034113_U3A_SettingsComplimentaryParameters')
BEGIN
    ALTER TABLE [SystemSettings] ADD [IncludeMailSurchargeInComplimentary] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207034113_U3A_SettingsComplimentaryParameters')
BEGIN
    ALTER TABLE [SystemSettings] ADD [IncludeMembershipFeeInComplimentary] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207034113_U3A_SettingsComplimentaryParameters')
BEGIN
    ALTER TABLE [SystemSettings] ADD [LeaderMaxComplimentaryCourses] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207034113_U3A_SettingsComplimentaryParameters')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221207034113_U3A_SettingsComplimentaryParameters', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207041315_U3A_CourseFees')
BEGIN
    DECLARE @var28 sysname;
    SELECT @var28 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Course]') AND [c].[name] = N'ClassFee');
    IF @var28 IS NOT NULL EXEC(N'ALTER TABLE [Course] DROP CONSTRAINT [' + @var28 + '];');
    ALTER TABLE [Course] DROP COLUMN [ClassFee];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207041315_U3A_CourseFees')
BEGIN
    DECLARE @var29 sysname;
    SELECT @var29 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Course]') AND [c].[name] = N'CourseFee');
    IF @var29 IS NOT NULL EXEC(N'ALTER TABLE [Course] DROP CONSTRAINT [' + @var29 + '];');
    ALTER TABLE [Course] DROP COLUMN [CourseFee];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207041315_U3A_CourseFees')
BEGIN
    EXEC sp_rename N'[Course].[CourseFeeDescription]', N'CourseFeePerYearDescription', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207041315_U3A_CourseFees')
BEGIN
    EXEC sp_rename N'[Course].[ClassFeeDescription]', N'CourseFeePerTermDescription', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207041315_U3A_CourseFees')
BEGIN
    ALTER TABLE [Course] ADD [CourseFeePerTerm] decimal(18,2) NOT NULL DEFAULT 0.0;
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Optional fee per term)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'CourseFeePerTerm';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207041315_U3A_CourseFees')
BEGIN
    ALTER TABLE [Course] ADD [CourseFeePerYear] decimal(18,2) NOT NULL DEFAULT 0.0;
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Optional once-only course enrolment fee';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'CourseFeePerYear';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207041315_U3A_CourseFees')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221207041315_U3A_CourseFees', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207192428_U3A_AdditionalLeaders')
BEGIN
    ALTER TABLE [Class] ADD [Leader2ID] uniqueidentifier NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207192428_U3A_AdditionalLeaders')
BEGIN
    ALTER TABLE [Class] ADD [Leader3ID] uniqueidentifier NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207192428_U3A_AdditionalLeaders')
BEGIN
    CREATE INDEX [IX_Class_Leader2ID] ON [Class] ([Leader2ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207192428_U3A_AdditionalLeaders')
BEGIN
    CREATE INDEX [IX_Class_Leader3ID] ON [Class] ([Leader3ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207192428_U3A_AdditionalLeaders')
BEGIN
    ALTER TABLE [Class] ADD CONSTRAINT [FK_Class_Person_Leader2ID] FOREIGN KEY ([Leader2ID]) REFERENCES [Person] ([ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207192428_U3A_AdditionalLeaders')
BEGIN
    ALTER TABLE [Class] ADD CONSTRAINT [FK_Class_Person_Leader3ID] FOREIGN KEY ([Leader3ID]) REFERENCES [Person] ([ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221207192428_U3A_AdditionalLeaders')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221207192428_U3A_AdditionalLeaders', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211214017_U3A_Fee')
BEGIN
    CREATE TABLE [Fee] (
        [ID] uniqueidentifier NOT NULL,
        [Date] datetime2 NOT NULL,
        [ProcessingYear] int NOT NULL,
        [Amount] decimal(18,2) NOT NULL,
        [Description] nvarchar(450) NOT NULL,
        [PersonID] uniqueidentifier NOT NULL,
        [CreatedOn] datetime2 NULL,
        [UpdatedOn] datetime2 NULL,
        [User] nvarchar(max) NULL,
        CONSTRAINT [PK_Fee] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_Fee_Person_PersonID] FOREIGN KEY ([PersonID]) REFERENCES [Person] ([ID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211214017_U3A_Fee')
BEGIN
    CREATE INDEX [IX_Fee_Date_Description] ON [Fee] ([Date], [Description]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211214017_U3A_Fee')
BEGIN
    CREATE INDEX [IX_Fee_PersonID] ON [Fee] ([PersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211214017_U3A_Fee')
BEGIN
    CREATE INDEX [IX_Fee_ProcessingYear] ON [Fee] ([ProcessingYear]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211214017_U3A_Fee')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221211214017_U3A_Fee', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221212000414_U3A_CourseComplimentaryOverride')
BEGIN
    ALTER TABLE [Course] ADD [OverrideComplimentaryPerTermFee] bit NOT NULL DEFAULT CAST(0 AS bit);
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Overrides the System Settings complimentary status for term fees';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'OverrideComplimentaryPerTermFee';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221212000414_U3A_CourseComplimentaryOverride')
BEGIN
    ALTER TABLE [Course] ADD [OverrideComplimentaryPerYearFee] bit NOT NULL DEFAULT CAST(0 AS bit);
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Overrides the System Settings complimentary status for year fees';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'OverrideComplimentaryPerYearFee';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221212000414_U3A_CourseComplimentaryOverride')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221212000414_U3A_CourseComplimentaryOverride', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221212023735_U3A_FeeIsMemberFee')
BEGIN
    ALTER TABLE [Fee] ADD [IsMembershipFee] bit NOT NULL DEFAULT CAST(0 AS bit);
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'If true, will be included in the calculation of member Financial To';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Fee', 'COLUMN', N'IsMembershipFee';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221212023735_U3A_FeeIsMemberFee')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221212023735_U3A_FeeIsMemberFee', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221213042626_U3A_CourseExcludeLeaderComplimentaryCount')
BEGIN
    ALTER TABLE [Course] ADD [ExcludeFromLeaderComplimentaryCount] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221213042626_U3A_CourseExcludeLeaderComplimentaryCount')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221213042626_U3A_CourseExcludeLeaderComplimentaryCount', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221222190932_U3A_SendMailTermID')
BEGIN
    ALTER TABLE [SendMail] ADD [TermID] uniqueidentifier NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221222190932_U3A_SendMailTermID')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221222190932_U3A_SendMailTermID', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230109042807_U3A_TermClassAllocationFinalised')
BEGIN
    ALTER TABLE [Term] ADD [IsClassAllocationFinalised] bit NOT NULL DEFAULT CAST(0 AS bit);
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'True if class enrolment allocation is finished';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Term', 'COLUMN', N'IsClassAllocationFinalised';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230109042807_U3A_TermClassAllocationFinalised')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230109042807_U3A_TermClassAllocationFinalised', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230127204532_U3A_Dropout')
BEGIN
    ALTER TABLE [Person] ADD [SilentNumber] nvarchar(20) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230127204532_U3A_Dropout')
BEGIN
    CREATE TABLE [Dropout] (
        [ID] uniqueidentifier NOT NULL,
        [TermID] uniqueidentifier NOT NULL,
        [CourseID] uniqueidentifier NOT NULL,
        [ClassID] uniqueidentifier NULL,
        [PersonID] uniqueidentifier NOT NULL,
        [Created] datetime2 NOT NULL,
        [DropoutDate] datetime2 NOT NULL,
        [DateEnrolled] datetime2 NULL,
        [IsWaitlisted] bit NOT NULL,
        CONSTRAINT [PK_Dropout] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_Dropout_Class_ClassID] FOREIGN KEY ([ClassID]) REFERENCES [Class] ([ID]),
        CONSTRAINT [FK_Dropout_Course_CourseID] FOREIGN KEY ([CourseID]) REFERENCES [Course] ([ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_Dropout_Person_PersonID] FOREIGN KEY ([PersonID]) REFERENCES [Person] ([ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_Dropout_Term_TermID] FOREIGN KEY ([TermID]) REFERENCES [Term] ([ID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230127204532_U3A_Dropout')
BEGIN
    CREATE INDEX [IX_Dropout_ClassID] ON [Dropout] ([ClassID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230127204532_U3A_Dropout')
BEGIN
    CREATE INDEX [IX_Dropout_CourseID] ON [Dropout] ([CourseID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230127204532_U3A_Dropout')
BEGIN
    CREATE INDEX [IX_Dropout_PersonID] ON [Dropout] ([PersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230127204532_U3A_Dropout')
BEGIN
    CREATE INDEX [IX_Dropout_TermID] ON [Dropout] ([TermID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230127204532_U3A_Dropout')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230127204532_U3A_Dropout', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230127220550_U3A_DropoutDeletedBy')
BEGIN
    ALTER TABLE [Dropout] ADD [DeletedBy] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230127220550_U3A_DropoutDeletedBy')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230127220550_U3A_DropoutDeletedBy', N'7.0.1');
END;
GO

COMMIT;
GO

