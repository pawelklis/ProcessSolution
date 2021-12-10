using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcessSolution
{
    public interface IAddress:IEntity
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Local { get; set; }
        public string ZipCode { get; set; }
    }
}