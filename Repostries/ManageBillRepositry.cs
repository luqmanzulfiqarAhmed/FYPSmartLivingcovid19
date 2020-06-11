
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using smartLiving.Models;
using smartLiving.MongoDb;

namespace smartLiving.Repostries
{
    public class ManageBillRepositry 
    {

            private MongoDbContext dbContext = null;
        
        public ManageBillRepositry(IConfiguration config)
        {


        dbContext = MongoDbContext.getMongoDbContext(config);
            manageBill = dbContext.getDataBase().GetCollection<ManageBill>("ManageBills");
        }


        private readonly IMongoCollection<ManageBill> manageBill;
        public async Task<object> delete(string id)
        {

            return true;
        }

        public async Task<string> insert(object admin)
        {
            try{
            await manageBill.InsertOneAsync((ManageBill)admin);
            return "true";
            }catch(Exception ex){
                    string ax = ex.Message;
                return ax;
            }
        }

        public async Task<object> retrieveById(string id)
        {
            var admin = Builders<ManageBill>.Filter.Eq("billId", id);

            return await manageBill.Find(admin).ToListAsync();
        }
public async Task<object> retrieveBySidPidEmail(string sId,string pId,string email)
        {
            var bySId = Builders<ManageBill>.Filter.Eq("societyId", sId);
            var byPId = Builders<ManageBill>.Filter.Eq("propertyId", pId);
            var byEmail = Builders<ManageBill>.Filter.Eq("residentEmail", email);
            var combineFilters = Builders<ManageBill>.Filter.And(bySId,byPId,byEmail);
            return await manageBill.Find(combineFilters).ToListAsync();
        }
        public async Task<object> retrieveAll(string societyId)
        {
            var admin = Builders<ManageBill>.Filter.Eq("societyId", societyId);
            return await manageBill.Find(admin).ToListAsync();
        }

        public async Task<object> update(string id, object admin)
        {
            await manageBill.ReplaceOneAsync(ZZ => ZZ.billId == id, (ManageBill)admin);
            return true;
        }
    }

}
