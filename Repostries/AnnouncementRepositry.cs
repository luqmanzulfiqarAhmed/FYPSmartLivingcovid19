using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using smartLiving.Models;
using smartLiving.MongoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smartLiving.Repostries
{
    public class AnnouncementRepositry 
    {
        private MongoDbContext dbContext = null;
        public AnnouncementRepositry(IConfiguration config)
        {

            dbContext = MongoDbContext.getMongoDbContext(config);//geting singletone object of database
            collection = dbContext.getDataBase().GetCollection<Announcement>("Announcement");//use singletone object to get database 
            //and call that database to get collection of Announcement
        }
        private readonly IMongoCollection<Announcement> collection;

        public async Task<object> retriveAllData()
        {
            return await collection.Find(x => true).ToListAsync();
        }

        //not defined yet because we will not delete in server we only disable particular account
        public async Task<object> delete(string id)
        {
            try {
            var announcement = Builders<Announcement>.Filter.Eq("anouncementId", id);
            var flag = await collection.DeleteOneAsync(announcement);    
            return flag;
            }catch(Exception ex){
                return "false  " + ex.Message;
            }
        }

        public async Task<object> insert(object obj)
        {
            Announcement Announcement = (Announcement)obj;

            await collection.InsertOneAsync((Announcement)Announcement);
            return true;

        }

        public async Task<object> retrieve(string pId)
        {
            var Announcement = Builders<Announcement>.Filter.Eq("anouncementId", pId);
            return await collection.Find(Announcement).ToListAsync();
        }

        public async Task<object> retrieveAll(string societyId)
        {
            var Announcement = Builders<Announcement>.Filter.Eq("societyId", societyId);
            return await collection.Find(Announcement).ToListAsync();
        }

        public async Task<object> update(string id, object Announcement)
        {
            await collection.ReplaceOneAsync(ZZ => ZZ.anouncementId == id, (Announcement)Announcement);
            return true;
        }
    }

}
