using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;


public partial class ReportAllEmployee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        databaseaccesslayer dataobj = new databaseaccesslayer();
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
                string sql = @"ReportActiveEmployee";
                ReportDocument reportdocument = new ReportDocument();
                reportdocument.Load(Server.MapPath("Reports/RepAllEmployees.rpt"));
                reportdocument.DataSourceConnections[0].SetConnection(".", "Lawer", true);
                reportdocument.SetDataSource(dataobj.Selectdatatable(sql));
                CrystalReportViewer1.ReportSource = reportdocument;
            }
            catch (Exception)
            {
                Response.Redirect("MainPage.aspx");
            }
        }
    }
}