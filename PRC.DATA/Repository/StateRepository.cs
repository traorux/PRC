using PRC.CORE.Model;
using PRC.CORE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.DATA.Repository
{
    public class StateRepository : IStateRepository
    {
        private readonly PRCDbContext dbContext;


        public StateRepository(PRCDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        public async Task<bool> AddState(State state)
        {
            await dbContext.States.AddAsync(state);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task DeleteState(State state)
        {
            dbContext.States.Remove(state);
            await dbContext.SaveChangesAsync();
        }

        public Task<State> GetSateById(int IdState)
        {
            return Task.FromResult(dbContext.States.Where(c => (c.IdState.Equals(IdState))).FirstOrDefault());
        }

        public Task<IEnumerable<State>> GetAllState()
        {
            IEnumerable<State> List = dbContext.States.ToList();
            var list = Task.FromResult(List);
            return list;
        }

        public async Task<State> UpdateState(State state)
        {
            dbContext.States.Update(state);
            await dbContext.SaveChangesAsync();
            return state;
        }
    }
}
