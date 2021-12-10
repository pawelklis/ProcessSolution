using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSolution
{
    interface IUser : IEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public PersonType Person { get; set; }
        public EmployeeType Employee {get;set;}

    }
}
