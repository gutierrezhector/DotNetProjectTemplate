namespace SaM.Core.Abstractions.Tests.Mappers.FakeModels;

internal class FakeBlogDao
{
    public required string FakeTitle { get; set; }
    public List<FakePostDao>? FakePosts { get; set; }
}