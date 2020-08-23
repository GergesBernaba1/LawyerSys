using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Select_Task : System.Web.UI.Page
{
    databaseaccesslayer dataObj = new databaseaccesslayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                string sql1 = @"select * from Application_Setting where User_Id=" + Session["Id"] + " and Appl_Id=26 and IsVaild=1";
                DataTable dt1 = dataObj.Selectdatatable(sql1);
                if (dt1.Rows.Count != 1)
                {
                    Response.Redirect("MainPage.aspx");
                }
                BindgrdTrades();
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
    private void BindgrdTrades()
    {
        try
        {
            if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "")
            {
                gridSelect.DataSource = dataObj.Selectdatatable("select Id as كود_المهمة,DateOfTask as تاريخ_المهمة,TaskName as اسم_المهمة,TaskType as نوع_المهمة,Notes as ملاحظات from Ta_Task where Status=1 and DateOfTask between '" + DateTime.Parse(txtDateFrom.Text).ToShortDateString() + "' and '" + DateTime.Parse(txtDateTo.Text).ToShortDateString() + "' order by Id desc");
                gridSelect.DataBind();
            }
            else 
            {
                gridSelect.DataSource = dataObj.Selectdatatable("select Id as كود_المهمة,DateOfTask as تاريخ_المهمة,TaskName as اسم_المهمة,TaskType as نوع_المهمة,Notes as ملاحظات from Ta_Task where Status=1 order by Id desc");
                gridSelect.DataBind();
            }
        }
        catch (Exception ex)
        {
            dataObj.Alert(ex.Message, this);
        }
    }
    protected void drpGovernate_TextChanged(object sender, EventArgs e)
    {
        BindgrdTrades();
    }
    protected void gridSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = gridSelect.SelectedRow;
            Response.Redirect("Update_Task.aspx?Id=" + row.Cells[1].Text);
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
    protected void txtDateFrom_TextChanged(object sender, EventArgs e)
    {
        BindgrdTrades();
    }
    protected void txtDateTo_TextChanged(object sender, EventArgs e)
    {
        BindgrdTrades();
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        Session["DateFrom"] = DateTime.Parse(txtDateFrom.Text).ToShortDateString();
        Session["DateTo"] = DateTime.Parse(txtDateTo.Text).ToShortDateString();
        Response.Redirect("ReportAllTask.aspx?Status=1");
    }
}