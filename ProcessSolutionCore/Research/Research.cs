using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProcessSolution
{
    public class Research:DBController, IEntity
    {
        public int Id { get; set; }
        public ResearchModel Model { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }        
        public List<ResearchEntry> Entries { get; set; }
        public string Annotation { get; set; }
        public UserType Researcher { get; set; }
        public LocationType Location { get; set; }

        public Research()
        {
            this.Entries = new List<ResearchEntry>();
        }
        public Research(ResearchModel model)
        {
            this.Entries = new List<ResearchEntry>();
            this.Model = model;
        }
        public void AddEntry()
        {
            ResearchEntry entry = new ResearchEntry();

            this.Model.Columns.ForEach(x =>
            {
                ResearchItem item = new ResearchItem();
                item.Model = x;
                if (item.Model.ItemType == ResearchModelItemTypes.SystemTime)
                    item.Value = DateTime.Now.ToString();
                entry.Items.Add(item);

            });


            ResearchEntry.Add<ResearchEntry>(entry);

            this.Entries.Add(entry);
            db.SaveChanges();

        }

        public DataTable toTable()
        {
            if (Model == null)
                return new DataTable();

            DataTable dt = new DataTable();
            dt.Columns.Add("id");

            Model.Columns.ForEach(x =>
            {
                if (x.Name?.ToLower() == "id")
                    x.Name = "_" + x.Name;
                dt.Columns.Add(x.Name);
            });

            dt.Columns.Add("ItemTime");

            Entries.ForEach(x =>
            {
                dt.Rows.Add(x.Id);
                int rowI = dt.Rows.Count - 1;
                int colI = 1;
                x.Items.ForEach(y =>
                {
                    if (colI < dt.Columns.Count-1)
                    {
                        dt.Rows[rowI][colI] = CastManager.CastValue(y);                        
                    }

                        dt.Rows[rowI][dt.Columns.Count-1] = y.ItemTime.ToString();
                    

                    colI++;
                });
            });


            return dt;
        }

    }
}