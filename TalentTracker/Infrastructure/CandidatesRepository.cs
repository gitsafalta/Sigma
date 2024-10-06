using Sigma.Core;

namespace Sigma.Infrastructure;
public interface ICandidatesRepository
{
 Task SaveCandidate(Candidates candidate);
}

public class CandidatesRepository : ICandidatesRepository
{
 private readonly SigmaDBContext _context;

 public CandidatesRepository(SigmaDBContext context)
 {
  _context = context;
 }
 public Task SaveCandidate(Candidates candidate)
 {
   var existingCandidate = _context.Candidates.FirstOrDefault(x=>x.Id == candidate.Id);
   
   //create new candidate if not exists else update
   if(existingCandidate is null)
   {
    candidate.CreatedOn = DateTime.Now;
    _context.Candidates.Add(candidate);
   }
   else
   {
    existingCandidate.FirstName = candidate.FirstName;
    existingCandidate.LastName = candidate.LastName;
    existingCandidate.Email = candidate.Email;
    existingCandidate.PhoneNumber = candidate.PhoneNumber;
    existingCandidate.PreferredCallTimeInterval = candidate.PreferredCallTimeInterval;
    existingCandidate.LinkedInUrl = candidate.LinkedInUrl;
    existingCandidate.GitHubUrl = candidate.GitHubUrl;
    existingCandidate.Comment = candidate.Comment;
   }
   _context.SaveChanges();
   return Task.CompletedTask;
 }
}