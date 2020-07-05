
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
        public async Task <Object> postMariageHallProfile( string sIdPId,[FromBody]Menue menue)
         {
                  if(menue != null){
                string []id=sIdPId.Split(",");
            if(id !=null && sIdPId.Contains(",")){                                 
           Object flag = await context.updatemarriageHall(id[0],id[1], menue);
            
            return flag;
            }            
            return "no comma detected";
             }
             return "Mariage Hall is null";
        

                
         }

        [HttpPut("{sIdPId}", Name = "updateMariageHallProfile")]        
        public async Task <Object> updateMariageHallProfile( string sIdPId,[FromBody]MarriageHall MariageHall)
         {
        //      if(MariageHall != null){
        //         string []id=sIdPId.Split(",");
        //     if(id !=null && sIdPId.Contains(",")){                                 
        //    Object flag = await context.updateMariageHall(id[0],id[1], MariageHall);
            
        //     return flag;
        //     }            
        //     return "no comma detected";
        //      }
        //      return "MariageHall is null";
                return JsonConvert.SerializeObject(MariageHall); 
        }
    }
}

    