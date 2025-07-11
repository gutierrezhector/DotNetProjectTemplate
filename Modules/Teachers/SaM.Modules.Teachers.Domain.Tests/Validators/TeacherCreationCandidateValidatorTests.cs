using FluentAssertions;
using Moq;
using SaM.Core.Types.Enums;
using SaM.Modules.Students.Ports.OutBounds.Repositories;
using SaM.Modules.Teachers.Application.Candidates;
using SaM.Modules.Teachers.Domain.Validators;
using SaM.Modules.Teachers.Ports.OuBounds.Repositories;
using Xunit;

namespace SaM.Modules.Teachers.Domain.Tests.Validators;

public class TeacherCreationCandidateValidatorTests
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

        var validator = new TeacherCreationCandidateValidator(teacherRepositoryMock.Object, studentsRepositoryMock.Object);

        var candidate = new TeacherCreationCandidate
        {
            SchoolSubject = SchoolSubject.English,
            UserId = 1,
        };

        // Act
        var result = await validator.ValidateAsync(candidate);

        // Assert
        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public async Task SchoolSubject_Should_not_be_undefined()
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

        var validator = new TeacherCreationCandidateValidator(teacherRepositoryMock.Object, studentsRepositoryMock.Object);

        var candidate = new TeacherCreationCandidate
        {
            SchoolSubject = SchoolSubject.Undefined,
            UserId = 1,
        };

        // Act
        var result = await validator.ValidateAsync(candidate);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().HaveCount(1);
        result.Errors.First().ErrorMessage.Should().Be("SchoolSubject needs to be defined.");
    }

    [Fact]
    public async Task Teacher_Should_Not_already_exist()
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

        var validator = new TeacherCreationCandidateValidator(teacherRepositoryMock.Object, studentsRepositoryMock.Object);

        var candidate = new TeacherCreationCandidate
        {
            SchoolSubject = SchoolSubject.English,
            UserId = 1,
        };

        // Act
        var result = await validator.ValidateAsync(candidate);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().HaveCount(1);
        result.Errors.First().ErrorMessage.Should().Be("Teacher already exists.");
    }

    [Fact]
    public async Task User_candidate_Should_Not_already_be_a_student()
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

        var validator = new TeacherCreationCandidateValidator(teacherRepositoryMock.Object, studentsRepositoryMock.Object);

        var candidate = new TeacherCreationCandidate
        {
            SchoolSubject = SchoolSubject.English,
            UserId = 1,
        };

        // Act
        var result = await validator.ValidateAsync(candidate);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().HaveCount(1);
        result.Errors.First().ErrorMessage.Should().Be("User is already a student.");
    }
}