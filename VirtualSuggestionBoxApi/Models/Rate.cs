using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualSuggestionBoxApi.Models
{
    public class Rate
    {
        public int Score;
        public String Feedback;

        public Rate(int score, string feedback)
        {
            Score = score;
            Feedback = feedback;
        }
    }
}
