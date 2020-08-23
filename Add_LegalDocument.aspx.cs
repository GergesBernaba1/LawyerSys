using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Add_LegalDocument : System.Web.UI.Page
{
    databaseaccesslayer dataObj = new databaseaccesslayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                string sql1 = @"select * from Application_Setting where User_Id=" + Session["Id"] + " and Appl_Id=29 and IsVaild=1";
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
                drpType.Items.Insert(0, "اختار نوع الوثيقة");
                drpType.Items.Insert(1, "وكالة عامة");
                drpType.Items.Insert(2, "وكالة خاصة");
                drpType.Items.Insert(3, "وكالة عدلية");
                drpType.Items.Insert(4, "إقرار");
                drpType.Items.Insert(5, "سند دين منظم");
                drpType.Items.Insert(6, "تعهد عدلي");
                drpType.Items.Insert(7, "صك ملكية");
                drpType.Items.Insert(8, "أخري");
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
            string sql = @"INSERT INTO [dbo].[Ta_LegalDocument]
           ([Employee_Id]
           ,[Number]
           ,[DocumentType]
           ,[Details]
           ,[DocumentNumber]
           ,[Notes])
     VALUES
           (@1,@2,@3,@4,@5,@6)";
            dataObj.Execute(sql, drpEmployee.SelectedItem.Value, txtNumber.Text, drpType.Text, txtDetails.Text,txtDocumentNumber.Text, txtNotes.Text);
            helper.cleartxt(UpdatePanel1);
            drpType.SelectedIndex = drpEmployee.SelectedIndex = 0;
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