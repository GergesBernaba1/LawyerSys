using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Add_MoveIssue : System.Web.UI.Page
{
    databaseaccesslayer dataObj = new databaseaccesslayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                string sql1 = @"select * from Application_Setting where User_Id=" + Session["Id"] + " and Appl_Id=17 and IsVaild=1";
                DataTable dt1 = dataObj.Selectdatatable(sql1);
                if (dt1.Rows.Count != 1)
                {
                    Response.Redirect("MainPage.aspx");
                }
                addValidationGroup();
                drpIssueNumber.DataSource = dataObj.Selectdatatable("select Id,IssueNumber from Ta_Issue where IssaueStatus=1");
                drpIssueNumber.DataTextField = "IssueNumber";
                drpIssueNumber.DataValueField = "Id";
                drpIssueNumber.DataBind();
                drpIssueNumber.Items.Insert(0, "أختار رقم القضية");
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = @"INSERT INTO [dbo].[Ta_MoveIssue]
           ([Issue_Id]
           ,[DateOfMove]
           ,[NumberAppeal]
           ,[NumberVeto]
           ,[NumberExecution]
           ,[Notes])
     VALUES
           (@1,@2,@3,@4,@5,@6)";
            dataObj.Execute(sql, drpIssueNumber.SelectedItem.Value, DateTime.Parse(txtDate.Text).ToShortDateString(),txtNumAgain.Text,txtNumGanist.Text,txtNumWork.Text, txtNotes.Text);
                helper.cleartxt(UpdatePanel1);
                drpIssueNumber.SelectedIndex = 0;
                dataObj.Alert("تم الحفظ بنجاح", this);
        }
        catch (Exception ex)
        {
            dataObj.Alert(ex.Message, this);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("MainPage.aspx");
    }
}