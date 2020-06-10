using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using smartLiving.Models;
using smartLiving.Repostries;

namespace smartLiving.Controllers
{
    [Route("api/Transport")]
    [ApiController]
    public class TransportController : ControllerBase
    {
        private TransportRepositry context;
        public TransportController(TransportRepositry transportRepositry)
        {
            context = transportRepositry;
        }

        [HttpGet]
        public string getTest()
        {
            return "working";
        }

        [HttpGet("{societyId}", Name = "getAllTransportData")]
        public async Task<string> getAllTransportData(string societyId)
        {
            var complainsData = await context.retriveAllData(societyId);
            return JsonConvert.SerializeObject(complainsData);
        }

        [HttpGet("{routeId}/{societyId}", Name = "getTransportData")]
        public async Task<string> getTransportData(string routeId,string societyId)
        {

            var transportData = await context.retrieve(routeId);
            if (transportData == null)
                return null;
            return JsonConvert.SerializeObject(transportData);
        }

        [HttpPost(Name = "uploadSchdule")]
        public async Task<ActionResult<Object>> uploadSchdule( [FromBody]Transport Transport)
        {
            
                
                Object var =await context.insert(Transport);
                return Transport;
        }

        [HttpPut(Name = "updateSchdule")]
        public async Task<ActionResult> updateSchdule([FromBody]Transport Transport)
        {
            
            
            await context.update(Transport.transportId,Transport);
            return NoContent();
        }

    }
}