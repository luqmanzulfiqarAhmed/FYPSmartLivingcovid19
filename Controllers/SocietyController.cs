﻿using System;
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
    [Route("api/Society")]
    [ApiController]
    public class SocietyController : ControllerBase
    {
        private readonly SocietyRepositry context;

        public SocietyController(SocietyRepositry SocietyRepositry)
        {
            context = SocietyRepositry;
        }
        [HttpGet]
        public async Task<string> getAllSocietysData()
        {

            var SocietyData = await context.retriveAllData();
            return JsonConvert.SerializeObject(SocietyData);

        }
        //http://localhost:5000/api/Society/1       
        [HttpGet("{id}", Name = "getSocietyData")]
        public async Task<string> getSocietyData(string id)
        {
            var SocietyData = await context.retrieve(id);
            if (SocietyData == null)
                return null;
            return JsonConvert.SerializeObject(SocietyData);
        }
        

        [HttpPost(Name = "SocietyRegister")]
        public async Task<String> registerSociety([FromBody]Society Society)

        {
            var SocietyData = await context.retrieveAllById(Society.societyId);


            SocietyData = JsonConvert.SerializeObject(SocietyData);
            if (SocietyData.ToString() == "[]")
            {
                await context.insert(Society);

                return "true";
            }

            return SocietyData.ToString();
        }



        [HttpPut]
        public async Task<ActionResult> updateSocietyProfile([FromBody]Society Society)
        {


            await context.update(Society.societyId, Society);
            return Ok(Society);
        }
    }
}