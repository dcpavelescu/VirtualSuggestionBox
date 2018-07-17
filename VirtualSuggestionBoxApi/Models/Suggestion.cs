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
    public class Suggestion
    {
        [BsonId]
        public ObjectId SuggestionID;
        private String Improvement;
        private String Solution;
        [BsonId]
        private ObjectId EmployeeID;
        private DateTime Date;
        private List<Rate> Ratings;
        private List<String> Category;
        private Double avgRate;


        //generates an unique ID for Suggestion
        static object locker = new object();
        public void GenerateUniqueID()
        {
            lock (locker)
            {
                //   Thread.Sleep(100);
                this.SuggestionID = MongoDB.Bson.ObjectId.GenerateNewId();// ObjectId.Parse(DateTime.Now.ToString("yyyyMMddHHmmssf"));
                this.EmployeeID = MongoDB.Bson.ObjectId.GenerateNewId();// ObjectId.Parse(DateTime.Now.ToString("yyyyMMddHHmmssf"));
            }
        }

        public Suggestion(string improvement, string solution)
        {
            Ratings = new List<Rate>();
            Category = new List<String>();
            Improvement = improvement;
            Solution = solution;
            Date = DateTime.Now;
        }

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
            return  SuggestionID.ToString();
        }

        public List<Rate> getRateList()
        {
            return Ratings;
        }
    }
}
