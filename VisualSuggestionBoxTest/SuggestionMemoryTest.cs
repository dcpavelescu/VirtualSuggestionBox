using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using VirtualSuggestionBoxApi.Storages;
using VirtualSuggestionBoxApi.Controllers;
using MongoDB.Bson;
using VirtualSuggestionBoxApi;
using VirtualSuggestionBoxApi.Repositories;
using VirtualSuggestionBoxApi.Models;
using System.Linq;

namespace VisualSuggestionBoxTest
{
    [TestClass]
    public class SuggestionMemoryTest
    {
        static SuggestionMemory mem = new SuggestionMemory();
        SuggestionMemoryRepository repository = new SuggestionMemoryRepository(mem);

        [TestMethod]
        public void TestAdd()
        {

            Suggestion s1 = new Suggestion("improv1", "sol1", MongoDB.Bson.ObjectId.GenerateNewId());
            Suggestion s2 = new Suggestion("improv2", "sol2", MongoDB.Bson.ObjectId.GenerateNewId());
            Suggestion s3 = new Suggestion("improv3", "sol3", MongoDB.Bson.ObjectId.GenerateNewId());

            repository.memory.Add(s1);
            repository.memory.Add(s2);
            repository.memory.Add(s3);

            Assert.AreEqual(repository.memory.dictionary.Count(), 3);

        }

        [TestMethod]
        public void TestDelete()
        {
            Suggestion s4 = new Suggestion("improv4", "sol4", MongoDB.Bson.ObjectId.GenerateNewId() );

            repository.memory.Add(s4);

            repository.memory.Remove(s4.getID());

            Assert.AreEqual(repository.memory.dictionary.Count(), 3);

        }

        [TestMethod]
        public void TestGet()
        {
            Suggestion s5 = new Suggestion("improv5", "sol5", MongoDB.Bson.ObjectId.GenerateNewId());

            repository.memory.Add(s5);

            Assert.AreEqual( repository.memory.Get(s5.getID()), s5);

        }

        [TestMethod]
        public void TestUpdate()
        {
            Suggestion s6 = new Suggestion("improv6", "sol6", MongoDB.Bson.ObjectId.GenerateNewId());
            repository.memory.Add(s6);

            s6.setEmployeeId( new ObjectId("507f1f77bcf86cd799439011") );

            repository.memory.Update(s6);

            Assert.AreEqual(repository.memory.Get(s6.getID()), s6);

        }

        [TestMethod]
        public void TestAddRate()
        {
            Suggestion s7 = new Suggestion("improv7", "sol7", MongoDB.Bson.ObjectId.GenerateNewId());

            repository.memory.Add(s7);

            Rate r1 = new Rate(5, "fed1", "emp1");

            repository.AddRate(s7.getID(), r1);

            Assert.AreEqual( repository.memory.Get(s7.getID()).getRateList(), s7.getRateList() );
        }

        [TestMethod]
        public void TestGetAll()
        {
            Suggestion s8 = new Suggestion("improv8", "sol8", MongoDB.Bson.ObjectId.GenerateNewId());
            Suggestion s9 = new Suggestion("improv9", "sol9", MongoDB.Bson.ObjectId.GenerateNewId());
            Suggestion s10 = new Suggestion("improv10", "sol10", MongoDB.Bson.ObjectId.GenerateNewId());
            Suggestion s11 = new Suggestion("improv11", "sol11", MongoDB.Bson.ObjectId.GenerateNewId());
            Suggestion s12 = new Suggestion("improv12", "sol12", MongoDB.Bson.ObjectId.GenerateNewId());
            Suggestion s13 = new Suggestion("improv13", "sol13", MongoDB.Bson.ObjectId.GenerateNewId());

            repository.memory.Add(s8);
            repository.memory.Add(s9);
            repository.memory.Add(s10);
            repository.memory.Add(s11);
            repository.memory.Add(s12);
            repository.memory.Add(s13);


            List<String> listId = repository.memory.GetAll();

            Assert.AreEqual( listId.Count, repository.memory.dictionary.Keys.ToList().Count );

            for(var i = 0; i < listId.Count; i++)
            {
                Assert.AreEqual( listId[i], repository.memory.dictionary.Keys.ToList()[i] );
            }
        }

        /*
        [TestMethod]
        public void TestSuggestionSaveInMemory()
        {
             nu exista SuggestionInMemory
            SuggestionInMemory suggestionInMemory = new SuggestionInMemory();
            suggestionInMemory.dictionary.Add("id1", new VirtualSuggestionBoxApi.Models.Suggestion("dasdsad", "dssdsa", "employee1"));
            suggestionInMemory.dictionary.Add("id2", new VirtualSuggestionBoxApi.Models.Suggestion("ggdgd", "fgfd", "employee1"));
            suggestionInMemory.dictionary.Add("id3", new VirtualSuggestionBoxApi.Models.Suggestion("gfdgd", "gfgd", "employee1"));

            Assert.AreEqual(suggestionInMemory.dictionary.Count, 3);
            

              AccountController a1 = new AccountController();
              System.Diagnostics.Debug.WriteLine(a1.Get(ObjectId.Parse("5b4a61e8c55178134c79a7c5")));
            var _db = new MongoDBStorage();
            Assert.IsNotNull(_db.GetAccounts());
            System.Diagnostics.Debug.WriteLine(_db.GetAccounts());
        }
        */
    }
}
