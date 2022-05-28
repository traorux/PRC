using Microsoft.EntityFrameworkCore;
using PRC.CORE.Model;
using PRC.DATA.Configuration;
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
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Extension> Extensions { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<DataCustom> DataCustoms { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<State> Users_Roles { get; set; }
        


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new UserConfiguration());
            builder
               .ApplyConfiguration(new RoleConfiguration());
            builder
                .ApplyConfiguration(new CallConfiguration());
            builder
                .ApplyConfiguration(new CustomerConfiguration());
            builder
                .ApplyConfiguration(new ExtensionConfiguration());
            builder
                .ApplyConfiguration(new DataCustomConfiguration());
            builder
                .ApplyConfiguration(new RequestConfiguration());
            builder
                .ApplyConfiguration(new StateConfiguration());
            builder
                .ApplyConfiguration(new User_RoleConfiguration());

            //builder.Entity<Role>().HasData(new Role { IdRole = 1, isAdmin = true, isSupervisor = true, isUser = false, isReporter =false });
            builder.Entity<Customer>().HasData(new Customer { IdCustomer = 1, CustomerNumber = "890", LastName = "Kouame", FirstName = "JeanLuc" });
            builder.Entity<Extension>().HasData(new Extension { Number = "891", Password = "0000"});
            builder.Entity<User>().HasData(new User { IdUser = 1, DeviceNumber = "891", LastName = "Kouadio", FirstName = "Marc", UserEmail = "jean@gmail.com" });
            builder.Entity<DataCustom>().HasData(new DataCustom { IdDataCustom = 1, NumeroCompte = "oxe890", TypeVoiture = "Navara", DateVisiteTec = "12/06/2022" });
            builder.Entity<Call>().HasData(new Call { CallRef = "a2daba6270000400", ExtensionNumber = "891", IdCustomer = 1, CustomerNumber = "890", typeCall = "IncommingCall", removeParticipant = "890" });
            builder.Entity<State>().HasData(new State { IdState = 1, CallRef = "a2daba6270000400", Status = "Pending" });
            builder.Entity<Request>().HasData(new Request { IdRequest = "a2daba6270000400", Motif = "Demande de cotation", status = "En cours de traitement" });


        }

    }
}
