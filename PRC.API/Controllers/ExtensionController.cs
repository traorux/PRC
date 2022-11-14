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
    public class ExtensionController : ControllerBase
    {
        private readonly IMediaService mediaService;

        public ExtensionController(IMediaService mediaService)
        {
            this.mediaService = mediaService;
        }

        [HttpPost]
        public async Task<bool> CreerExtension(Extension extension)
        {
            return await mediaService.CreateExtension(extension);
        }

        [HttpPost]
        public async Task<Extension> GetExtension(string ExtensionNumber)
        {
            return await mediaService.GetExtensionByNumber(ExtensionNumber);
        }

        [HttpPut]
        public async Task<bool> ModifierExtension(Extension extension)
        {
            return await mediaService.UpdateExtension(extension);
        }

        

    }

}
