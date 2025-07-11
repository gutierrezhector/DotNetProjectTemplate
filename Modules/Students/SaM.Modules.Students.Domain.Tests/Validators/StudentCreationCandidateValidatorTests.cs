using FluentAssertions;
using Moq;
using SaM.Modules.Students.Application.Candidates;
using SaM.Modules.Students.Domain.Validators;
using SaM.Modules.Students.Ports.OutBounds.Repositories;
using SaM.Modules.Teachers.Ports.OuBounds.Repositories;
using Xunit;

namespace SaM.Modules.Students.Domain.Tests.Validators;

public class StudentCreationCandidateValidatorTests
{
    [Fact]
    public async Task Validation_Should_work_When_candidate_respect_validator_rules()
    {
        // Arrange
        var teacherRepositoryMock = new Mock<ITeacherRepository>();
        teacherRepositoryMock
            .Setup(r => r.ExistAsync(It.IsAny<int>()))
            .ReturnsAsync(false);

        var studentsRepositoryMock = new Mock<IStudentsRepository>();
        studentsRepositoryMock
            .Setup(r => r.ExistAsync(It.IsAny<int>()))
            .ReturnsAsync(false);

        var validator = new StudentCreationCandidateValidator(teacherRepositoryMock.Object, studentsRepositoryMock.Object);

        var candidate = new StudentCreationCandidate
        {
            UserId = 1,
        };

        // Act
        var result = await validator.ValidateAsync(candidate);

        // Assert
        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public async Task Student_Should_Not_already_exist()
    {
        // Arrange
        var teacherRepositoryMock = new Mock<ITeacherRepository>();
        teacherRepositoryMock
            .Setup(r => r.ExistAsync(It.IsAny<int>()))
            .ReturnsAsync(false);

        var studentsRepositoryMock = new Mock<IStudentsRepository>();
        studentsRepositoryMock
            .Setup(r => r.ExistAsync(It.IsAny<int>()))
            .ReturnsAsync(true);

        var validator = new StudentCreationCandidateValidator(teacherRepositoryMock.Object, studentsRepositoryMock.Object);

        var candidate = new StudentCreationCandidate
        {
            UserId = 1,
        };

        // Act
        var result = await validator.ValidateAsync(candidate);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().HaveCount(1);
        result.Errors.First().ErrorMessage.Should().Be("User is already a student.");
    }


    [Fact]
    public async Task User_candidate_Should_Not_already_be_a_teacher()
    {
        // Arrange
        var teacherRepositoryMock = new Mock<ITeacherRepository>();
        teacherRepositoryMock
            .Setup(r => r.ExistAsync(It.IsAny<int>()))
            .ReturnsAsync(true);

        var studentsRepositoryMock = new Mock<IStudentsRepository>();
        studentsRepositoryMock
            .Setup(r => r.ExistAsync(It.IsAny<int>()))
            .ReturnsAsync(false);

        var validator = new StudentCreationCandidateValidator(teacherRepositoryMock.Object, studentsRepositoryMock.Object);

        var candidate = new StudentCreationCandidate
        {
            UserId = 1,
        };

        // Act
        var result = await validator.ValidateAsync(candidate);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().HaveCount(1);
        result.Errors.First().ErrorMessage.Should().Be("Teacher already exists.");
    }
}