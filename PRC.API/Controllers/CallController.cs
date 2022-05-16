using Microsoft.AspNetCore.Mvc;
using PRC.CORE.Media.Call;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PRC.API.Models;
using PRC.CORE.Model.Media;
using Microsoft.EntityFrameworkCore;
using PRC.CORE.Service;




// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PRC.COEUR.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CallController : ControllerBase
    {
        private readonly IMediaCall mediaCall;
        private readonly ICallService callService;

        public CallController(IMediaCall mediaCall, ICallService callService )
        {
            this.mediaCall = mediaCall;
            this.callService = callService;
        }
        
        private void _mediaCall_ReceivedCall(string obj)
        {
            Console.WriteLine(obj);
        }

      

        //Get All Calls
        [HttpPost]
        public async Task<Call> AddCallInBase(Call call)
        {
            await callService.MakeCall(call);
            return null;
        }

        [HttpGet]
        public async Task<Call> GetACall(string agent)
        {
            return await callService.GetACall(agent);
        }

        [HttpGet]
        public async Task<Call> CherchCall(string agent, string customer, DateTime dateHeure)
        {
            return await callService.GetACallByCritere(agent, customer, dateHeure);
        }

        ////Add Call
        //[HttpPost]
        //public async Task AddCallInBase(Call call)
        //{
        //    await mediaCallService.AddCall(call);

        //}

        //[HttpGet]
        //[Route("{id:guid}")]
        //public async Task GetACall(Guid id)
        //{
        //    await mediaCallService.ObtenirAppel(id);
        //}


        ////Get single Call
        //[HttpGet]
        //[Route("{id:guid}")]
        //[ActionName("GetCall")]
        //public async Task<IActionResult> GetCall([FromRoute] Guid id)
        //{
        //    var call = await callsDbContext.Calls.FirstOrDefaultAsync(x => x.Id == id);
        //    if (call != null)
        //    {
        //        return Ok(call);
        //    }
        //    return NotFound("Call not found");
        //}

        //Add Call
        //[HttpPost]
        //public async Task<IActionResult> AddCall(Call call)
        //{
        //    call.Id = Guid.NewGuid();
        //    await callsDbContext.Calls.AddAsync(call);
        //    await callsDbContext.SaveChangesAsync();
        //    return CreatedAtAction(nameof(GetCall), new { id = call.Id }, call);

        //}

        //Updating A Call
        //[HttpPut]
        //[Route("{id:guid}")]
        //public async Task<IActionResult> UpdateCall([FromRoute] Guid id, [FromBody] Call call)
        //{
        //    var existingCall = await callsDbContext.Calls.FirstOrDefaultAsync(x => x.Id == id);
        //    if (existingCall != null)
        //    {
        //        existingCall.AgentNumber = call.AgentNumber;
        //        existingCall.CustomNumber = call.CustomNumber;
        //        await callsDbContext.SaveChangesAsync();
        //        return Ok(existingCall);
        //    }
        //    return NotFound("Card not found");
        //}


        //Delete A Call
        //[HttpDelete]
        //[Route("{id:guid}")]
        //public async Task<IActionResult> DeleteCall([FromRoute] Guid id)
        //{
        //    var existingCall = await callsDbContext.Calls.FirstOrDefaultAsync(x => x.Id == id);
        //    if (existingCall != null)
        //    {
        //        callsDbContext.Remove(existingCall);
        //        await callsDbContext.SaveChangesAsync();
        //        return Ok(existingCall);
        //    }
        //    return NotFound("Card not found");
        //}



        //[HttpPost]
        //public async Task<IActionResult> MakeCall(Call call)
        //{
        //    call.Id = Guid.NewGuid();
        //    await callsDbContext.Calls.AddAsync(call);
        //    await callsDbContext.SaveChangesAsync();
        //    await mediaCall.BasicMakeCallAsync(call.AgentNumber, call.CustomNumber);
        //    return CreatedAtAction(nameof(GetCall), new { id = call.Id }, call);

        //}



        //[HttpPost]
        //public async Task AnswerCall()

        //{
        //    await mediaCall.BasicAnswerCallAsync("890");

        //}
        //[HttpPost]
        //public async Task DropMeCall()
        //{
        //    await mediaCall.BasicDropMeAsync("890");

        //}


        //[HttpPut]
        //public async Task<IEnumerable<string>> Put()
        //{
        //    await mediaCall.BasicDropMeAsync("890");

        //    return new string[] { "value1", "value2" };
        //}

        //[HttpGet]
        //public async Task<IEnumerable<string>> MakeCall()
        //{
        //    await mediaCall.BasicMakeCallAsync("890", "764");

        //    return new string[] { "value1", "value2" };
        //}

        //GET: api/<CallController>
        //[HttpGet]
        //public async Task<IEnumerable<string>> Get()
        //{
        //    await _mediaCall.MakeCallAsync("890", "764", true, false);

        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<CallController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}


        // PUT api/<CallController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<CallController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}


    }

}
