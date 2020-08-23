using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReportDetailsIssue : System.Web.UI.Page
{
    databaseaccesslayer dataobj = new databaseaccesslayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                string sql1 = @"select * from Application_Setting where User_Id=" + Session["Id"] + " and Appl_Id=12 and IsVaild=1";
                DataTable dt1 = dataobj.Selectdatatable(sql1);
                if (dt1.Rows.Count != 1)
                {
                    Response.Redirect("MainPage.aspx");
                }
                addValidationGroup();
            }
            catch (Exception)
            {
                Response.Redirect("MainPage.aspx");
            }
        }
    }
    private void addValidationGroup()
    {
        foreach (Control ctrl in UpdatePanel1.Controls[0].Controls)
        {

            TextBox txtbx = ctrl as TextBox;
            if (txtbx != null)
            {
                txtbx.Attributes["ValidationGroup"] = txtbx.ValidationGroup;
            }

            DropDownList drp = ctrl as DropDownList;
            if (drp != null)
            {
                drp.Attributes["ValidationGroup"] = drp.ValidationGroup;
            }
        }
    }

    protected void btnReport_Click(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(txtNumber.Text))
            {
                string sql = "select * from Ta_Issue where IssueNumber='" + txtNumber.Text + "'";
                DataTable dt = dataobj.Selectdatatable(sql);
                if (dt.Rows.Count == 1)
                {
                    Response.Redirect("ReportIssueDetails.aspx?Number=" + txtNumber.Text);
                }
                else
                {
                    dataobj.Alert("Error", this);
                }
            }
            else
            {
                dataobj.Alert("من فضلك ادخل رقم القضية", this);
            }
        }
        catch (Exception)
        {
        }
    }
}