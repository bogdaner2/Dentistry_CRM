using System.Configuration;
using Dentistry_CRM.Properties;
using MongoDB.Driver;

namespace Dentistry_CRM.DAL
{
    public class MongoDataContext : IMongoDataContext
    {
        public IMongoDatabase MongoDatabase { get; }

        public MongoDataContext()
        {
            var client = new MongoClient(ConfigurationManager.ConnectionStrings["MongoDb"].ConnectionString);
            MongoDatabase = client.GetDatabase(ConfigurationManager.AppSettings["Database"]);
        }
    }
}
