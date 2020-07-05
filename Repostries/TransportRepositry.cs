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
    public class TransportRepositry 
    {
        private MongoDbContext dbContext = null;
        public TransportRepositry(IConfiguration config)
        {

            dbContext = MongoDbContext.getMongoDbContext(config);//geting singletone object of database
            collection = dbContext.getDataBase().GetCollection<Transport>("Transport");//use singletone object to get database 
            //and call that database to get collection of Transport
        }
        private readonly IMongoCollection<Transport> collection;

        public async Task<object> retriveAllData(string societyId)
        {
            var Transport = Builders<Transport>.Filter.Eq("societyId", societyId);
            return await collection.Find(Transport).ToListAsync();
        }

        //not defined yet because we will not delete in server we only disable particular account
        public async Task<object> delete(string id)
        {

            return true;
        }

        public async Task<object> insert(Transport transport)
        {
            try{
            await collection.InsertOneAsync(transport);
            return true;
            }catch(Exception ex){

                return ex.Message;
            }

        }

        public async Task<object> retrieve(string tId)
        {
            var Transport = Builders<Transport>.Filter.Eq("transportId", tId);
            return await collection.Find(Transport).ToListAsync();
        }

        public async Task<object> retrieveBySocietyID(string societyId)
        {
            var Transport = Builders<Transport>.Filter.Eq("societyId", societyId);
            return await collection.Find(Transport).ToListAsync();
        }

        public async Task<object> update(string id, object Transport)
        {
            await collection.ReplaceOneAsync(ZZ => ZZ.transportId == id, (Transport)Transport);
            return true;
        }

    }
}
