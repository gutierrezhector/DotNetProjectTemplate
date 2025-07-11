using FluentAssertions;
using Moq;
using SaM.Modules.Exams.Application.Candidates;
using SaM.Modules.Exams.Domain.Validators;
using SaM.Modules.Teachers.Ports.OuBounds.Repositories;
using Xunit;

namespace SaM.Modules.Exams.Domain.Tests.Validators;

public class ExamCreationCandidateValidatorTests
{
    [Fact]
    public async Task Validation_Should_work_When_candidate_respect_validator_rules()
    {
        // Arrange
        var teacherRepositoryMock = new Mock<ITeacherRepository>();
        teacherRepositoryMock
            .Setup(r => r.ExistAsync(It.IsAny<int>()))
            .ReturnsAsync(true);

        var validator = new ExamCreationCandidateValidator(teacherRepositoryMock.Object);

        var candidate = new ExamCreationCandidate
        {
            MaxPoints = 20,
            StartDate = new DateTime(2000, 1, 1),
            EndDate = new DateTime(2000, 12, 31),
            ResponsibleTeacherId = 1,
            Title = "title",
        };

        // Act
        var result = await validator.ValidateAsync(candidate);

        // Assert
        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public async Task Title_Should_not_be_empty()
    {
        // Arrange
        var teacherRepositoryMock = new Mock<ITeacherRepository>();
        teacherRepositoryMock
            .Setup(r => r.ExistAsync(It.IsAny<int>()))
            .ReturnsAsync(true);

        var validator = new ExamCreationCandidateValidator(teacherRepositoryMock.Object);

        var candidate = new ExamCreationCandidate
        {
            MaxPoints = 20,
            StartDate = new DateTime(2000, 1, 1),
            EndDate = new DateTime(2000, 12, 31),
            ResponsibleTeacherId = 1,
            Title = "",
        };

        // Act
        var result = await validator.ValidateAsync(candidate);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().HaveCount(1);
        result.Errors.First().ErrorMessage.Should().Be("Title must not be empty.");
    }

    [Fact]
    public async Task MaxPoints_Should_not_be_superior_than_20()
    {
        // Arrange
        var teacherRepositoryMock = new Mock<ITeacherRepository>();
        teacherRepositoryMock
            .Setup(r => r.ExistAsync(It.IsAny<int>()))
            .ReturnsAsync(true);

        var validator = new ExamCreationCandidateValidator(teacherRepositoryMock.Object);

        var candidate = new ExamCreationCandidate
        {
            MaxPoints = 21,
            StartDate = new DateTime(2000, 1, 1),
            EndDate = new DateTime(2000, 12, 31),
            ResponsibleTeacherId = 1,
            Title = "title",
        };

        // Act
        var result = await validator.ValidateAsync(candidate);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().HaveCount(1);
        result.Errors.First().ErrorMessage.Should().Be("MaxPoints must not be superior to 20.");
    }

    [Fact]
    public async Task StartDate_Should_be_less_than_EndDate()
    {
        // Arrange
        var teacherRepositoryMock = new Mock<ITeacherRepository>();
        teacherRepositoryMock
            .Setup(r => r.ExistAsync(It.IsAny<int>()))
            .ReturnsAsync(true);

        var validator = new ExamCreationCandidateValidator(teacherRepositoryMock.Object);

        var candidate = new ExamCreationCandidate
        {
            MaxPoints = 20,
            StartDate = new DateTime(2000, 12, 2),
            EndDate = new DateTime(2000, 12, 1),
            ResponsibleTeacherId = 1,
            Title = "title",
        };

        // Act
        var result = await validator.ValidateAsync(candidate);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().HaveCount(1);
        result.Errors.First().ErrorMessage.Should().Be("StartDate must be less than EndDate.");
    }

    [Fact]
    public async Task Validation_Should_Fail_When_responsible_teacher_does_not_exist()
    {
        // Arrange
        var teacherRepositoryMock = new Mock<ITeacherRepository>();
        teacherRepositoryMock
            .Setup(r => r.ExistAsync(It.IsAny<int>()))
            .ReturnsAsync(false);

        var validator = new ExamCreationCandidateValidator(teacherRepositoryMock.Object);

        var candidate = new ExamCreationCandidate
        {
            MaxPoints = 20,
            StartDate = new DateTime(2000, 1, 1),
            EndDate = new DateTime(2000, 12, 31),
            ResponsibleTeacherId = 1,
            Title = "title",
        };

        // Act
        var result = await validator.ValidateAsync(candidate);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().HaveCount(1);
        result.Errors.First().ErrorMessage.Should().Be("Responsible Teacher must exists.");
    }
}