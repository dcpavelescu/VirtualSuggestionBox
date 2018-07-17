using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualSuggestionBoxApi.Models;

namespace VirtualSuggestionBoxApi
{
    interface IStorage
    {
        void CreateStorage();
        void EnumElements();
        void OpenStorage();
        void Revert();
        void StatO();

        void Commit();

        void Update();
        void Remove();
        void Create();

        void Add(Suggestion s);
        void Remove(String ID);
        Suggestion Get(String ID);
        void Update(Suggestion s);
        List<String> GetAll();

    }
}
