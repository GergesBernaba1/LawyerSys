using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Select_PlaceLawer : System.Web.UI.Page
{
    databaseaccesslayer dataObj = new databaseaccesslayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                string sql1 = @"select * from Application_Setting where User_Id=" + Session["Id"] + " and Appl_Id=42 and IsVaild=1";
                DataTable dt1 = dataObj.Selectdatatable(sql1);
                if (dt1.Rows.Count != 1)
                {
                    Response.Redirect("MainPage.aspx");
                }
                BindgrdTrades();
                drpGovernate.DataSource = dataObj.Selectdatatable("select Id,GovernateName from Ta_Governate");
                drpGovernate.DataTextField = "GovernateName";
                drpGovernate.DataValueField = "Id";
                drpGovernate.DataBind();
                drpGovernate.Items.Insert(0, "اسم المحافظة");
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
            if (drpGovernate.SelectedIndex > 0)
            {
                gridSelect.DataSource = dataObj.Selectdatatable("select Name as اسم_المحكمة,Address as العنوان,Telephone as التليفون,GovernateName as المحافظة,Notes as ملاحظات from Ta_LawerPlace l left join Ta_Governate g on l.Governate_Id=g.Id where Governate_Id=" + drpGovernate.SelectedItem.Value);
                gridSelect.DataBind();
            }
            else
            {
                gridSelect.DataSource = dataObj.Selectdatatable("select Name as اسم_المحكمة,Address as العنوان,Telephone as التليفون,GovernateName as المحافظة,Notes as ملاحظات from Ta_LawerPlace l left join Ta_Governate g on l.Governate_Id=g.Id");
                gridSelect.DataBind();
            }
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
            string sql = @"select l.Id as Id,Name,Address,Telephone,GovernateName,Notes from Ta_LawerPlace l left join Ta_Governate g on l.Governate_Id=g.Id where Name='" + row.Cells[1].Text + "' and GovernateName='" + row.Cells[4].Text + "'";
            DataTable dt = dataObj.Selectdatatable(sql);
            if (dt.Rows.Count == 1)
            {
                Response.Redirect("Update-PlaceLawer.aspx?Id=" + dt.Rows[0]["Id"].ToString());
            }
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
    protected void drpGovernate_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindgrdTrades();
    }
}