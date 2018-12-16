using Microsoft.EntityFrameworkCore.Design;

namespace SupplyContext.Infrastructure.Ef.Factories
{
    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SupplyDataContext>
    {
        public SupplyDataContext CreateDbContext(string[] args)
        {
            var settings = new SupplyDataContextSettings
            {
                ConnectionString = @"data source=localhost,1433;initial catalog=SupplyContext;
                    integrated security=False;User Id=sa; Password=SuperS3cretPassw0rd; 
                    MultipleActiveResultSets=True;App=SupplyContext;Packet size=1500"
            };

            return new SupplyDataContext(settings);
        }
    }
}