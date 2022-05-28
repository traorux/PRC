using PRC.CORE.Model;
using PRC.CORE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.DATA.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly PRCDbContext dbContext;


        public CustomerRepository(PRCDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        public async Task<bool> AddCustomer(Customer customer)
        {
            await dbContext.Customers.AddAsync(customer);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task DeleteCustomer(Customer customer)
        {
            dbContext.Customers.Remove(customer);
            await dbContext.SaveChangesAsync();
        }

        public Task<Customer> GetCustomerById(int IdCustomer)
        {
            return Task.FromResult(dbContext.Customers.Where(c => (c.IdCustomer.Equals(IdCustomer))).FirstOrDefault());
        }

        public Task<Customer> GetCustomerByNumber(string CustomerNumber)
        {
            return Task.FromResult(dbContext.Customers.Where(c => (c.CustomerNumber.Equals(CustomerNumber))).FirstOrDefault());
        }

        public Task<IEnumerable<Customer>> GetAllCustomer()
        {
            IEnumerable<Customer> List = dbContext.Customers.ToList();
            var list = Task.FromResult(List);
            return list;
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            dbContext.Customers.Update(customer);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
