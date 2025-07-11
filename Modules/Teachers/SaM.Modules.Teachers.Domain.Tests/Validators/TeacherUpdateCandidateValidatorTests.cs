using FluentAssertions;
using SaM.Core.Types.Entities.Teachers;
using SaM.Core.Types.Enums;
using SaM.Modules.Teachers.Application.Candidates;
using SaM.Modules.Teachers.Domain.Validators;
using Xunit;

namespace SaM.Modules.Teachers.Domain.Tests.Validators;

public class TeacherUpdateCandidateValidatorTests
{
    [Fact]
    public async Task Validation_Should_work_When_candidate_respect_validator_rules()
    {
        // Arrange
        var validator = new TeacherUpdateCandidateValidator();

        var candidate = new TeacherUpdateCandidate
        {
            SchoolSubject = SchoolSubject.French,
            UserId = 1,
        };

        var entity = new Teacher
        {
            Id = 1,
            SchoolSubject = SchoolSubject.English,
            UserId = 1,
        };

        var wrapper = new TeacherUpdateWrapper(candidate, entity);

        // Act
        var result = await validator.ValidateAsync(wrapper);

        // Assert
        result.IsValid.Should().BeTrue();
    }
    
    [Fact]
    public async Task SchoolSubject_Should_not_be_undefined()
    {
        // Arrange
        var validator = new TeacherUpdateCandidateValidator();

        var candidate = new TeacherUpdateCandidate
        {
            SchoolSubject = SchoolSubject.Undefined,
            UserId = 1,
        };

        var entity = new Teacher
        {
            Id = 1,
            SchoolSubject = SchoolSubject.English,
            UserId = 1,
        };

        var wrapper = new TeacherUpdateWrapper(candidate, entity);

        // Act
        var result = await validator.ValidateAsync(wrapper);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().HaveCount(1);
        result.Errors.First().ErrorMessage.Should().Be("SchoolSubject needs to be defined.");
    }
    
    [Fact]
    public async Task UserId_Should_not_be_updatable()
    {
        // Arrange
        var validator = new TeacherUpdateCandidateValidator();

        var candidate = new TeacherUpdateCandidate
        {
            SchoolSubject = SchoolSubject.English,
            UserId = 2,
        };

        var entity = new Teacher
        {
            Id = 1,
            SchoolSubject = SchoolSubject.English,
            UserId = 1,
        };

        var wrapper = new TeacherUpdateWrapper(candidate, entity);

        // Act
        var result = await validator.ValidateAsync(wrapper);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().HaveCount(1);
        result.Errors.First().ErrorMessage.Should().Be("Can't update UserId, create a new teacher.");
    }
}