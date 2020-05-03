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
    public class ResidentController : ControllerBase
    {
        private readonly ResidentRepositry context;

        public ResidentController(ResidentRepositry ResidentRepositry)
        {
            context = ResidentRepositry;
        }
        [HttpGet]
        public async Task<string> getAllResidentsData()
        {

            var ResidentData = await context.retriveAllData();
            return JsonConvert.SerializeObject(ResidentData);

        }
        //http://localhost:5000/api/Resident/1       
        [HttpGet("{id}", Name = "ResidentProfile")]
        public async Task<string> getResidentData(string[] credentials)

        {
            string email = "", sId="", pId="";
            if (credentials != null)
            {                             
                sId = credentials[0];
                pId = credentials[1];                
                email = credentials[2];
            }
            if (!email.Equals(""))
            {
                var ResidentData = await context.retrieveByEmail(email);
                if (ResidentData == null)
                    return null;
                return JsonConvert.SerializeObject(ResidentData);
            }
            var ResidentDataByIds = await context.retrieveBySidPid(sId,pId);
            if (ResidentDataByIds == null)
                return null;
            return JsonConvert.SerializeObject(ResidentDataByIds);
        }

        [HttpPost(Name = "ResidentRegister")]
        public async Task<String> registerResident([FromBody]Resident Resident)

        {
            var ResidentData = await context.retrieveByEmail(Resident.residentEmaill);


            ResidentData = JsonConvert.SerializeObject(ResidentData);
            if (ResidentData.ToString() == "[]")
            {
                await context.insert(Resident);

                return "true";
            }

            return ResidentData.ToString();
        }



        [HttpPut
        ]
        public async Task<ActionResult> updateResidentProfile([FromBody]Resident Resident)
        {


            await context.update(Resident.residentEmaill, Resident);
            return Ok(Resident);
        }
    }
}
