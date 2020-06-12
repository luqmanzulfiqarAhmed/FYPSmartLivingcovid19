
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using smartLiving.Models;
using smartLiving.MongoDb;

using Newtonsoft.Json;
namespace smartLiving.Repostries

{
    public class ShopRepositry
    {

        private MongoDbContext dbContext = null;
        public ShopRepositry(IConfiguration config)
        {

            dbContext = MongoDbContext.getMongoDbContext(config);//geting singletone object of database
            collection = dbContext.getDataBase().GetCollection<Shop>("Shop");//use singletone object to get database 
            //and call that database to get collection of Shop
        }
        private readonly IMongoCollection<Shop> collection;

          
        public async Task<object> delete(string id)
        {

            return true;
        }

        public async Task<object> insert(object obj)
        {           
             Shop Shop = (Shop)obj;                                               
                await collection.InsertOneAsync((Shop)Shop);
                return true;

        }

        public async Task<object> retrieve(string societyId)
        {
            var Shop = Builders<Shop>.Filter.Eq("societyId", societyId);            
            return  await collection.Find(Shop).ToListAsync();
        }

        public async Task<object> retrieveAll(string ShopId, string societyId)
        {
            var Shop = Builders<Shop>.Filter.Eq("societyId", societyId);
            var society = Builders<Shop>.Filter.Eq("ShopId", ShopId);
            var combineFilters = Builders<Shop>.Filter.And(Shop, society);
            return await collection.Find(combineFilters).SingleAsync();
            
        }

        public async Task<object> update(string id, object Shop)
        {
            return null;
        }
    }
}
