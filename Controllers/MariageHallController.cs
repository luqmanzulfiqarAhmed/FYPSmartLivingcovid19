
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using smartLiving.Models;


using Newtonsoft.Json;
using smartLiving.Repostries;
using System;

namespace smartLiving.Controllers
{
    
    [Route("api/MariageHall")]
    [ApiController]

    public class MariageHallController : ControllerBase
    {
        private readonly MarriageHallRepositry context;

        public MariageHallController(MarriageHallRepositry MarriageHallRepositry)
        {
            context = MarriageHallRepositry;
        }

        


        
        [HttpGet("{sId},{pId}", Name = "getMariageHallData")]
        public async Task<Object> getMariageHallData(string sId,string pId)
        {
            var MariageHallData = await context.retrieveMarriageHall(sId,pId);
            if (MariageHallData == null)
                return "no data";
            return JsonConvert.SerializeObject(MariageHallData);        
        }

       
        
        [HttpPost( "{sIdPId}" ,Name = "postMariageHallProfile")]         
        public async Task <Object> postMariageHallProfile( string sIdPId,[FromBody]MarriageHall marriageHall)
         {
                  if(marriageHall != null){
                string []id=sIdPId.Split(",");
            if(id !=null && sIdPId.Contains(",")){                                 
           Object flag = await context.updatemarriageHallMenue(id[0],id[1], marriageHall);
            
            return flag;
            }            
            return "no comma detected";
             }
             return "Mariage Hall is null";
        

                
         }

        [HttpPut("{sIdPId}", Name = "updateMariageHallProfile")]        
        public async Task <Object> updateMariageHallProfile( string sIdPId,[FromBody]MarriageHall MariageHall)
         {
             if(MariageHall != null){
                string []id=sIdPId.Split(",");
            if(id !=null && sIdPId.Contains(",")){                                 
           Object flag = await context.updatemarriageHallMenue(id[0],id[1], MariageHall);
            
            return flag;
            }            
            return "no comma detected";
             }
        
                return JsonConvert.SerializeObject(MariageHall); 
        }
    }
}

    