using PRC.CORE.Model.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Service
{
    public interface ICallService
    {
        Task<Call> MakeCall(Call call);
        //Task<Call> GetListCall();
        Task<Call> GetACall(string agent);
        Task<Call> GetACallByCritere(string agent, string customer, DateTime dateHeure);

    }
}
