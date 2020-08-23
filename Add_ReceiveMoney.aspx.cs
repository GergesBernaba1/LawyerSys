using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Add_ReceiveMoney : System.Web.UI.Page
{
    databaseaccesslayer dataObj = new databaseaccesslayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                string sql1 = @"select * from Application_Setting where User_Id=" + Session["Id"] + " and Appl_Id=34 and IsVaild=1";
                DataTable dt1 = dataObj.Selectdatatable(sql1);
                if (dt1.Rows.Count != 1)
                {
                    Response.Redirect("MainPage.aspx");
                }
                addValidationGroup();
                drpEmployee.DataSource = dataObj.Selectdatatable("select Id,EmployeeName from Ta_Employee where Status=1");
                drpEmployee.DataTextField = "EmployeeName";
                drpEmployee.DataValueField = "Id";
                drpEmployee.DataBind();
                drpEmployee.Items.Insert(0, "اختار العميل");
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
            string sql = @"INSERT INTO [dbo].[Ta_PayMoney]
           ([DateOfOperation]
           ,[Employee_Id]
           ,[Amount]
           ,[Notes]
           ,[Type])
     VALUES
           (@1,@2,@3,@4,@5)";
            dataObj.Execute(sql, DateTime.Parse(txtDate.Text), drpEmployee.SelectedItem.Value, float.Parse(txtAmount.Text), txtNotes.Text, "سند قبض");

            string Up = @"UPDATE [dbo].[Ta_Employee]
   SET [Balance] = [Balance]-@1
 WHERE [Id]=@2";
            dataObj.Execute(Up, float.Parse(txtAmount.Text), drpEmployee.SelectedItem.Value);

            helper.cleartxt(UpdatePanel1);
            drpEmployee.SelectedIndex = 0;
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