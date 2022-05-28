using PRC.CORE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Repository
{
    public interface ICallRepository
    {
        Task<IEnumerable<Call>> GetAllCall();
        Task<Call> GetACallByCallRef(string CallRef);
        Task<Call> AddCall(Call call);
        Task<Call> UpdateCall(Call call);
        Task DeleteCall(Call call);
        Task<IEnumerable<Call>> GetLastCall(string customerNumber);
        Task<IEnumerable<Call>> GetHistCall(string customerNumber);
    }
}
