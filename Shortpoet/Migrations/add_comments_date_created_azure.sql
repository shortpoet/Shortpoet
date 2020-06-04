-- Run 20200604

ALTER TABLE [ProfilesTest].[Educations] ADD [DateCreated] DATETIME NOT NULL DEFAULT ('20200427 4:20:00 PM') WITH VALUES;
ALTER TABLE [ProfilesTest].[Jobs] ADD [DateCreated] DATETIME NOT NULL DEFAULT ('20200427 4:20:00 PM') WITH VALUES;
ALTER TABLE [ProfilesTest].[Skills] ADD [DateCreated] DATETIME NOT NULL DEFAULT ('20200427 4:20:00 PM') WITH VALUES;
ALTER TABLE [ProfilesTest].[Socials] ADD [DateCreated] DATETIME NOT NULL DEFAULT ('20200427 4:20:00 PM') WITH VALUES;
ALTER TABLE [ProfilesTest].[SpokenLanguages] ADD [DateCreated] DATETIME NOT NULL DEFAULT ('20200427 4:20:00 PM') WITH VALUES;
ALTER TABLE [ProfilesTest].[ResumeEducations] ADD [DateCreated] DATETIME NOT NULL DEFAULT ('20200427 4:20:00 PM') WITH VALUES;
ALTER TABLE [ProfilesTest].[ResumeJobs] ADD [DateCreated] DATETIME NOT NULL DEFAULT ('20200427 4:20:00 PM') WITH VALUES;
ALTER TABLE [ProfilesTest].[ResumeSkills] ADD [DateCreated] DATETIME NOT NULL DEFAULT ('20200427 4:20:00 PM') WITH VALUES;
ALTER TABLE [ProfilesTest].[ResumeSocials] ADD [DateCreated] DATETIME NOT NULL DEFAULT ('20200427 4:20:00 PM') WITH VALUES;
ALTER TABLE [ProfilesTest].[ResumeSpokenLanguages] ADD [DateCreated] DATETIME NOT NULL DEFAULT ('20200427 4:20:00 PM') WITH VALUES;

ALTER TABLE [profiles].[Educations] ADD [DateCreated] DATETIME NOT NULL DEFAULT ('20200427 4:20:00 PM') WITH VALUES;
ALTER TABLE [profiles].[Jobs] ADD [DateCreated] DATETIME NOT NULL DEFAULT ('20200427 4:20:00 PM') WITH VALUES;
ALTER TABLE [profiles].[Skills] ADD [DateCreated] DATETIME NOT NULL DEFAULT ('20200427 4:20:00 PM') WITH VALUES;
ALTER TABLE [profiles].[Socials] ADD [DateCreated] DATETIME NOT NULL DEFAULT ('20200427 4:20:00 PM') WITH VALUES;
ALTER TABLE [profiles].[SpokenLanguages] ADD [DateCreated] DATETIME NOT NULL DEFAULT ('20200427 4:20:00 PM') WITH VALUES;
ALTER TABLE [profiles].[ResumeEducations] ADD [DateCreated] DATETIME NOT NULL DEFAULT ('20200427 4:20:00 PM') WITH VALUES;
ALTER TABLE [profiles].[ResumeJobs] ADD [DateCreated] DATETIME NOT NULL DEFAULT ('20200427 4:20:00 PM') WITH VALUES;
ALTER TABLE [profiles].[ResumeSkills] ADD [DateCreated] DATETIME NOT NULL DEFAULT ('20200427 4:20:00 PM') WITH VALUES;
ALTER TABLE [profiles].[ResumeSocials] ADD [DateCreated] DATETIME NOT NULL DEFAULT ('20200427 4:20:00 PM') WITH VALUES;
ALTER TABLE [profiles].[ResumeSpokenLanguages] ADD [DateCreated] DATETIME NOT NULL DEFAULT ('20200427 4:20:00 PM') WITH VALUES;

ALTER TABLE [ProfilesTest].[Educations] ADD [Comments] NVARCHAR(MAX) NULL;
ALTER TABLE [ProfilesTest].[Jobs] ADD [Comments] NVARCHAR(MAX) NULL;
ALTER TABLE [ProfilesTest].[Resumes] ADD [Comments] NVARCHAR(MAX) NULL;
ALTER TABLE [ProfilesTest].[Skills] ADD [Comments] NVARCHAR(MAX) NULL;
ALTER TABLE [ProfilesTest].[Socials] ADD [Comments] NVARCHAR(MAX) NULL;
ALTER TABLE [ProfilesTest].[SpokenLanguages] ADD [Comments] NVARCHAR(MAX) NULL;
ALTER TABLE [ProfilesTest].[ResumeEducations] ADD [Comments] NVARCHAR(MAX) NULL;
ALTER TABLE [ProfilesTest].[ResumeJobs] ADD [Comments] NVARCHAR(MAX) NULL;
ALTER TABLE [ProfilesTest].[ResumeSkills] ADD [Comments] NVARCHAR(MAX) NULL;
ALTER TABLE [ProfilesTest].[ResumeSocials] ADD [Comments] NVARCHAR(MAX) NULL;
ALTER TABLE [ProfilesTest].[ResumeSpokenLanguages] ADD [Comments] NVARCHAR(MAX) NULL;

ALTER TABLE [profiles].[Educations] ADD [Comments] NVARCHAR(MAX) NULL;
ALTER TABLE [profiles].[Jobs] ADD [Comments] NVARCHAR(MAX) NULL;
ALTER TABLE [profiles].[Resumes] ADD [Comments] NVARCHAR(MAX) NULL;
ALTER TABLE [profiles].[Skills] ADD [Comments] NVARCHAR(MAX) NULL;
ALTER TABLE [profiles].[Socials] ADD [Comments] NVARCHAR(MAX) NULL;
ALTER TABLE [profiles].[SpokenLanguages] ADD [Comments] NVARCHAR(MAX) NULL;
ALTER TABLE [profiles].[ResumeEducations] ADD [Comments] NVARCHAR(MAX) NULL;
ALTER TABLE [profiles].[ResumeJobs] ADD [Comments] NVARCHAR(MAX) NULL;
ALTER TABLE [profiles].[ResumeSkills] ADD [Comments] NVARCHAR(MAX) NULL;
ALTER TABLE [profiles].[ResumeSocials] ADD [Comments] NVARCHAR(MAX) NULL;
ALTER TABLE [profiles].[ResumeSpokenLanguages] ADD [Comments] NVARCHAR(MAX) NULL;