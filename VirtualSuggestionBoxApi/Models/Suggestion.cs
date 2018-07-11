using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VirtualSuggestionBoxApi.Models
{
    public class Suggestion
    {
       
        private int SuggestionIndex { get; set; }
        private String Improvement { get; set; }
        private String Solution { get; set; }
        private String EmployeeId { get; set; }

        private DateTime Date { get; set; }
        private List<int> Ratings { get; set; }
        private List<String> Category { get; set; }
           
        public Suggestion()
        {
            Ratings = new List<int>();
            Category = new List<String>();
           // SuggestionId = null;
            Improvement = null;
            Solution = null;
            EmployeeId = null;
            Date = default(DateTime);

        }


    }
}
