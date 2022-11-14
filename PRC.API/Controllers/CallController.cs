using Microsoft.AspNetCore.Mvc;
using PRC.CORE.Media.Call;
using PRC.CORE.Model;
using PRC.CORE.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PRC.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CallController : ControllerBase
    {
        private readonly IMediaCall mediaCall;
        private readonly IMediaService mediaService;

        public CallController(IMediaCall mediaCall, IMediaService mediaService)
        {
            this.mediaCall = mediaCall;
            this.mediaService = mediaService;
        }

        private void _mediaCall_ReceivedCall(string obj)
        {
            Console.WriteLine(obj);
        }



        [HttpPost]
        public async Task<bool> EmettreAppel(Call call)
        {
            return await mediaService.MakeOutgoingCall(call);
        }

        [HttpPost]
        public async Task<bool> MettreEntente(Call call)
        {
            return await mediaService.MiseEntente(call);
        }

        [HttpPost]
        public async Task<bool> RecupererEntente(Call call)
        {
            return await mediaService.FinEntente(call);
        }



        [HttpPost]
        public async Task<Call> RepondreAppel(Call call)
        {
            return await mediaService.IncomingCallCommunication(call);
        }



        [HttpPost]
        public async Task<bool> Racrocher(string loginName)
        {
            return await mediaService.DropeCall(loginName);
        }

        [HttpGet]   
        public async Task<IEnumerable<Call>> CallsList()
        {
            return await mediaService.GetCallsList();
        }

        [HttpPost]
        public async Task<IEnumerable<Call>> CallsHistory(string customerNumber)
        {
            return await mediaService.GetHistsList(customerNumber);
        }



        [HttpPost]
        public async Task<Call> ObtenirCall(string CallRef)
        {
            return await mediaService.GetCallInfos(CallRef);
        }

        [HttpPost]
        public async Task<Call> ObtCall(string CustomerNumber)
        {
            return await mediaService.CallInfos(CustomerNumber);
        }

       [HttpGet]
       public int GetNumberOfIncomingCalls()
       {
            return mediaService.GetNumberOfIncomingCalls();
       }

       [HttpGet]
       public int GetNumberOfOutgoingCalls()
        {
            return mediaService.GetNumberOfOutgoingCalls();
        }

        [HttpGet]

        public dynamic GetStatistique()
        {
            var date = (DateTime.Now - TimeSpan.FromDays(1));
            return mediaService.GetStatistique(date);
        }

    }
}

