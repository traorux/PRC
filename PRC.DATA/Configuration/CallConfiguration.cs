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
    public class CallConfiguration : IEntityTypeConfiguration<Call>
    {
        public void Configure(EntityTypeBuilder<Call> builder)
        {
            builder
                .HasKey(a => a.CallRef);

            builder
                .Property(m => m.ExtensionNumber)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(m => m.CustomerNumber)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(m => m.dateHeure)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(m => m.typeCall)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(m => m.removeParticipant)
                .HasMaxLength(50);

            builder
               .HasOne<Extension>(a => a.Extension)
               .WithMany(c => c.Calls)
               .HasForeignKey(a => a.ExtensionNumber);
            builder
               .HasOne<Customer>(c => c.Customer)
               .WithMany(c => c.Calls)
               .HasForeignKey(c => c.IdCustomer);

            builder
                .ToTable("Calls");
        }
    }
}
