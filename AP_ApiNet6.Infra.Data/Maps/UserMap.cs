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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("IdUsuario")
                .UseIdentityColumn();

            builder.Property(c => c.Email)
                .HasColumnName("Email");

            builder.Property(c => c.Password)
                .HasColumnName("Senha");

            builder.HasMany(c => c.UserPermissions)
                .WithOne(p => p.User)
                .HasForeignKey(c => c.UserId);

        }
    }
}
