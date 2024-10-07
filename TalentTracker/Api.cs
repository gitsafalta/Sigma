using FluentValidation;
using Sigma.Application;

public static class Api
{
 public static void ConfigureApi(this WebApplication app)
 {
  var candidate = app.MapGroup("api/candidate").WithTags("/candidate");
  candidate.MapPost("", SaveCandidate).WithTags("Candidate");
 }

 private async static Task<IResult> SaveCandidate(ICandidateService candidatService, CandidateDTO model, IValidator<CandidateDTO> validator)
 {
    FluentValidation.Results.ValidationResult result = await validator.ValidateAsync(model);
    if (!result.IsValid)
    {
        // Return a validation problem response with the errors
      return Results.ValidationProblem(result.ToDictionary());
    }
    await candidatService.SaveCandidate(model);
    return Results.Created();
 }
}