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
    [Route("api/Resident")]
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
            return JsonConvert.SerializeObject(ResidentData) +"success";

        }
        //http://localhost:5000/api/Resident/1       
        [HttpGet("{data}", Name = "ResidentProfile")]
        public async Task<string> getResidentData(string data)

        {
            
            string[]credentials = data.Split(","); 
            string email = "", sId="", pId="";
            if (credentials != null)
            {                             
                sId = credentials[0];
                pId = credentials[1];                
                email = credentials[2];
            }
            if (!sId.Equals(" "))
            {
                var ResidentDataBySid = await context.retrieveBySid(sId);
                if (ResidentDataBySid == null)
                    return null;
                return JsonConvert.SerializeObject(ResidentDataBySid);
            }
            if (!email.Equals(" "))
            {
                var ResidentData = await context.retrieveByEmail(email);
                if (ResidentData == null)
                    return null;
                return JsonConvert.SerializeObject(ResidentData);
            }
            if(!sId.Equals(" ") && !pId.Equals(" ") && !email.Equals(" ")  ){
                    var existResident = await context.retrieveBySidPidEmail(sId,pId,email);
            if (existResident == null)
                return null;
            return JsonConvert.SerializeObject(existResident);        
            }
            if(!sId.Equals(" ") && !pId.Equals(" ")) {
            var ResidentDataByIds = await context.retrieveBySidPid(sId,pId);
            if (ResidentDataByIds == null)
                return null;
            return JsonConvert.SerializeObject(ResidentDataByIds);
            }
            return "no response";
            
        }

        [HttpPost(Name = "ResidentRegister")]
        public async Task<bool> registerResident([FromBody]Resident Resident)

        {
            var ResidentData = await context.retrieveList(Resident.residentEmaill);


            ResidentData = JsonConvert.SerializeObject(ResidentData);
            if (ResidentData.ToString() == "[]")
            {
                await context.insert(Resident);

                return true;
            }

            return false;
        }



        [HttpPut]
        public async Task<bool> updateResidentProfile([FromBody]Resident Resident)
        {


            bool flag = await context.update(Resident.residentEmaill, Resident);
            return flag;
        }
    }
}