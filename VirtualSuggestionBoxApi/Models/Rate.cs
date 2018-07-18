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
        private String EmployeeId;

        public Rate(int Score, string Feedback, string EmployeeId)
        {
            this.Score = Score;
            this.Feedback = Feedback;
            this.EmployeeId = EmployeeId;
        }

        public int getScore()
        {
            return Score;
        }
    }
}
