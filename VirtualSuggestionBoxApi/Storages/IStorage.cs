using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VirtualSuggestionBoxApi.Models;

namespace VirtualSuggestionBoxApi
{
    public interface IStorage<Tentity>
    {   
        void Add(Tentity e);
        void Update(Tentity e);
        void Remove(String Id);
        void RemoveAll();
        Tentity Get(String Id);
        IEnumerable<Tentity> GetAll();
    }
}
