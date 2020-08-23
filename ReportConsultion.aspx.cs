using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReportConsultion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        databaseaccesslayer dataobj = new databaseaccesslayer();
        if (!IsPostBack)
        {
            string sql1 = @"select * from Application_Setting where User_Id=" + Session["Id"] + " and Appl_Id=24 and IsVaild=1";
            DataTable dt1 = dataobj.Selectdatatable(sql1);
            if (dt1.Rows.Count != 1)
            {
                Response.Redirect("MainPage.aspx");
            }
            if (Request.QueryString["Id"].ToString() != null && Request.QueryString["Id"].ToString() != "" && Session["DateFrom"] != null && Session["DateFrom"].ToString() != "" && Session["DateTo"] != null && Session["DateTo"].ToString() != "")
            {
                try
                {
                    string sql = @"ReportConsultation " + Request.QueryString["Id"].ToString() + ",'" + Session["DateFrom"] + "','" + Session["DateTo"] + "'";
                    ReportDocument reportdocument = new ReportDocument();
                    reportdocument.Load(Server.MapPath("Reports/RepConsultation.rpt"));
                    reportdocument.DataSourceConnections[0].SetConnection(".", "Lawer", true);
                    reportdocument.SetDataSource(dataobj.Selectdatatable(sql));
                    reportdocument.SetParameterValue("@Id", int.Parse(Request.QueryString["Id"].ToString()));
                    reportdocument.SetParameterValue("@DateFrom", DateTime.Parse(Session["DateFrom"].ToString()).ToShortDateString());
                    reportdocument.SetParameterValue("@DateTo", DateTime.Parse(Session["DateTo"].ToString()).ToShortDateString());
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