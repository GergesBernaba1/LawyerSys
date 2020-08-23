using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReportIssueDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                databaseaccesslayer dataobj = new databaseaccesslayer();
                string sql1 = @"select * from Application_Setting where User_Id=" + Session["Id"] + " and Appl_Id=12 and IsVaild=1";
                DataTable dt1 = dataobj.Selectdatatable(sql1);
                if (dt1.Rows.Count != 1)
                {
                    Response.Redirect("MainPage.aspx");
                }
                if (Request.QueryString["Number"] != null && Request.QueryString["Number"].ToString() != "")
                {
                    string sql = @"ReportDetailsIssue " + Request.QueryString["Number"].ToString();
                    ReportDocument reportdocument = new ReportDocument();
                    reportdocument.Load(Server.MapPath("Reports/RepIssueDetails.rpt"));
                    reportdocument.DataSourceConnections[0].SetConnection(".", "Lawer", true);
                    reportdocument.SetDataSource(dataobj.Selectdatatable(sql));
                    reportdocument.SetParameterValue("@Number", int.Parse(Request.QueryString["Number"].ToString()));
                    CrystalReportViewer1.ReportSource = reportdocument;
                }
                else
                {
                    Response.Redirect("ReportDetailsIssue.aspx");
                }
            }
            catch (Exception)
            {
                Response.Redirect("MainPage.aspx");
            }
        }
    }
}