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
    public class RequestConfiguration : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder
                .HasKey(a => a.IdRequest);


            builder
                .Property(m => m.Motif)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(m => m.status)
                .IsRequired()
                .HasMaxLength(50);

            builder
                 .HasOne<Call>(c => c.Call)
                 .WithOne(a => a.Request)
                 .HasForeignKey<Request>(c => c.IdRequest);


            builder
                .ToTable("Requests");
        }
    }
}
