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

        
        [HttpGet("{societyId}", Name = "AllHouseResidentBillData")]
        public async Task<string> getAllHouseResidentBillData(string societyId)
        {
            var billData = await context.retrieveAll(societyId);
            return JsonConvert.SerializeObject(billData);
        }

        
        [HttpGet("{id}", Name = "ResidentBill")]
        public async Task<string> getResidentBill(string id)
        {

            var billData = await context.retrieve(id);
            if (billData == null)
                return null;
            return JsonConvert.SerializeObject(billData);
        }

        [HttpPost( Name = "submitBill")]
        public async Task<string> submitBill( ManageBill bill)
        {
            
                //here first i will call 'calculateBill' function using bill object
                string msg = await context.insert(bill);
                return msg;
            
            
        }
 
        [HttpPut( Name = "updateBillManageBill")]
        public async Task<ActionResult> updateBill( ManageBill bill)
        {
            
            //here first i will call 'calculateBill' function using bill object to update bill
            await context.update("", bill);
            return NoContent();
        }

    }
}