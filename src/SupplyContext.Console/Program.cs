using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SupplyContext.Domain;
using SupplyContext.Domain.Abstractions;
using SupplyContext.Domain.Aggregates;
using SupplyContext.Domain.Entities;
using SupplyContext.Domain.ValueObjects;
using SupplyContext.Infrastructure.Ef;

namespace SupplyContext.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = BuildConfiguration();

            var dbSettings = new SupplyDataContextSettings
            {
                ConnectionString = config.GetConnectionString("SqlDataConnection")
            };

            var provider = new ServiceCollection()
                .AddEfSupplyContext(dbSettings).BuildServiceProvider();

            var repo = provider.GetService<IInvoceRepository>();

            //=====

            var goods = new[]
            {
                GoodNumber.Parse("G4"),
                GoodNumber.Parse("G2"),
                GoodNumber.Parse("G6"),
                GoodNumber.Parse("G6"),
                GoodNumber.Parse("G6")
            };

            var invoce = new Invoce("34h-334", "AAA-2", goods);

            var invoceList = new InvoceList(
                    InvoiceBarCode.Parse("CodeBI-1"), 
                    FileKey.Parse("FK-1")
                );

            invoce.WhenListBeScan(invoceList);

            //repo.Save(invoce);

            var invoces = repo.Query(0, 10, null);
        }

        private static IConfiguration BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true);

            return builder.Build();
        }
    }
}
