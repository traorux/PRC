using Microsoft.AspNetCore.Mvc;
using PRC.CORE.Model;
using PRC.CORE.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRC.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IMediaService mediaService;

        public HistoryController(IMediaService mediaService)
        {
            this.mediaService = mediaService;
        }

        [HttpPost]
        public async Task<ICollection<History>> searchHistories(string customerNumber)
        {
            return await mediaService.GetHistories(customerNumber);
        }

        [HttpGet]
        public async Task<ICollection<History>> GetIncommingCalls(string typeCall="IncomingCall")
        {
            return await mediaService.GetIncommingCalls(typeCall);
        }

        [HttpGet]
        public async Task<ICollection<History>> GetOutgoingCalls(string typeCall="OutgoingCall")
        {
            return await mediaService.GetOutgoingCalls(typeCall);
        }
    }
}
