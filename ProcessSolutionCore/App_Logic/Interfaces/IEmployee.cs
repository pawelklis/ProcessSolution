using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSolution
{
    public interface IEmployee:IEntity
    {
        public string JobTitle { get; set; }
        public ContactType WorkContact { get; set; }
        public LocationType Location { get; set; }
    }
}
