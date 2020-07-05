
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using smartLiving.Repostries;
using smartLiving.Models;
using Newtonsoft.Json;

namespace smartLiving.Controllers
{
    
    [Route("api/Admin")]
    [ApiController]

    public class AdminController : ControllerBase
    {
        private readonly AdminRepositry context;

        public AdminController(AdminRepositry adminRepositry)
        {
            context = adminRepositry;
        }
        [HttpGet]
        public async Task<string> getAllAdminsData()
        {

            var adminData = await context.retriveAllData();
            return JsonConvert.SerializeObject(adminData);
            
        }
         //http://localhost:5000/api/Admin/1       
        [HttpGet("{id}", Name = "AdminProfile")]
        public async Task<string> getAdminData(string id)
        {
            var adminData = await context.retrieve(id);
            if (adminData == null)
                return null;
            return JsonConvert.SerializeObject(adminData);        
        }

        [HttpPost(Name = "AdminRegister")]
        public async Task <bool > registerAdmin([FromBody]Admin admin)

        {            
            var adminData = await context.retrieve(admin.adminEmail);
                                

            adminData= JsonConvert.SerializeObject(adminData);
            if (adminData.ToString() == "[]")
            {
                 await context.insert(admin);                 
                 
                 return true;
            }
            
            return false;
        }
         

        
        [HttpPut
        ]
        public async Task <ActionResult> updateAdminProfile( [FromBody]Admin admin)
         {
            
        
           await context.update(admin.adminEmail, admin);
            return Ok(admin);
        }
    }
}
    