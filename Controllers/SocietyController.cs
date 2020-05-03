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
    [Route("api/[controller]")]
    [ApiController]
    public class SocietyController : ControllerBase
    {
        private readonly SocietyRepositry context;

        public SocietyController(SocietyRepositry SocietyRepositry)
        {
            context = SocietyRepositry;
        }
        [HttpGet]
        public async Task<string> getAllSocietysData()
        {

            var SocietyData = await context.retriveAllData();
            return JsonConvert.SerializeObject(SocietyData);

        }
        //http://localhost:5000/api/Society/1       
        [HttpGet("{id}", Name = "SocietyProfile")]
        public async Task<string> getSocietyData(string societyId)
        {
            var SocietyData = await context.retrieve(societyId);
            if (SocietyData == null)
                return null;
            return JsonConvert.SerializeObject(SocietyData);
        }

        [HttpPost(Name = "SocietyRegister")]
        public async Task<String> registerSociety([FromBody]Society Society)

        {
            var SocietyData = await context.retrieve(Society.societyId);


            SocietyData = JsonConvert.SerializeObject(SocietyData);
            if (SocietyData.ToString() == "[]")
            {
                await context.insert(Society);

                return "true";
            }

            return SocietyData.ToString();
        }



        [HttpPut]
        public async Task<ActionResult> updateSocietyProfile([FromBody]Society Society)
        {


            await context.update(Society.societyId, Society);
            return Ok(Society);
        }
    }
}