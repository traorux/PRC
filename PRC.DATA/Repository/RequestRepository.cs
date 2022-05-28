using PRC.CORE.Model;
using PRC.CORE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.DATA.Repository
{
    public class RequestRepository : IRequestRepository
    {
        private readonly PRCDbContext dbContext;


        public RequestRepository(PRCDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        public async Task<Request> AddRequest(Request request)
        {
            await dbContext.Requests.AddAsync(request);
            await dbContext.SaveChangesAsync();
            return request;
        }

        public async Task DeleteRequest(Request request)
        {
            dbContext.Requests.Remove(request);
            await dbContext.SaveChangesAsync();
        }

        public Task<Request> GetRequestById(int IdRequest)
        {
            return Task.FromResult(dbContext.Requests.Where(c => (c.IdRequest.Equals(IdRequest))).FirstOrDefault());
        }

        public Task<IEnumerable<Request>> GetAllRequest()
        {
            IEnumerable<Request> List = dbContext.Requests.ToList();
            var list = Task.FromResult(List);
            return list;
        }

        public async Task<Request> UpdateRequest(Request request)
        {
            dbContext.Requests.Update(request);
            await dbContext.SaveChangesAsync();
            return request;
        }
    }
}
