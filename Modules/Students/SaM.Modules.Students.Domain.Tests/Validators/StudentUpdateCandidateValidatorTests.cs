using FluentAssertions;
using SaM.Core.Types.Entities.Students;
using SaM.Modules.Students.Application.Candidates;
using SaM.Modules.Students.Domain.Validators;
using SaM.Modules.Students.Ports.InBounds;
using Xunit;

namespace SaM.Modules.Students.Domain.Tests.Validators;

public class StudentUpdateCandidateValidatorTests
{

    [Fact]
    public async Task Validation_Should_work_When_candidate_respect_validator_rules()
    {
        // Arrange
        var validator = new StudentUpdateCandidateValidator();

        var candidate = new StudentUpdateCandidate
        {
            UserId = 1,
        };

        var entity = new Student
        {
            Id = 1,
            UserId = 1,
        };

        var wrapper = new StudentUpdateWrapper(candidate, entity);

        // Act
        var result = await validator.ValidateAsync(wrapper);

        // Assert
        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public async Task UserId_Should_not_be_updatable()
    {
        // Arrange
        var validator = new StudentUpdateCandidateValidator();

        var candidate = new StudentUpdateCandidate
        {
            UserId = 2,
        };

        var entity = new Student
        {
            Id = 1,
            UserId = 1,
        };

        var wrapper = new StudentUpdateWrapper(candidate, entity);

        // Act
        var result = await validator.ValidateAsync(wrapper);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().HaveCount(1);
        result.Errors.First().ErrorMessage.Should().Be("Can't update UserId, create a new student.");
    }
}