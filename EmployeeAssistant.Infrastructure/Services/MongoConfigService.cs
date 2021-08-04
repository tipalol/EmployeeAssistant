using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace EmployeeAssistant.Infrastructure.Services
{
    public class MongoConfigService
    {
        public static void AddImplementation<T1, T2>() where T2 : class, T1, new()
        {
            BsonSerializer.RegisterSerializer<T1>(new ImpliedImplementationInterfaceSerializer<T1,T2>(BsonSerializer.LookupSerializer<T2>()));
        }
    }
}