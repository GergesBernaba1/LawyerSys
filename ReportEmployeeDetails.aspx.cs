using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;


public partial class ReportEmployeeDetails : System.Web.UI.Page
{
    databaseaccesslayer dataobj = new databaseaccesslayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Id"].ToString() != null && Request.QueryString["Id"].ToString() != "")
            {
                try
                {
                    string sql1 = @"select * from Application_Setting where User_Id=" + Session["Id"] + " and Appl_Id=8 and IsVaild=1";
                    DataTable dt1 = dataobj.Selectdatatable(sql1);
                    if (dt1.Rows.Count != 1)
                    {
                        Response.Redirect("MainPage.aspx");
                    }
                    string sql = @"ReportEmployeeDetails " + Request.QueryString["Id"].ToString();
                    ReportDocument reportdocument = new ReportDocument();
                    reportdocument.Load(Server.MapPath("Reports/RepEmployeeDetails.rpt"));
                    reportdocument.DataSourceConnections[0].SetConnection(".", "Lawer", true);
                    reportdocument.SetDataSource(dataobj.Selectdatatable(sql));
                    reportdocument.SetParameterValue("@Id", int.Parse(Request.QueryString["Id"].ToString()));
                    CrystalReportViewer1.ReportSource = reportdocument;
                }
                catch (Exception)
                {
                    Response.Redirect("MainPage.aspx");
                }
            }
            else
            {
                Response.Redirect("MainPage.aspx");
            }
        }
    }
}