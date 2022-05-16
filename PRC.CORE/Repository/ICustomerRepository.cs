using PRC.CORE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Repository
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();
        Customer GetById(string Id);
        void Insert(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
        void Save();
    }
}
