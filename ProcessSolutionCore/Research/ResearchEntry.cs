using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcessSolution
{
    public class ResearchEntry:DBController,IEntity
    {
        public int Id { get; set; }
        public List<ResearchItem> Items { get; set; }


        public ResearchEntry()
        {
            this.Items = new List<ResearchItem>();
        }
    }
}