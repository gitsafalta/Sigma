
using FluentValidation;

namespace Sigma.Application;

public class CandidateValidator : AbstractValidator<CandidateDTO>
{
   public CandidateValidator()
   {
    RuleFor(x=>x.FirstName).NotEmpty();
    RuleFor(x=>x.LastName).NotEmpty();
    RuleFor(x=>x.Email).NotEmpty();
    RuleFor(x=>x.Comment).NotEmpty();
   }
}