using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using System;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;
using VirtualSuggestionBoxApi.Models;
using MongoDB.Bson;
using Microsoft.EntityFrameworkCore;
using System.Security.Authentication;

namespace VirtualSuggestionBoxApi
{
        public class MongoDBStorage<T> : IStorage<T> where T: TmodelInterface
    {
            MongoClient _client;
            MongoServerAddress _server;
            IMongoDatabase _db;
            IMongoDatabase _dbS;

        public IMongoDatabase _database;
        public MongoDBStorage()
        {

            var MongoDatabaseName = "Account";//Configuration["MongoDBOption:Database"];
            var MongoDatabaseNameSuggestion = "Suggestion";
            var MongoUsername = "";
            var MongoPassword = "";
            var MongoPort = 27017;
            var MongoHost = "localhost";

            var credential = MongoCredential.CreateMongoCRCredential
                            (MongoDatabaseName,
                             MongoUsername,
                             MongoPassword);

           // var settings = new MongoClientSettings
         //   {
          //      Credentials = new[] { credential },
         //       Server = new MongoServerAddress(MongoHost, Convert.ToInt32(MongoPort))
        //    };
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb://localhost:27017/Account"));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            _client = new MongoClient(settings);
            //  _server = _client.GetServer();
            _db = _client.GetDatabase(MongoDatabaseName); //_client
            _db.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait();
            _dbS = _client.GetDatabase(MongoDatabaseNameSuggestion);
        }
        public MongoDBStorage(MongoClient client)       
            {

                var MongoDatabaseName = "Account";//Configuration["MongoDBOption:Database"];
                var MongoDatabaseNameSuggestion = "Suggestion";
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
                _db = client.GetDatabase(MongoDatabaseName); //_client
                _dbS = client.GetDatabase(MongoDatabaseNameSuggestion);
        }

        public IEnumerable<T> Get()
        {
            return _db.GetCollection<T>(typeof(T).Name).Find(_ => true).ToList();
        }
        public T GetObject(ObjectId id)
        {
         //   var res = DbQuery<Account>.Eq(a => a.Id, id);

            var res = Builders<T>.Filter.Eq(a => a.Id, id);
   
            return _db.GetCollection<T>(typeof(T).Name).Find(res).SingleOrDefault();
        }

        public T Create(T a)
        {
            _db.GetCollection<T>(typeof(T).Name).InsertOne(a);
            return a;
        }

        public void Update(ObjectId id, T a)
        {
            a.Id = id;
            var res = Builders<T>.Filter.Eq(ac => ac.Id, id);
          //  var update = Builders<BsonDocument>.Update();
            //var operation = Update<Account>.Replace(a);
            _db.GetCollection<T>(typeof(T).Name).ReplaceOneAsync(res, a);
        }
        public void Remove(ObjectId id)
        {
            var res = Builders<T>.Filter.Eq(ac => ac.Id, id);
            var operation = _db.GetCollection<T>(typeof(T).Name).FindOneAndDeleteAsync(res);
        }
        /*
        public IEnumerable<Suggestion> GetSuggestions()
        {
            return _dbS.GetCollection<Suggestion>("Suggestion").Find(_ => true).ToList();
        }
        public Suggestion GetSuggestion(ObjectId id)
        {
            //   var res = DbQuery<Account>.Eq(a => a.Id, id);

            var res = Builders<Suggestion>.Filter.Eq(a => a.SuggestionID, id);

            return _dbS.GetCollection<Suggestion>("Suggestion").Find(res).SingleOrDefault();
        }

        public Suggestion CreateSuggestion(Suggestion a)
        {
            _dbS.GetCollection<Suggestion>("Suggestion").InsertOne(a);
            return a;
        }

        public void UpdateSuggestion(ObjectId id, Suggestion a)
        {
            a.SuggestionID = id;
            var res = Builders<Suggestion>.Filter.Eq(ac => ac.SuggestionID, id);
            //  var update = Builders<BsonDocument>.Update();
            //var operation = Update<Account>.Replace(a);
            _dbS.GetCollection<Suggestion>("Suggestion").ReplaceOneAsync(res, a);
        }
        public void RemoveSuggestion(ObjectId id)
        {
            var res = Builders<Suggestion>.Filter.Eq(ac => ac.SuggestionID, id);
            var operation = _dbS.GetCollection<Suggestion>("Suggestion").FindOneAndDeleteAsync(res);
        }
        */

    }
}
