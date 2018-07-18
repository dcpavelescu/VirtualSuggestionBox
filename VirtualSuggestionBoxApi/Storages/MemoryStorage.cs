using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualSuggestionBoxApi.Models;

namespace VirtualSuggestionBoxApi.Storages
{
    public class MemoryStorage<TEntity> : IStorage<TEntity> where TEntity : IEntity
    { 
        public Dictionary<String, TEntity> dictionary = new Dictionary<String, TEntity>();

        public void GenerateUniqueID(TEntity e)
        {
            e.Id = e.GetHashCode().ToString();  
        }
       
        public void Add(TEntity e)
        {
            GenerateUniqueID(e);
            dictionary.Add(e.Id, e);
        }

        public void Update(TEntity e)
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

        public TEntity Get(string Id)
        {
            return dictionary[Id];
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dictionary.Values;
        }
    }
}
