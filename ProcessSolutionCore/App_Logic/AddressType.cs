using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcessSolution
{
    public class AddressType :DBController, IAddress
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Local { get; set; }
        public string ZipCode { get; set; }
        public int Id { get; set; }
    }
}