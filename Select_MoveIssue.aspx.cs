using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Select_MoveIssue : System.Web.UI.Page
{
    databaseaccesslayer dataObj = new databaseaccesslayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                string sql1 = @"select * from Application_Setting where User_Id=" + Session["Id"] + " and Appl_Id=18 and IsVaild=1";
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
            if (drpIssueNumber.SelectedIndex > 0)
            {
                gridSelect.DataSource = dataObj.Selectdatatable("select m.Id as كود_الحركة,IssueNumber as رقم_القضية,DateOfMove as التاريخ,NumberAppeal as محكمة_الاسئناف,NumberVeto as محكمة_النقض,NumberExecution as محكمة_التنفيذ,m.Notes as ملاحظات from Ta_MoveIssue m left join Ta_Issue i on m.Issue_Id=i.Id where m.Issue_Id=" + drpIssueNumber.SelectedItem.Value + " order by m.Id desc");
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
                Response.Redirect("Update_MoveIssue.aspx?Id=" + row.Cells[1].Text);
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
    protected void drpIssueNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindgrdTrades();
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReportMoveIssue.aspx?Id=" + drpIssueNumber.SelectedValue);
    }
}