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
    [Route("api/Employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepositry context;

        public EmployeeController(EmployeeRepositry EmployeeRepositry)
        {
            context = EmployeeRepositry;
        }
        [HttpGet(Name = "getAllEmployeesData")]
        public async Task<string> getAllEmployeesData()
        {

            var EmployeeData = await context.retriveAllData();
            return JsonConvert.SerializeObject(EmployeeData) + "this";

        }
        //http://localhost:5000/api/Employee/1       
        [HttpGet("{societyId}", Name = "EmployeeProfile")]
        public async Task<string> getEmployeeData(string societyId)
        {
            var EmployeeData = await context.retrieve(societyId);
            if (EmployeeData == null)
                return null;
            return JsonConvert.SerializeObject(EmployeeData);
        }
        [HttpGet("{societyId}/{designation}", Name = "EmployeeProfileDesignation")]
        public async Task<string> getEmployeeDataBydesignation(string societyId,string designation)
        {
            var EmployeeData = await context.retrieveByDesignation(societyId,designation);
            if (EmployeeData == null)
                return null;
            return JsonConvert.SerializeObject(EmployeeData);
        }
        [HttpPost(Name = "EmployeeRegister")]
        public async Task<String> registerEmployee([FromBody]Employee Employee)

        {
            var EmployeeData = await context.retrieve(Employee.employeeEmail);


            EmployeeData = JsonConvert.SerializeObject(EmployeeData);
            if (EmployeeData.ToString() == "[]")
            {
                await context.insert(Employee);

                return "true";
            }

            return EmployeeData.ToString();
        }



        [HttpPut]
        public async Task<ActionResult> updateEmployeeProfile([FromBody]Employee Employee)
        {


            await context.update(Employee.employeeEmail, Employee);
            return Ok(Employee);
        }
    }
}