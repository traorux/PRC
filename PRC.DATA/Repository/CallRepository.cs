using PRC.CORE.Model;
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
            await GetACallByCallRef(call.CallRef);
            return call;

        }

        public async Task DeleteCall(Call call)
        {
            dbContext.Calls.Remove(call);
            await dbContext.SaveChangesAsync();
        }

        public Task<IEnumerable<Call>> GetAllCall()
        {
            IEnumerable<Call> List = dbContext.Calls.ToList();
            var list = Task.FromResult(List);
            return list;

        }

        public Task<IEnumerable<Call>> GetLastCall(string customerNumber)
        {

            IEnumerable<Call> List = dbContext.Calls
                .Where(c => (c.CustomerNumber.Equals(customerNumber)))
                .OrderBy(c => (c.dateHeure)).ThenByDescending(c => (c.dateHeure));
            var list = Task.FromResult(List);
            return list;

        }

        public Task<IEnumerable<Call>> GetHistCall(string customerNumber)
        {

            IEnumerable<Call> List = dbContext.Calls
                .Where(c => (c.CustomerNumber.Equals(customerNumber)));
                //.OrderBy(c => (c.dateHeure)).ThenByDescending(c => (c.dateHeure));
            var list = Task.FromResult(List);
            return list;

        }


        public async Task<Call> UpdateCall(Call call)
        {
            dbContext.Calls.Update(call);
            await dbContext.SaveChangesAsync();
            return call;

        }

        public Task<Call> GetACallByCallRef(string CallRef)
        {
            return Task.FromResult(dbContext.Calls.Where(c => (c.CallRef.Equals(CallRef))).FirstOrDefault());
        }

    }
}
