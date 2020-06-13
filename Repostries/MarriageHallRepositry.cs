
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
    public class MarriageHallRepositry
    {

        private MongoDbContext dbContext = null;
        public MarriageHallRepositry(IConfiguration config)
        {

            dbContext = MongoDbContext.getMongoDbContext(config);//geting singletone object of database
            collection = dbContext.getDataBase().GetCollection<Property>("Property");//use singletone object to get database 
            //and call that database to get collection of Shop
        }
        private readonly IMongoCollection<Property> collection;

        public async Task<MarriageHall> retrieveMarriageHall(string sId,string pId)

        {
            var Property = Builders<Property>.Filter.Eq("propertyId", pId);
            var society = Builders<Property>.Filter.Eq("societyId", sId);
            var combineFilters = Builders<Property>.Filter.And(society,Property);            
            Task <Property> itemsTask =Task.Run(() =>( collection.Find(Property).FirstOrDefaultAsync() )) ;            

            if(itemsTask !=null){    
            Property prop  = itemsTask.Result;    
            if(prop.Commercial !=null)        {
            MarriageHall marriageHallData = prop.Commercial.marriageHall;            
            return marriageHallData;
                }
            }
            return null;
        }
        public async Task<Object> updatemarriageHall(string sId,string pId,Menue menue)
        {
            try{
                var society = Builders<Property>.Filter.Eq("societyId", sId);
                var Property = Builders<Property>.Filter.Eq("propertyId", pId);                
                var combineFilters = Builders<Property>.Filter.And(society,Property);            
                Task <Property> itemsTask =Task.Run(() =>( collection.Find(Property).FirstOrDefaultAsync()));
            //Property prop  = (Property)var;
            if(itemsTask !=null){    
                Property prop  = itemsTask.Result;    
            if(prop.Commercial !=null) {
                    if(prop.Commercial.marriageHall != null){
                        prop.Commercial.marriageHall.menues.Add(menue);
                        await collection.ReplaceOneAsync(ZZ => ZZ.propertyId == pId && 
                        ZZ.societyId == sId, prop);
                        return true;
                    }else{
                        return  pId+ " is not a marriage Hall"  ;
                    }
                        
                                      }
                    else                                      
                         return pId+ " is not a commercial property";;
            }
        }catch(Exception ex){
                return ex.Message;            
        }
        return false;
    }
  
        
    }
}
