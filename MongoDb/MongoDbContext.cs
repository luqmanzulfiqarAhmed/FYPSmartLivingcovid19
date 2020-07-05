using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace smartLiving.MongoDb
{
    public class MongoDbContext
    {

        private IMongoDatabase database = null;
        private static MongoDbContext mongoDb = null;
        private MongoDbContext(IConfiguration config)
        {

            // var client = new MongoClient("mongodb://localhost:27017");
            // database = client.GetDatabase("HousingSocietyAppBuilder");

            string connectionString =
  @"mongodb://mongodbfyp:hSWkjL1hjX944DCjfkwEMzHA4JRvGAAUOt8ZiRu1CVqyRMAQ8bs9LkVaOAe4xTtN0WM5tOf7Va3N13vRCdKU9g==@mongodbfyp.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";
            MongoClientSettings settings = MongoClientSettings.FromUrl(

              new MongoUrl(connectionString)
            );
            settings.SslSettings =
              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings);
            database = mongoClient.GetDatabase("HousingSocietyAppBuilder");

        }
        public static MongoDbContext getMongoDbContext(IConfiguration config)
        {

            if (mongoDb == null)
            {
                mongoDb = new MongoDbContext(config);
            }
            return mongoDb;
        }
        public IMongoDatabase getDataBase()
        {
            return database;
        }


    }
}
