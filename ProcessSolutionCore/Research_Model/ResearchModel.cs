using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProcessSolution
{
    [Table("ResearchModels")]
    public class ResearchModel :DBController, IResearchModel
    {
        public int Id { get; set; }
        public List<ResearchModelItem> Columns { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ResearchPlannedStartTime { get; set; }
        public DateTime ResearchPlannedEndTime { get; set; }
 

        public ResearchModel()
        {
            Columns = new List<ResearchModelItem>();
        }
    }
}