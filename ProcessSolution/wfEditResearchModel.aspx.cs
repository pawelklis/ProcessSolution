using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProcessSolutionCore;

namespace ProcessSolution
{
    public partial class wfEditResearchModel : System.Web.UI.Page
    {
        int smi;
        int selectedResearchModel
        {
            get { smi = (int)Session["smi"]; return smi; }
            set
            {
                smi = value; 
                Session["smi"]=smi;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
        {
            RenderEditForm(int.Parse(lbid.Text));

            if (!IsPostBack)
            {
                BindDG0();
            }

        }

        public ResearchModel GetModel()
        {
            return DBController.db.ResearchModels.Where<ResearchModel>(x => x.Id == selectedResearchModel).Include("Columns").FirstOrDefault();
        }

        void Bind()
        {
            ResearchModel m = GetModel();
            if (m == null)
            {

                dg1.DataSource = null;
                dg1.DataBind();
                dg2.DataSource = null;
                dg2.DataBind();
                PlaceHolder1.Controls.Clear();
                return;
            }



            dg1.DataSource = m.Columns;
            dg1.DataBind();


            Research test = null;
            
            if(Research.db.Researches.Where<Research>(x=>x.Model.Id==selectedResearchModel).ToList().Count<Research>() > 0)
                test = Research.db.Researches.Where<Research>(x => x.Model.Id == selectedResearchModel).Include(x=> x.Entries.Select(y => y.Items)).ToList()[0];
            if (test == null)
            {
                test = new Research(GetModel());
                test.AddEntry();
                test.AddEntry();
                test.AddEntry();
                Research.db.Researches.Add(test);
                Research.db.SaveChanges();
            }

            dg2.DataSource = test.toTable();
            dg2.DataBind();


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ResearchModel m = new ResearchModel();
            ResearchModel.Add<ResearchModel>(m, false);

            BindDG0();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Save();
        }
        void Save()
        {
            ResearchModel m = GetModel();
            

            foreach (GridViewRow row in dg1.Rows)
            {
                TextBox txname = row.FindControl("txname") as TextBox;
                TextBox txdescription = row.FindControl("txdescription") as TextBox;
                TextBox txitemtype = row.FindControl("txitemtype") as TextBox;
                DropDownList ddlitemtype = row.FindControl("ddlitemtype") as DropDownList;
                TextBox txlistpossibleitems = row.FindControl("txlistpossibleitems") as TextBox;
                Button btnDelete = row.FindControl("btnDelete") as Button;


                ResearchModelItem item = new ResearchModelItem();
                item.Id = int.Parse(btnDelete.CommandArgument.ToString());
                item.Name = txname.Text;
                item.Description = txdescription.Text;
                try
                {
                var x =Enum.GetValues(typeof(ResearchModelItemTypes)).Cast<ResearchModelItemTypes>().ToList().Find(x=> x.ToString()== ddlitemtype.SelectedValue);
                item.ItemType = x;
                }
                catch (Exception ex)
                {                    
                }

                //item.Items = txlistpossibleitems.Text;


                IResearchModelItem exItem = m.Columns.Find(x => x.Id == item.Id);
                if (exItem != null)
                {
                    item.CopyTo(exItem);
                }
                else
                {
                    ResearchModelItem.Add<ResearchModelItem>(item);
                    m.Columns.Add(item);
                }

            }

            DBController.db.SaveChanges();
            Bind();

        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Save();
            ResearchModel m = GetModel();
            ResearchModelItem item = new ResearchModelItem();
            ResearchModelItem.Add<ResearchModelItem>(item);
            
            GetModel().Columns.Add(item);
            DBController.db.SaveChanges();
            
            Bind();
        }

        protected void dg1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                try
                {
                    Save();
            
                    int id = int.Parse(e.CommandArgument.ToString());
                    ResearchModel.db.ResearchModelItems.Remove(ResearchModel.db.ResearchModelItems.Single<ResearchModelItem>(x => x.Id == id));
                    ResearchModel.db.SaveChanges();
                    Bind();
                }
                catch (Exception ex)
                {
                    //najpierw usun podobiekty powiazane
                }
            }
            if (e.CommandName == "sav")
            {

            }

        }

