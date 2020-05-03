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
    public class MarriageHallReservationRepositry : InterfaceDataBase
    {
        private MongoDbContext dbContext = null;
        public MarriageHallReservationRepositry(IConfiguration config)
        {

            dbContext = MongoDbContext.getMongoDbContext(config);//geting singletone object of database
            collection = dbContext.getDataBase().GetCollection<MarriageHallReservation>("MarriageHallReservation");//use singletone object to get database 
            //and call that database to get collection of MarriageHallReservation
        }
        private readonly IMongoCollection<MarriageHallReservation> collection;

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
            MarriageHallReservation MarriageHallReservation = (MarriageHallReservation)obj;

            await collection.InsertOneAsync((MarriageHallReservation)MarriageHallReservation);
            return true;

        }

        public async Task<object> retrieve(string pId)
        {
            var MarriageHallReservation = Builders<MarriageHallReservation>.Filter.Eq("hallReservationId", pId);
            return await collection.Find(MarriageHallReservation).ToListAsync();
        }

        public async Task<object> retrieveAll(string societyId)
        {
            var MarriageHallReservation = Builders<MarriageHallReservation>.Filter.Eq("societyId", societyId);
            return await collection.Find(MarriageHallReservation).ToListAsync();
        }

        public async Task<object> update(string id, object MarriageHallReservation)
        {
            await collection.ReplaceOneAsync(ZZ => ZZ.hallReservationId == id, (MarriageHallReservation)MarriageHallReservation);
            return true;
        }

    }
}
