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

drop table Profiles.SpokenLanguages
drop table Profiles.Skills
drop table Profiles.Jobs
drop table Profiles.Experiences
drop table Profiles.Resumes
