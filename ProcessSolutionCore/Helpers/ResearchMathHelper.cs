using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcessSolution
{
    public class ResearchMathHelper
    {


        public static void SetResearchItemsStepsTime(List<ResearchItem> items)
        {
            List<ResearchItem> filterreditems = (from o in items
                                                where o.Model.ItemType == ResearchModelItemTypes.Date ||  o.Model.ItemType == ResearchModelItemTypes.SystemTime || o.Model.ItemType == ResearchModelItemTypes.Time
                                                select o).ToList();


            int i = 0;
            filterreditems.ForEach(x =>
            {
                if (x.Model != null)
                {
                   if(x.Model.ItemType== ResearchModelItemTypes.Date ||
                        x.Model.ItemType == ResearchModelItemTypes.SystemTime ||
                        x.Model.ItemType == ResearchModelItemTypes.Time)
                    {
                    
                        ResearchItem nextitem = NextItem(i, filterreditems);
                        if (nextitem != null)
                        {
                            DateTime thisTime = (DateTime)CastManager.CastValue(x);
                            DateTime nextTime = (DateTime)CastManager.CastValue(nextitem);
                            TimeSpan ts = nextTime - thisTime;
                            x.ItemTime = ts;                        
                        }
                    }
                }


                i++;
            });
            ResearchItem.db.SaveChanges();
        }

        private static ResearchItem NextItem(int index, List<ResearchItem> items)
        {
            
            if (index + 1 < items.Count)
                return items[index + 1];
            else
                return null;
        }


    }
}