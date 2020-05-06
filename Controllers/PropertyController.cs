using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using smartLiving.Models;
using smartLiving.Repostries;

namespace smartLiving.Controllers
{
    [Route("api/Property")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly PropertyRepositry context;

        public PropertyController(PropertyRepositry PropertyRepositry)
        {
            context = PropertyRepositry;
        }
        [HttpGet]
        public async Task<string> getAllPropertysData()
        {

            var PropertyData = await context.retriveAllData();
            return JsonConvert.SerializeObject(PropertyData);

        }
        //http://localhost:5000/api/Property/1       
        [HttpGet("{data}", Name = "PropertyProfile")]
        public async Task<string> getPropertyData(  string data)
        {
                string []id=data.Split(",");
            if(id !=null){    
            if(id[1].Equals("")){//get all properties of a scoiety
                    
            var propertiesData = await context.retrieveAll(id[0]);
            return JsonConvert.SerializeObject(propertiesData);

            }
            var PropertyData = await context.retrieve(id[0],id[1]);
            if (PropertyData == null)
                return null;
            return JsonConvert.SerializeObject(PropertyData);
            }
            return "adsda";
        }

        // [HttpPost(Name = "PropertyRegister")]
        // public async Task<String> registerProperty([FromBody]Property Property)

        // {
        //     var PropertyData = await context.retrieve(Property.propertyId);


        //     PropertyData = JsonConvert.SerializeObject(PropertyData);
        //     if (PropertyData.ToString() == "[]")
        //     {
        //         await context.insert(Property);

        //         return "true";
        //     }

        //     return PropertyData.ToString();
        // }
        [HttpPost(Name = "PropertyRegisterAll")]
        public async Task<bool> registerPropertiesAll([FromBody]Property[] Property){

                bool flag =await context.insert(Property);
                return flag;
                
        }

        



        [HttpPut
        ]
        public async Task<ActionResult> updatePropertyProfile([FromBody]Property Property)
        {


            await context.update(Property.propertyId, Property);
            return Ok(Property);
        }
    }
}