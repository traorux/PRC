using Microsoft.EntityFrameworkCore;
using PRC.CORE.Model.Media;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.DATA
{
    public class PRCDbContext : DbContext
    {
        public PRCDbContext(DbContextOptions<PRCDbContext> options) : base(options)
        {
            
        }

        //Dbset
        public DbSet<Call> Calls { get; set; }

    }
}
