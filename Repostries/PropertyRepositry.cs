using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Threading.Tasks;
using smartLiving.Models;
using smartLiving.MongoDb;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace smartLiving.Repostries
{
    public class PropertyRepositry
    {
        private MongoDbContext dbContext = null;
        public PropertyRepositry(IConfiguration config)
        {

            dbContext = MongoDbContext.getMongoDbContext(config);//geting singletone object of database
            collection = dbContext.getDataBase().GetCollection<Property>("Property");//use singletone object to get database 
            //and call that database to get collection of Property
        }
        private readonly IMongoCollection<Property> collection;

        public async Task<object> retriveAllData()
        {
            return await collection.Find(x => true).ToListAsync();
        }
        

        //not defined yet because we will not delete in server we only disable particular account
        public async Task<object> delete(string id)
        {

            var byPId = Builders<Property>.Filter.Eq("propertyId", id);            
             return await collection.DeleteOneAsync(byPId);  
        }

        public async Task<string> insert(Property[] properties)
        {
            
            
            
            try{
            await collection.InsertManyAsync(properties);
            return "true";
            }
            catch(MongoException ex){
            return ex.Message;

            }
            

        }
public async Task<Object> retrievePropertyBySidPid(string sId,string pId)

        {
            var bySId = Builders<Property>.Filter.Eq("societyId", sId);
            var byPId = Builders<Property>.Filter.Eq("propertyId", pId);
            var combineFilters = Builders<Property>.Filter.And(bySId, byPId);
            var result = await collection.Find(combineFilters).FirstOrDefaultAsync();            
            return result;

        }
        public async Task<Shop> retrieveShop(string sId,string pId)

        {
            var Property = Builders<Property>.Filter.Eq("propertyId", pId);
            var society = Builders<Property>.Filter.Eq("societyId", sId);
            var combineFilters = Builders<Property>.Filter.And(society,Property);            
            var itemsTask =collection.Find(Property).FirstOrDefaultAsync()  ;            

            if(itemsTask !=null){    
            Property prop  = itemsTask.Result;    
            if(prop!=null){
            if(prop.Commercial !=null)        {
            Shop shopData = prop.Commercial.shop;            
            return shopData;}
            }
            return null;
            }
            return null;
        }
 public async Task<Property> retrieveGraveyard(string sId)

        {
            
            var society = Builders<Property>.Filter.Eq("societyId", sId);
            var Property = Builders<Property>.Filter.Eq("PropertyType", "Graveyard");
            var combineFilters = Builders<Property>.Filter.And(society,Property);            
            var itemsTask =collection.Find(Property).FirstOrDefaultAsync()  ;            
                Property graveYard = itemsTask.Result;
                return graveYard;
            
        }
        public async Task<Object> retrieveAll(string societyId)
        {
            var Property = Builders<Property>.Filter.Eq("societyId", societyId);
            return await collection.Find(Property).ToListAsync();

            
        }
        public async Task<object> updateProperty(Property prop)
        {
            try{
                await collection.ReplaceOneAsync(ZZ => ZZ.propertyId == prop.propertyId && 
            ZZ.societyId == prop.societyId, prop);
            return true;
            }catch(Exception ex){
                 return ex.Message;   
            }
        }
         public async Task<object> updateShopMenue(string societyId,string pId,Shop shop)
        {
            try{
                 
                

            return true;
            }catch(Exception ex){
                 return ex.Message;   
            }
        }
        public async Task<Object> updateShop(string sId,string pId,Shop shop)
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
                    if(prop.Commercial.shop != null){
                        int lastIndex = prop.Commercial.shop.shopMenues.Count;
                     //   if(prop.Commercial.shop.shopMenues[lastIndex].menueId != shop.shopMenues[shop.shopMenues.Count].menueId)
                        prop.Commercial.shop = shop;
                            await collection.ReplaceOneAsync(ZZ => ZZ.propertyId == pId && 
                            ZZ.societyId == sId, prop);
                            return true;
                        //}else{
                        //    return shop.shopMenues[shop.shopMenues.Count-1].menueId + " : menue id already exist";
                        //}
                    }else{
                        return  pId+ " is not a shop"  ;
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