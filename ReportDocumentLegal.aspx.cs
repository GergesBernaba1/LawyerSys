using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReportDocumentLegal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            databaseaccesslayer dataobj = new databaseaccesslayer();
            if (Request.QueryString["Id"].ToString() != null && Request.QueryString["Id"].ToString() != "")
            {
                try
                {
                    string sql1 = @"select * from Application_Setting where User_Id=" + Session["Id"] + " and Appl_Id=32 and IsVaild=1";
                    DataTable dt1 = dataobj.Selectdatatable(sql1);
                    if (dt1.Rows.Count != 1)
                    {
                        Response.Redirect("MainPage.aspx");
                    }
                    string sql = @"ReportDocumentLegal " + Request.QueryString["Id"].ToString();
                    ReportDocument reportdocument = new ReportDocument();
                    reportdocument.Load(Server.MapPath("Reports/RepDocumentLegal.rpt"));
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