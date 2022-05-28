using PRC.CORE.Model;
using PRC.CORE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.DATA.Repository
{
    public class DataCustomRepository : IDataCustomRepository
    {
        private readonly PRCDbContext dbContext;


        public DataCustomRepository(PRCDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        public async Task<bool> AddDataCustom(DataCustom dataCustom)
        {
            await dbContext.DataCustoms.AddAsync(dataCustom);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task DeleteDataCustom(DataCustom dataCustom)
        {
            dbContext.DataCustoms.Remove(dataCustom);
            await dbContext.SaveChangesAsync();
        }

        public Task<DataCustom> GetDataCustomById(int IdDataCustom)
        {
            return Task.FromResult(dbContext.DataCustoms.Where(c => (c.IdDataCustom.Equals(IdDataCustom))).FirstOrDefault());
        }

        public Task<IEnumerable<DataCustom>> GetAllDataCustom()
        {
            IEnumerable<DataCustom> List = dbContext.DataCustoms.ToList();
            var list = Task.FromResult(List);
            return list;
        }

        public async Task<DataCustom> UpdateDataCustom(DataCustom dataCustom)
        {
            dbContext.DataCustoms.Update(dataCustom);
            await dbContext.SaveChangesAsync();
            return dataCustom;
        }
    }
}
