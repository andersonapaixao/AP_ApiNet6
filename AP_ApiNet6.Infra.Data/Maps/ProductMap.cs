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
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Idproduto")
                .UseIdentityColumn();

            builder.Property(c => c.CodErp)
                .HasColumnName("CodErp");

            builder.Property(c => c.Name)
                .HasColumnName("Nome");

            builder.Property(c => c.Price)
                .HasColumnName("Preco");

            builder.HasMany(c => c.Purchases)
                .WithOne(p => p.Product)
                .HasForeignKey(c => c.ProductId);
        }
    }
}
