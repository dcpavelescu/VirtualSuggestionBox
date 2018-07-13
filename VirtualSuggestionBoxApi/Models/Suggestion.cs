using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace VirtualSuggestionBoxApi.Models
{
    public class Suggestion
    {

        private String SuggestionID;
        private String Improvement;
        private String Solution;
        private String EmployeeID;
        private DateTime Date;
        private List<Rate> Ratings;
        private List<String> Category;
        private Double avgRate;


        //generates an unique ID for Suggestion
        static object locker = new object();
        static string GenerateUniqueID()
        {
            lock (locker)
            {
                Thread.Sleep(100);
                return DateTime.Now.ToString("yyyyMMddHHmmssf");
            }
        }


        public Suggestion(string improvement, string solution, string employeeID)
        {
            Ratings = new List<Rate>();
            Category = new List<String>();
            SuggestionID = GenerateUniqueID();
            Improvement = improvement;
            Solution = solution;
            EmployeeID = employeeID;
            Date = DateTime.Now;
        }


        //calculates the average rating
        public Double averageRate()
        {
            double avg = 0;
            foreach (Rate r in Ratings)
            {
                avg += r.getScore();
            }
            avg /= Ratings.Count();
            return avg;
        }

        public void addRate(Rate r)
        {
            Ratings.Add(r);
        }

        public void setAvgRate(Double avg)
        {
            avgRate = avg;
        }

        public double getAvgRate()
        {
            return avgRate;
        }
        public List<String> getCategory()
        {
            return Category;
        }

        public String getEmployeeID()
        {
            return EmployeeID;
        }

        public String getID()
        {
            return SuggestionID;
        }


    }
}
