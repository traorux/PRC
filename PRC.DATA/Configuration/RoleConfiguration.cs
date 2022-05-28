using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PRC.CORE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.DATA.Configuration 
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder
                .HasKey(a => a.IdRole);

            builder
                .Property(m => m.IdRole)
                .UseIdentityColumn();

            builder
                .Property(m => m.Name)
                .HasMaxLength(50);

            builder
                .ToTable("Roles");
        }
    }
}
