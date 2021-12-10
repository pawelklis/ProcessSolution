using System;

namespace ProcessSolution
{


    public class CastManager
    {
        public static object CastValue(ResearchItem item)
        {
            if (item.Model == null)
                return null;
            switch (item.Model.ItemType)
            {
                case ResearchModelItemTypes.Text:
                    return CastValueString(item);
                case ResearchModelItemTypes.Number:
                    return CastValueInt(item);
                case ResearchModelItemTypes.Checkbox:
                    return CastValueBool(item);
                case ResearchModelItemTypes.List:
                    return CastValueList(item);
                case ResearchModelItemTypes.Date:
                    return CastValueDateTime(item);
                case ResearchModelItemTypes.SystemTime:
                    return CastValueDateTime(item);
                case ResearchModelItemTypes.Time:
                    return CastValueString(item);
                default:
                    break;
            }
            return null;
        }
        private static DateTime CastValueDateTime(ResearchItem item)
        {
            if (item.Value == null)
                item.Value = "";
            DateTime dt=DateTime.Parse("0001-01-01 00:00:00");
            DateTime.TryParse(item.Value.ToString(),out dt);
            return dt;
        }

        private static string CastValueString(ResearchItem item)
        {
            if (item.Value == null)
                item.Value = "";
            return item.Value.ToString();
        }      
        private static string CastValueList(ResearchItem item)
        {
            if (item.Value == null || string.IsNullOrEmpty(item.Value.ToString()))
            {
                item.Value = "0";
                return "";
            }

            ResearchItemNested o = item.Model.Items.Find(x => x.Id == int.Parse(item.Value));
            if (o == null)
                return "";

            return o.Name;
        }
        private static double CastValueInt(ResearchItem item)
        {
            if (item.Value == null)
                item.Value = "0";
            return double.Parse(item.Value);
        }
        private static bool CastValueBool(ResearchItem item)
        {
            if (item.Value == null)
                item.Value = "false";
            return bool.Parse(item.Value);
        }


    }
}