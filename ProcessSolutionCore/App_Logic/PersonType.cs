using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcessSolution
{
    public class PersonType : DBController, IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ContactType PrivateContact { get; set; }
        public AddressType Address { get; set; }
 
        public PersonType()
        {
            PrivateContact = new ContactType();
            Address = new AddressType();
        }
    }
}