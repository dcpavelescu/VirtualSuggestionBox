using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualSuggestionBoxApi.Models
{
    public class Employee : IEntity
    {
        private String id;
        public String Id { get { return id; } set { id = value; } }
        private String Name;
        private String User;
        private String Email;
        private String Unit;
    }

}
