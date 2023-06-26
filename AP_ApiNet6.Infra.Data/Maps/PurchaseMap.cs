using AP_ApiNet6.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_ApiNet6.Infra.Data.Maps
{
    public class PurchaseMap : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("Compra");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("IdCompra")
                .UseIdentityColumn();

            builder.Property(c => c.PersonId)
                .HasColumnName("IdPessoa");

            builder.Property(c => c.ProductId)
                .HasColumnName("IdProduto");

            builder.Property(c => c.Date)
                .HasColumnType("date")
                .HasColumnName("DataCompra");

            builder.HasOne(c => c.Person)
                .WithMany(p => p.Purchases);

            builder.HasOne(c => c.Product)
                .WithMany(p => p.Purchases);

        }
    }
}
