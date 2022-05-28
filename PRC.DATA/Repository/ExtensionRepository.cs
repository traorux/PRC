using PRC.CORE.Model;
using PRC.CORE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.DATA.Repository
{
    public class ExtensionRepository : IExtensionRepository
    {
        private readonly PRCDbContext dbContext;


        public ExtensionRepository(PRCDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        public async Task<bool> AddExtension(Extension extension)
        {
            await dbContext.Extensions.AddAsync(extension);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task DeleteExtension(Extension extension)
        {
            dbContext.Extensions.Remove(extension);
            await dbContext.SaveChangesAsync();
        }

        public Task<Extension> GetExtensionById(string Number)
        {
            return Task.FromResult(dbContext.Extensions.Where(c => (c.Number.Equals(Number))).FirstOrDefault());
        }

        public Task<Extension> GetExtensionByNumber(string ExtensionNumber)
        {
            return Task.FromResult(dbContext.Extensions.Where(c => (c.Number.Equals(ExtensionNumber))).FirstOrDefault());
        }

        public Task<IEnumerable<Extension>> GetAllExtension()
        {
            IEnumerable<Extension> List = dbContext.Extensions.ToList();
            var list = Task.FromResult(List);
            return list;
        }

        public async Task<bool> UpdateExtension(Extension extension)
        {
            dbContext.Extensions.Update(extension);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
