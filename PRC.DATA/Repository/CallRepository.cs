using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly IServiceProvider service;

        public CallRepository(IServiceProvider service)
        {
            //this.dbContext = dbContext;
            this.dbContext = service.CreateScope().ServiceProvider.GetRequiredService<PRCDbContext>();
            this.service = service;
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

        public Task<IEnumerable<Call>> GetLastCall(string CustomerNumber)
        {

            IEnumerable<Call> List = dbContext.Calls
                .Where(c => (c.CustomerNumber.Equals(CustomerNumber)))
                .OrderBy(c => (c.dateHeure)).ThenByDescending(c => (c.dateHeure));
            var list = Task.FromResult(List);
            return list;

        }

        public Task<IEnumerable<Call>> GetHistCall(string customerNumber)
        {

            IEnumerable<Call> List = dbContext.Calls
                .Where(c => (c.CustomerNumber.Equals(customerNumber)));
            var list = Task.FromResult(List);
            return list;
        }


        public async Task<Call> UpdateCall(Call call)
        {
            var _dbContext = this.service.CreateScope().ServiceProvider.GetRequiredService<PRCDbContext>();
            _dbContext.Calls.Update(call);
            await _dbContext.SaveChangesAsync();
            return call;

        }

        public Task<Call> GetACallByCallRef(string CallRef)
        {
            var _dbContext= this.service.CreateScope().ServiceProvider.GetRequiredService<PRCDbContext>();
            return Task.FromResult(_dbContext.Calls.Where(c => (c.CallRef.Equals(CallRef))).FirstOrDefault());
        }

        public Task<Call> GetACallByNumber(string CustomerNumber)
        {
            return Task.FromResult(dbContext.Calls.Where(c => (c.CustomerNumber.Equals(CustomerNumber))).FirstOrDefault());
        }

        public int GetNumberOfIncomingCalls()
        {
            var numbercall = dbContext.Calls
                .Where(c => c.typeCall == "IncomingCall")
                .Count();
            return numbercall;
        }

        public int GetNumberOfOutgoingCalls()
        {
            var numbercall = dbContext.Calls
                .Where(c => c.typeCall == "OutgoingCall")
                .Count();
            return numbercall;
        }

        public dynamic GetStatistique( DateTime date)
        {
            var numbercall = dbContext
                .Calls
                .Where(c => c.dateHeure > date)
                .Include(c => c.States)
                .ToList()
                .GroupBy(c => c.CallRef)
                .Select(c => new
                {
                    Id = "10",
                    nombreAppels = c.Count(),
                    nombreAppelEntrants = c.Count(a => a.typeCall == "IncomingCall"),
                    nombreAppelSortants = c.Count(a => a.typeCall == "OutgoingCall"),
                    nombreAppelTraites = c.Count(a => a.States.Any(b => b.Status == "Conversation"))


                }).GroupBy(g => g.Id)
                .Select(d => new { 
                    nombreAppelEntrants = d.Sum(s => s.nombreAppelEntrants),
                    nombreAppelSortants = d.Sum(s => s.nombreAppelSortants),
                    nombreAppelTraites = d.Sum(s => s.nombreAppelTraites),
                    nombreAppels = d.Sum(s => s.nombreAppels)
                }).FirstOrDefault();
            return numbercall;
        }


    }
}
