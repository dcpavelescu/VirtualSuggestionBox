using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using VirtualSuggestionBoxApi.Storages;
using VirtualSuggestionBoxApi.Controllers;
using VirtualSuggestionBoxApi;
using VirtualSuggestionBoxApi.Repositories;
using VirtualSuggestionBoxApi.Models;
using System.Linq;

namespace VisualSuggestionBoxTest
{
    [TestClass]
    public class SuggestionMemoryTest
    {
        static MemoryStorage<IEntity> mem = new MemoryStorage<IEntity>();
        SuggestionMemoryRepository repository = new SuggestionMemoryRepository(mem);

        [TestMethod]
        public void TestAdd()
        {

            Suggestion s1 = new Suggestion("improv1", "sol1", "emp1");
            Suggestion s2 = new Suggestion("improv2", "sol2", "emp2");
            Suggestion s3 = new Suggestion("improv3", "sol3", "emp3");

            repository.memory.Add(s1);
            repository.memory.Add(s2);
            repository.memory.Add(s3);

            Assert.AreEqual(repository.memory.dictionary.Count(), 3);
            repository.memory.RemoveAll();
        }

        [TestMethod]
        public void TestDelete()
        {
            Suggestion s4 = new Suggestion("improv4", "sol4", "emp4");
            repository.memory.Add(s4);

            repository.memory.Remove(s4.Id);

            Assert.AreEqual(repository.memory.dictionary.Count(), 0);
            repository.memory.RemoveAll();
        }

        [TestMethod]
        public void TestGet()
        {
            Suggestion s5 = new Suggestion("improv5", "sol5", "emp5");

            repository.memory.Add(s5);

            Assert.AreEqual( repository.memory.Get(s5.Id), s5);
            repository.memory.RemoveAll();
        }

        [TestMethod]
        public void TestUpdate()
        {
            Suggestion s6 = new Suggestion("improv6", "sol6","emp6");
            repository.memory.Add(s6);

            s6.setEmployeeId("idnou");

            repository.memory.Update(s6);

            Assert.AreEqual(repository.memory.Get(s6.Id), s6);
            repository.memory.RemoveAll();
        }

        [TestMethod]
        public void TestAddRate()
        {
            Suggestion s7 = new Suggestion("improv7", "sol7", "emp7");

            repository.memory.Add(s7);

            Rate r1 = new Rate(5, "fed1", "emp1");

            repository.AddRate(s7.Id, r1);
            Suggestion s = (Suggestion)repository.memory.Get(s7.Id);
            Assert.AreEqual( s.getRatings(), s7.getRatings());
            repository.memory.RemoveAll();
        }

        [TestMethod]
        public void TestGetAll()
        {
            Suggestion s8 = new Suggestion("improv8", "sol8", "emp8");
            Suggestion s9 = new Suggestion("improv9", "sol9", "emp9");
            Suggestion s10 = new Suggestion("improv10", "sol10", "emp10");
            Suggestion s11 = new Suggestion("improv11", "sol11", "emp11");
            Suggestion s12 = new Suggestion("improv12", "sol12", "emp12");
            Suggestion s13 = new Suggestion("improv13", "sol13", "emp13");

            repository.memory.Add(s8);
            repository.memory.Add(s9);
            repository.memory.Add(s10);
            repository.memory.Add(s11);
            repository.memory.Add(s12);
            repository.memory.Add(s13);

            List<Suggestion> listId = repository.memory.GetAll().Cast<Suggestion>().ToList();

            Assert.AreEqual( listId.Count, repository.memory.dictionary.Keys.ToList().Count );
            repository.memory.RemoveAll();
        }
    }
}
