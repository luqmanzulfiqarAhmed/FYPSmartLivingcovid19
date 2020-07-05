
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
       
       private readonly Notification context;

        public EmailController(Notification notification)
        {
            context = notification;
        }

        [HttpPost(Name = "sendEmail")]
        public async Task <object> registerAdmin([FromBody]Notification notification)

        {            
            
            var flag = notification.sendEmail();
            return flag;
        }
                
    }
}
    