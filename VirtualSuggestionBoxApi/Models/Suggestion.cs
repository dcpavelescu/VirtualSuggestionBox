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
    public class Suggestion : BaseEntity
    {
        public String Subject;
        public String Improvement;
        public String Solution;
        public DateTime Date;
        public List<Rate> Ratings;
        public List<String> Category;
        private Double avgRate;

        public Suggestion(string improvement, string solution)
        {
            Ratings = new List<Rate>();
            Category = new List<String>();
            Improvement = improvement;
            Solution = solution;
            Date = DateTime.Now;
        }

       public double GetAvgRate()
        {
            return avgRate;
        }

        public void SetAvgRate()
        {
            double media = Ratings.Select( x => x.Score).Sum();
            avgRate = media / Ratings.Count();
        }
        public void boostRateForTesting(int n)
        {
            avgRate = n;
        }

    }
}
