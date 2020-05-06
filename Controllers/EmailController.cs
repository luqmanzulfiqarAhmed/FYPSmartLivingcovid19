
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using smartLiving;
using Newtonsoft.Json;

namespace smartLiving.Controllers
{
    
    [Route("api/Email")]
    [ApiController]

    public class EmailController : ControllerBase
    {
       

        public EmailController(Notification notification)
        {
            context = notification;
        }

        [HttpPost(Name = "sendEmail")]
        public async Task <bool> registerAdmin([FromBody]Notification notification)

        {            
            
            bool flag = notification.sendEmail();
            return flag;
        }
                
    }
}
    