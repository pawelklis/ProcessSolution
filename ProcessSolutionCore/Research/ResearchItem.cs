using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcessSolution
{
    public class ResearchItem :DBController, IEntity
    {
        public int Id { get; set; }
        public ResearchModelItem Model { get; set; }
        public string Value { get; set; }
        public TimeSpan ItemTime { get; set; }
    }
}