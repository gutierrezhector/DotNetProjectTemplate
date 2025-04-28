using SaM.Core.Abstractions.Mappers;
using SaM.Core.Abstractions.Tests.Mappers.FakeModels;

namespace SaM.Core.Abstractions.Tests.Mappers.FakeMappers;

internal class FakeBlogDaoMapper(
    Mapper<FakePostEntity, FakePostDao> fakePostDaoMapper
) : Mapper<FakBlogEntity, FakeBlogDao>
{
    public override FakeBlogDao MapNonNullable(FakBlogEntity from)
    {
        return new FakeBlogDao
        {
            FakeTitle = from.FakeTitle,
            FakePosts = fakePostDaoMapper.MapNullable(from.FakePosts)
        };
    }
}