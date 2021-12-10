using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcessSolution
{
    public interface IResearchModel:IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ResearchPlannedStartTime { get; set; }
        public DateTime ResearchPlannedEndTime { get; set; }
        public List<ResearchModelItem> Columns { get; set; }
    }
}