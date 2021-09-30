# Shortpoet Db Connect

## Usage

- load correct data into Data/Models
- set connection string source folders in Program.cs
  - resume
    - new data in dYYYYMMDD
    - new relations in rYYYYMMDD (complete set)
    - find/replace €resumeId: {x}€ -> €resumeId: {x}€
    - find/replace comments: {x}€ -> comments: {x}€
    - change necessary relation according to new data
  - jobs get added in order so have to readd jobs that you want to show up with most current at top
  - new skills break grid on pdf

## TODO

- implement safe guard so no data is written in case of error

- reset identity
- [Reset identity seed after deleting records in SQL Server](https://stackoverflow.com/questions/21824478/reset-identity-seed-after-deleting-records-in-sql-server)

- data tables

  - resumes

  ```sql
  delete from [shortpoet].[ProfilesTest].[Resumes] where Id = 5

  declare @max int select @max=ISNULL(max([Id]),0) from [shortpoet].[ProfilesTest].[Resumes];
  PRINT @max;
  DBCC CHECKIDENT ('[shortpoet].[ProfilesTest].[Resumes]', RESEED, @max );

  SELECT IDENT_CURRENT( '[shortpoet].[ProfilesTest].[Resumes]' );
  ```

  - skills

  ```sql
  delete from [shortpoet].[ProfilesTest].[Skills] where Id between 19 and 20

  declare @max int select @max=ISNULL(max([Id]),0) from [shortpoet].[ProfilesTest].[Skills];
  PRINT @max;
  DBCC CHECKIDENT ('[shortpoet].[ProfilesTest].[Skills]', RESEED, @max );

  SELECT IDENT_CURRENT( '[shortpoet].[ProfilesTest].[Skills]' );
  ```

  - jobs

  ```sql
  delete from [shortpoet].[ProfilesTest].[Jobs] where Id between 23 and 38

  declare @max int select @max=ISNULL(max([Id]),0) from [shortpoet].[ProfilesTest].[Jobs];
  PRINT @max;
  DBCC CHECKIDENT ('[shortpoet].[ProfilesTest].[Jobs]', RESEED, @max );

  SELECT IDENT_CURRENT( '[shortpoet].[ProfilesTest].[Jobs]' );
  ```

- relation tables

  - resume spoken languages

  ```sql
  delete from [shortpoet].[ProfilesTest].[ResumeSpokenLanguages] where ResumeId = 5
  ```

  - resume jobs

  ```sql
  delete from [shortpoet].[ProfilesTest].[ResumeJobs] where ResumeId = 5
  ```

  - resume skills

  ```sql
  delete from [shortpoet].[ProfilesTest].[ResumeSkills] where ResumeId = 5
  ```

  - resume socials

  ```sql
  delete from [shortpoet].[ProfilesTest].[ResumeSocials] where ResumeId = 5
  ```

- implement rollback method
