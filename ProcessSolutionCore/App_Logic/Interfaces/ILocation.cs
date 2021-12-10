using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSolution
{
    public interface ILocation:IEntity
    {
        public string Name { get; set; }
        public AddressType Address { get; set; }

    }
}
