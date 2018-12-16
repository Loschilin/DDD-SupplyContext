namespace SupplyContext.Domain.Common
{
    public interface ISpecification<TEntity>
    {
        bool IsSatisfiedBy(TEntity candidate);
        ISpecification<TEntity> And(ISpecification<TEntity> other);
        ISpecification<TEntity> Or(ISpecification<TEntity> other);
        ISpecification<TEntity> Not();
    }
}
