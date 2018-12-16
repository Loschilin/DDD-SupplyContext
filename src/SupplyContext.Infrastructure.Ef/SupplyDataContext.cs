using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SupplyContext.Domain;
using SupplyContext.Domain.Aggregates;
using SupplyContext.Domain.Common;
using SupplyContext.Infrastructure.Ef.ContextConfig;

namespace SupplyContext.Infrastructure.Ef
{
    internal class SupplyDataContext : DbContext
    {
        private readonly SupplyDataContextSettings _settings;

        public DbSet<Supply> Supplies { get; set; }
        public DbSet<Invoce> Invoces { get; set; }

        public SupplyDataContext(SupplyDataContextSettings settings)
        {
            _settings = settings;
        }

        public override int SaveChanges()
        {
            OnBeforeSaving();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = new CancellationToken())
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges(
            bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess, 
            CancellationToken cancellationToken = new CancellationToken())
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_settings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SupplyEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SupplyListEntityConfiguration());
            modelBuilder.ApplyConfiguration(new InvoceEntityConfiguration());
            modelBuilder.ApplyConfiguration(new InvoceListEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        private void OnBeforeSaving()
        {
            foreach (var entry in ChangeTracker.Entries<IAggregateRoot>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["Deleted"] = false;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["Deleted"] = true;
                        break;
                }
            }
        }
    }
}
