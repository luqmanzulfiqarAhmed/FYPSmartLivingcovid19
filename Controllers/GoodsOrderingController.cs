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
    [Route("api/GoodsOrdering")]
    [ApiController]
    public class GoodsOrderingController : ControllerBase
    {
        private readonly GoodsOrderingRepositry context;

        public GoodsOrderingController(GoodsOrderingRepositry GoodsOrderingRepositry)
        {
            context = GoodsOrderingRepositry;
        }
        [HttpGet]
        public async Task<string> getAllGoodsOrderingsData()
        {

            var GoodsOrderingData = await context.retriveAllData();
            return JsonConvert.SerializeObject(GoodsOrderingData);

        }
        //http://localhost:5000/api/GoodsOrdering/1       
        [HttpGet("{sId}/{Pid}", Name = "GoodsOrderingProfile")]
        public async Task<string> getGoodsOrderingData(string sId,string pId)
        {

            var GoodsOrderingData = await context.retrieve(sId,pId);
            if (GoodsOrderingData == null)
                return null;
            return JsonConvert.SerializeObject(GoodsOrderingData);
        }

        [HttpPost(Name = "GoodsOrderingRegister")]
        public async Task<Boolean> registerGoodsOrdering([FromBody]GoodsOrdering GoodsOrdering)

        {
            


            
            
            
                Boolean flag = await context.insert(GoodsOrdering);

                return flag;
            

            return false;
        }



        [HttpPut]
        public async Task<Boolean> updateGoodsOrderingProfile([FromBody]GoodsOrdering GoodsOrdering)
        {


            Boolean flag= await context.update(GoodsOrdering.orderId, GoodsOrdering);
            return flag;
        }
    }
}
