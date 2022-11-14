using PRC.CORE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Repository
{
    public interface IHistoryRepository
    {
        Task<ICollection<History>> GetHistories(string customerNumber);
        Task<ICollection<History>> GetIncommingCalls(string typeCall);
        Task<ICollection<History>> GetOutgoingCalls(string typeCall);
    }
}
