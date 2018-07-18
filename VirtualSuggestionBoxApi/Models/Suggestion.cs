using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VirtualSuggestionBoxApi.Models
{
    public class Suggestion : Tentity
    {
        private String id;
        public String Id { get { return id; } set { id = value; } }
        private String Improvement;
        private String Solution;
        private String EmployeeId;
        private DateTime Date;
        private List<Rate> Ratings;
        private List<String> Category;
        private Double avgRate;


        public Suggestion(string Improvement, string Solution, String EmployeeId)
        {
            Ratings = new List<Rate>();
            Category = new List<String>();
            this.Improvement = Improvement;
            this.Solution = Solution;
            this.EmployeeId = EmployeeId;
            Date = DateTime.Now;
        }

        public String getEmployeeId()
        {
            return this.EmployeeId;
        }

        public void setEmployeeId(String EmployeeId)
        {
            this.EmployeeId = Id;
        }

       public double getAvgRate()
        {
            return avgRate;
        }

        public void setAvgRate()
        {
            double media = Ratings.Select(x => x.getScore()).Sum();
            this.avgRate = media / Ratings.Count();
        }

        public void addRate(Rate rate)
        {
            this.Ratings.Add(rate);
        }

        public List<String> getCategory()
        {
            return this.Category;
        }

        public List<Rate> getRatings()
        {
            return this.Ratings;
        }
    }
}
