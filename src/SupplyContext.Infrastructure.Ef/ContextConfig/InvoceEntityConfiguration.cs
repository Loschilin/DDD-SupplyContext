using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Remotion.Linq.Clauses;
using SupplyContext.Domain.Aggregates;
using SupplyContext.Domain.Common;
using SupplyContext.Domain.ValueObjects;

namespace SupplyContext.Infrastructure.Ef.ContextConfig
{
    internal class InvoceEntityConfiguration: IEntityTypeConfiguration<Invoce>
    {
        private const string CollectionValueSeparator = "(:)";

        public void Configure(EntityTypeBuilder<Invoce> builder)
        {
            builder.ToTable("Invoces", SupplyContextSchemes.Deault);

            builder.Property<int>("Id").ValueGeneratedOnAdd();
            builder.HasKey("Id");

            builder.HasIndex(e => new {e.Number}).IsUnique();
            builder.HasIndex(e => e.SupplyNumber);

            builder.Property(e => e.Goods);

            var navigation =
                builder.Metadata.FindNavigation(nameof(Invoce.Lists));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder
                .Property(e => e.Goods)
                .HasConversion(e => GetCollectionValue(e), v => ParseGoods(v).ToArray());

            builder.HasMany(e => e.Lists).WithOne().HasForeignKey("InvoceId");
            builder.Property<bool>("Deleted").HasDefaultValue(false);
        }

        private static IEnumerable<GoodNumber> ParseGoods(string s)
        {
            return s.Split(CollectionValueSeparator, StringSplitOptions.RemoveEmptyEntries)
                .Select(GoodNumber.Parse).ToArray();
        }

        private static string GetCollectionValue<TValue>(IEnumerable<TValue> values)
            where TValue : IValueObject
        {
            return string.Join(CollectionValueSeparator, values);
        }
    }
}