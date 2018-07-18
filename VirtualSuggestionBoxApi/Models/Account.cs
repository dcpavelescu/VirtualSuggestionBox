using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualSuggestionBoxApi.Models
{/*
    class Program
    {
        private MongoDatabaseBase db;
        public AccountContext()
        {
            MongoClient client = new MongoClient();
            this.db = client.GetDatabase("Account");
            var collection = db.GetCollection<Account>("Account");
            Account account = new Account();

            collection.save(account);
        }
    }
    */
    public class Account :IEntity
    {
        public String Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        private string email { get; set; }
        private string rDate { get; set; }
        private string accessLevel { get; set; }
        private string firstName { get; set; }
        private string secondName { get; set; }

        [BsonExtraElements]
        public BsonDocument CatchAll { get; set; }
    }
}
