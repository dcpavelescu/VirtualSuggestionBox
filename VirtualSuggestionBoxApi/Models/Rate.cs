using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualSuggestionBoxApi.Models
{
    public class Rate
    {
        private int score;
        private String feedback;
        private String employeeId;

        public Rate(int score, string feedback, string employeeId)
        {
            this.score = score;
            this.feedback = feedback;
            this.employeeId = employeeId;
        }

        public int GetScore()
        {
            return score;
        }
    }
}
