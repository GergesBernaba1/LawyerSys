using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Add_Sitting : System.Web.UI.Page
{
    databaseaccesslayer dataObj = new databaseaccesslayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                string sql1 = @"select * from Application_Setting where User_Id=" + Session["Id"] + " and Appl_Id=13 and IsVaild=1";
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
            int x = 0;
            if (checkStatus.Checked == false)
            {
                x = 1;
            }
            string check = @"select * from Ta_Sitting where Issue_Id=" + drpIssueNumber.SelectedItem.Value + " and SittingDate='"+DateTime.Parse(txtDate.Text).ToShortDateString()+"'";
            DataTable dt = dataObj.Selectdatatable(check);
            if (dt.Rows.Count == 0)
            {
                string sql = @"INSERT INTO [dbo].[Ta_Sitting]
           ([Issue_Id]
           ,[HakamName]
           ,[SittingTime]
           ,[SittingDate]
           ,[AlertDate]
           ,[Notes]
           ,[Type])
     VALUES
           (@1,@2,@3,@4,@5,@6,@7)";
                dataObj.Execute(sql, drpIssueNumber.SelectedItem.Value,txtHakamName.Text, txtTime.Text,DateTime.Parse(txtDate.Text).ToShortDateString(),
                    DateTime.Parse(txtAlertDate.Text).ToShortDateString(), txtNotes.Text, x);
                helper.cleartxt(UpdatePanel1);
                drpIssueNumber.SelectedIndex  = 0;
                checkStatus.Checked = false;
                dataObj.Alert("تم الحفظ بنجاح", this);
            }
            else
            {
                dataObj.Alert("تم تحديد الجلسة من قبل", this);
            }
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