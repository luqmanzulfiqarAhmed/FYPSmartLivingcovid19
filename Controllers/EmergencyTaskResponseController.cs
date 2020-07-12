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
    public class EmergencyTaskResponseController : ControllerBase
    {
        private readonly EmergencyTaskResponseRepositry context;

        public EmergencyTaskResponseController(EmergencyTaskResponseRepositry EmergencyTaskResponseRepositry)
        {
            context = EmergencyTaskResponseRepositry;
        }
        [HttpGet]
        public async Task<string> getAllEmergencyTaskResponsesData()
        {

            var EmergencyTaskResponseData = await context.retriveAllData();
            return JsonConvert.SerializeObject(EmergencyTaskResponseData);

        }
        //http://localhost:5000/api/EmergencyTaskResponse/1       
        [HttpGet("{id}", Name = "EmergencyTaskResponseData")]
        public async Task<string> getEmergencyTaskResponseData(string vehicleId)
        {
            var EmergencyTaskResponseData = await context.retrieveTask(vehicleId);
            if (EmergencyTaskResponseData == null)
                return null;
            return JsonConvert.SerializeObject(EmergencyTaskResponseData);
        }

        [HttpPost(Name = "EmergencyTaskResponseRegister")]
        public async Task<String> registerEmergencyTaskResponse([FromBody]EmergencyTaskResponse EmergencyTaskResponse)

        {
            var TaskResponseData = await context.retrieveAll(EmergencyTaskResponse.taskId);
            TaskResponseData = JsonConvert.SerializeObject(TaskResponseData);
            if (TaskResponseData.ToString() == "[]")
            {
                await context.insert(EmergencyTaskResponse);

                // if (EmergencyTaskResponse.taskType.Equals("MedicalEmergency"))
                // {
                //     var vehiclesAmbulance = await context.getVehichles("Ambulance");
                //     return JsonConvert.SerializeObject(vehiclesAmbulance);
                // }
                // if (EmergencyTaskResponse.taskType.Equals("FireEmergency"))
                // {
                //     var vehiclesFireBrigade = await context.getVehichles("Fire Brigade");
                //     return JsonConvert.SerializeObject(vehiclesFireBrigade);
                // }

            }
            return null;

        }



        [HttpPut]
        public async Task<ActionResult> updateEmergencyTaskResponseProfile([FromBody]EmergencyTaskResponse EmergencyTaskResponse)
        {


            await context.update(EmergencyTaskResponse.taskId, EmergencyTaskResponse);
            return Ok(EmergencyTaskResponse);
        }
    }
}
