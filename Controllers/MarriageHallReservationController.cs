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
        [HttpGet]
        public async Task<string> getAllMarriageHallsData()
        {

            var MarriageHallData = await context.retriveAllData();
            return JsonConvert.SerializeObject(MarriageHallData);

        }
        //http://localhost:5000/api/MarriageHallReservation/1       
        [HttpGet("{id}", Name = "MarriageHallProfile")]
        public async Task<string> getMarriageHallData(string societyId)
        {
            var MarriageHallData = await context.retrieve(societyId);
            if (MarriageHallData == null)
                return null;
            return JsonConvert.SerializeObject(MarriageHallData);
        }

        [HttpPost(Name = "MarriageHallRegister")]
        public async Task<String> registerMarriageHall([FromBody]MarriageHallReservation MarriageHallReservation)

        {
            var MarriageHallData = await context.retrieve(MarriageHallReservation.hallReservationId);


            MarriageHallData = JsonConvert.SerializeObject(MarriageHallData);
            if (MarriageHallData.ToString() == "[]")
            {
                await context.insert(MarriageHallReservation);

                return "true";
            }

            return MarriageHallData.ToString();
        }



        [HttpPut]
        public async Task<ActionResult> updateMarriageHallProfile([FromBody]MarriageHallReservation MarriageHallReservation)
        {


            await context.update(MarriageHallReservation.hallReservationId, MarriageHallReservation);
            return Ok(MarriageHallReservation);
        }
    }
}
