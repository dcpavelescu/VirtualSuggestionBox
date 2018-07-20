using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualSuggestionBoxApi.Models;
using VirtualSuggestionBoxApi.Storages;

namespace VirtualSuggestionBoxApi.Repositories
{
    public class SuggestionRepository
    {
        private IStorage<Suggestion> suggestionStorage;

        public SuggestionRepository(IStorage<Suggestion> storage)
        {
            suggestionStorage = storage;
        }

        public void Add(Suggestion s)
        {
            suggestionStorage.Add(s);
        }

        public void Update(Suggestion s)
        {
            suggestionStorage.Update(s);
        }

        public void Remove(string Id)
        {
            suggestionStorage.Remove(Id);
        }

        public void RemoveAll()
        {
            suggestionStorage.RemoveAll();
        }

        public Suggestion Get(string Id)
        {
            return suggestionStorage.Get(Id);
        }

        public IEnumerable<Suggestion> GetAll()
        {
            return suggestionStorage.GetAll();
        }

        public long Count()
        {
            return suggestionStorage.Count();
        }

        public void AddRate(String Id, Rate r)
        {
            Suggestion s = suggestionStorage.Get(Id);
            s.AddRate(r);
            s.SetAvgRate();
            suggestionStorage.Update(s);
        }

        public List<Suggestion> ViewByEmployee(String EmployeeId)
        {
            return suggestionStorage.GetAll().Where( x => x.GetEmployeeId().Equals(EmployeeId) ).ToList();
        }

        public List<Suggestion> ViewTop3()
        {
            return suggestionStorage.GetAll().OrderByDescending( x => x.GetAvgRate() ).Take(3).ToList();
        }

        public List<Suggestion> ViewByCategory(String c)
        {
            return suggestionStorage.GetAll().Where( x => x.GetCategory().Contains(c) ).ToList();
        }

    }
}
    