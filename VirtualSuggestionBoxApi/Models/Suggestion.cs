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
    public class Suggestion : IEntity
    {
        private String id; // ce este acesta?

        public String Id { get { return id; } set { id = value; } }
       
        private String improvement;
        private String solution;
        private String employeeId;
        private DateTime date;
        private List<Rate> ratings;
        private List<String> category;
        private Double avgRate;

        public Suggestion(string improvement, string solution, String employeeId)
        {
            ratings = new List<Rate>();
            category = new List<String>();
            this.improvement = improvement;
            this.solution = solution;
            this.employeeId = employeeId;
            date = DateTime.Now;
        }

        public String GetEmployeeId()
        {
            return employeeId;
        }

        public void SetEmployeeId(String employeeId)
        {
            this.employeeId = employeeId;
        }

       public double GetAvgRate()
        {
            return avgRate;
        }

        public void SetAvgRate()
        {
            double media = ratings.Select( x => x.GetScore() ).Sum();
            avgRate = media / ratings.Count();
        }

        public void AddRate(Rate rate)
        {
            ratings.Add(rate);
        }

        public List<String> GetCategory()
        {
            return category;
        }

        public void SetCategory( List<String> category )
        {
            this.category = category;
        }

        public List<Rate> GetRatings()
        {
            return ratings;
        }
    }
}
