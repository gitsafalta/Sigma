using Microsoft.Extensions.Caching.Memory;
using Sigma.Core;

namespace Sigma.Infrastructure;
public interface ICandidatesRepository
{
 Task SaveCandidate(Candidates candidate);
}

public class CandidatesRepository : ICandidatesRepository
{
 private readonly SigmaDBContext _context;
 private readonly IMemoryCache _cache;

 public CandidatesRepository(IMemoryCache cache, SigmaDBContext context)
 {
  _context = context;
  _cache = cache;
 }
 public Task SaveCandidate(Candidates candidate)
 {
  
    Candidates? existingCandidate;
  
    if (_cache.TryGetValue(candidate.Id, out Candidates? cachedCandidate))
      existingCandidate = cachedCandidate;
    else
      existingCandidate = _context.Candidates.FirstOrDefault(x=>x.Id == candidate.Id);
   
   //create new candidate if not exists else update
   if(existingCandidate is null)
   {
    candidate.CreatedOn = DateTime.Now;
    _context.Candidates.Add(candidate);
     _cache.Set(candidate.Id, candidate, TimeSpan.FromMinutes(10));
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
     _cache.Set(candidate.Id, existingCandidate, TimeSpan.FromMinutes(10));
   }

   
   _context.SaveChanges();
   return Task.CompletedTask;
 }
}