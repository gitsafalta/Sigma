
using AutoMapper;
using Sigma.Core;

namespace Sigma.Application.Mapper;
public class CandidateMapper :Profile
{
 public CandidateMapper(){
   CreateMap<Candidates, CandidateDTO>().ReverseMap();
 }
}