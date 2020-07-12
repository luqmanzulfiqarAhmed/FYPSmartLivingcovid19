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
    public class MarriageHallReservationRepositry 
    {
        private MongoDbContext dbContext = null;
        public MarriageHallReservationRepositry(IConfiguration config)
        {

            dbContext = MongoDbContext.getMongoDbContext(config);//geting singletone object of database
            collection = dbContext.getDataBase().GetCollection<MarriageHallReservation>("MarriageHallReservation");//use singletone object to get database 
            //and call that database to get collection of MarriageHallReservation
        }
        private readonly IMongoCollection<MarriageHallReservation> collection;

        public async Task<MarriageHallReservation> retriveAllData(string sid,string hid)
        {
            var society = Builders<MarriageHallReservation>.Filter.Eq("societyId", sid);        
            
            var property = Builders<MarriageHallReservation>.Filter.Eq("hallReservationId", hid);

            var combineFilters = Builders<MarriageHallReservation>.Filter.And(society,property);
            
             var result = collection.Find(combineFilters).FirstOrDefaultAsync();
            MarriageHallReservation hallReservations = result.Result;
            return hallReservations;
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

        public async Task<List<MarriageHallReservation>> retrieveBySidPidrEmail(string sId,string rEmail)
        {
            var society = Builders<MarriageHallReservation>.Filter.Eq("societyId", sId);        
            
            var Email = Builders<MarriageHallReservation>.Filter.Eq("residentEmail", rEmail);
            var combineFilters = Builders<MarriageHallReservation>.Filter.And(society,Email);
            
             var result = collection.Find(combineFilters).ToListAsync();
            List<MarriageHallReservation> hallReservations = result.Result;
            return hallReservations;
        }
public async Task<List<MarriageHallReservation>> retrieveBySidPid(string sId,string pId)
        {
            var society = Builders<MarriageHallReservation>.Filter.Eq("societyId", sId);        
            var property = Builders<MarriageHallReservation>.Filter.Eq("marriageHallPropertyId", pId);
            
            var combineFilters = Builders<MarriageHallReservation>.Filter.And(society, property);
            
             var result = collection.Find(combineFilters).ToListAsync();
            List<MarriageHallReservation> hallReservations = result.Result;
            return hallReservations;
        }
        public async Task<object> retrieveAll(string societyId)
        {
            var MarriageHallReservation = Builders<MarriageHallReservation>.Filter.Eq("societyId", societyId);
            return await collection.Find(MarriageHallReservation).ToListAsync();
        }

        public async Task<Boolean> update(string id, MarriageHallReservation obj)
        {
            try{
            await collection.ReplaceOneAsync(ZZ => ZZ.hallReservationId == id, obj);
            return true;
            }catch(Exception ex){
                    return false;
            }
        }

    }
}
