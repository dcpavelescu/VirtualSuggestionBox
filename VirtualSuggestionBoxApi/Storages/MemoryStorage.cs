using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualSuggestionBoxApi.Models;

namespace VirtualSuggestionBoxApi.Storages
{
    public class MemoryStorage : IStorage<Tentity>
    { 
        public Dictionary<String, Tentity> dictionary = new Dictionary<String, Tentity>();

        public void GenerateUniqueID(Tentity e)
        {
            e.Id = e.GetHashCode().ToString();  
        }
       
        public void Add(Tentity e)
        {
            GenerateUniqueID(e);
            dictionary.Add(e.Id, e);
        }

        public void Update(Tentity e)
        {
            dictionary[e.Id] = e;
        }

        public void Remove(string Id)
        {
            dictionary.Remove(Id);
        }

        public void RemoveAll()
        {
            dictionary.Clear();
        }

        public Tentity Get(string Id)
        {
            return dictionary[Id];
        }

        public IEnumerable<Tentity> GetAll()
        {
            return dictionary.Values;
        }
    }
}
