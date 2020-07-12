
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using smartLiving.Models;


using Newtonsoft.Json;
using smartLiving.Repostries;
using System;

namespace smartLiving.Controllers
{
    
    [Route("api/Graveyard")]
    [ApiController]

    public class GraveyardController : ControllerBase
    {
        private readonly PropertyRepositry context;

        public GraveyardController(PropertyRepositry PropertyRepositry)
        {
            context = PropertyRepositry;
        }

        
        
        [HttpGet]
        public async Task<string> getTest(){

            var vehichleData = await context.retrieveAll("SitaraSapna@123");
            return JsonConvert.SerializeObject(vehichleData);
        }

        
        [HttpGet("{sId}", Name = "getGraveyardData")]
        public async Task<String> getGraveyardData(string sId)
        {
            var ShopData = await context.retrieveGraveyard(sId);
            if (ShopData == null)
                return null;
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
                return JsonConvert.SerializeObject(Shop); 
        }
    }
}

    