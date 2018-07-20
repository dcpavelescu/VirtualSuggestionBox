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
        public String Improvement;
        public String Solution;
        public String EmployeeId;
        public DateTime Date;
        public List<Rate> Ratings;
        public List<String> Category;
        private Double avgRate;

        public Suggestion(string improvement, string solution, String employeeId)
        {
            Ratings = new List<Rate>();
            Category = new List<String>();
            Improvement = improvement;
            Solution = solution;
            EmployeeId = employeeId;
            Date = DateTime.Now;
        }

       public double GetAvgRate()
        {
            return avgRate;
        }

        public void SetAvgRate()
        {
            double media = Ratings.Select( x => x.GetScore() ).Sum();
            avgRate = media / Ratings.Count();
        }

    }
}
