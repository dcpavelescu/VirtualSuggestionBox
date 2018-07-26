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
        public static MemoryStorage<Suggestion> mem = new MemoryStorage<Suggestion>();
        SuggestionRepository repository = new SuggestionRepository(mem);

        [TestMethod]
        public void TestAdd()
        {

            Suggestion s1 = new Suggestion("improv1", "sol1");
            Suggestion s2 = new Suggestion("improv2", "sol2");
            Suggestion s3 = new Suggestion("improv3", "sol3");

            repository.Add(s1);
            repository.Add(s2);
            repository.Add(s3);

            Assert.AreEqual(repository.Count(), 3);
            repository.RemoveAll();
        }

        [TestMethod]
        public void TestDelete()
        {
            Suggestion s4 = new Suggestion("improv4", "sol4");
            repository.Add(s4);

            repository.Remove( s4.Id );

            Assert.AreEqual(repository.Count(), 0);
            repository.RemoveAll();
        }

        [TestMethod]
        public void TestGet()
        {
            Suggestion s5 = new Suggestion("improv5", "sol5");

            repository.Add(s5);

            Assert.AreEqual( repository.Get(s5.Id), s5);
            repository.RemoveAll();
        }

        [TestMethod]
        public void TestUpdate()
        {
            Suggestion s6 = new Suggestion("improv6", "sol6");
            repository.Add(s6);

            //s6.SetEmployeeId("idnou");

            repository.Update(s6);

            Assert.AreEqual(repository.Get(s6.Id), s6);
            repository.RemoveAll();
        }

        [TestMethod]
        public void TestAddRate()
        {
            Suggestion s7 = new Suggestion("improv7", "sol7");

            repository.Add(s7);

            Rate r1 = new Rate(5, "fed1");

            repository.AddRate(s7.Id, r1);
            Suggestion s = repository.Get(s7.Id);

           // Assert.AreEqual( s.GetRatings(), s7.GetRatings());

            repository.RemoveAll();
        }

        [TestMethod]
        public void TestGetAll()
        {
            //Suggestion with 2 args
            Suggestion s8 = new Suggestion("improv8", "sol8");
            Suggestion s9 = new Suggestion("improv9", "sol9");
            Suggestion s10 = new Suggestion("improv10", "sol10");
            Suggestion s11 = new Suggestion("improv11", "sol11");
            Suggestion s12 = new Suggestion("improv12", "sol12");
            Suggestion s13 = new Suggestion("improv13", "sol13");

            repository.Add(s8);
            repository.Add(s9);
            repository.Add(s10);
            repository.Add(s11);
            repository.Add(s12);
            repository.Add(s13);

            List<Suggestion> listResult = repository.GetAll().ToList();

            Assert.AreEqual(listResult.Count, repository.Count() );

            List<Suggestion> testList = new List<Suggestion> { s8, s9, s10, s11, s12, s13 };

            for ( var i = 0; i < listResult.Count; i++ )
            {
                Assert.AreEqual( testList[i], listResult[i] );
            }

            repository.RemoveAll();
            testList.Clear();
            listResult.Clear();
        }

        [TestMethod]
        public void TestViewByCategory()
        {/*
            Suggestion s14 = new Suggestion("improv14", "sol14", "emp14");
            s14.SetCategory( new List<String>() { "A", "B", "C", "D" } );
            repository.Add(s14);

            Suggestion s15 = new Suggestion("improv15", "sol15", "emp15");
            s15.SetCategory(new List<String>() { "A", "B", "C" });
            repository.Add(s15);

            Suggestion s16 = new Suggestion("improv16", "sol16", "emp16");
            s16.SetCategory(new List<String>() { "A", "B" });
            repository.Add(s16);

            Suggestion s17 = new Suggestion("improv17", "sol17", "emp17");
            s17.SetCategory(new List<String>() { "A" });
            repository.Add(s17);

            List<Suggestion> testList = repository.GetAll().ToList();
            List<Suggestion> listResult = repository.ViewByCategory( "A" );

            Assert.AreEqual( testList.Count, listResult.Count );

            for ( var i = 0; i < listResult.Count; i++ )
            {
                Assert.AreEqual( testList[i], listResult[i] );
            }

            repository.RemoveAll();
            listResult.Clear();
            testList.Clear();
            */
        }

        [TestMethod]
        public void TestViewByEmployee()
        {/*
            Suggestion s18 = new Suggestion("improv18", "sol18", "emp18");
            repository.Add(s18);

            Suggestion s19 = new Suggestion("improv19", "sol19", "emp18");
            repository.Add(s19);

            Suggestion s20 = new Suggestion("improv20", "sol20", "emp19");
            repository.Add(s20);

            Suggestion s21 = new Suggestion("improv21", "sol21", "emp19");
            repository.Add(s21);

            List<Suggestion> listResult = repository.ViewByEmployee( "emp18" );
            List<Suggestion> testList = repository.GetAll().ToList();

            Assert.AreEqual( listResult.Count, 2 );

            for ( var i = 0; i < listResult.Count; i++ )
            {
                Assert.AreEqual( testList[i], listResult[i] );       
            }

            repository.RemoveAll();
            listResult.Clear();
            testList.Clear();
            */
        }

        [TestMethod]
        public void TestViewTop3()
        {
            /*
            Suggestion s22 = new Suggestion("improv22", "sol22", "emp22");
            Suggestion s23 = new Suggestion("improv23", "sol23", "emp23");
            Suggestion s24 = new Suggestion("improv24", "sol24", "emp24");
            Suggestion s25 = new Suggestion("improv25", "sol25", "emp25");
            Suggestion s26 = new Suggestion("improv26", "sol26", "emp26");
            Suggestion s27 = new Suggestion("improv27", "sol27", "emp27");

            repository.Add(s22);
            repository.Add(s23);
            repository.Add(s24);
            repository.Add(s25);
            repository.Add(s26);
            repository.Add(s27);

            repository.AddRate(s22.Id, new Rate(5, "abc", "emp22"));
            repository.AddRate(s23.Id, new Rate(4, "abc", "emp23"));
            repository.AddRate(s24.Id, new Rate(3, "abc", "emp24"));
            repository.AddRate(s25.Id, new Rate(2, "abc", "emp25"));
            repository.AddRate(s26.Id, new Rate(1, "abc", "emp26"));
            repository.AddRate(s27.Id, new Rate(1, "abc", "emp27"));

            List<Suggestion> testList = repository.GetAll().ToList();
            List<Suggestion> listResult = repository.ViewTop3();

            Assert.AreEqual( listResult.Count, 3 );

            for ( var i = 0; i < listResult.Count; i++ )
            {
                Assert.AreEqual( testList[i], listResult[i] );
            }

            repository.RemoveAll();
            listResult.Clear();
            testList.Clear();
            */
        }

        [TestMethod]
        public void TestCount()
        {
            /*
            Suggestion s28 = new Suggestion("improv28", "sol28", "emp28");
            repository.Add(s28);

            Suggestion s29 = new Suggestion("improv29", "sol29", "emp29");
            repository.Add(s29);

            Suggestion s30 = new Suggestion("improv30", "sol30", "emp30");
            repository.Add(s30);

            List <Suggestion> listResult = repository.GetAll().ToList();

            Assert.AreEqual( listResult.Count, repository.Count() );

            repository.RemoveAll();
            listResult.Clear();
            */
        }

        [TestMethod]
        public void TestSearch()
        {
            Suggestion s31 = new Suggestion("improv1", "sol1");
            Suggestion s32 = new Suggestion("improv2", "sol2");
            Suggestion s33 = new Suggestion("improv3", "sol3");

            s31.boostRateForTesting(4);
            s32.boostRateForTesting(4);
            s33.boostRateForTesting(5);

            s31.Categories = new List<String> { "cat1", "cat2", "cat3" };
            s32.Categories = new List<String> { "cat1", "cat2", "cat3" };
            s33.Categories = new List<String> { "cat1", "cat2" };

            repository.Add(s31);
            repository.Add(s32);
            repository.Add(s33);


            List<Suggestion> testList = repository.Search(new List<String> { "cat1", "cat2", "cat3" }, 4 );

            Assert.AreEqual( 3, testList.Count() );

            List<Suggestion> list = new List<Suggestion> { s31, s32, s33 };

            for (var i = 0; i < list.Count(); i++)
            {
                Assert.AreEqual(testList[i], list[i]);
            }

            repository.RemoveAll();
            testList.Clear();
            list.Clear();

        }

    }
}
