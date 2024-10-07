using System.Text;
using AutoMapper;
using Moq;
using Newtonsoft.Json;
using Sigma.Application;
using Sigma.Core;
using Sigma.Infrastructure;

namespace TalentTracker.UnitTests;

public class CandidateTests
{
    private readonly Mock<ICandidatesRepository> _candidateRepositoryMock;
    private readonly CandidateService _candidateService;
    private readonly IMapper _mapper;

    private readonly string baseAddress = "http://localhost:5040";

    public CandidateTests()
    {
        _candidateRepositoryMock = new Mock<ICandidatesRepository>();
        _mapper = new Mock<IMapper>().Object;
        _candidateService = new CandidateService(_mapper,_candidateRepositoryMock.Object);
    }
 
    [Fact]
    public async Task CreateCandidateAsync_ValidCandidate_ReturnsCreatedResult()
    {
        // Arrange
        var id = Guid.Parse("4685db1a-d8ee-4ffd-af70-c56a49bb1a72");
        var newCandidate = new Candidates{
                                  Id =id, 
                                  FirstName="Irina", 
                                  LastName="Rusak", 
                                  PhoneNumber = "", 
                                  Email="irina.rusak@sigma.com", 
                                  PreferredCallTimeInterval = "between 5PM to 5:30PM",
                                  LinkedInUrl = "www.linkedin.com/in/irina-rusak-1b854326",
                                  GitHubUrl = "https://github.com/gitirina/sigma",
                                  Comment="applied for .Net Developer"
                                 };
        _candidateRepositoryMock.Setup(repo => repo.SaveCandidate(newCandidate));
        
        var httpClient = new HttpClient();
        var jsonContent = JsonConvert.SerializeObject(newCandidate);
        var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        // Act
        var response = await httpClient.PostAsync($@"{baseAddress}/api/candidate", httpContent);

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);
    }

   [Fact]
    public async Task UpdateCandidateAsync_ValidCandidate_ReturnsCreatedResult()
    {
        // Arrange
         var id = Guid.Parse("4685db1a-d8ee-4ffd-af70-c56a49bb1a72");
        var updateCandidate = new Candidates{
                                  Id =id, 
                                  FirstName="Safalta", 
                                  LastName="Manandhar", 
                                  PhoneNumber = "", 
                                  Email="safalta@sigma.com", 
                                  PreferredCallTimeInterval = "between 6PM to 6:30PM",
                                  LinkedInUrl = "www.linkedin.com/in/safalta-manandhar-1b854326",
                                  GitHubUrl = "https://github.com/gitsafalta/sigma",
                                  Comment="applied for .Net Developer"
                                 };
        _candidateRepositoryMock.Setup(repo => repo.SaveCandidate(updateCandidate));
        
        var httpClient = new HttpClient();
        var jsonContent = JsonConvert.SerializeObject(updateCandidate);
        var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        // Act
        var response = await httpClient.PostAsync($@"{baseAddress}/api/candidate", httpContent);

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);
    }

   
    [Fact]
    public async Task CreateCandidateAsync_NullCandidate_ReturnsBadRequest()
    {
        // Arrange
        Candidates nullCandidate = null;
        
        var httpClient = new HttpClient();
        var jsonContent = JsonConvert.SerializeObject(nullCandidate);
        var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        // Act
        var response = await httpClient.PostAsync($@"{baseAddress}/api/candidate", httpContent);

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }
    
}
