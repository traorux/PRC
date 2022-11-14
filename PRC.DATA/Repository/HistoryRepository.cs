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
        public  Task<ICollection<History>> GetHistories(string customerNumber)  //param fonct à gerer
        {
            var history = (ICollection<History>)dbContext
                .Calls
                .Where(c => c.CustomerNumber == customerNumber)
                .OrderByDescending(c => (c.dateHeure)).Take(6)  // premier element à eliminer
                .Select(c => new
                {
                    ExtensionNumber = c.ExtensionNumber,
                    Agent = dbContext.Users.Where(u => u.DeviceNumber == c.ExtensionNumber).FirstOrDefault(),
                    CustomerNumber = c.CustomerNumber,
                    dateHeure = c.dateHeure,
                    Request = dbContext.Requests.Where(r => r.IdRequest == c.CallRef).FirstOrDefault(),
                })
                .Select(h => new History
                {
                    ExtensionNumber = h.ExtensionNumber,
                    AgentLastName = h.Agent.LastName,
                    AgentFirstName = h.Agent.FirstName,
                    CustomerNumber = h.CustomerNumber,
                    Motif = h.Request.Motif,
                    Status = h.Request.status,
                    dateHeure = h.dateHeure
                })
                .ToList();

            return Task.FromResult(history);
        }

        public Task<ICollection<History>> GetIncommingCalls(string typeCall)
        {
            var history = (ICollection<History>)dbContext
                .Calls
                .Where(c => c.typeCall == typeCall)
                .OrderByDescending(c => (c.dateHeure)).Take(10)
                .Select(c => new
                {
                    ExtensionNumber = c.ExtensionNumber,
                    Agent = dbContext.Users.Where(u => u.DeviceNumber == c.ExtensionNumber).FirstOrDefault(),
                    CustomerNumber = c.CustomerNumber,
                    Customer = dbContext.Customers.Where(u => u.CustomerNumber == c.CustomerNumber).FirstOrDefault(),
                    dateHeure = c.dateHeure,
                    Request = dbContext.Requests.Where(r => r.IdRequest == c.CallRef).FirstOrDefault(),
                })
                .Select(h => new History
                {
                    ExtensionNumber = h.ExtensionNumber,
                    AgentLastName = h.Agent.LastName,
                    AgentFirstName = h.Agent.FirstName,
                    CustomerNumber = h.CustomerNumber,
                    CustomerLastName = h.Customer.LastName,
                    CustomerFirstName = h.Customer.FirstName,
                    Motif = h.Request.Motif,
                    Status = h.Request.status,
                    dateHeure = h.dateHeure
                })
                .ToList();

            return Task.FromResult(history);
        }


        public Task<ICollection<History>> GetOutgoingCalls(string typeCall)
        {
            var history = (ICollection<History>)dbContext
                .Calls
                .Where(c => c.typeCall == "OutgoingCall")
                .OrderByDescending(c => (c.dateHeure)).Take(10)
                .Select(c => new
                {
                    ExtensionNumber = c.ExtensionNumber,
                    Agent = dbContext.Users.Where(u => u.DeviceNumber == c.ExtensionNumber).FirstOrDefault(),
                    CustomerNumber = c.CustomerNumber,
                    Customer = dbContext.Customers.Where(u => u.CustomerNumber == c.CustomerNumber).FirstOrDefault(),
                    dateHeure = c.dateHeure,
                    Request = dbContext.Requests.Where(r => r.IdRequest == c.CallRef).FirstOrDefault(),
                })
                .Select(h => new History
                {
                    ExtensionNumber = h.ExtensionNumber,
                    AgentLastName = h.Agent.LastName,
                    AgentFirstName = h.Agent.FirstName,
                    CustomerNumber = h.CustomerNumber,
                    CustomerLastName = h.Customer.LastName,
                    CustomerFirstName = h.Customer.FirstName,
                    Motif = h.Request.Motif,
                    Status = h.Request.status,
                    dateHeure = h.dateHeure
                })
                .ToList();

            return Task.FromResult(history);
        }
    }
}
