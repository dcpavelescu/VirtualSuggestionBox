using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VirtualSuggestionBoxApi.Models;

namespace VirtualSuggestionBoxApi
{
    public interface IStorage<T>
    {
        /*
        void CreateStorage();
        void EnumElements();
        void OpenStorage();
        void Revert();
        void StatO();

        void Commit();

        void Update();
        void Remove();
        void Create();
        */
        T Create(T s);
        void Remove(ObjectId ID);
        T GetObject(ObjectId ID);
        void Update(ObjectId id, T a);
        IEnumerable<T> Get(); //<--GetAll()
        //void Add();

    }
}
