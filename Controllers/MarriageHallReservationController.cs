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
    [Route("api/MarriageHallReservation")]
    [ApiController]
    public class MarriageHallReservationController : ControllerBase
    {
        private readonly MarriageHallReservationRepositry context;

        public MarriageHallReservationController(MarriageHallReservationRepositry MarriageHallRepositry)
        {
            context = MarriageHallRepositry;
        }
        // [HttpGet]
        [HttpGet("{sId}/{rId}", Name = "getAllMarriageHallsData")]
        public async Task<string> getAllMarriageHallsData(string sId,string rId)
        {

            var MarriageHallData = await context.retriveAllData(sId,rId);
            return JsonConvert.SerializeObject(MarriageHallData);

        }
        //http://localhost:5000/api/MarriageHallReservation/1       
        [HttpGet("{sIdPidRemail}", Name = "getMarriageHallData")]
        public async Task<List<MarriageHallReservation>> getMarriageHallData(string sIdPidRemail)
        {
            //string []id=sIdPidRemail.Split(",");
                
                     string []id=sIdPidRemail.Split(",");
                    if(id[0]!= null && id[1] == "" && id[2]!=null){
                        var reserve = context.retrieveBySidPidrEmail(id[0],id[2]);
                        List<MarriageHallReservation> hallReservations = reserve.Result;
                            return hallReservations;
                    }
                    if(id[0]!= null && id[1]!=null && id[2] == ""){
                        var reserve2 = context.retrieveBySidPid(id[0],id[1]) ;
                        List<MarriageHallReservation> hallReservations = reserve2.Result;
                            return hallReservations;
                    }
                
                
                return null;
             
            //  var reserve2 = context.retrieveBySidPidrEmail(id[0],id[1],id[2]);
            // List<MarriageHallReservation> hallReservations = reserve2.Result;
            //     return hallReservations;
            
        }

        [HttpPost(Name = "MarriageHallRegister")]
        public async Task<Boolean> registerMarriageHall([FromBody]MarriageHallReservation MarriageHallReservation)

        {
            
            
            
                await context.insert(MarriageHallReservation);

                    return true;
            

            
        }



        [HttpPut]
        public async Task<Boolean> updateMarriageHallProfile([FromBody]MarriageHallReservation MarriageHallReservation)
        {


           Boolean flag=  await context.update(MarriageHallReservation.hallReservationId, MarriageHallReservation);
            return flag;
        }
    }
}
