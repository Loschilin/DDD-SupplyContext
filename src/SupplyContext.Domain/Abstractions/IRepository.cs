using System.Collections.Generic;
using SupplyContext.Domain.Common;

namespace SupplyContext.Domain.Abstractions
{
    public interface IRepository<TEntity> where TEntity: IAggregateRoot
    {
        void Save(TEntity entity);
        void Delete(TEntity entity);
        IReadOnlyCollection<TEntity> Query(int skip, int take, ISpecification<TEntity> query);
    }
}