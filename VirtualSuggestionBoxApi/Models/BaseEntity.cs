using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualSuggestionBoxApi.Models
{

    public class BaseEntity
    {
        private String Id;

        public void SetId( String Id )
        {
            this.Id = Id;
        }

        public String GetId()
        {
            return Id;
        }

    }

}
