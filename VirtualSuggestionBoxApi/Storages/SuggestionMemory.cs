using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualSuggestionBoxApi.Models;

namespace VirtualSuggestionBoxApi.Storages
{
    public class SuggestionMemory
    {
        //key: suggestionID , value: suggestion s 
        public Dictionary<String, Suggestion> dictionary = new Dictionary<String, Suggestion>();

        //generates an unique ID for Suggestion
        static object locker = new object();
        public void GenerateUniqueID(Suggestion s)
        {
            lock (locker)
            {
                //   Thread.Sleep(100);
                s.setID(MongoDB.Bson.ObjectId.GenerateNewId()); // ObjectId.Parse(DateTime.Now.ToString("yyyyMMddHHmmssf"));
                // this.EmployeeID = MongoDB.Bson.ObjectId.GenerateNewId();// ObjectId.Parse(DateTime.Now.ToString("yyyyMMddHHmmssf"));
            }
        }

        //add Suggestion s to memory
        public void Add(Suggestion s)
        {
            GenerateUniqueID(s);
            dictionary.Add(s.getID(), s);
        }

        //removes Suggestion by ID
        public void Remove(String ID)
        {
            dictionary.Remove(ID);
        }

        //returns a Suggestion searched by ID
        public Suggestion Get(String ID)
        {
            return dictionary[ID];
        }

        //updates a suggestion from memory
        public void Update(Suggestion s)
        {
            dictionary[s.getID()] = s;
        }

        //returns all the keys of the dictionary
        public List<String> GetAll()
        {
            return dictionary.Keys.ToList();
        }

    }
}
