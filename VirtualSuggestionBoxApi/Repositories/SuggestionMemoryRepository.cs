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
        public SuggestionMemory memory;

        public SuggestionMemoryRepository(SuggestionMemory suggestionMemory)
        {
            memory = suggestionMemory;
        }

        //adds rating r for a Suggestion ID, recalculates the averageRate
        public void AddRate(String ID, Rate r)
        {
            Suggestion s = memory.Get(ID);
            s.addRate(r);
            s.setAvgRate();
            memory.Update(s);
        }

        //returns a key(ID) list by Suggestion category
        public List<String> ViewByCategory(String c)
        {
            /* IN CAZUL IN CARE AVEM MAI MULTE CATEGORII PENTRU O SUGESTIE
             
         
            List<String> list = new List<String>();
            foreach (KeyValuePair<String, Suggestion> entry in memory.dictionary)
            {
                List<String> cat = entry.Value.getCategory();
                foreach (String i in cat)
                {
                    if (String.Compare(c, i) == 0)
                        list.Add(entry.Key);
                }
            }
            return list;

            */

            //CAZUL IN CARE AVEM O SINGURA CATEGORIE / SUGESTIE
            return (List<String>)memory.dictionary.Select( x => x.Value.getCategory()[1] ).Where( x => x.Equals(c) );

        }

        //returns a key(ID) list by employeeID- all suggestions posted by that employee
        public List<String> ViewByEmployee(ObjectId EmployeeID)
        {
            return (List<String>)memory.dictionary.Select(x => x.Value.getEmployeeID()).Where(x => x.Equals(EmployeeID));
            /*
            List<String> list = new List<String>();
            foreach (KeyValuePair<String, Suggestion> entry in memory.dictionary)
            {
                ObjectId ID = entry.Value.getEmployeeID();
                if (String.Compare(ID.ToString(), EmployeeID.ToString()) == 0)
                    list.Add(entry.Key);
            }
            return list;
            */
        }

        public List<String> ViewTop3()
        {
            // return (List<String>)memory.dictionary.OrderByDescending(x => x.Value.getAvgRate()).Select(x => x.Key).Take(3);
            return (List<String>)memory.dictionary.OrderByDescending(x => x.Value.getAvgRate()).Take(3);
        }
    }
}
    