
using AutoMapper;
using Sigma.Core;
using Sigma.Infrastructure;

namespace Sigma.Application;
public interface ICandidateService
{
 Task SaveCandidate(CandidateDTO model);
}


public class CandidateService : ICandidateService
{
 private readonly IMapper _mapper;
 private readonly ICandidatesRepository _candidateRepository;

 public CandidateService(IMapper mapper, ICandidatesRepository candidateRepository)
 {
  _mapper = mapper;
  _candidateRepository = candidateRepository;
 }

 public Task SaveCandidate(CandidateDTO model)
 {
   var candidate = _mapper.Map<Candidates>(model);
   candidate.Id = candidate.Id == Guid.Empty ? Guid.NewGuid() : candidate.Id;
   _candidateRepository.SaveCandidate(candidate);
   return Task.CompletedTask;
 }
}