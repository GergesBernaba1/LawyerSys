using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Select_Sitting : System.Web.UI.Page
{
    databaseaccesslayer dataObj = new databaseaccesslayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                string sql1 = @"select * from Application_Setting where User_Id=" + Session["Id"] + " and Appl_Id=14 and IsVaild=1";
                DataTable dt1 = dataObj.Selectdatatable(sql1);
                if (dt1.Rows.Count != 1)
                {
                    Response.Redirect("MainPage.aspx");
                }
                drpIssueNumber.DataSource = dataObj.Selectdatatable("select Id,IssueNumber from Ta_Issue where IssaueStatus=1");
                drpIssueNumber.DataTextField = "IssueNumber";
                drpIssueNumber.DataValueField = "Id";
                drpIssueNumber.DataBind();
                drpIssueNumber.Items.Insert(0, "أختار رقم القضية");
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
            if (drpIssueNumber.SelectedIndex>0&&txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "")
            {
                gridSelect.DataSource = dataObj.Selectdatatable("select IssueNumber as رقم_القضية,HakamName as القاضي,SittingTime as الميعاد,SittingDate as التاريخ,s.Notes as ملاحظات from Ta_Sitting s left join Ta_Issue i on s.Issue_Id=i.Id where Type=1 and s.Issue_Id="+drpIssueNumber.SelectedItem.Value+" and SittingDate between '" + DateTime.Parse(txtDateFrom.Text).ToShortDateString() + "' and '" + DateTime.Parse(txtDateTo.Text).ToShortDateString() + "' order by i.Id desc");
                gridSelect.DataBind();
            }
            else if(drpIssueNumber.SelectedIndex>0)
            {
                gridSelect.DataSource = dataObj.Selectdatatable("select IssueNumber as رقم_القضية,HakamName as القاضي,SittingTime as الميعاد,SittingDate as التاريخ,s.Notes as ملاحظات from Ta_Sitting s left join Ta_Issue i on s.Issue_Id=i.Id where Type=1 and s.Issue_Id="+drpIssueNumber.SelectedItem.Value+" order by i.Id desc");
                gridSelect.DataBind();
            }
            else
            {
                gridSelect.DataSource = null;
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
            string sql = @"select * from Ta_Sitting where Issue_Id=" + drpIssueNumber.SelectedItem.Value + " and SittingDate='" + DateTime.Parse(row.Cells[4].Text).ToShortDateString() + "'";
            DataTable dt = dataObj.Selectdatatable(sql);
            if (dt.Rows.Count == 1)
            {
                Response.Redirect("Update_Sitting.aspx?Id=" + dt.Rows[0]["Id"].ToString());
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
    protected void txtDateFrom_TextChanged(object sender, EventArgs e)
    {
        BindgrdTrades();
    }
    protected void txtDateTo_TextChanged(object sender, EventArgs e)
    {
        BindgrdTrades();
    }
    protected void drpIssueNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindgrdTrades();
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReportSeetings.aspx?Id=" + drpIssueNumber.SelectedValue);
    }
}