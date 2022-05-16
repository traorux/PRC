using PRC.CORE.Model.Media;
using PRC.CORE.Repository;
using PRC.CORE.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.SERVICE.Media
{
    public class CallService : ICallService
    {
        private readonly ICallRepository callRepository;

        public CallService(ICallRepository callRepository)
        {
            this.callRepository = callRepository;
        }

        public async Task<Call> GetACall(string agent)
        {
            return await callRepository.GetCallByAgent(agent);
        }

        public async Task<Call> GetACallByCritere(string agent, string customer, DateTime dateHeure)
        {
            return await callRepository.GetACallByCr(agent, customer, dateHeure);
        }



        //public async Task<Call> GetListCall()
        //{
        //    return (Call) await callRepository.GetAllCall();
        //}

        public async Task<Call> MakeCall(Call call)
        {
            return await callRepository.AddCall(call);
            

        }
    }
}
