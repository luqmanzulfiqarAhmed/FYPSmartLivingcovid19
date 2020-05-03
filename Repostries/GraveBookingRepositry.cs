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
    public class GraveBookingRepositry : InterfaceDataBase
    {
        private MongoDbContext dbContext = null;
        public GraveBookingRepositry(IConfiguration config)
        {

            dbContext = MongoDbContext.getMongoDbContext(config);//geting singletone object of database
            collection = dbContext.getDataBase().GetCollection<GraveBooking>("GraveBooking");//use singletone object to get database 
            //and call that database to get collection of GraveBooking
        }
        private readonly IMongoCollection<GraveBooking> collection;

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
            GraveBooking GraveBooking = (GraveBooking)obj;

            await collection.InsertOneAsync((GraveBooking)GraveBooking);
            return true;

        }

        public async Task<object> retrieve(string pId)
        {
            var GraveBooking = Builders<GraveBooking>.Filter.Eq("graveBookId", pId);
            return await collection.Find(GraveBooking).ToListAsync();
        }

        public async Task<object> retrieveAll(string societyId)
        {
            var GraveBooking = Builders<GraveBooking>.Filter.Eq("societyId", societyId);
            return await collection.Find(GraveBooking).ToListAsync();
        }

        public async Task<object> update(string id, object GraveBooking)
        {
            await collection.ReplaceOneAsync(ZZ => ZZ.graveBookId == id, (GraveBooking)GraveBooking);
            return true;
        }
    }
}
