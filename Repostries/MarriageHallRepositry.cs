
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

        public async Task<Object> retrieveMarriageHall(string sId,string pId)

        {
            var Property = Builders<Property>.Filter.Eq("propertyId", pId);
            var society = Builders<Property>.Filter.Eq("societyId", sId);
            var combineFilters = Builders<Property>.Filter.And(society,Property);            
            var itemsTask  = collection.Find(Property).FirstOrDefaultAsync() ;            

            if(itemsTask !=null){    
            Property prop  = itemsTask.Result;     
                if(prop != null)   {
            if(prop.Commercial !=null){
                MarriageHall marriageHallData = prop.Commercial.marriageHall;            
                    return marriageHallData;
                }
                }
                return "No property found";
            }
            return null;
        }
        public async Task<Object> updatemarriageHallMenue(string sId,string pId,MarriageHall marriageHall)
        {
            Property prop = null;
            try{
                var society = Builders<Property>.Filter.Eq("societyId", sId);
                var Property = Builders<Property>.Filter.Eq("propertyId", pId);                
                var combineFilters = Builders<Property>.Filter.And(society,Property);                                                
                var result  = collection.Find(Property).FirstOrDefaultAsync();
                            
                
        
            if(result !=null){    
                  prop = result.Result;    
                if(prop !=null) {
            if(prop.Commercial !=null) {
                    if(prop.Commercial.marriageHall != null){                        
                     //   if(prop.Commercial.shop.shopMenues[lastIndex].menueId != shop.shopMenues[shop.shopMenues.Count].menueId)
                        prop.Commercial.marriageHall = marriageHall;
                            await collection.ReplaceOneAsync(ZZ => ZZ.propertyId == pId && 
                            ZZ.societyId == sId, prop);
                            return true;
                        //}else{
                        //    return shop.shopMenues[shop.shopMenues.Count-1].menueId + " : menue id already exist";
                        //}
                    }else{
                        return  pId+ " is not a marriage hall"  ;
                    }
                        
                        }
                    else                                      
                         return pId+ " is not a commercial property";;
            }
        }else{
            return pId+ " is not a property :"  + "\n property: "+ prop;
        }
        }catch(Exception ex){
                return ex.Message;            
        }
        return false;
    }
    

            
    }
    
  
        
}

