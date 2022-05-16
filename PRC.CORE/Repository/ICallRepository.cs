using PRC.CORE.Model.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Repository
{
    public  interface ICallRepository
    {
        Task<IEnumerable<Call>> GetAllCall();
        Task<Call> GetCallById(string Id);
        Task<Call> GetCallByAgent(string agent);
        Task<Call> GetACallByCr(string agent, string customer, DateTime dateHeure);
        Task<Call> AddCall(Call call);
        Task UpdateCall(Call call);
        Task DeleteCall(Call call);
    }
}
