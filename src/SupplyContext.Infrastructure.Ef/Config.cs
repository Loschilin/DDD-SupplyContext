using Microsoft.Extensions.DependencyInjection;
using SupplyContext.Domain.Abstractions;
using SupplyContext.Infrastructure.Ef.Factories;
using SupplyContext.Infrastructure.Ef.Factories.Abstractions;
using SupplyContext.Infrastructure.Ef.Repositories;

namespace SupplyContext.Infrastructure.Ef
{
    public static class Config
    {
        public static IServiceCollection AddEfSupplyContext(
            this IServiceCollection services,
            SupplyDataContextSettings settings)
        {
            services.AddSingleton(settings);

            services.AddSingleton<IInvoceRepository, InvoceRepository>();

            services.AddSingleton<IContextFactory<SupplyDataContext>, SupplyContextFactory>();

            return services;
        }
    }
}
