use master
drop database Shortpoet
use Shortpoet
select * from ProfilesTest.Educations
select * from ProfilesTest.SpokenLanguages
select * from ProfilesTest.Skills
select * from ProfilesTest.Jobs
select * from ProfilesTest.Experiences
select * from ProfilesTest.Resumes
select * from dbo.__EFMigrationsHistory


delete from ProfilesTest.SpokenLanguages
delete from ProfilesTest.Skills
delete from ProfilesTest.Jobs
delete from ProfilesTest.Resumes

drop table ProfilesTest.ResumeSpokenLanguages
drop table ProfilesTest.ResumeSkills
drop table ProfilesTest.ResumeJobs
drop table ProfilesTest.ResumeEducations
drop table ProfilesTest.ResumeSocials
drop table ProfilesTest.Educations
drop table ProfilesTest.SpokenLanguages
drop table ProfilesTest.Skills
drop table ProfilesTest.Jobs
drop table ProfilesTest.Socials
drop table ProfilesTest.Resumes
drop table ProfilesTest.__EFMigrationsHistory

select * from ProfilesTest.Resumes
select * from ProfilesTest.ResumeSkills
select * from Profiles.Resumes
select * from Profiles.ResumeSkills

select * from ProfilesTest.Resumes
select * from ProfilesTest.ResumeSkills
select * from Profiles.Resumes
select * from Profiles.ResumeSkills


DELETE FROM ProfilesTest.Resumes
delete from ProfilesTest.SpokenLanguages
delete from ProfilesTest.Skills
delete from ProfilesTest.Jobs
delete from ProfilesTest.Educations
WHERE Id = 1

TRUNCATE TABLE ProfilesTest.Resumes
GO
DBCC CHECKIDENT ('ProfilesTest.Resumes', RESEED, 0)
DBCC CHECKIDENT ('ProfilesTest.SpokenLanguages')
DBCC CHECKIDENT ('ProfilesTest.Skills')
DBCC CHECKIDENT ('ProfilesTest.Jobs')
DBCC CHECKIDENT ('ProfilesTest.Resumes')
DBCC CHECKIDENT ('ProfilesTest.Educations')

DBCC CHECKIDENT ('ProfilesTest.SpokenLanguages', RESEED, 0)
DBCC CHECKIDENT ('ProfilesTest.Skills', RESEED, 0)
DBCC CHECKIDENT ('ProfilesTest.Jobs', RESEED, 0)
DBCC CHECKIDENT ('ProfilesTest.Resumes', RESEED, 0)
DBCC CHECKIDENT ('ProfilesTest.Educations', RESEED, 0)
