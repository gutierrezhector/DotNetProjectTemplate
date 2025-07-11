using FluentAssertions;
using SaM.Modules.Users.Application.Candidates;
using SaM.Modules.Users.Domain.Validators;
using Xunit;

namespace SaM.Modules.Users.Domain.Tests.Validators;

public class UserCreationCandidateValidatorTests
{
    [Fact]
    public async Task Validation_Should_work_When_candidate_respect_validator_rules()
    {
        // Arrange
        var validator = new UserCreationCandidateValidator();

        var candidate = new UserCreationCandidate
        {
            FirstName = "Jotaro",
            LastName = "Kujo",
        };
        
        // Act
        var result = await validator.ValidateAsync(candidate);

        // Assert
        result.IsValid.Should().BeTrue();
    }
    
    [Fact]
    public async Task FirstName_Should_not_be_empty()
    {
        // Arrange
        var validator = new UserCreationCandidateValidator();

        var candidate = new UserCreationCandidate
        {
            FirstName = "",
            LastName = "Kujo",
        };
        
        // Act
        var result = await validator.ValidateAsync(candidate);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().HaveCount(1);
        result.Errors.First().ErrorMessage.Should().Be("FirstName can't be empty");
    }
    
    [Fact]
    public async Task LastName_Should_not_be_empty()
    {
        // Arrange
        var validator = new UserCreationCandidateValidator();

        var candidate = new UserCreationCandidate
        {
            FirstName = "Jotaro",
            LastName = "",
        };
        
        // Act
        var result = await validator.ValidateAsync(candidate);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().HaveCount(1);
        result.Errors.First().ErrorMessage.Should().Be("LastName can't be empty");
    }
}