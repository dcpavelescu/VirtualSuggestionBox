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
        public SuggestionMemory memory = new SuggestionMemory();

        //adds rating r for a Suggestion ID, recalculates the averageRate
        public void AddRate(String ID, Rate r)
        {
            Suggestion s = memory.Get(ID);
            s.addRate(r);
            s.setAvgRate();
            memory.Update(s);
        }

        //returns a key(ID) list of all suggestions
        public List<String> ViewAll()
        {
            List<String> list = new List<String>();
            list = memory.dictionary.Keys.ToList();
            return list;
        }

        //returns a key(ID) list by Suggestion category
        public List<String> ViewByCategory(String c)
        {
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
        }

        //returns a key(ID) list by employeeID- all suggestions posted by that employee
        public List<String> ViewByEmployee(ObjectId EmployeeID)
        {
            List<String> list = new List<String>();
            foreach (KeyValuePair<String, Suggestion> entry in memory.dictionary)
            {
                ObjectId ID = entry.Value.getEmployeeID();
                if (String.Compare(ID.ToString(), EmployeeID.ToString()) == 0)
                    list.Add(entry.Key);
            }
            return list;
        }

        public List<String> ViewTop3()
        {
            List<String> list = new List<String>();
            double max1 = 0, max2 = 0, max3 = 0;
            string s1 = null, s2 = null, s3 = null;
            foreach (KeyValuePair<String, Suggestion> entry in memory.dictionary)
            {
                double tmp = entry.Value.getAvgRate();
                if (tmp > max1)
                {
                    max1 = tmp;
                    s1 = entry.Value.getID();
                }
            }

            foreach (KeyValuePair<String, Suggestion> entry in memory.dictionary)
            {
                double tmp = entry.Value.getAvgRate();
                if (tmp > max2 && tmp < max1)
                {
                    max2 = tmp;
                    s2 = entry.Value.getID();
                }
            }

            foreach (KeyValuePair<String, Suggestion> entry in memory.dictionary)
            {
                double tmp = entry.Value.getAvgRate();
                if (tmp > max3 && tmp < max2)
                {
                    max3 = tmp;
                    s3 = entry.Value.getID();
                }
            }
            list.Add(s1);
            list.Add(s2);
            list.Add(s3);
            return list;
        }


    }
}
