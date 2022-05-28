using PRC.CORE.Model;
using PRC.CORE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.DATA.Repository
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly PRCDbContext dbContext;


        public HistoryRepository(PRCDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        public  Task<ICollection<History>> GetHistories(string customerNumber)
        {
            var history = (ICollection < History >) dbContext
                .Calls
                .Where(c => c.CustomerNumber == customerNumber)
                .Select(c=>new Call 
                {
                    ExtensionNumber = c.ExtensionNumber,
                    CustomerNumber = c.CustomerNumber,
                    dateHeure = c.dateHeure,
                    Request = dbContext.Requests.Find(c.CallRef)
                })
                .Select(h => new History 
                {
                     ExtensionNumber = h.ExtensionNumber,
                     CustomerName = h.Customer.LastName,
                     CustomerNumbner = h.CustomerNumber,
                     Motif = h.Request.Motif,
                     Status = h.Request.status,
                     dateHeure = h.dateHeure
                }).ToList();

            return Task.FromResult(history);
        }
    }
}
