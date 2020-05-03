
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


using smartLiving.Models;
using Newtonsoft.Json;
using smartLiving.Repostries;

namespace smartLiving.Controllers
{
    
    [Route("api/GraveBooking")]
    [ApiController]

    public class GraveBookController : ControllerBase
    {
        private readonly GraveBookingRepositry context;

        public GraveBookController(GraveBookingRepositry GraveBookRepositry)
        {
            context = GraveBookRepositry;
        }
        [HttpGet]
        public async Task<string> getAllGraveBooksData()
        {

            var adminData = await context.retriveAllData();
            return JsonConvert.SerializeObject(adminData);
            
        }
         //http://localhost:5000/api/GraveBooking/1       
        [HttpGet("{id}", Name = "GraveBookProfile")]
        public async Task<string> getGraveBookData(string id)
        {
            var adminData = await context.retrieve(id);
            if (adminData == null)
                return null;
            return JsonConvert.SerializeObject(adminData);        
        }

        [HttpPost(Name = "GraveBookRegister")]
        public async Task <bool > registerGraveBook([FromBody]GraveBooking GraveBooking)

        {            
            var adminData = await context.retrieve(GraveBooking.graveBookId);
                                

            adminData= JsonConvert.SerializeObject(adminData);
            if (adminData.ToString() == "[]")
            {
                 await context.insert(GraveBooking);                 
                 
                 return true;
            }
            
            return false;
        }
         

        
        [HttpPut
        ]
        public async Task <ActionResult> updateGraveBookProfile( [FromBody]GraveBooking GraveBooking)
         {
            
        
           await context.update(GraveBooking.graveBookId, GraveBooking);
            return Ok(GraveBooking);
        }
    }
}
    