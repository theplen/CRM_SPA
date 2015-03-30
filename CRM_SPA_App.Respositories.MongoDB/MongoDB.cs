using CRM_SPA_App.Entities;
using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

namespace CRM_SPA_App.Repositories.MongoDB
{
    public class MongoDB
    {      
        public MongoDatabase DB { get; private set; }

        public MongoDB()
        {

            var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            DB = server.GetDatabase("crm");
            
                      
        }

        public static void RegisterMappers(){
            if (!BsonClassMap.IsClassMapRegistered(typeof(Customer)))
            {
                BsonClassMap.RegisterClassMap<Customer>(cm =>
                {
                    cm.AutoMap();
                    cm.SetIgnoreExtraElements(true);
                    cm.IdMemberMap.SetRepresentation(BsonType.ObjectId);
                    cm.SetIdMember(cm.GetMemberMap(c => c.Id));
                    cm.MapIdField(c => c.Id).SetIdGenerator(new StringObjectIdGenerator());
                    cm.MapProperty(c => c.First_Name).SetElementName("first_name");
                    cm.MapProperty(c => c.Last_Name).SetElementName("last_name");
                    cm.MapProperty(c => c.Email).SetElementName("email");
                    cm.MapProperty(c => c.Country).SetElementName("country");
                    cm.MapProperty(c => c.Language).SetElementName("language");
                    cm.MapProperty(c => c.Person_Id).SetElementName("person_id");
                });
            }  
        }
    }

}
