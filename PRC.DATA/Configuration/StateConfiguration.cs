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
    public class StateConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder
                .HasKey(a => a.IdState);

            builder
                .Property(m => m.IdState)
                .UseIdentityColumn();

            builder
                .Property(m => m.Status)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(m => m.dateHeure)
                .IsRequired()
                .HasMaxLength(50);
            builder
               .HasOne<Call>(d => d.Call)
               .WithMany(c => c.States)
               .HasForeignKey(d => d.CallRef);

            builder
                .ToTable("States");
        }
    }
}
