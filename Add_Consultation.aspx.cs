using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Add_Consultation : System.Web.UI.Page
{
    databaseaccesslayer dataObj = new databaseaccesslayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                string sql1 = @"select * from Application_Setting where User_Id=" + Session["Id"] + " and Appl_Id=21 and IsVaild=1";
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
                drpUser.DataSource = dataObj.Selectdatatable("select Id,UserName from Ta_Users");
                drpUser.DataTextField = "UserName";
                drpUser.DataValueField = "Id";
                drpUser.DataBind();
                drpUser.Items.Insert(0, "أختار المسئول");
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
            string sql = @"INSERT INTO [dbo].[Ta_Consultation]
           ([DateOfConsultation]
           ,[Employee_Id]
           ,[User_Id]
           ,[Type]
           ,[PublicRate]
           ,[Stage]
           ,[Subject]
           ,[Notes]
           ,[Description]
           ,[Answer])
     VALUES
           (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10)";
            dataObj.Execute(sql, DateTime.Parse(txtDate.Text).ToShortDateString(), drpEmployee.SelectedItem.Value,drpUser.SelectedItem.Value, txtType.Text,
                txtTasnif.Text,txtStage.Text,txtSubject.Text,txtNotes.Text,txtDescription.Text,txtAnswer.Text);
            helper.cleartxt(UpdatePanel1);
            drpUser.SelectedIndex = drpEmployee.SelectedIndex = 0;
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