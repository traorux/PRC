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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .HasKey(a => a.IdCustomer);

            builder
                .Property(m => m.IdCustomer)
                .UseIdentityColumn();

            builder
                .Property(m => m.CustomerNumber)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(m => m.LastName)
                .HasMaxLength(50);
            builder
                .Property(m => m.FirstName)
                .HasMaxLength(50);
            builder
               .HasOne<DataCustom>(d => d.DataCustom)
               .WithOne(c => c.Customer)
               .HasForeignKey<DataCustom>(d => d.IdDataCustom);

            builder
                .ToTable("Customers");
        }
    }
}
