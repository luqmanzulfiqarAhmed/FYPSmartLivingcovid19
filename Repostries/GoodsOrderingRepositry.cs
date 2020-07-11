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
    public class GoodsOrderingRepositry
    {
        private MongoDbContext dbContext = null;
        public GoodsOrderingRepositry(IConfiguration config)
        {

            dbContext = MongoDbContext.getMongoDbContext(config);//geting singletone object of database
            collection = dbContext.getDataBase().GetCollection<GoodsOrdering>("GoodsOrdering");//use singletone object to get database 
            //and call that database to get collection of GoodsOrdering
        }
        private readonly IMongoCollection<GoodsOrdering> collection;

        public async Task<object> retriveAllData()
        {
            return await collection.Find(x => true).ToListAsync();
        }

        //not defined yet because we will not delete in server we only disable particular account
        public async Task<object> delete(string id)
        {

            return true;
        }

        public async Task<Boolean> insert(object obj)
        {
            try{
            GoodsOrdering GoodsOrdering = (GoodsOrdering)obj;

            await collection.InsertOneAsync((GoodsOrdering)GoodsOrdering);
            return true;
            }catch(Exception ex){
                return false;
            }

        }

        public async Task<object> retrieve(string pId)
        {
            var GoodsOrdering = Builders<GoodsOrdering>.Filter.Eq("orderId", pId);
            return await collection.Find(GoodsOrdering).ToListAsync();
        }

        public async Task<object> retrieveAll(string societyId)
        {
            var GoodsOrdering = Builders<GoodsOrdering>.Filter.Eq("societyId", societyId);
            return await collection.Find(GoodsOrdering).ToListAsync();
        }

        public async Task<object> update(string id, object GoodsOrdering)
        {
            await collection.ReplaceOneAsync(ZZ => ZZ.orderId == id, (GoodsOrdering)GoodsOrdering);
            return true;
        }
    }
}

