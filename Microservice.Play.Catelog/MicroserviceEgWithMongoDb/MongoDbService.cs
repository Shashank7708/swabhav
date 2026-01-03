using MongoDB.Driver;

namespace MicroserviceEgWithMongoDb
{
    public class MongoDbService
    {
        private readonly IConfiguration _config;
        private readonly IMongoDatabase? database;
        public MongoDbService(IConfiguration configuration)
        {
            this._config = configuration;
            var connString = _config.GetConnectionString("DbConn");
            var mongUrl=MongoUrl.Create(connString);
            var mongoClient=new MongoClient(mongUrl);
            database = mongoClient.GetDatabase(mongUrl.DatabaseName); 
        }
    }
}
