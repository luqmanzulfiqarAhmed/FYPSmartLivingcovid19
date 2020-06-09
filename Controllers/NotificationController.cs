using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace smartLiving.Controllers
{
    [Route("api/Notification")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        

        // POST: api/Notification
        [HttpPost]
        public async Task<string> Post([FromBody] Notification notification)
        {
            string flag= await notification.sendEmail();
            return flag;
        }

        
    }
}
