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
    public class PersonImageMap : IEntityTypeConfiguration<PersonImage>
    {
        public void Configure(EntityTypeBuilder<PersonImage> builder)
        {
            builder.ToTable("PessoaImagem");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("IdImagem")
                .UseIdentityColumn();

            builder.Property(c => c.PersonId)
                .HasColumnName("IdPessoa");

            builder.Property(c => c.ImageBase)
                .HasColumnName("ImagemBase");

            builder.Property(c => c.ImageUri)
                .HasColumnName("ImagemUrl");

            builder.HasOne(x => x.Person)
                .WithMany(x => x.PersonImages);
        }
    }
}
