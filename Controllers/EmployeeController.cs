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
            return JsonConvert.SerializeObject(EmployeeData) ;

        }
        //http://localhost:5000/api/Employee/1       
        // [HttpGet("{societyId}", Name = "EmployeeProfile")]
        // public async Task<string> getEmployeeData(string societyId)
        // {
        //     var EmployeeData = await context.retrieveAll(societyId);
        //     if (EmployeeData == null)
        //         return null;
        //     return JsonConvert.SerializeObject(EmployeeData);
        // }
        [HttpGet("{societyId}/{department}", Name = "EmployeeProfiledepartment")]
        public async Task<string> getEmployeeDataByDepartment(string societyId,string department)
        {
            var EmployeeData = await context.retrieveByDepartment(societyId,department);
            if (EmployeeData == null)
                return null;
            return JsonConvert.SerializeObject(EmployeeData);
        }
        [HttpGet("{societyIdEmail}", Name = "getEmployeeDataByEmail")]
        public async Task<string> getEmployeeDataByEmail(string societyIdEmail)
        {
            string []id=societyIdEmail.Split(",");
            if(id !=null){   
                if(!id[0].Equals("") && id[1].Equals("")){
                    var EmployeeData = await context.retrieveAll(id[0]);
                    if (EmployeeData == null)
                                return null;
                    return JsonConvert.SerializeObject(EmployeeData);
                }              
                if(!id[0].Equals("") && !id[1].Equals("")){
                        var EmployeeData = await context.retrieveByEmail(id[0],id[1]);
                        if (EmployeeData == null)
                            return null;
                    return JsonConvert.SerializeObject(EmployeeData);
            }
            return "send like this : societyId,EmployeeEmail";
        }
            return "null parameter";
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