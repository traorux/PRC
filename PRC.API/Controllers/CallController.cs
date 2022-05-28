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
        public async Task<Call> RepondreAppel(Call call)
        {
            return await mediaService.IncomingCallCommunication(call);
        }



        [HttpGet]
        public async Task<bool> Racrocher()
        {
            return await mediaService.DropeCall();
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

    }
}

