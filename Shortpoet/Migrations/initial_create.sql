IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Educations] (
    [Id] int NOT NULL IDENTITY,
    [Institution] nvarchar(max) NULL,
    [Degree] nvarchar(max) NULL,
    [Focus] nvarchar(max) NULL,
    CONSTRAINT [PK_Educations] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Jobs] (
    [Id] int NOT NULL IDENTITY,
    [ExperienceType] nvarchar(max) NULL,
    [Position] nvarchar(max) NULL,
    [Company] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [StartDate] nvarchar(max) NULL,
    [EndDate] nvarchar(max) NULL,
    CONSTRAINT [PK_Jobs] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Resumes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [Title] nvarchar(max) NULL,
    [Name] nvarchar(max) NULL,
    [Surname] nvarchar(max) NULL,
    [Address] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Visas] nvarchar(max) NULL,
    [Flags] nvarchar(max) NULL,
    [Brief] nvarchar(max) NULL,
    [AboutMe] nvarchar(max) NULL,
    [Interests] nvarchar(max) NULL,
    CONSTRAINT [PK_Resumes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Skills] (
    [Id] int NOT NULL IDENTITY,
    [Type] nvarchar(max) NULL,
    [Details] nvarchar(max) NULL,
    CONSTRAINT [PK_Skills] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Socials] (
    [Id] int NOT NULL IDENTITY,
    [Provider] nvarchar(max) NULL,
    [Url] nvarchar(max) NULL,
    CONSTRAINT [PK_Socials] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [SpokenLanguages] (
    [Id] int NOT NULL IDENTITY,
    [Type] nvarchar(max) NULL,
    [Languages] nvarchar(max) NULL,
    [TranslationInterpretationProfessional] bit NOT NULL,
    CONSTRAINT [PK_SpokenLanguages] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [ResumeEducations] (
    [ResumeId] int NOT NULL,
    [EducationId] int NOT NULL,
    CONSTRAINT [PK_ResumeEducations] PRIMARY KEY ([ResumeId], [EducationId]),
    CONSTRAINT [FK_ResumeEducations_Educations_EducationId] FOREIGN KEY ([EducationId]) REFERENCES [Educations] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ResumeEducations_Resumes_ResumeId] FOREIGN KEY ([ResumeId]) REFERENCES [Resumes] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ResumeJobs] (
    [ResumeId] int NOT NULL,
    [JobId] int NOT NULL,
    CONSTRAINT [PK_ResumeJobs] PRIMARY KEY ([ResumeId], [JobId]),
    CONSTRAINT [FK_ResumeJobs_Jobs_JobId] FOREIGN KEY ([JobId]) REFERENCES [Jobs] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ResumeJobs_Resumes_ResumeId] FOREIGN KEY ([ResumeId]) REFERENCES [Resumes] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ResumeSkills] (
    [ResumeId] int NOT NULL,
    [SkillId] int NOT NULL,
    CONSTRAINT [PK_ResumeSkills] PRIMARY KEY ([ResumeId], [SkillId]),
    CONSTRAINT [FK_ResumeSkills_Resumes_ResumeId] FOREIGN KEY ([ResumeId]) REFERENCES [Resumes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ResumeSkills_Skills_SkillId] FOREIGN KEY ([SkillId]) REFERENCES [Skills] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ResumeSocials] (
    [ResumeId] int NOT NULL,
    [SocialId] int NOT NULL,
    CONSTRAINT [PK_ResumeSocials] PRIMARY KEY ([ResumeId], [SocialId]),
    CONSTRAINT [FK_ResumeSocials_Resumes_ResumeId] FOREIGN KEY ([ResumeId]) REFERENCES [Resumes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ResumeSocials_Socials_SocialId] FOREIGN KEY ([SocialId]) REFERENCES [Socials] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ResumeSpokenLanguages] (
    [ResumeId] int NOT NULL,
    [SpokenLanguagesId] int NOT NULL,
    CONSTRAINT [PK_ResumeSpokenLanguages] PRIMARY KEY ([ResumeId], [SpokenLanguagesId]),
    CONSTRAINT [FK_ResumeSpokenLanguages_Resumes_ResumeId] FOREIGN KEY ([ResumeId]) REFERENCES [Resumes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ResumeSpokenLanguages_SpokenLanguages_SpokenLanguagesId] FOREIGN KEY ([SpokenLanguagesId]) REFERENCES [SpokenLanguages] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_ResumeEducations_EducationId] ON [ResumeEducations] ([EducationId]);

GO

CREATE INDEX [IX_ResumeJobs_JobId] ON [ResumeJobs] ([JobId]);

GO

CREATE INDEX [IX_ResumeSkills_SkillId] ON [ResumeSkills] ([SkillId]);

GO

CREATE INDEX [IX_ResumeSocials_SocialId] ON [ResumeSocials] ([SocialId]);

GO

CREATE INDEX [IX_ResumeSpokenLanguages_SpokenLanguagesId] ON [ResumeSpokenLanguages] ([SpokenLanguagesId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200427003154_InitialCreate', N'3.1.4');

GO