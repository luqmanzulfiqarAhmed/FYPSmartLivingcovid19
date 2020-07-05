
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using smartLiving.Models;


using Newtonsoft.Json;
using smartLiving.Repostries;

namespace smartLiving.Controllers
{
    
    [Route("api/Vehicle")]
    [ApiController]

    public class VehicleController : ControllerBase
    {
        private readonly VehicleRepositry context;

        public VehicleController(VehicleRepositry VehicleRepositry)
        {
            context = VehicleRepositry;
        }

        
        
        // [HttpGet]
        // public async Task<string> getTest(){

        //     var vehichleData = await context.retrieveAll("SitaraSapna@123");
        //     return JsonConvert.SerializeObject(vehichleData);
        // }

        [HttpGet("{societyId}", Name = "getAllVehichleData")]
        public async Task<string> getAllVehichleData(string societyId)
        {
            var SocietyData = await context.retrieve(societyId);
            if (SocietyData == null)
                return null;
            return JsonConvert.SerializeObject(SocietyData);
        }
         //http://localhost:5000/api/vehichle/1       
        [HttpGet("{vId}/{sId}", Name = "getVehichleData")]
        public async Task<string> getvehichleData(string vId,string sId)
        {
            var adminData = await context.retrieveAll(vId,sId);
            if (adminData == null)
                return null;
            return JsonConvert.SerializeObject(adminData);        
        }

        [HttpPost(Name = "VehicleRegister")]
        public async Task <bool > registerVehicle([FromBody]Vehicle vehicle)//ActionResult<Vehicle>

        {            
            var VehicleData = await context.retrieve(vehicle.vehicleId);
                                

            VehicleData= JsonConvert.SerializeObject(VehicleData);
            if (VehicleData.ToString() == "[]")
            {
                 await context.insert(vehicle);                 
                 
                 return true;
            }
            
            return false;
        }
         

        //[HttpPut("{VehicleId},{societyId},{Vehicle}", Name = "UpdateProfileVehicle")]
        [HttpPut]
        public async Task <ActionResult> updateVehicleProfile( [FromBody]Vehicle vehicle)
         {
            

           await context.update(vehicle.vehicleId, vehicle);
            return Ok(vehicle);
        }
    }
}

    