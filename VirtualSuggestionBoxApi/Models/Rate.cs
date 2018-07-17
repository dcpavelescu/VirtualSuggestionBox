using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualSuggestionBoxApi.Models
{
    public class Rate
    {
        private int Score;
        private String Feedback;
        private String EmployeeID;

        public Rate(int score, string feedback, string employeeID)
        {
            Score = score;
            Feedback = feedback;
            EmployeeID = employeeID;
        }

        public int getScore()
        {
            return Score;
        }
    }
}
