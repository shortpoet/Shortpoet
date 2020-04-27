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

drop table ProfilesTest.Educations

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



DELETE FROM ProfilesTest.Resumes
delete from ProfilesTest.SpokenLanguages
delete from ProfilesTest.Skills
delete from ProfilesTest.Jobs
delete from ProfilesTest.Educations
delete from ProfilesTest.ResumeSpokenLanguages
delete from ProfilesTest.ResumeSkills
delete from ProfilesTest.ResumeJobs
delete from ProfilesTest.ResumeEducations
delete from ProfilesTest.ResumeSocials

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

DBCC CHECKIDENT ('ProfilesTest.SpokenLanguages')
DBCC CHECKIDENT ('ProfilesTest.Skills')
DBCC CHECKIDENT ('ProfilesTest.Jobs')
DBCC CHECKIDENT ('ProfilesTest.Resumes')
DBCC CHECKIDENT ('ProfilesTest.Educations')
