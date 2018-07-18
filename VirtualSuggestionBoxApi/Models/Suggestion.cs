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
    public class Suggestion : TmodelInterface
    {
        [BsonId]
        public ObjectId Id { get; set; }
        private String Improvement;
        private String Solution;
        [BsonId]
        private ObjectId EmployeeID;
        private DateTime Date;
        private List<Rate> Ratings;
        private List<String> Category;
        private Double avgRate;

        //public object Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Suggestion(string improvement, string solution, ObjectId employeeID)
        {
            Ratings = new List<Rate>();
            Category = new List<String>();
            Improvement = improvement;
            Solution = solution;
            EmployeeID = employeeID;
            Date = DateTime.Now;
        }

        public void addRate(Rate r)
        {
            Ratings.Add(r);
        }

        //calculates the average rating
        public void setAvgRate()
        {
            double media = 0;
            foreach (Rate r in Ratings)
            {
                media += r.getScore();
            }
            media /= Ratings.Count();
            this.avgRate = media;
        }

        public double getAvgRate()
        {
            return avgRate;
        }
        public List<String> getCategory()
        {
            return Category;
        }

        public ObjectId getEmployeeID()
        {
            return EmployeeID;
        }

        public void setEmployeeId(ObjectId newId)
        {
            this.EmployeeID = newId;
        }

        public String getID()
        {
            return  Id.ToString();
        }

        public void setID(ObjectId newId)
        {
            Id = newId;
        }

        public List<Rate> getRateList()
        {
            return Ratings;
        }
    }
}
