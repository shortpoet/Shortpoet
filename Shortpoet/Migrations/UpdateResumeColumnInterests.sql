-- 20200320214827_UpdateResumeColumnInterests.cs

IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF SCHEMA_ID(N'Profile') IS NULL EXEC(N'CREATE SCHEMA [Profile];');

GO

CREATE TABLE [Profile].[Resumes] (
    [ResumeId] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NULL,
    [Name] nvarchar(max) NULL,
    [Surname] nvarchar(max) NULL,
    [Address] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [AboutMe] nvarchar(max) NULL,
    CONSTRAINT [PK_Resumes] PRIMARY KEY ([ResumeId])
);

GO

CREATE TABLE [Profile].[Educations] (
    [EducationId] int NOT NULL IDENTITY,
    [ResumeId] int NULL,
    [Institution] nvarchar(max) NULL,
    [Degree] nvarchar(max) NULL,
    [Focus] nvarchar(max) NULL,
    CONSTRAINT [PK_Educations] PRIMARY KEY ([EducationId]),
    CONSTRAINT [FK_Educations_Resumes_ResumeId] FOREIGN KEY ([ResumeId]) REFERENCES [Profile].[Resumes] ([ResumeId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Profile].[Experiences] (
    [ExperienceId] int NOT NULL IDENTITY,
    [ResumeId] int NULL,
    [Type] nvarchar(max) NULL,
    CONSTRAINT [PK_Experiences] PRIMARY KEY ([ExperienceId]),
    CONSTRAINT [FK_Experiences_Resumes_ResumeId] FOREIGN KEY ([ResumeId]) REFERENCES [Profile].[Resumes] ([ResumeId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Profile].[Skills] (
    [SkillId] int NOT NULL IDENTITY,
    [ResumeId] int NULL,
    [Type] nvarchar(max) NULL,
    [Details] nvarchar(max) NULL,
    CONSTRAINT [PK_Skills] PRIMARY KEY ([SkillId]),
    CONSTRAINT [FK_Skills_Resumes_ResumeId] FOREIGN KEY ([ResumeId]) REFERENCES [Profile].[Resumes] ([ResumeId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Profile].[SpokenLanguages] (
    [SpokenLanguagesId] int NOT NULL IDENTITY,
    [ResumeId] int NULL,
    [Type] nvarchar(max) NULL,
    [Languages] nvarchar(max) NULL,
    [TranslationInterpretationProfessional] bit NOT NULL,
    CONSTRAINT [PK_SpokenLanguages] PRIMARY KEY ([SpokenLanguagesId]),
    CONSTRAINT [FK_SpokenLanguages_Resumes_ResumeId] FOREIGN KEY ([ResumeId]) REFERENCES [Profile].[Resumes] ([ResumeId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Profile].[Jobs] (
    [JobId] int NOT NULL IDENTITY,
    [ResumeId] int NULL,
    [ExperienceId] int NULL,
    [Position] nvarchar(max) NULL,
    [Company] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [StartDate] nvarchar(max) NULL,
    [EndDate] nvarchar(max) NULL,
    CONSTRAINT [PK_Jobs] PRIMARY KEY ([JobId]),
    CONSTRAINT [FK_Jobs_Experiences_ExperienceId] FOREIGN KEY ([ExperienceId]) REFERENCES [Profile].[Experiences] ([ExperienceId])
);

GO

CREATE INDEX [IX_Educations_ResumeId] ON [Profile].[Educations] ([ResumeId]);

GO

CREATE INDEX [IX_Experiences_ResumeId] ON [Profile].[Experiences] ([ResumeId]);

GO

CREATE INDEX [IX_Jobs_ExperienceId] ON [Profile].[Jobs] ([ExperienceId]);

GO

CREATE INDEX [IX_Skills_ResumeId] ON [Profile].[Skills] ([ResumeId]);

GO

CREATE INDEX [IX_SpokenLanguages_ResumeId] ON [Profile].[SpokenLanguages] ([ResumeId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200320024431_InitialCreate', N'3.1.1');

GO

ALTER TABLE [Profile].[Resumes] ADD [Interests] nvarchar(max) NULL;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Interests') AND [object_id] = OBJECT_ID(N'[Profile].[Resumes]'))
    SET IDENTITY_INSERT [Profile].[Resumes] ON;
INSERT INTO [Profile].[Resumes] ([Interests])
VALUES (N'Cooking, organic gardening, yoga, health and fitness, scuba diving, voiceovers, acting');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Interests') AND [object_id] = OBJECT_ID(N'[Profile].[Resumes]'))
    SET IDENTITY_INSERT [Profile].[Resumes] OFF;

GO

UPDATE Profile.Resume SET Interests = 'Cooking, organic gardening, yoga, health and fitness, scuba diving, voiceovers, acting' WHERE ResumeId = 1

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200320183528_UpdateResumeColumnInterests', N'3.1.1');

GO


