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
    public class ExtensionConfiguration : IEntityTypeConfiguration<Extension>
    {
        public void Configure(EntityTypeBuilder<Extension> builder)
        {
            builder
                .HasKey(a => a.Number);


            builder
                .Property(m => m.Number)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(m => m.loginName)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(m => m.Password)
                .HasMaxLength(50);

            builder
                .ToTable("Extensions");
        }
    }
}
