using System;

namespace DbConnect.Data.Models.BlogData
{
  public class Post
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string Body { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;

  }
}