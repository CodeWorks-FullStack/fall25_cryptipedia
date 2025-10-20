using System.ComponentModel.DataAnnotations;

namespace cryptipedia.Models;

// REVIEW cs:class code snippet

public class Cryptid : RepoItem<int>
{
  public string Name { get; set; }
  public int ThreatLevel { get; set; }
  public int Size { get; set; }
  [Url] public string ImgUrl { get; set; }
  public string Origin { get; set; }
  public string Description { get; set; }
  public string DiscovererId { get; set; }
  public Profile Discoverer { get; set; }
}