
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using smartLiving.Models;


using Newtonsoft.Json;
using smartLiving.Repostries;
using System;

namespace smartLiving.Controllers
{
    
    [Route("api/Shop")]
    [ApiController]

    public class ShopController : ControllerBase
    {
        private readonly PropertyRepositry context;

        public ShopController(PropertyRepositry PropertyRepositry)
        {
            context = PropertyRepositry;
        }

        
        
        [HttpGet]
        public async Task<string> getTest(){

            var vehichleData = await context.retrieveAll("SitaraSapna@123");
            return JsonConvert.SerializeObject(vehichleData);
        }

        
        [HttpGet("{sId},{pId}", Name = "getShopData")]
        public async Task<Object> getShopData(string sId,string pId)
        {
            var ShopData = await context.retrieve(sId,pId);
            if (ShopData == null)
                return "no data";
            return JsonConvert.SerializeObject(ShopData);        
        }

       
         

        //[HttpPut("{ShopId},{societyId},{Shop}", Name = "UpdateProfileShop")]
        [HttpPut]
        public async Task <Object> updateShopProfile( string sId, string pId,[FromBody]Shop Shop)
         {
            

           Object flag = await context.updateShop(sId,pId, Shop);
            return flag;
        }
    }
}

    