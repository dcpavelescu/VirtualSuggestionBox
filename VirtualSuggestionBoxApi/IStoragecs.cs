using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

    }
}
