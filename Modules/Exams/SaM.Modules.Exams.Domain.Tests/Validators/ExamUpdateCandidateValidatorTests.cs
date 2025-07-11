using FluentAssertions;
using Moq;
using SaM.Core.Types.Entities.Exams;
using SaM.Modules.Exams.Application.Candidates;
using SaM.Modules.Exams.Domain.Validators;
using SaM.Modules.Teachers.Ports.OuBounds.Repositories;
using Xunit;

namespace SaM.Modules.Exams.Domain.Tests.Validators;

public class ExamUpdateCandidateValidatorTests
{
    [Fact]
    public async Task Validation_Should_work_When_candidate_respect_validator_rules()
    {
        // Arrange
        var teacherRepositoryMock = new Mock<ITeachersRepository>();
        teacherRepositoryMock
            .Setup(r => r.ExistAsync(It.IsAny<int>()))
            .ReturnsAsync(true);

        var validator = new ExamUpdateCandidateValidator(teacherRepositoryMock.Object);

        var entity = new Exam
        {
            Id = 1,
            MaxPoints = 20,
            StartDate = new DateTimeOffset(2025, 1, 1, 9, 0, 0, TimeSpan.FromHours(2)),
            EndDate = new DateTimeOffset(2025, 1, 1, 10, 0, 0, TimeSpan.FromHours(2)),
            ResponsibleTeacherId = 1,
            Title = "title",
        };

        var candidate = new ExamUpdateCandidate
        {
            MaxPoints = 10,
            StartDate = new DateTimeOffset(2025, 1, 1, 16, 0, 0, TimeSpan.FromHours(2)),
            EndDate = new DateTimeOffset(2025, 1, 1, 17, 0, 0, TimeSpan.FromHours(2)),
            ResponsibleTeacherId = 1,
            Title = "title updated",
        };

        var wrapper = new TeacherUpdateWrapper(candidate, entity);

        // Act
        var result = await validator.ValidateAsync(wrapper);

        // Assert
        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public async Task Title_Should_not_be_empty()
    {
        // Arrange
        var teacherRepositoryMock = new Mock<ITeachersRepository>();
        teacherRepositoryMock
            .Setup(r => r.ExistAsync(It.IsAny<int>()))
            .ReturnsAsync(true);

        var validator = new ExamUpdateCandidateValidator(teacherRepositoryMock.Object);

        var entity = new Exam
        {
            Id = 1,
            MaxPoints = 20,
            StartDate = new DateTimeOffset(2025, 1, 1, 9, 0, 0, TimeSpan.FromHours(2)),
            EndDate = new DateTimeOffset(2025, 1, 1, 10, 0, 0, TimeSpan.FromHours(2)),
            ResponsibleTeacherId = 1,
            Title = "title",
        };

        var candidate = new ExamUpdateCandidate
        {
            MaxPoints = 20,
            StartDate = new DateTimeOffset(2025, 1, 1, 9, 0, 0, TimeSpan.FromHours(2)),
            EndDate = new DateTimeOffset(2025, 1, 1, 10, 0, 0, TimeSpan.FromHours(2)),
            ResponsibleTeacherId = 1,
            Title = "",
        };

        var wrapper = new TeacherUpdateWrapper(candidate, entity);

        // Act
        var result = await validator.ValidateAsync(wrapper);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().HaveCount(1);
        result.Errors.First().ErrorMessage.Should().Be("Title must not be empty.");
    }

    [Fact]
    public async Task MaxPoints_Should_not_be_superior_than_20()
    {
        // Arrange
        var teacherRepositoryMock = new Mock<ITeachersRepository>();
        teacherRepositoryMock
            .Setup(r => r.ExistAsync(It.IsAny<int>()))
            .ReturnsAsync(true);

        var validator = new ExamUpdateCandidateValidator(teacherRepositoryMock.Object);

        var entity = new Exam
        {
            Id = 1,
            MaxPoints = 20,
            StartDate = new DateTimeOffset(2025, 1, 1, 9, 0, 0, TimeSpan.FromHours(2)),
            EndDate = new DateTimeOffset(2025, 1, 1, 10, 0, 0, TimeSpan.FromHours(2)),
            ResponsibleTeacherId = 1,
            Title = "title",
        };

        var candidate = new ExamUpdateCandidate
        {
            MaxPoints = 21,
            StartDate = new DateTimeOffset(2025, 1, 1, 9, 0, 0, TimeSpan.FromHours(2)),
            EndDate = new DateTimeOffset(2025, 1, 1, 10, 0, 0, TimeSpan.FromHours(2)),
            ResponsibleTeacherId = 1,
            Title = "title",
        };

        var wrapper = new TeacherUpdateWrapper(candidate, entity);

        // Act
        var result = await validator.ValidateAsync(wrapper);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().HaveCount(1);
        result.Errors.First().ErrorMessage.Should().Be("MaxPoints must not be superior to 20.");
    }

    [Fact]
    public async Task StartDate_Should_be_less_than_EndDate()
    {
        // Arrange
        var teacherRepositoryMock = new Mock<ITeachersRepository>();
        teacherRepositoryMock
            .Setup(r => r.ExistAsync(It.IsAny<int>()))
            .ReturnsAsync(true);

        var validator = new ExamUpdateCandidateValidator(teacherRepositoryMock.Object);

        var entity = new Exam
        {
            Id = 1,
            MaxPoints = 20,
            StartDate = new DateTimeOffset(2025, 1, 1, 9, 0, 0, TimeSpan.FromHours(2)),
            EndDate = new DateTimeOffset(2025, 1, 1, 10, 0, 0, TimeSpan.FromHours(2)),
            ResponsibleTeacherId = 1,
            Title = "title",
        };

        var candidate = new ExamUpdateCandidate
        {
            MaxPoints = 20,
            StartDate = new DateTimeOffset(2025, 1, 1, 9, 0, 0, TimeSpan.FromHours(2)),
            EndDate = new DateTimeOffset(2025, 1, 1, 8, 0, 0, TimeSpan.FromHours(2)),
            ResponsibleTeacherId = 1,
            Title = "title",
        };

        var wrapper = new TeacherUpdateWrapper(candidate, entity);

        // Act
        var result = await validator.ValidateAsync(wrapper);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().HaveCount(1);
        result.Errors.First().ErrorMessage.Should().Be("StartDate must be less than EndDate.");
    }

    [Fact]
    public async Task Validation_Should_Fail_When_responsible_teacher_does_not_exist()
    {
        // Arrange
        var teacherRepositoryMock = new Mock<ITeachersRepository>();
        teacherRepositoryMock
            .Setup(r => r.ExistAsync(It.IsAny<int>()))
            .ReturnsAsync(false);

        var validator = new ExamUpdateCandidateValidator(teacherRepositoryMock.Object);

        var entity = new Exam
        {
            Id = 1,
            MaxPoints = 20,
            StartDate = new DateTimeOffset(2025, 1, 1, 9, 0, 0, TimeSpan.FromHours(2)),
            EndDate = new DateTimeOffset(2025, 1, 1, 10, 0, 0, TimeSpan.FromHours(2)),
            ResponsibleTeacherId = 1,
            Title = "title",
        };

        var candidate = new ExamUpdateCandidate
        {
            MaxPoints = 20,
            StartDate = new DateTimeOffset(2025, 1, 1, 9, 0, 0, TimeSpan.FromHours(2)),
            EndDate = new DateTimeOffset(2025, 1, 1, 10, 0, 0, TimeSpan.FromHours(2)),
            ResponsibleTeacherId = 2,
            Title = "title",
        };

        var wrapper = new TeacherUpdateWrapper(candidate, entity);

        // Act
        var result = await validator.ValidateAsync(wrapper);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().HaveCount(1);
        result.Errors.First().ErrorMessage.Should().Be("Responsible Teacher must exists.");
    }
}