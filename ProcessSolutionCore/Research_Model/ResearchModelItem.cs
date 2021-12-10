using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProcessSolution
{
    [Table("ResearchModelItems")]
    public class ResearchModelItem : DBController,  IResearchModelItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ResearchModelItemTypes ItemType { get; set; }        
        public List<ResearchItemNested> Items { get; set; }
    
        public void CopyTo(IResearchModelItem toItem)
        {
            ResearchModelItem _toItem = (ResearchModelItem)toItem;
            _toItem.Id = Id;
            _toItem.Name = Name;
            _toItem.Description = Description;
            _toItem.ItemType = ItemType;
            //_toItem.Items = Items;            
        }

        public List<Tuple<int, string, string>> ListPossibleItems()
        {
            List<Tuple<int, string, string>> vals = new List<Tuple<int, string, string>>();
            Items.ForEach(x =>
            {
                vals.Add(new Tuple<int, string, string>(x.Id, x.Name, x.Description));
            });
            
            return vals;
        }


    }
}