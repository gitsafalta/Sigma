using FluentValidation.TestHelper;
using Sigma.Application;

namespace TalentTracker.UnitTests;

public class CandidateValidatorTests
{
    private readonly CandidateValidator _validator;

    private CandidateDTO model = new CandidateDTO {
                                  Id =Guid.NewGuid(),
                                  FirstName = "Irish", 
                                  LastName="Rusak", 
                                  PhoneNumber = "", 
                                  Email="irina.rusak@sigma.com", 
                                  PreferredCallTimeInterval = "between 5PM to 5:30PM",
                                  LinkedInUrl = "www.linkedin.com/in/irina-rusak-1b854326",
                                  GitHubUrl = "https://github.com/gitirina/sigma",
                                  Comment="applied for .Net Developer"
                                 };

    public CandidateValidatorTests()
    {
        _validator = new CandidateValidator();
    }

    [Fact]
    public void Should_Have_Error_When_FirstName_Is_Empty()
    {
        // Arrange
        var model = new CandidateDTO { FirstName = string.Empty };

        // Act & Assert
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(candidate => candidate.FirstName);
    }

    [Fact]
    public void Should_Have_Error_When_FirstName_Is_Null()
    {
        // Arrange
        model.FirstName = null;

        // Act & Assert
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(candidate => candidate.FirstName);
    }

    [Fact]
    public void Should_Have_Error_When_LastName_Is_Empty()
    {
        // Arrange
        var model = new CandidateDTO { LastName = string.Empty };

        // Act & Assert
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(candidate => candidate.LastName);
    }

     [Fact]
    public void Should_Have_Error_When_LastName_Is_NULL()
    {
        // Arrange
       model.LastName = null;

        // Act & Assert
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(candidate => candidate.LastName);
    }

    [Fact]
    public void Should_Have_Error_When_Email_Is_Empty()
    {
        // Arrange
        var model = new CandidateDTO { Email = string.Empty };

        // Act & Assert
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(candidate => candidate.Email);
    }

    [Fact]
    public void Should_Have_Error_When_Email_Is_Null()
    {
        // Arrange
        model.Email = null;

        // Act & Assert
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(candidate => candidate.Email);
    }


    [Fact]
    public void Should_Have_Error_When_Comment_Is_Empty()
    {
        // Arrange
        var model = new CandidateDTO { Comment = string.Empty };

        // Act & Assert
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(candidate => candidate.Comment);
    }

    [Fact]
    public void Should_Have_Error_When_Comment_Is_Null()
    {
        // Arrange
        model.Comment = null;

        // Act & Assert
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(candidate => candidate.Comment);
    }
}
