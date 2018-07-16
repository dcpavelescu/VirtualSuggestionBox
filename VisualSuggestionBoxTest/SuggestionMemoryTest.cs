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

        SuggestionMemoryRepository repository = new SuggestionMemoryRepository();

        [TestMethod]
        public void TestAdd()
        {
            Suggestion s1 = new Suggestion("improv1", "sol1", "1");
            Suggestion s2 = new Suggestion("improv2", "sol2", "2");
            Suggestion s3 = new Suggestion("improv3", "sol3", "3");

            repository.memory.Add(s1);
            repository.memory.Add(s2);
            repository.memory.Add(s3);

            Assert.AreEqual(repository.memory.dictionary.Count(), 3);

        }

        [TestMethod]
        public void TestDelete()
        {
            Suggestion s4 = new Suggestion("improv4", "sol4", "4");
            repository.memory.Add(s4);

            repository.memory.Remove(s4.getID());

            Assert.AreEqual(repository.memory.dictionary.Count(), 3);

        }

        [TestMethod]
        public void TestGet()
        {
            Suggestion s5 = new Suggestion("improv5", "sol5", "5");
            repository.memory.Add(s5);

            Assert.AreEqual( repository.memory.Get(s5.getID()), s5);

        }

        [TestMethod]
        public void TestUpdate()
        {
            Suggestion s6 = new Suggestion("improv6", "sol6", "6");
            repository.memory.Add(s6);

            s6.setEmployeeId("666");

            repository.memory.Update(s6);

            Assert.AreEqual(repository.memory.Get(s6.getID()), s6);

        }

        [TestMethod]
        public void TestAddRate()
        {
            Suggestion s7 = new Suggestion("improv7", "sol7", "7");
            repository.memory.Add(s7);

            Rate r1 = new Rate(5, "fed1", "emp1");

            repository.AddRate(s7.getID(), r1);

            Assert.AreEqual( repository.memory.Get(s7.getID()).getRateList(), s7.getRateList() );
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
