
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
            var ShopData = await context.retrieveShop(sId,pId);
            if (ShopData == null)
                return "no data";
            return JsonConvert.SerializeObject(ShopData);        
        }

       
         

        [HttpPut("{sIdPId}", Name = "updateShopProfile")]        
        public async Task <Object> updateShopProfile( string sIdPId,[FromBody]Shop Shop)
         {
        //      if(Shop != null){
        //         string []id=sIdPId.Split(",");
        //     if(id !=null && sIdPId.Contains(",")){                                 
        //    Object flag = await context.updateShop(id[0],id[1], Shop);
            
        //     return flag;
        //     }            
        //     return "no comma detected";
        //      }
        //      return "shop is null";
                return "jahdjhasdb" + "your data!!!   " + Shop;
        }
    }
}

    