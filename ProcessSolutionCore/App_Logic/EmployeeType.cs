using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcessSolution
{
    public class EmployeeType : DBController, IEmployee
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public ContactType WorkContact { get; set; }
        public LocationType Location { get; set; }

        public EmployeeType()
        {
            WorkContact = new ContactType();
            Location = new LocationType();
        }
    }
}