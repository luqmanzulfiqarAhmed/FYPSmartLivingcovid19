using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;


using smartLiving.Repostries;
using smartLiving.Models;
using Newtonsoft.Json;

namespace smartLiving.Controllers
{
    [Route("api/ManageBill")]
    [ApiController]
    public class ManageBillController : ControllerBase
    {
        private ManageBillRepositry context;
        public ManageBillController(ManageBillRepositry billRepositry) {
            context = billRepositry;
        }

        
        [HttpGet("{data}", Name = "getHouseResidentBillData")]
        public async Task<string> getHouseResidentBillData(string data)
        {
            string []id=data.Split(",");
            if(id !=null){                 
                if(!id[0].Equals("") && id[1].Equals("") && id[2].Equals(""))
                {//get all bills Data of a scoiety                    
                    var billsData = await context.retrieveAll(id[0]);
                    if(billsData == null)
                        return null;                
                    return JsonConvert.SerializeObject(billsData) ;
            }              
            var billData = await context.retrieveBySidPidEmail(id[0],id[1],id[2]);
            if (billData == null)
                return null;
            return JsonConvert.SerializeObject(billData) ;
            }
            return "no response wrong parameters!";
        }

        
        // [HttpGet("{sid},{email}", Name = "getResidentBill")]
        // public async Task<string> getResidentBill(string sid,string email)
        // {

        //     var billData = await context.retrieveBySidEmail(sid,email);
        //     if (billData == null)
        //         return null;
        //     return JsonConvert.SerializeObject(billData);
        // }

        [HttpPost( Name = "submitBill")]
        public async Task<string> submitBill( [FromBody]ManageBill bill)
        {
            
                //here first i will call 'calculateBill' function using bill object
                string msg = await context.insert(bill);
                return msg;
            
            
        }
 
        [HttpPut( Name = "updateBill")]
        public async Task<Object> updateBill( [FromBody]ManageBill bill)
        {
            
            //here first i will call 'calculateBill' function using bill object to update bill
            
            return await context.update(bill);
        }

    }
}