using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VirtualSuggestionBoxApi.Models;

namespace VirtualSuggestionBoxApi
{
    public interface IStorage<TEntity> where TEntity : IEntity
    {   
        void Add(TEntity e);
        void Update(TEntity e);
        void Remove(String Id);
        void RemoveAll();
        TEntity Get(String Id);
        IEnumerable<TEntity> GetAll();
        long Count();
    }
}
