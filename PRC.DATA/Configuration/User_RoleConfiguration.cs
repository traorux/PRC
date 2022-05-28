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
    public class User_RoleConfiguration : IEntityTypeConfiguration<User_Role>
    {
        public void Configure(EntityTypeBuilder<User_Role> builder)
        {
            builder
                .HasKey(a => new { a.IdRole, a.IdUser });

            builder
                .Property(m => m.IdRole)
                .HasMaxLength(50);
            builder
                .Property(m => m.IdUser)
                .HasMaxLength(50);
            builder
               .HasOne<User>(a => a.User)
               .WithMany(c => c.Users_Roles)
               .HasForeignKey(a => a.IdUser);
            builder
               .HasOne<Role>(a => a.Role)
               .WithMany(c => c.Users_Roles)
               .HasForeignKey(a => a.IdRole);


            builder
                .ToTable("Users_Roles");
        }
    }
}
