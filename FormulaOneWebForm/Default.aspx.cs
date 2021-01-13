using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FormulaOneDLL;

namespace FormulaOneWebForm
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //inizializzazioni che vengono eseguite sonlo la prima volta che load la page
                //lblMessaggio.Text = "Digita Username e Password e premi invia";
                DBtools d = new DBtools();
                DataTable dt = d.nameTable();
                List<string> list = new List<string>();
                foreach(DataRow item in dt.Rows)
                {

                    list.Add((item["TABLE_NAME"]).ToString());
                }
                lstTabelle.DataSource = list;
                lstTabelle.DataBind();
            }
            else
            {

            }
        }
        protected void changeIndex(object sender, EventArgs e)
        {
            DBtools d = new DBtools();
            if(lstTabelle.SelectedValue=="country")
                dg.DataSource = d.getCountries();
            else if (lstTabelle.SelectedValue == "Teams")
                dg.DataSource = d.getTeams();
            else
                dg.DataSource = d.getPilot();
            dg.DataBind();

        }
    }
}