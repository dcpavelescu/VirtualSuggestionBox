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
        public MemoryStorage memory;

        public SuggestionMemoryRepository(MemoryStorage suggestionMemory)
        {
            memory = suggestionMemory;
        }

        public void AddRate(String Id, Rate r)
        {
            Suggestion s = (Suggestion)memory.Get(Id);
            s.addRate(r);
            s.setAvgRate();
            memory.Update(s);
        }

        public List<Suggestion> ViewByEmployee(String EmployeeId)
        {
            return memory.GetAll().Select(x =>(Suggestion)x).Where(x => x.Id.Equals(EmployeeId)).ToList();
        }

        public List<Suggestion> ViewTop3()
        {
            return memory.GetAll().Select(x => (Suggestion)x).OrderByDescending(x => x.getAvgRate()).Take(3).ToList();
        }


        public List<Suggestion> ViewByCategory(String c)
        {
            return memory.GetAll().Select(x => (Suggestion)x).Where(x => x.getCategory().Contains(c)).ToList();
        }
    }
}
    