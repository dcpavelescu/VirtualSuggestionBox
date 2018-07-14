using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using System;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace VirtualSuggestionBoxApi
{
        public class MongoContext
        {
            MongoClient _client;
            MongoServerAddress _server;
            public IMongoDatabase _database;
            public MongoContext()       
            {
     
                var MongoDatabaseName = "Account";
                var MongoUsername = "";
                var MongoPassword = "";
                var MongoPort = 27017;
                var MongoHost = "localhost";  

                var credential = MongoCredential.CreateMongoCRCredential
                                (MongoDatabaseName,
                                 MongoUsername,
                                 MongoPassword);

                var settings = new MongoClientSettings
                {
                    Credentials = new[] { credential },
                    Server = new MongoServerAddress(MongoHost, Convert.ToInt32(MongoPort))
                };
                _client = new MongoClient(settings);
              //  _server = _client.GetServer();
                _database = _client.GetDatabase(MongoDatabaseName);
            }
        }
}
