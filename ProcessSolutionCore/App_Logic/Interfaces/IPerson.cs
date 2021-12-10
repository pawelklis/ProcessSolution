using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcessSolution
{
    public interface IPerson:IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ContactType PrivateContact { get; set; }
        public AddressType Address { get; set; }
    }
}