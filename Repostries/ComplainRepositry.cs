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
    public class ComplainRepositry : InterfaceDataBase
    {
        private MongoDbContext dbContext = null;
        public ComplainRepositry(IConfiguration config)
        {

            dbContext = MongoDbContext.getMongoDbContext(config);//geting singletone object of database
            collection = dbContext.getDataBase().GetCollection<Complain>("Complain");//use singletone object to get database 
            //and call that database to get collection of Complain
        }
        private readonly IMongoCollection<Complain> collection;

        public async Task<object> retriveAllData()
        {
            return await collection.Find(x => true).ToListAsync();
        }

        //not defined yet because we will not delete in server we only disable particular account
        public async Task<object> delete(string id)
        {

            return true;
        }

        public async Task<object> insert(object obj)
        {
            Complain Complain = (Complain)obj;

            await collection.InsertOneAsync((Complain)Complain);
            return true;

        }

        public async Task<object> retrieve(string email )
        {
            var Complain = Builders<Complain>.Filter.Eq("residentEmail", email);
            return await collection.Find(Complain).ToListAsync();
        }

        public async Task<object> retrieveAll(string societyId)
        {
            var Complain = Builders<Complain>.Filter.Eq("societyId", societyId);
            return await collection.Find(Complain).ToListAsync();
        }

        public async Task<object> update(string id, object Complain)
        {
            try{
            await collection.ReplaceOneAsync(ZZ => ZZ.complaintId == id, (Complain)Complain);
            return true;
            }
            catch(Exception ex){
            return ex.Message;
            }
        }

    }
}
