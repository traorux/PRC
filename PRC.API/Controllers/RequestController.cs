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
    public class RequestController : ControllerBase
    {
        private readonly IMediaService mediaService;

        public RequestController(IMediaService mediaService)
        {
            this.mediaService = mediaService;
        }

        [HttpPost]
        public async Task<Request> CreerRequest(Request request)
        {
            return await mediaService.CreateRequest(request);
        }
    }
}
