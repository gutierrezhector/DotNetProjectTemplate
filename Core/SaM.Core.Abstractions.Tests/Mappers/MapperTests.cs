using FluentAssertions;
using SaM.Core.Abstractions.Tests.Mappers.FakeMappers;
using SaM.Core.Abstractions.Tests.Mappers.FakeModels;
using Xunit;

namespace SaM.Core.Abstractions.Tests.Mappers;

public class MapperTests
{
    [Fact]
    public void MapNullable_with_null_instance_Should_not_map_and_return_null()
    {
        // Init
        var mapper = GetMapper();
        
        // Act
        FakBlogEntity? fakeBlog = null;
        var result = mapper.MapNullable(fakeBlog);

        // Assert
        result.Should().BeNull();
    }
    
    [Fact]
    public void MapNullable_with_null_list_Should_not_map_and_return_null()
    {
        // Init
        var mapper = GetMapper();
        
        // Act
        List<FakBlogEntity>? fakeListBlog = null;
        var result = mapper.MapNullable(fakeListBlog);

        // Assert
        result.Should().BeNull();
    }
    
    [Fact]
    public void MapNullable_with_null_nested_list_Should_not_map_and_be_null()
    {
        // Init
        var mapper = GetMapper();
        
        // Act
        FakBlogEntity fakeListBlog = new FakBlogEntity
        {
            FakeTitle = "title",
            FakePosts = null,
        };
        
        var result = mapper.MapNullable(fakeListBlog);

        // Assert
        result.Should().NotBeNull();
        result.FakeTitle.Should().Be(fakeListBlog.FakeTitle);
        result.FakePosts.Should().BeNull();
    }
    
    private static FakeBlogDaoMapper GetMapper()
    {
        return new FakeBlogDaoMapper(new FakePostDaoMapper());
    }
}