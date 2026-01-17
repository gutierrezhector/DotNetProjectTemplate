using FluentAssertions;
using Moq;
using SaM.Modules.Users.Domain.Services;
using SaM.Modules.Users.Ports.OutBounds.Repositories;
using Xunit;

namespace SaM.Modules.Users.Domain.Tests.Services;

public class UserDeletableServiceTests
{
    [Fact]
    public async Task User_Should_be_deletable_When_it_is_not_linked_to_a_teacher_or_a_student()
    {
        // Arrange
        var userRepositoryMock = new Mock<IUsersRepository>();
        userRepositoryMock.Setup(r => r.IsUserLinkedToTeacherAsync(It.IsAny<int>()))
            .ReturnsAsync(false);

        userRepositoryMock.Setup(r => r.IsUserLinkedToStudentAsync(It.IsAny<int>()))
            .ReturnsAsync(false);

        var service = new UserDeletableService(userRepositoryMock.Object);

        var fakeUserId = 0;

        // Act
        var result = await service.IsUserDeletableAsync(fakeUserId);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task User_Should_not_be_deletable_When_it_is_linked_to_a_teacher()
    {
        // Arrange
        var userRepositoryMock = new Mock<IUsersRepository>();
        userRepositoryMock.Setup(r => r.IsUserLinkedToTeacherAsync(It.IsAny<int>()))
            .ReturnsAsync(true);

        userRepositoryMock.Setup(r => r.IsUserLinkedToStudentAsync(It.IsAny<int>()))
            .ReturnsAsync(false);

        var service = new UserDeletableService(userRepositoryMock.Object);

        var fakeUserId = 0;

        // Act
        var result = await service.IsUserDeletableAsync(fakeUserId);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task User_Should_not_be_deletable_When_it_is_linked_to_a_student()
    {
        // Arrange
        var userRepositoryMock = new Mock<IUsersRepository>();
        userRepositoryMock.Setup(r => r.IsUserLinkedToTeacherAsync(It.IsAny<int>()))
            .ReturnsAsync(false);

        userRepositoryMock.Setup(r => r.IsUserLinkedToStudentAsync(It.IsAny<int>()))
            .ReturnsAsync(true);

        var service = new UserDeletableService(userRepositoryMock.Object);

        var fakeUserId = 0;

        // Act
        var result = await service.IsUserDeletableAsync(fakeUserId);

        // Assert
        result.Should().BeFalse();
    }
}