﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SupplyContext.Infrastructure.Ef;

namespace SupplyContext.Infrastructure.Ef.Migrations
{
    [DbContext(typeof(SupplyDataContext))]
    [Migration("20181215180612_SoftDeleteInvoce")]
    partial class SoftDeleteInvoce
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SupplyContext.Domain.Aggregates.Invoce", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("Goods");

                    b.Property<string>("Number");

                    b.Property<string>("SupplyNumber");

                    b.HasKey("Id");

                    b.HasIndex("Number")
                        .IsUnique()
                        .HasFilter("[Number] IS NOT NULL");

                    b.HasIndex("SupplyNumber");

                    b.ToTable("Invoces","dbo");
                });

            modelBuilder.Entity("SupplyContext.Domain.Entities.InvoceList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BarCode")
                        .IsRequired();

                    b.Property<string>("FileKey")
                        .IsRequired();

                    b.Property<int>("InvoceId");

                    b.HasKey("Id");

                    b.HasIndex("InvoceId");

                    b.ToTable("InvoceList");
                });

            modelBuilder.Entity("SupplyContext.Domain.Entities.SupplyList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BarCode")
                        .IsRequired();

                    b.Property<string>("FileKey")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("SupplyLists","dbo");
                });

            modelBuilder.Entity("SupplyContext.Domain.Supply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContractorCode");

                    b.Property<DateTime>("Date");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<int?>("ListId");

                    b.Property<string>("Number");

                    b.HasKey("Id");

                    b.HasIndex("ListId")
                        .IsUnique()
                        .HasFilter("[ListId] IS NOT NULL");

                    b.HasIndex("Number");

                    b.ToTable("Supplies","dbo");
                });

            modelBuilder.Entity("SupplyContext.Domain.Entities.InvoceList", b =>
                {
                    b.HasOne("SupplyContext.Domain.Aggregates.Invoce")
                        .WithMany("Lists")
                        .HasForeignKey("InvoceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SupplyContext.Domain.Supply", b =>
                {
                    b.HasOne("SupplyContext.Domain.Entities.SupplyList", "TitleList")
                        .WithOne()
                        .HasForeignKey("SupplyContext.Domain.Supply", "ListId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
