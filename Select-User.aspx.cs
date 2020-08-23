using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Select_User : System.Web.UI.Page
{
    databaseaccesslayer dataObj = new databaseaccesslayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                string sql1 = @"select * from Application_Setting where User_Id=" + Session["Id"] + " and Appl_Id=2 and IsVaild=1";
                DataTable dt1 = dataObj.Selectdatatable(sql1);
                if (dt1.Rows.Count != 1)
                {
                    Response.Redirect("MainPage.aspx");
                }
                BindgrdTrades();
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
            string sql = @"select Name as الاسم,UserName as اسم_المستخدم,Mobil as الموبيل,Address as العنوان,Email as الايميل from Ta_Users";
            gridSelect.DataSource = dataObj.Selectdatatable(sql);
            gridSelect.DataBind();
        }
        catch (Exception ex)
        {
            dataObj.Alert(ex.Message, this);
        }
    }
    protected void gridSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = gridSelect.SelectedRow;
            Response.Redirect("Update-UserDetails.aspx?User=" + row.Cells[2].Text);
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
}