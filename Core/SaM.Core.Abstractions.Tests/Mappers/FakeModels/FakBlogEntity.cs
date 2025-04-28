namespace SaM.Core.Abstractions.Tests.Mappers.FakeModels;

internal class FakBlogEntity
{
    public required string FakeTitle { get; set; }
    public List<FakePostEntity>? FakePosts { get; set; }
}