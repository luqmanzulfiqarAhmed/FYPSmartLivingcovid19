
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using smartLiving.Models;


using Newtonsoft.Json;
using smartLiving.Repostries;
using System;

namespace smartLiving.Controllers
{
    
    [Route("api/Graveyard")]
    [ApiController]

    public class GraveyardController : ControllerBase
    {
        private readonly PropertyRepositry context;

        public GraveyardController(PropertyRepositry PropertyRepositry)
        {
            context = PropertyRepositry;
        }

        
        
        [HttpGet]
        public async Task<string> getTest(){

            var vehichleData = await context.retrieveAll("SitaraSapna@123");
            return JsonConvert.SerializeObject(vehichleData);
        }

        
        [HttpGet("{sId}", Name = "getGraveyardData")]
        public async Task<string> getGraveyardData(string sId)
        {
            var graveyardData = await context.retrieveGraveyard(sId);
            if (graveyardData == null)
                return null;
            return JsonConvert.SerializeObject(graveyardData);        
        }

       

    }
}

    