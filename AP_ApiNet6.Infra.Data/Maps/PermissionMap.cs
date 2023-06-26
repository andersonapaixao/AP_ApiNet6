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
    public class PermissionMap : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permissao");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("IdPermissao")
                .UseIdentityColumn();

            builder.Property(c => c.VisualName)
                .HasColumnName("NomeVisual");

            builder.Property(c => c.PermissionName)
                .HasColumnName("NomePermissao");

            builder.HasMany(c => c.UserPermissions)
                .WithOne(p => p.Permission)
                .HasForeignKey(c => c.PermissionId);
        }
    }
}
