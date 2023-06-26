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
    public class UserPermissionMap : IEntityTypeConfiguration<UserPermission>
    {
        public void Configure(EntityTypeBuilder<UserPermission> builder)
        {
            builder.ToTable("PermissaoUsuario");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("IdPermissaoUsuario")
                .UseIdentityColumn();

            builder.Property(c => c.PermissionId)
                .HasColumnName("IdPermissao");

            builder.Property(c => c.UserId)
                .HasColumnName("IdUsuario");

            builder.HasOne(c => c.Permission)
                .WithMany(p => p.UserPermissions);

            builder.HasOne(c => c.User)
                .WithMany(p => p.UserPermissions);

        }
    }
}
