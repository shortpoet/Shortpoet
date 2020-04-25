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

drop table Profiles.Educations

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