        protected void dg1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType== DataControlRowType.DataRow)
            {
                TextBox txitemtype = e.Row.FindControl("txitemtype") as TextBox;
                DropDownList ddlitemtype = e.Row.FindControl("ddlitemtype") as DropDownList;

                List<String> ls = Enum.GetNames(typeof(ResearchModelItemTypes)).Cast<string>().ToList();

                ddlitemtype.DataSource = ls;
                ddlitemtype.DataBind();
                ddlitemtype.SelectedValue = txitemtype.Text;

                Button btndel = e.Row.FindControl("btnDelete") as Button;
                int id = int.Parse( btndel.CommandArgument);
                GridView dg = e.Row.FindControl("dgitems") as GridView;

                ResearchModel m = GetModel();
         
                ResearchModelItem col = DBController.db.ResearchModelItems.Where<ResearchModelItem>(x => x.Id == id).Include(x=>x.Items).ToList().First();

 

                dg.DataSource = col.Items;
                dg.DataBind();

            }
        }

        void RenderEditForm(int id)
        {

                PlaceHolder1.Controls.Clear();
            if (id == 0)
            {
                editEntry.Visible = false;
                return;
            }
            else
            {
                editEntry.Visible = true;
            }
            try
            {
                ResearchEntry entry = DBController.db.ResearchEntries.Where(x => x.Id == id).Include(x=>x.Items).First();

                entry.Items.ForEach(x =>
                {
                    ControlRenderer rr = new ControlRenderer();
                    rr.AfterUpdateValue += Rr_AfterUpdateValue;
                    Control[] cs = rr.RenderControl(x);
                    bool canAdd = true;
                    foreach(Control c in PlaceHolder1.Controls)
                    {
                        if (c.ID == cs?[0].ID)
                            canAdd = false;
                    }

                    if(cs!=null)
                        if(cs.Count()>0)
                            if(canAdd==true)
                                PlaceHolder1.Controls.Add(cs?[0]);


                    

                    PlaceHolder1.Controls.Add(new LiteralControl("</br>"));
                });
            }
            catch (Exception ex)
            {
                editEntry.Visible = false;
            }

        }

        private void Rr_AfterUpdateValue(object sender, EventArgs e)
        {
            Bind();
            RenderEditForm(int.Parse(lbid.Text));
        }

        protected void dg2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "ed")
            {
                lbid.Text = id.ToString() ;
                RenderEditForm(id);
            }
            if (e.CommandName == "del")
            {
                try
                {
                    ResearchItem.db.ResearchEntries.Remove(ResearchItem.db.ResearchEntries.Single(x => x.Id == id));
                    ResearchItem.db.SaveChanges();
                    lbid.Text = "0";
                    Bind();
                    RenderEditForm(0);
                }
                catch (Exception ex)
                {
                    //usun powiwazane obiekty;
                }

            }



         }

        protected void Button5_Click(object sender, EventArgs e)
        {

            Research rs = Research.db.Researches.Where<Research>(x => x.Model.Id == selectedResearchModel).Include(x => x.Entries.Select(y => y.Items)).ToList()[0];
            List<ResearchItem> items = new List<ResearchItem>();

            rs.Entries.ForEach(x =>
            {
                items.AddRange(x.Items);
            });

            ResearchMathHelper.SetResearchItemsStepsTime(items);
            Bind();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Research test = null;
            if (Research.db.Researches.Count<Research>() > 0)
            {
                test = Research.db.Researches.Where<Research>(x => x.Model.Id == selectedResearchModel).Include(x => x.Entries.Select(y => y.Items)).ToList()[0];
                test.AddEntry();
                lbid.Text = test.Entries.Last().Id.ToString();
                Bind();

                RenderEditForm(int.Parse(lbid.Text));
            }
                
        }

        void BindDG0()
        {
            dg0.DataSource = ResearchModel.db.ResearchModels.ToList();
            dg0.DataBind();
        }
        protected void dg0_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "sel")
            {
                selectedResearchModel = id;
                Bind();
            }
            if (e.CommandName == "del")
            {
                try
                {
                    ResearchModel.db.ResearchModels.Remove(ResearchModel.db.ResearchModels.Single(x => x.Id == id));
                    DBController.db.SaveChanges();
                    selectedResearchModel = 0;
                    Bind();
                }
                catch (Exception ex)
                {
                    //Najpierw usuń podobiekty!
                }
                finally
                {
                    BindDG0();
                    Bind();
                }

            }
            if (e.CommandName == "sav")
            {
                selectedResearchModel = id;
                GridViewRow gvr = (GridViewRow)((Button)e.CommandSource).NamingContainer;
                ResearchModel o = ResearchModel.db.ResearchModels.Single(x => x.Id == id);
                o.Number=((TextBox)gvr.FindControl("txnumber")).Text;
                o.Name=((TextBox)gvr.FindControl("txName")).Text;
                o.Description=((TextBox)gvr.FindControl("txDescription")).Text;
                o.ResearchPlannedStartTime=DateTime.Parse(((TextBox)gvr.FindControl("txstart")).Text);
                o.ResearchPlannedEndTime= DateTime.Parse(((TextBox)gvr.FindControl("txend")).Text);


                DBController.db.SaveChanges();
                BindDG0();
                Bind();
            }


        }

        protected void btnCardClose_Click(object sender, EventArgs e)
        {
            lbid.Text = "0";
            RenderEditForm(0);
        }

        protected void dgitems_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int id = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "sav")
            {
                GridViewRow gvr = (GridViewRow)((Button)e.CommandSource).NamingContainer;
                TextBox txname = gvr.FindControl("txname") as TextBox;
                TextBox txdescription = gvr.FindControl("txdescription") as TextBox;

                ResearchItemNested o = DBController.db.ResearchItemNesteds.Single(x => x.Id == id);
                o.Name = txname.Text;
                o.Description = txdescription.Text;
                DBController.db.SaveChanges();
                Bind();
            }
            if (e.CommandName == "del")
            {
                DBController.db.ResearchItemNesteds.Remove(DBController.db.ResearchItemNesteds.Single(x => x.Id == id));
                Bind();
            }

        }

        protected void btnAddListItem_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            ResearchModel m = GetModel();
            int id = int.Parse(btn.CommandArgument);
            ResearchModelItem col = DBController.db.ResearchModelItems.Single<ResearchModelItem>(x => x.Id ==id);

            if (col.Items == null)
                col.Items = new List<ResearchItemNested>();

            ResearchItemNested o = new ResearchItemNested() { Name = "listitem1" };
            //ResearchItemNested.Add<ResearchItemNested>(o);
            DBController.db.ResearchModels.Single(x => x.Id == m.Id).Columns.Single(x => x.Id == int.Parse(btn.CommandArgument)).Items.Add(o);

            DBController.db.SaveChanges();


            Bind();

        }
    }
    }
