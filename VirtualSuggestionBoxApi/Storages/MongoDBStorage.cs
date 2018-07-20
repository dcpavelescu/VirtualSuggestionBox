using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;
using VirtualSuggestionBoxApi.Models;
using MongoDB.Bson;
using Microsoft.EntityFrameworkCore;
using System.Security.Authentication;

namespace VirtualSuggestionBoxApi
{
    public class MongoDBStorage<TEntity> : IStorage<TEntity> where TEntity : BaseEntity
    {
        public MongoClient _client;
        public MongoServerAddress _server;
        public IMongoDatabase _db;
        public IMongoDatabase _dbS;
        public IMongoDatabase _database;

        public MongoDBStorage()
        {
            var MongoDatabaseName = "Account";
            var MongoDatabaseNameSuggestion = "Suggestion";
            var MongoUsername = "";
            var MongoPassword = "";

            var credential = MongoCredential.CreateMongoCRCredential
                            (MongoDatabaseName,
                             MongoUsername,
                             MongoPassword);

            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb://localhost:27017/Account"));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            _client = new MongoClient(settings);
            
            _db = _client.GetDatabase(MongoDatabaseName); //_client
            _db.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait();
            _dbS = _client.GetDatabase(MongoDatabaseNameSuggestion);
        }

        public MongoDBStorage(MongoClient client)       
            {
                var MongoDatabaseName = "Account";
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
                    Credential = credential,
                    Server = new MongoServerAddress(MongoHost, Convert.ToInt32(MongoPort))
                };

                _client = new MongoClient(settings);
              
                _db = client.GetDatabase(MongoDatabaseName); //_client
                _dbS = client.GetDatabase(MongoDatabaseNameSuggestion);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _db.GetCollection<TEntity>(typeof(TEntity).Name).Find(_ => true).ToList();
        }

        public TEntity Get(String id)
        {
            var res = Builders<TEntity>.Filter.Eq( a => a.Id, id);
            return _db.GetCollection<TEntity>(typeof(TEntity).Name).Find(res).SingleOrDefault();
        }

        public void Add(TEntity a)
        {
            _db.GetCollection<TEntity>(typeof(TEntity).Name).InsertOne(a);
        }

        public void Update(TEntity a)
        {
            var res = Builders<TEntity>.Filter.Eq(ac => ac.Id, a.Id);
            _db.GetCollection<TEntity>(typeof(TEntity).Name).ReplaceOneAsync(res, a);
        }

        public void Remove(String id)
        {
            var res = Builders<TEntity>.Filter.Eq(ac => ac.Id, id);
            var operation = _db.GetCollection<TEntity>(typeof(TEntity).Name).FindOneAndDeleteAsync(res);
        }

        public void RemoveAll()
        {
            var operation = _db.GetCollection<TEntity>(typeof(TEntity).Name).FindOneAndDelete(_ => true);
        }

        public long Count()
        {
            return _db.GetCollection<TEntity>(typeof(TEntity).Name).Count(_ => true);
        }

    }
}