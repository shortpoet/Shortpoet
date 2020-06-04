using System;
using System.Collections;

namespace DbConnect
{
  public enum FileTypes
  {
    Education,
    Jobs,
    Skills,
    Socials,
    Languages,
    About
  }

  public static class ResumeFileStrings
  {
    public const string ProjectRoot = "Data/Models/ResumeData/Resumes";
    public const string Resume = "carlos_resume_about.yml";
    public const string Education = "carlos_resume_educations.yml";
    public const string Job = "carlos_resume_jobs.yml";
    public const string Skill = "carlos_resume_skills.yml";
    public const string Social = "carlos_resume_socials.yml";
    public const string SpokenLanguages = "carlos_resume_languages.yml";
    public const string ResumeEducations = "carlos_resume_resumeeducations.yml";
    public const string ResumeJobs = "carlos_resume_resumejobs.yml";
    public const string ResumeSkills = "carlos_resume_resumeskills.yml";
    public const string ResumeSocials = "carlos_resume_resumesocials.yml";
    public const string ResumeSpokenLanguages = "carlos_resume_resumespokenlanguages.yml";

  }
  // https://support.microsoft.com/en-us/help/322022/how-to-make-a-visual-c-class-usable-in-a-foreach-statement
  public class ResumeFiles : IEnumerable, IEnumerator
  {
    private string[] fileArray;
    public ResumeFiles(string dateFolder)
    {
      fileArray = new string[11];
      fileArray[0] = Resume = $"{ResumeFileStrings.ProjectRoot}/{dateFolder}/{ResumeFileStrings.Resume}";
      fileArray[1] = Education = $"{ResumeFileStrings.ProjectRoot}/{dateFolder}/{ResumeFileStrings.Education}";
      fileArray[2] = Job = $"{ResumeFileStrings.ProjectRoot}/{dateFolder}/{ResumeFileStrings.Job}";
      fileArray[3] = Skill = $"{ResumeFileStrings.ProjectRoot}/{dateFolder}/{ResumeFileStrings.Skill}";
      fileArray[4] = Social = $"{ResumeFileStrings.ProjectRoot}/{dateFolder}/{ResumeFileStrings.Social}";
      fileArray[5] = SpokenLanguages = $"{ResumeFileStrings.ProjectRoot}/{dateFolder}/{ResumeFileStrings.SpokenLanguages}";
      fileArray[6] = ResumeEducations = $"{ResumeFileStrings.ProjectRoot}/{dateFolder}/{ResumeFileStrings.ResumeEducations}";
      fileArray[7] = ResumeJobs = $"{ResumeFileStrings.ProjectRoot}/{dateFolder}/{ResumeFileStrings.ResumeJobs}";
      fileArray[8] = ResumeSkills = $"{ResumeFileStrings.ProjectRoot}/{dateFolder}/{ResumeFileStrings.ResumeSkills}";
      fileArray[9] = ResumeSocials = $"{ResumeFileStrings.ProjectRoot}/{dateFolder}/{ResumeFileStrings.ResumeSocials}";
      fileArray[10] = ResumeSpokenLanguages = $"{ResumeFileStrings.ProjectRoot}/{dateFolder}/{ResumeFileStrings.ResumeSpokenLanguages}";
    }
    public string Resume { get; set; }
    public string Education { get; set; }
    public string Job { get; set; }
    public string Skill { get; set; }
    public string Social { get; set; }
    public string SpokenLanguages { get; set; }
    public string ResumeEducations { get; set; }
    public string ResumeJobs { get; set; }
    public string ResumeSkills { get; set; }
    public string ResumeSocials { get; set; }
    public string ResumeSpokenLanguages { get; set; }

    int position = -1;
    public object Current => fileArray[position];

    public IEnumerator GetEnumerator()
    {
      return (IEnumerator)this;
    }

    public bool MoveNext()
    {
      position++;
      return (position < fileArray.Length);
    }

    public void Reset()
    {
      position = 0;
    }
  }
}
