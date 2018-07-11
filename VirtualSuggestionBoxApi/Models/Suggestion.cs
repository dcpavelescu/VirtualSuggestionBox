using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualSuggestionBoxApi.Models
{
    public class Suggestion
    {
        private String SuggestionId { get; set; }
        private String Improvement { get; set; }
        private String Solution { get; set; }
        private String EmployeeId { get; set; }

        private DateTime Date { get; set; }
        private List<int> Ratings { get; set; }
        private List<string> Category { get; set; }
           
        public Suggestion()
        {
            Ratings = new List<int>();
            Category = new List<string>();

        }
        
    }
}
