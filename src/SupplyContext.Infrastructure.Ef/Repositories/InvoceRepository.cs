using System;
using System.Collections.Generic;
using System.Linq;
using SupplyContext.Domain.Abstractions;
using SupplyContext.Domain.Aggregates;
using SupplyContext.Domain.Common;
using SupplyContext.Infrastructure.Ef.Extentions;
using SupplyContext.Infrastructure.Ef.Factories.Abstractions;

namespace SupplyContext.Infrastructure.Ef.Repositories
{
    internal class InvoceRepository : IInvoceRepository
    {
        private readonly IContextFactory<SupplyDataContext> _contextFactory;

        public InvoceRepository(
            IContextFactory<SupplyDataContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public void Save(Invoce entity)
        {
            using (var context = _contextFactory.Cretae())
            {
                var exists = context
                    .Invoces
                    .FirstOrDefault(e => e.Number == entity.Number);

                if (exists == null)
                {
                    context.Add(entity);
                }
                else
                {
                    Update(exists, entity);
                }

                context.SaveChanges();
            }
        }

        private static void Update(Invoce source, Invoce destination)
        {
            throw new NotImplementedException();
        }

        public void Delete(Invoce entity)
        {
            using (var context = _contextFactory.Cretae())
            {
                context.Remove(entity);
            }
        }

        public IReadOnlyCollection<Invoce> Query(int skip, int take, ISpecification<Invoce> query)
        {
            using (var context = _contextFactory.Cretae())
            {
                var result = context.QInvoce();

                if (query != null)
                {
                    result = result.Where(e => query.IsSatisfiedBy(e));
                }

                result = result.Skip(skip).Take(take);
                return result.ToArray();
            }
        }
    }
}
