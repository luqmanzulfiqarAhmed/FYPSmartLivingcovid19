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
    [Route("api/Announcement")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly AnnouncementRepositry context;

        public AnnouncementController(AnnouncementRepositry AnnouncementRepositry)
        {
            context = AnnouncementRepositry;
        }
        [HttpGet]
        public async Task<string> getAllAnnouncementsData()
        {

            var AnnouncementData = await context.retriveAllData();
            return JsonConvert.SerializeObject(AnnouncementData);

        }
        //http://localhost:5000/api/Announcement/1       
        [HttpGet("{societyId}", Name = "getAnnouncementData")]
        public async Task<string> getAnnouncementData(string societyId)
        {
            var AnnouncementData = await context.retrieveAll(societyId);
            if (AnnouncementData == null)
                return null;
            return JsonConvert.SerializeObject(AnnouncementData);
        }

        [HttpPost(Name = "registerAnnouncement")]
        public async Task<String> registerAnnouncement([FromBody]Announcement Announcement)

        {
            var AnnouncementData = await context.retrieve(Announcement.anouncementId);


            AnnouncementData = JsonConvert.SerializeObject(AnnouncementData);
            if (AnnouncementData.ToString() == "[]")
            {
                await context.insert(Announcement);

                return "true";
            }

            return AnnouncementData.ToString();
        }



        [HttpPut]
        public async Task<ActionResult> updateAnnouncementProfile([FromBody]Announcement Announcement)
        {


            await context.update(Announcement.anouncementId, Announcement);
            return Ok(Announcement);
        }
        [HttpDelete("{anouncementId}", Name = "deleteAnnouncement")]
        
        public async Task<Boolean> deleteAnnouncement(string anouncementId){
            
            var  flag = (Boolean)await context.delete(anouncementId);

            return flag;
        }
    }
}
