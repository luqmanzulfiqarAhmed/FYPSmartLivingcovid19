using smartLiving.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using smartLiving.MongoDb;
using Newtonsoft.Json;
namespace smartLiving.Repositires

{
    public class AdminRepositry
    {

        private MongoDbContext dbContext = null;
        public AdminRepositry(IConfiguration config)
        {

            dbContext = MongoDbContext.getMongoDbContext(config);//geting singletone object of database
            collection = dbContext.getDataBase().GetCollection<Admin>("Admin");//use singletone object to get database 
            //and call that database to get collection of Admin
        }
        private readonly IMongoCollection<Admin> collection;

        public async Task<object> retriveAllData()
        {            
            return await collection.Find(x=>true).ToListAsync();
        }

        //not defined yet because we will not delete in server we only disable particular account
        public async Task<object> delete(string id)
        {

            return true;
        }

        public async Task<object> insert(object obj)
        {           
             Admin admin = (Admin)obj;                                               
                await collection.InsertOneAsync((Admin)admin);
                return true;

        }

        public async Task<object> retrieve(string adminEmail)
        {
            var admin = Builders<Admin>.Filter.Eq("adminEmail", adminEmail);            
            return  await collection.Find(admin).ToListAsync();
        }

        public async Task<object> retrieveAll(string societyId)
        {
            var admin = Builders<Admin>.Filter.Eq("HousingSocietyID", societyId);
            return await collection.Find(admin).ToListAsync();
        }

        public async Task<object> update(string id, object admin)
        {
            await collection.ReplaceOneAsync(ZZ => ZZ.adminEmail == id, (Admin)admin);
            return true;
        }
    }
}
