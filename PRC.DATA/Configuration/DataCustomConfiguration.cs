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
    public class DataCustomConfiguration : IEntityTypeConfiguration<DataCustom>
    {
        public void Configure(EntityTypeBuilder<DataCustom> builder)
        {
            builder
                .HasKey(a => a.IdDataCustom);

            //builder
            //    .Property(m => m.IdDataCustom)
            //    .UseIdentityColumn();

            builder
                .Property(m => m.NumeroCompte)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(m => m.TypeVoiture)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(m => m.DateVisiteTec)
                .IsRequired()
                .HasMaxLength(50);
           

            builder
                .ToTable("DataCustoms");
        }
    }
}
