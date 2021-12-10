using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProcessSolution
{
    
    public interface IResearchModelItem : IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ResearchModelItemTypes ItemType { get; set; }
        public void CopyTo(IResearchModelItem toItem);


    }
    public enum ResearchModelItemTypes
    {
        Text,Number,Checkbox,List,Date,SystemTime,Time
    }
}