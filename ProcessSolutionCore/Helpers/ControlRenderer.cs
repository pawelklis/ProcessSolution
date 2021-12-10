using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProcessSolution
{
    public class ControlRenderer
    {
        public event EventHandler AfterUpdateValue;

        private ResearchItem Item;
        public  Control[] RenderControl(ResearchItem item)
        {
            this.Item = item;
            if (item.Model == null)
                return null;

            Panel panel;
            TextBox tx;
            Label lb;
            CheckBox cx;
            DropDownList ddl;
            LiteralControl lt = new LiteralControl("<button type='button' class='btn btn-secondary' data-bs-container='body' data-toggle='popover' data-bs-toggle='popover' data-bs-placement='top' data-bs-content='" + item.Model.Description  + "'>?</button> ");

            switch (item.Model.ItemType)
            {
 

                case ResearchModelItemTypes.Text:
                    tx = new TextBox();
                    tx.ID = item.Model.Name+"_"+ item.Id.ToString();
                    tx.Text = item.Value.ToString();
                    tx.TextMode = TextBoxMode.SingleLine;
                    tx.TextChanged += Tx_TextChanged;
                    tx.AutoPostBack = true;
                    tx.CssClass = "form-control";

                    lb = new Label();
                    lb.Text = item.Model.Name;
                    lb.ID = "lb_" + tx.ID;
                    lb.CssClass = "input-group-text";


                    panel = new Panel();
                    panel.ID = "pn_" + item.Id.ToString();
                    panel.CssClass = "input-group";

                    panel.Controls.Add(lb);
                    panel.Controls.Add(tx);
                    panel.Controls.Add(lt);

                    return new Control[] { panel };






                case ResearchModelItemTypes.Number:
                    tx = new TextBox();
                    tx.ID = item.Model.Name + "_" + item.Id.ToString();
                    tx.Text = item.Value.ToString();
                    tx.TextMode = TextBoxMode.Number;
                    tx.TextChanged += Txn_TextChanged;
                    tx.AutoPostBack = true;
                    tx.CssClass = "form-control";

                    lb = new Label();
                    lb.Text = item.Model.Name;
                    lb.ID = "lb_" + tx.ID;
                    lb.CssClass = "input-group-text";

                    panel = new Panel();
                    panel.ID = "pn_" + item.Id.ToString();
                    panel.CssClass = "input-group";

                    panel.Controls.Add(lb);
                    panel.Controls.Add(tx);
                    panel.Controls.Add(lt);

                    return new Control[] { panel };
                case ResearchModelItemTypes.Checkbox:
                    cx = new CheckBox();
                    cx.ID = item.Model.Name + "_" + item.Id.ToString();
                    cx.Checked = (bool)CastManager.CastValue(item);
                    cx.CheckedChanged += Cx_CheckedChanged;
                    cx.AutoPostBack = true;
                    cx.CssClass = "form-control";

                    lb = new Label();
                    lb.Text = item.Model.Name;
                    lb.ID = "lb_" + cx.ID;
                    lb.CssClass = "input-group-text";

                    panel = new Panel();
                    panel.ID = "pn_" + item.Id.ToString();
                    panel.CssClass = "input-group";

                    panel.Controls.Add(lb);
                    panel.Controls.Add(cx);
                    panel.Controls.Add(lt);
                    return new Control[] { panel };
                case ResearchModelItemTypes.List:
                    ddl = new DropDownList();
                    ddl.ID = item.Model.Name + "_" + item.Id.ToString();

                    ddl.DataSource = item.Model.Items;
                    ddl.DataTextField = "name";
                    ddl.DataValueField = "id";
                    ddl.DataBind();


                    if (item.Model.Items.Find(x => x.Name == item.Value) != null)
                    {
                        item.Value = item.Model.Items[0].Id.ToString();
                        ResearchItem.db.SaveChanges();
                        RaiseEvent();
                    }



                    ddl.SelectedValue = (string)CastManager.CastValue(item);
                    ddl.SelectedIndexChanged += Ddl_SelectedIndexChanged;
                    ddl.AutoPostBack = true;
                    ddl.CssClass = "form-control";

                    lb = new Label();
                    lb.Text = item.Model.Name;
                    lb.ID = "lb_" + ddl.ID;
                    lb.CssClass = "input-group-text";

                    panel = new Panel();
                    panel.ID = "pn_" + item.Id.ToString();
                    panel.CssClass = "input-group";

                    panel.Controls.Add(lb);
                    panel.Controls.Add(ddl);
                    panel.Controls.Add(lt);
                    return new Control[] { panel };
                case ResearchModelItemTypes.Date:
                    tx = new TextBox();
                    tx.ID = item.Model.Name + "_" + item.Id.ToString();
                    tx.Text = item.Value.ToString();
                    tx.TextMode = TextBoxMode.DateTime;
                    tx.TextChanged += Tx_TextChanged;
                    tx.AutoPostBack = true;
                    tx.CssClass = "form-control";


                    Button datebutton = new Button();
                    datebutton.ID = "datebtn_" + tx.ID;
                    datebutton.CssClass = "btn btn-success";
                    datebutton.Text = "T";
                    datebutton.Click += Datebutton_Click;

                    lb = new Label();
                    lb.Text = item.Model.Name;
                    lb.ID = "lb_" + tx.ID;
                    lb.CssClass = "input-group-text";

                    panel = new Panel();
                    panel.ID = "pn_" + item.Id.ToString();
                    panel.CssClass = "input-group";

                    panel.Controls.Add(lb);
                    panel.Controls.Add(datebutton);
                    panel.Controls.Add(tx);
                    panel.Controls.Add(lt);
                    return new Control[] { panel };

                case ResearchModelItemTypes.SystemTime:
                     lb = new Label();
                    lb.ID = item.Model.Name + "_" + item.Id.ToString();
                    lb.Text = item.Value.ToString();
                    lb.CssClass = "form-control";

                    Label ll2 = new Label();
                    ll2.Text = item.Model.Name;
                    ll2.ID = "lb_" + lb.ID;
                    ll2.CssClass = "input-group-text";

                    panel = new Panel();
                    panel.ID = "pn_" + item.Id.ToString();
                    panel.CssClass = "input-group";

                    panel.Controls.Add(ll2);
                    panel.Controls.Add(lb);
                    panel.Controls.Add(lt);

                    return new Control[] { panel };

                case ResearchModelItemTypes.Time:
                    tx = new TextBox();
                    tx.ID = item.Model.Name + "_" + item.Id.ToString();
                    tx.Text = item.Value?.ToString();
                    tx.TextMode = TextBoxMode.Time;
                    tx.TextChanged += Tx_TextChanged;
                    tx.AutoPostBack = true;
                    tx.CssClass = "form-control";
                    tx.Attributes.Add("step", "1");

                    lb = new Label();
                    lb.Text = item.Model.Name;
                    lb.ID = "lb_" + tx.ID;
                    lb.CssClass = "input-group-text";


                    Button btn = new Button();
                    btn.ID = "btt_" + tx.ID;
                    btn.CssClass = "btn btn-success";
                    btn.Text = "T";
                    btn.Click += Btn_Click;

                    panel = new Panel();
                    panel.ID = "pn_" + item.Id.ToString();
                    panel.CssClass = "input-group";

                    panel.Controls.Add(lb);
                    panel.Controls.Add(btn);
                    panel.Controls.Add(tx);
                    panel.Controls.Add(lt);
                    return new Control[] { panel };


                default:
                    return null;

            }

        }

        private void Datebutton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Item.Value = DateTime.Now.ToString();
            ResearchItem.db.SaveChanges();
            RaiseEvent();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            DateTime dt = DateTime.Now;

            Item.Value = dt.Hour.ToString("00") + ":" + dt.Minute.ToString("00") + ":" + dt.Second.ToString("00");
            ResearchItem.db.SaveChanges();
            RaiseEvent();
        }

        void RaiseEvent()
        {
            EventHandler handler = AfterUpdateValue;
            handler?.Invoke(this, null);
        }
        private void Ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = sender as DropDownList;
            int id =int.Parse( ddl.ID.Split('_').Last());
            Item.Value = ddl.SelectedValue;
            ResearchItem.db.SaveChanges();
            RaiseEvent();
        }

        private void Cx_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cx = sender as CheckBox;
            Item.Value = cx.Checked.ToString();
            ResearchItem.db.SaveChanges();
            RaiseEvent();
        }

        private void Txn_TextChanged(object sender, EventArgs e)
        {
            TextBox tx = sender as TextBox;
            Item.Value = tx.Text;
            ResearchItem.db.SaveChanges();
            RaiseEvent();
        }

        private void Tx_TextChanged(object sender, EventArgs e)
        {
            TextBox tx = sender as TextBox;
            Item.Value = tx.Text;
            ResearchItem.db.SaveChanges();
            RaiseEvent();
        }
    }
}