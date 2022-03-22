using Microsoft.AspNetCore.Mvc;
using PRC.CORE.Media.Call;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PRC.COEUR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallController : ControllerBase
    {
        private readonly IMediaCall _mediaCall;

        public CallController(IMediaCall mediaCall)
        {
            _mediaCall = mediaCall;
        }

        // GET: api/<CallController>
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            await _mediaCall.MakeCall("1001", "1002");

            return new string[] { "value1", "value2" };
        }

        // GET api/<CallController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CallController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CallController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CallController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
