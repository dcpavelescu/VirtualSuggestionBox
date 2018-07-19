using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualSuggestionBoxApi.Models;
using VirtualSuggestionBoxApi.Storages;

namespace VirtualSuggestionBoxApi.Repositories
{
    public class SuggestionMemoryRepository
    {
        public MemoryStorage<BaseEntity> memory;

        public SuggestionMemoryRepository(MemoryStorage<BaseEntity> suggestionMemory)
        {
            memory = suggestionMemory;
        }

        public void AddRate(String Id, Rate r)
        {
            Suggestion s = (Suggestion)memory.Get(Id);
            s.AddRate(r);
            s.SetAvgRate();
            memory.Update(s);
        }

        public List<Suggestion> ViewByEmployee(String EmployeeId)
        {
            return memory.GetAll().Select( x => (Suggestion)x ).Where( x => x.GetEmployeeId().Equals(EmployeeId) ).ToList();
        }

        public List<Suggestion> ViewTop3()
        {
            return memory.GetAll().Select( x => (Suggestion)x ).OrderByDescending( x => x.GetAvgRate() ).Take(3).ToList();
        }

        public List<Suggestion> ViewByCategory(String c)
        {
            return memory.GetAll().Select( x => (Suggestion)x ).Where( x => x.GetCategory().Contains(c) ).ToList();
        }

    }
}
    