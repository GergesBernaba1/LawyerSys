using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;

public partial class ReportDetailsEmployee : System.Web.UI.Page
{
    databaseaccesslayer dataobj = new databaseaccesslayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                string sql1 = @"select * from Application_Setting where User_Id=" + Session["Id"] + " and Appl_Id=8 and IsVaild=1";
                DataTable dt1 = dataobj.Selectdatatable(sql1);
                if (dt1.Rows.Count != 1)
                {
                    Response.Redirect("MainPage.aspx");
                }
                ddlEmployee.DataSource = dataobj.Selectdatatable("select * from Ta_Employee order by Id desc");
                ddlEmployee.DataTextField = "EmployeeName";
                ddlEmployee.DataValueField = "Id";
                ddlEmployee.DataBind();
                ddlEmployee.Items.Insert(0, "Select Employee");
                ddlEmployee.SelectedIndex = 0;
            }
            catch (Exception)
            {
                Response.Redirect("MainPage.aspx");
            }
            
        }
    }
    protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlEmployee.SelectedIndex>0)
        {
            Response.Redirect("ReportEmployeeDetails.aspx?Id="+ddlEmployee.SelectedValue);
        }
    }
}