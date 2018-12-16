using SupplyContext.Infrastructure.Ef.Factories.Abstractions;

namespace SupplyContext.Infrastructure.Ef.Factories
{
    internal class SupplyContextFactory : IContextFactory<SupplyDataContext>
    {
        private readonly SupplyDataContextSettings _settings;

        public SupplyContextFactory(SupplyDataContextSettings settings)
        {
            _settings = settings;
        }

        public SupplyDataContext Cretae()
        {
            return new SupplyDataContext(_settings);
        }
    }
}
