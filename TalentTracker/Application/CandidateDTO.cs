
using System.ComponentModel.DataAnnotations;

public class CandidateDTO
{
 public Guid Id{get; set;}
 
 public string? FirstName { get; set; }
 public string? LastName { get; set; }
 public  string? PhoneNumber { get; set; } 
 public string? Email { get; set; }
 public string? PreferredCallTimeInterval { get; set; }
 public string? LinkedInUrl { get; set; }
 public string? GitHubUrl { get; set; }
 public string? Comment { get; set; }
}
