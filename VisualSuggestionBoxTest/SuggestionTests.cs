using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using VirtualSuggestionBoxApi.Storages;
using VirtualSuggestionBoxApi.Controllers;
using MongoDB.Bson;
using VirtualSuggestionBoxApi;

namespace VisualSuggestionBoxTest
{
    [TestClass]
    public class SuggestionTests
    {
        public SuggestionTests()
        {
            

        }

        [TestMethod]
        public void TestSuggestionSaveInMemory()
        {
            /* nu exista SuggestionInMemory
            SuggestionInMemory suggestionInMemory = new SuggestionInMemory();
            suggestionInMemory.dictionary.Add("id1", new VirtualSuggestionBoxApi.Models.Suggestion("dasdsad", "dssdsa", "employee1"));
            suggestionInMemory.dictionary.Add("id2", new VirtualSuggestionBoxApi.Models.Suggestion("ggdgd", "fgfd", "employee1"));
            suggestionInMemory.dictionary.Add("id3", new VirtualSuggestionBoxApi.Models.Suggestion("gfdgd", "gfgd", "employee1"));

            Assert.AreEqual(suggestionInMemory.dictionary.Count, 3);
            */
            //  AccountController a1 = new AccountController();
            //  System.Diagnostics.Debug.WriteLine(a1.Get(ObjectId.Parse("5b4a61e8c55178134c79a7c5")));
            var _db = new MongoDBStorage();
            Assert.IsNotNull(_db.GetAccounts());
            System.Diagnostics.Debug.WriteLine(_db.GetAccounts());
        }

    }
}
