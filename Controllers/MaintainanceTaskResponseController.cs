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
    public class MaintainanceTaskResponseController : ControllerBase
    {
        private readonly MaintainanceTaskResponseRepositry context;

        public MaintainanceTaskResponseController(MaintainanceTaskResponseRepositry MaintainanceTaskResponseRepositry)
        {
            context = MaintainanceTaskResponseRepositry;
        }
        [HttpGet]
        public async Task<string> getAllMaintainanceTaskResponsesData()
        {

            var MaintainanceTaskResponseData = await context.retriveAllData();
            return JsonConvert.SerializeObject(MaintainanceTaskResponseData);

        }
        //http://localhost:5000/api/MaintainanceTaskResponse/1       
        [HttpGet("{id}", Name = "MaintainanceTaskResponseProfile")]        
        public async Task<string> getMaintainanceTaskResponseData(string employeeEmail)
        {
            var MaintainanceTaskResponseData = await context.retrieveTask(employeeEmail);
            if (MaintainanceTaskResponseData == null)
                return null;
            return JsonConvert.SerializeObject(MaintainanceTaskResponseData);
        }
        [HttpPost(Name = "MaintainanceTaskResponseRegister")]
        public async Task<String> registerMaintainanceTaskResponse([FromBody]MaintainanceTaskResponse MaintainanceTaskResponse)

        {
            var MaintainanceTaskResponseData = await context.retrieve(MaintainanceTaskResponse.taskId);
            MaintainanceTaskResponseData = JsonConvert.SerializeObject(MaintainanceTaskResponseData);
            if (MaintainanceTaskResponseData.ToString() == "[]")
            {
                await context.insert(MaintainanceTaskResponse);
                var employees = context.getEmployees("Maintenance");
                return employees.ToString();
            }

            return "All ready exist the task"+ MaintainanceTaskResponseData.ToString();
        }



        [HttpPut]
        public async Task<ActionResult> updateMaintainanceTaskResponseProfile([FromBody]MaintainanceTaskResponse MaintainanceTaskResponse)
        {


            await context.update(MaintainanceTaskResponse.taskId, MaintainanceTaskResponse);
            return Ok(MaintainanceTaskResponse);
        }
    }
}