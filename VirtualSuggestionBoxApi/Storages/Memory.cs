using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualSuggestionBoxApi.Models;

namespace VirtualSuggestionBoxApi.Storages
{
    public class Memory
    {
        //key: suggestionID , value: suggestion s 
        Dictionary<String, Suggestion> dictionary = new Dictionary<String, Suggestion>();


        //add Suggestion s to memory
        public void addSuggestion(Suggestion s)
        {
            dictionary.Add(s.getID(), s);
        }

        //removes Suggestion by ID
        public void removeSuggestion(String ID)
        {
            dictionary.Remove(ID);
        }

        //returns a Suggestion searched by ID
        public Suggestion getSuggestion(String ID)
        {
            Suggestion s;
            if (dictionary.TryGetValue(ID, out s))
                return s;
            else return null;
        }

        //adds rating r for a Suggestion ID, recalculates the averageRate
        public void addRate(String ID, Rate r)
        {
            Suggestion s = getSuggestion(ID);
            s.addRate(r);
            s.setAvgRate(s.averageRate());
        }

        //returns a key(ID) list of all suggestions
        public List<String> viewSuggestions()
        {
            List<String> list = new List<String>();
            list = dictionary.Keys.ToList();
            return list;
        }

        //returns a key(ID) list by Suggestion category
        public List<String> viewByCategory(String c)
        {
            List<String> list = new List<String>();
            foreach (KeyValuePair<String, Suggestion> entry in dictionary)
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
        public List<String> viewSuggestionsByEmployee(String EmployeeID)
        {
            List<String> list = new List<String>();
            foreach (KeyValuePair<String, Suggestion> entry in dictionary)
            {
                String ID = entry.Value.getEmployeeID();
                if (String.Compare(ID, EmployeeID) == 0)
                    list.Add(entry.Key);
            }
            return list;
        }

        public List<String> Top3()
        {
            List<String> list = new List<String>();
            double max1 = 0, max2 = 0, max3 = 0;
            string s1 = null, s2 = null, s3 = null;
            foreach (KeyValuePair<String, Suggestion> entry in dictionary)
            {
                double tmp = entry.Value.getAvgRate();
                if (tmp > max1)
                {
                    max1 = tmp;
                    s1 = entry.Value.getID();
                }
            }

            foreach (KeyValuePair<String, Suggestion> entry in dictionary)
            {
                double tmp = entry.Value.getAvgRate();
                if (tmp > max2 && tmp < max1)
                {
                    max2 = tmp;
                    s2 = entry.Value.getID();
                }
            }

            foreach (KeyValuePair<String, Suggestion> entry in dictionary)
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
