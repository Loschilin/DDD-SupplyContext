using System.Linq;
using Microsoft.EntityFrameworkCore;
using SupplyContext.Domain.Aggregates;

namespace SupplyContext.Infrastructure.Ef.Extentions
{
    internal static class SupplyContextExtentions
    {
        public static IQueryable<Invoce> QInvoce(this SupplyDataContext context)
        {
            return context
                .Invoces
                .Include(e => e.Lists)
                .AsNoTracking();
        }
    }
}