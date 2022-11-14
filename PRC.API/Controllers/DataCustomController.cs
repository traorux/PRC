﻿using Microsoft.AspNetCore.Mvc;
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
    public class DataCustomController : ControllerBase
    {
        private readonly IMediaService mediaService;

        public DataCustomController(IMediaService mediaService)
        {
            this.mediaService = mediaService;
        }

        [HttpPost]
        public async Task<DataCustom> SearchDataCustom(int IdDataCustom)
        {
            return  await mediaService.SearchDataCustom(IdDataCustom);
        }
    }
}