using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using demoELiving.Repositires;
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

        [Route("[action]/{societyId}")]
        [HttpGet("{societyId}", Name = "AllHouseResidentBillData")]
        public async Task<string> getAllHouseResidentBillData(string societyId)
        {
            var billData = await context.retrieveAll(societyId);
            return JsonConvert.SerializeObject(billData);
        }

        [Route("[action]/{id}")]
        [HttpGet("{id}", Name = "ResidentBill")]
        public async Task<string> getResidentBill(string id)
        {

            var billData = await context.retrieve(id);
            if (billData == null)
                return null;
            return JsonConvert.SerializeObject(billData);
        }

        [HttpPost("{residentId,bill}", Name = "submitBill")]
        public async Task<ActionResult<ManageBill>> submitBill(string residentId, ManageBill bill)
        {
            if (residentId == bill.residentId)
            {
                //here first i will call 'calculateBill' function using bill object
                await context.insert(bill);
                return CreatedAtAction("submitBill", new ManageBill { bill_Id = bill.bill_Id }, bill);//just telling that this HouseResident is registered with this id
            }
            return BadRequest();
        }
 
        [HttpPut( Name = "updateBillManageBill")]
        public async Task<ActionResult> updateBill(string adminId, ManageBill bill)
        {
            if (adminId != bill.adminId )
            {
                return BadRequest();
            }
            //here first i will call 'calculateBill' function using bill object to update bill
            await context.update(adminId, bill);
            return NoContent();
        }

    }
}