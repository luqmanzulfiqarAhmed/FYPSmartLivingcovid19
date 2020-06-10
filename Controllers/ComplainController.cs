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
    [Route("api/Complain")]
    [ApiController]
    public class ComplainController : ControllerBase
    {
        private readonly ComplainRepositry context;

        public ComplainController(ComplainRepositry ComplainRepositry)
        {
            context = ComplainRepositry;
        }
        [HttpGet]
        public async Task<string> getAllComplainsData()
        {

            var ComplainData = await context.retriveAllData();
            return JsonConvert.SerializeObject(ComplainData);

        }
        //http://localhost:5000/api/Complain/1       
        [HttpGet("{data}", Name = "getComplainData")]
        public async Task<string> getComplainData(string data)
        {
            if(data != null){
            string[]credentials = data.Split(","); 
            string email = "", sId="";
            if (credentials != null)
            {                             
                sId = credentials[0];                                
                email = credentials[1];
            }
            if(sId != "" ){
                var ComplainData = await context.retrieveAll(sId);
                if (ComplainData == null)
                    return null;
            return JsonConvert.SerializeObject(ComplainData);
            }
            if(sId != "" && email != ""  ){
                var ComplainData = await context.retrieve(sId,email);
                if (ComplainData == null)
                    return null;
            return JsonConvert.SerializeObject(ComplainData);
            }
        }
            return "data is null";
        }

        [HttpPost(Name = "ComplainRegister")]
        public async Task<String> registerComplain([FromBody]Complain Complain)

        {
            var ComplainData = await context.retrieve(Complain.complaintId);


            ComplainData = JsonConvert.SerializeObject(ComplainData);
            if (ComplainData.ToString() == "[]")
            {
                await context.insert(Complain);

                return "true";
            }

            return ComplainData.ToString();
        }



        [HttpPut]
        public async Task<ActionResult> updateComplainProfile([FromBody]Complain Complain)
        {


            await context.update(Complain.complaintId, Complain);
            return Ok(Complain);
        }
    }
}