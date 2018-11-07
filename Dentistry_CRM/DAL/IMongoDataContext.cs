using MongoDB.Driver;

namespace Dentistry_CRM.DAL
{
    public interface IMongoDataContext
    {
        IMongoDatabase MongoDatabase { get; }
    }
}
