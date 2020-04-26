use master
drop database Shortpoet
use Shortpoet
select * from Profiles.Educations
select * from Profiles.SpokenLanguages
select * from Profiles.Skills
select * from Profiles.Jobs
select * from Profiles.Experiences
select * from Profiles.Resumes
select * from dbo.__EFMigrationsHistory


delete from Profiles.SpokenLanguages
delete from Profiles.Skills
delete from Profiles.Jobs
delete from Profiles.Resumes

drop table Profiles.ResumeSpokenLanguages
drop table Profiles.ResumeSkills
drop table Profiles.ResumeJobs
drop table Profiles.ResumeEducations
drop table Profiles.ResumeSocials
drop table Profiles.Educations
drop table Profiles.SpokenLanguages
drop table Profiles.Skills
drop table Profiles.Jobs
drop table Profiles.Socials
drop table Profiles.Resumes
drop table Profiles.__EFMigrationsHistory

select * from Profiles.Resumes
select * from Profiles.ResumeSkills
select * from Profiles.Resumes
select * from Profiles.ResumeSkills

select * from Profiles.Resumes
select * from Profiles.ResumeSkills
select * from Profiles.Resumes
select * from Profiles.ResumeSkills


DELETE FROM Profiles.Resumes
delete from Profiles.SpokenLanguages
delete from Profiles.Skills
delete from Profiles.Jobs
delete from Profiles.Educations
WHERE Id = 1

TRUNCATE TABLE Profiles.Resumes
GO
DBCC CHECKIDENT ('Profiles.Resumes', RESEED, 0)
DBCC CHECKIDENT ('Profiles.SpokenLanguages')
DBCC CHECKIDENT ('Profiles.Skills')
DBCC CHECKIDENT ('Profiles.Jobs')
DBCC CHECKIDENT ('Profiles.Resumes')
DBCC CHECKIDENT ('Profiles.Educations')

DBCC CHECKIDENT ('Profiles.SpokenLanguages', RESEED, 0)
DBCC CHECKIDENT ('Profiles.Skills', RESEED, 0)
DBCC CHECKIDENT ('Profiles.Jobs', RESEED, 0)
DBCC CHECKIDENT ('Profiles.Resumes', RESEED, 0)
DBCC CHECKIDENT ('Profiles.Educations', RESEED, 0)
