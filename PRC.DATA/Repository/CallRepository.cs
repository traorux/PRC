using PRC.CORE.Model.Media;
using PRC.CORE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.DATA.Repository
{
    public class CallRepository : ICallRepository
    {
        private readonly PRCDbContext dbContext;

        public CallRepository(PRCDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Call> AddCall(Call call)
        {
            await dbContext.Calls.AddAsync(call);
            await dbContext.SaveChangesAsync();
            return call;

        }

        public async Task DeleteCall(Call call)
        {
            dbContext.Calls.Remove(call);
            await dbContext.SaveChangesAsync();
        }

        public Task<IEnumerable<Call>> GetAllCall()
        {
            IEnumerable<Call> List =  dbContext.Calls.ToList();
            var list = Task.FromResult(List);
            return list;

        }

        public Task<Call> GetCallByAgent(string agent)
        {
            return Task.FromResult(dbContext.Calls.Where(c => c.agent.Equals(agent)).FirstOrDefault());
        }

        public Task<Call> GetACallByCr(string agent, string customer, DateTime dateHeure)
        {
            return Task.FromResult(dbContext.Calls.Where(c => (c.agent.Equals(agent)) &&  (c.customer.Equals(customer)) && (c.dateHeure.Equals(dateHeure))).FirstOrDefault());
        }

        public Task<Call> GetCallById(string Id)
        {
            return Task.FromResult(dbContext.Calls.Where(c => c.Id == Id).FirstOrDefault());

        }

        public async Task UpdateCall(Call call)
        {
            dbContext.Calls.Update(call);
            await dbContext.SaveChangesAsync();

        }
    }
}
