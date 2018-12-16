using Microsoft.EntityFrameworkCore;

namespace SupplyContext.Infrastructure.Ef.Factories.Abstractions
{
    internal interface IContextFactory<out TContext>
        where TContext: DbContext
    {
        TContext Cretae();
    }
}
