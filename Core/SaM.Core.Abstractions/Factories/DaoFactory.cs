namespace SaM.Core.Abstractions.Factories;

public abstract class DaoFactory<TDao, T, TCandidate>
{
    public abstract TDao CreateFromEntity(T entity);
    public abstract void UpdateFromCandidate(TDao daoToUpdate, TCandidate updateCandidate);
}