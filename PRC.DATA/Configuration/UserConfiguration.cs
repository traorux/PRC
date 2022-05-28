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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(a => a.IdUser);
            builder
                .Property(m => m.IdUser)
                .UseIdentityColumn();

            builder
                .Property(m => m.DeviceNumber)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(m => m.FirstName)
                .HasMaxLength(50);
            builder
                .Property(m => m.LastName)
                .HasMaxLength(50);
            builder
               .Property(m => m.UserEmail)
               .HasMaxLength(50);

            builder
                .ToTable("Users");
        }
    }
}
