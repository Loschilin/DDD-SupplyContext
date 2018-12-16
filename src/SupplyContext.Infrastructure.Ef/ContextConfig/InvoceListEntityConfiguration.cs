using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplyContext.Domain;
using SupplyContext.Domain.Entities;
using SupplyContext.Domain.ValueObjects;

namespace SupplyContext.Infrastructure.Ef.ContextConfig
{
    internal class InvoceListEntityConfiguration : IEntityTypeConfiguration<InvoceList>
    {
        public void Configure(EntityTypeBuilder<InvoceList> builder)
        {
            builder.Property(e => e.BarCode)
                .HasConversion(e => e.ToString(), e => InvoiceBarCode.Parse(e));

            builder.Property(e => e.FileKey)
                .HasConversion(e => e.ToString(), e => FileKey.Parse(e));

            builder.Property<int>("Id").ValueGeneratedOnAdd();
            builder.HasKey("Id");

            builder.Property<int>("InvoceId");
        }
    }
}