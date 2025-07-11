using FluentAssertions;
using Moq;
using SaM.Core.Types.Entities.Exams;
using SaM.Modules.Exams.Ports.OutBounds.Repositories;
using SaM.Modules.Grades.Domain.Candidates;
using SaM.Modules.Grades.Domain.Validators;
using SaM.Modules.Grades.Ports.OutBounds.Repositories;
using Xunit;

namespace SaM.Modules.Grades.Domain.Tests.Validators;

public class GradeCreationCandidateValidatorTests
{
    [Fact]
    public async Task Validation_Should_work_When_candidate_respect_validator_rules()
    {
        // Arrange
        var gradeRepositoryMock = new Mock<IGradesRepository>();
        gradeRepositoryMock
            .Setup(r => r.ExistAsync(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(false);
        
        var examRepositoryMock = new Mock<IExamsRepository>();
        examRepositoryMock
            .Setup(r => r.GetByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(new Exam
            {
                Id = 1,
                MaxPoints = 20,
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 12, 31),
                ResponsibleTeacherId = 1,
                Title = "title",
            });
        
        var validator = new GradeCreationCandidateValidator(gradeRepositoryMock.Object, examRepositoryMock.Object);

        var candidate = new GradeCreationCandidate
        {
            Notation = 10,
            ExamId = 1,
            StudentId = 1,
        };
        
        // Act
        var result = await validator.ValidateAsync(candidate);

        // Assert
        result.IsValid.Should().BeTrue();
    }
    
    [Fact]
    public async Task Notation_Should_not_be_negative()
    {
        // Arrange
        var gradeRepositoryMock = new Mock<IGradesRepository>();
        gradeRepositoryMock
            .Setup(r => r.ExistAsync(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(false);
        
        var examRepositoryMock = new Mock<IExamsRepository>();
        examRepositoryMock
            .Setup(r => r.GetByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(new Exam
            {
                Id = 1,
                MaxPoints = 20,
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 12, 31),
                ResponsibleTeacherId = 1,
                Title = "title",
            });
        
        var validator = new GradeCreationCandidateValidator(gradeRepositoryMock.Object, examRepositoryMock.Object);

        var candidate = new GradeCreationCandidate
        {
            Notation = -1,
            ExamId = 1,
            StudentId = 1,
        };
        
        // Act
        var result = await validator.ValidateAsync(candidate);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().HaveCount(1);
        result.Errors.First().ErrorMessage.Should().Be("Notation must not be negative.");
    }
    
    [Fact]
    public async Task Notation_Should_not_be_superior_to_exam_max_points()
    {
        // Arrange
        var gradeRepositoryMock = new Mock<IGradesRepository>();
        gradeRepositoryMock
            .Setup(r => r.ExistAsync(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(false);
        
        var examRepositoryMock = new Mock<IExamsRepository>();
        examRepositoryMock
            .Setup(r => r.GetByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(new Exam
            {
                Id = 1,
                MaxPoints = 20,
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 12, 31),
                ResponsibleTeacherId = 1,
                Title = "title",
            });
        
        var validator = new GradeCreationCandidateValidator(gradeRepositoryMock.Object, examRepositoryMock.Object);

        var candidate = new GradeCreationCandidate
        {
            Notation = 21,
            ExamId = 1,
            StudentId = 1,
        };
        
        // Act
        var result = await validator.ValidateAsync(candidate);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().HaveCount(1);
        result.Errors.First().ErrorMessage.Should().Be("Grade notation must be inferior or equal to exam max points.");
    }
    
    [Fact]
    public async Task Grade_Should_not_already_exist_for_a_student_exam()
    {
        // Arrange
        var gradeRepositoryMock = new Mock<IGradesRepository>();
        gradeRepositoryMock
            .Setup(r => r.ExistAsync(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(true);
        
        var examRepositoryMock = new Mock<IExamsRepository>();
        examRepositoryMock
            .Setup(r => r.GetByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(new Exam
            {
                Id = 1,
                MaxPoints = 20,
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 12, 31),
                ResponsibleTeacherId = 1,
                Title = "title",
            });
        
        var validator = new GradeCreationCandidateValidator(gradeRepositoryMock.Object, examRepositoryMock.Object);

        var candidate = new GradeCreationCandidate
        {
            Notation = 10,
            ExamId = 1,
            StudentId = 1,
        };
        
        // Act
        var result = await validator.ValidateAsync(candidate);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().HaveCount(1);
        result.Errors.First().ErrorMessage.Should().Be("This exam already have a grade for this student.");
    }
}