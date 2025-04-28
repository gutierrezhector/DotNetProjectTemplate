using SaM.Core.Abstractions.Mappers;
using SaM.Core.Abstractions.Tests.Mappers.FakeModels;

namespace SaM.Core.Abstractions.Tests.Mappers.FakeMappers;

internal class FakePostDaoMapper : Mapper<FakePostEntity, FakePostDao>
{
    public override FakePostDao? MapNonNullable(FakePostEntity? from)
    {
        if (from is null)
        {
            return null;
        }

        return new FakePostDao
        {
            FakeMessage = from.FakeMessage,
        };
    }
}