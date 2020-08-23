using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Alert : System.Web.UI.Page
{
    databaseaccesslayer dataObj = new databaseaccesslayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                string sql1 = @"select * from Application_Setting where User_Id=" + Session["Id"] + " and Appl_Id=43 and IsVaild=1";
                DataTable dt1 = dataObj.Selectdatatable(sql1);
                if (dt1.Rows.Count != 1)
                {
                    Response.Redirect("MainPage.aspx");
                }
                string sql = @"select * from Ta_Sitting where AlertDate='" + DateTime.Now.ToShortDateString() + "' and Type=1";
                DataTable dt = dataObj.Selectdatatable(sql);
                if (dt.Rows.Count>0)
                {
                    divSitting.Visible = true;
                    BindgrdTrades();
                }
                string sqlT = @"select * from Ta_Task where DateOfAlert='" + DateTime.Now.ToShortDateString() + "' and Status=1";
                DataTable dts = dataObj.Selectdatatable(sqlT);
                if (dts.Rows.Count > 0)
                {
                    divTask.Visible = true;
                    BindgrdTradesTask();
                }
            }
            catch (Exception)
            {
                Response.Redirect("MainPage.aspx");
            }

        }
    }
    private void BindgrdTrades()
    {
        try
        {
            gridSelect.DataSource = dataObj.Selectdatatable("select i.IssueNumber as رقم_القضية,HakemName as القاضي,SittingTime as الوقت,S.SittingDate as التاريخ,s.Notes as ملاحظات from Ta_Sitting s left join Ta_Issue i on s.Issue_Id=i.Id where AlertDate='" + DateTime.Now.ToShortDateString() + "' and Type=1"); 
            gridSelect.DataBind();
        }
        catch (Exception ex)
        {
            dataObj.Alert(ex.Message, this);
        }
    }
    private void BindgrdTradesTask()
    {
        try
        {
            GridView1.DataSource = dataObj.Selectdatatable("select DateOfTask as التاريخ,TaskName as اسم_المهمة,TaskType as نوع_المهمة,Notes as ملاحظات from Ta_Task where DateOfAlert='" + DateTime.Now.ToShortDateString() + "' and Status=1");
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            dataObj.Alert(ex.Message, this);
        }
    }
    protected void gridSelect_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridSelect.PageIndex = e.NewPageIndex;
        BindgrdTrades();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindgrdTradesTask();
    }
}