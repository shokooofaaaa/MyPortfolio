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

CREATE TABLE [ContactMessages] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Message] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_ContactMessages] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Educations] (
    [Id] uniqueidentifier NOT NULL,
    [InstituteName] nvarchar(max) NOT NULL,
    [DateOfStart] datetime2 NOT NULL,
    [DateOfEnd] datetime2 NOT NULL,
    [FieldOfStudy] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Educations] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Profiles] (
    [Id] uniqueidentifier NOT NULL,
    [FullName] nvarchar(max) NOT NULL,
    [Title] nvarchar(max) NOT NULL,
    [About] nvarchar(max) NOT NULL,
    [ImageUrl] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Profiles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Projects] (
    [Id] uniqueidentifier NOT NULL,
    [Title] nvarchar(max) NOT NULL,
    [GithubUrl] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Projects] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Skills] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Level] int NOT NULL,
    CONSTRAINT [PK_Skills] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [users] (
    [Id] uniqueidentifier NOT NULL,
    [Username] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_users] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [WorkExperiences] (
    [Id] uniqueidentifier NOT NULL,
    [Title] nvarchar(max) NOT NULL,
    [CompanyName] nvarchar(max) NOT NULL,
    [YearOfStart] datetime2 NOT NULL,
    [YearOfEnd] datetime2 NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_WorkExperiences] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260501130628_InitialCreate', N'8.0.11');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Projects] ADD [IsDelete] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260504111618_AddIsDeletePropertyInProjectsEntity', N'8.0.11');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Abouts] (
    [Id] uniqueidentifier NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Abouts] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260505064051_AddAboutTable', N'8.0.11');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Languages] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Level] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Languages] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260510055141_AddLanguageEntity', N'8.0.11');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[Abouts].[Description]', N'DescriptionFa', N'COLUMN';
GO

ALTER TABLE [Abouts] ADD [DescriptionEn] nvarchar(max) NOT NULL DEFAULT N'';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260510062008_AddDescriptionFaToAbout', N'8.0.11');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260510062134_AddDescriptionEnToAbout', N'8.0.11');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[Profiles].[Title]', N'ResumeFilePath', N'COLUMN';
GO

EXEC sp_rename N'[Profiles].[ImageUrl]', N'ProfileImagePath', N'COLUMN';
GO

EXEC sp_rename N'[Profiles].[FullName]', N'JobTitleFa', N'COLUMN';
GO

EXEC sp_rename N'[Profiles].[About]', N'JobTitleEn', N'COLUMN';
GO

ALTER TABLE [Profiles] ADD [FullNameEn] nvarchar(max) NOT NULL DEFAULT N'';
GO

ALTER TABLE [Profiles] ADD [FullNameFa] nvarchar(max) NOT NULL DEFAULT N'';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260510074110_RenameAndAddNewPropertiesInProfileEntity', N'8.0.11');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Profiles]') AND [c].[name] = N'ResumeFilePath');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Profiles] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Profiles] DROP COLUMN [ResumeFilePath];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260511085849_removeResumePath', N'8.0.11');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Educations] ADD [Degree] nvarchar(max) NOT NULL DEFAULT N'';
GO

ALTER TABLE [Educations] ADD [IsDelete] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260512071751_AddDegreeFieldANdIsDeleteToEducation', N'8.0.11');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Skills] ADD [IsDelete] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260513131822_IdeleteAdded', N'8.0.11');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [WorkExperiences] ADD [IsDelete] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260516160607_ISDeleteToWorkExprienceAdded', N'8.0.11');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[WorkExperiences].[YearOfStart]', N'DateOfStart', N'COLUMN';
GO

EXEC sp_rename N'[WorkExperiences].[YearOfEnd]', N'DateOfEnd', N'COLUMN';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260517070114_ReanameFieldOfWorkExprienceEntity', N'8.0.11');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[WorkExperiences]') AND [c].[name] = N'DateOfEnd');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [WorkExperiences] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [WorkExperiences] ALTER COLUMN [DateOfEnd] datetime2 NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260518103815_NullableDateTimeInWOrdExprienceEntity', N'8.0.11');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[Educations].[FieldOfStudy]', N'Title', N'COLUMN';
GO

EXEC sp_rename N'[Educations].[Degree]', N'Description', N'COLUMN';
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Educations]') AND [c].[name] = N'DateOfEnd');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Educations] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Educations] ALTER COLUMN [DateOfEnd] datetime2 NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260518134846_NullableDateTimeANDAddDescriptionToEducationEntity', N'8.0.11');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Educations]') AND [c].[name] = N'Description');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Educations] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Educations] ALTER COLUMN [Description] nvarchar(max) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260519072232_SetDescriptionNullableInEducationEntity', N'8.0.11');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Languages] ADD [IsDelete] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260519081402_IsDeleteAddedToLanguageEntity', N'8.0.11');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Languages]') AND [c].[name] = N'Level');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Languages] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Languages] ALTER COLUMN [Level] int NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260519081626_ChangeTypeOfLevelToIntInLanguageEntity', N'8.0.11');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [ContactMessages] ADD [CreatedAt] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260521141518_AddedCreatedAtInContactMessageEntity', N'8.0.11');
GO

COMMIT;
GO

