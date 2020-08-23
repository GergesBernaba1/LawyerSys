using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Add_Employee : System.Web.UI.Page
{
    databaseaccesslayer dataObj = new databaseaccesslayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                string sql1 = @"select * from Application_Setting where User_Id=" + Session["Id"] + " and Appl_Id=5 and IsVaild=1";
                DataTable dt1 = dataObj.Selectdatatable(sql1);
                if (dt1.Rows.Count != 1)
                {
                    Response.Redirect("MainPage.aspx");
                }
                addValidationGroup();
                //drpDescrip.DataSource = dataObj.Selectdatatable("select Id,TypeDescription from Ta_EmployeeDescription");
                //drpDescrip.DataTextField = "TypeDescription";
                //drpDescrip.DataValueField = "Id";
                //drpDescrip.DataBind();
                //drpDescrip.Items.Insert(0, "اختار الصفة");
                drpType.Items.Insert(0, "نوع العميل");
                drpType.Items.Insert(1, "أفراد");
                drpType.Items.Insert(2, "شركات");
                drpStatus.Items.Insert(0, "اختار الحالة");
                drpStatus.Items.Insert(1, "نشط");
                drpStatus.Items.Insert(2, "غير نشط");
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
            if (drpStatus.SelectedIndex==1)
            {
                x = 1;
            }
            string sql = @"INSERT INTO [dbo].[Ta_Employee]
           ([EmployeeName]
           ,[Adderss]
           ,[EmployeeType]
           ,[EmployeeJob]
           ,[DateOfBirth]
           ,[Nationality]
           ,[NationalNumber]
           ,[Phone]
           ,[Mobil]
           ,[Email]
           ,[AnotherContact]
           ,[Status]
           ,[Notes],[Balance])
     VALUES
           (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14)";
            dataObj.Execute(sql, txtName.Text,txtAddress.Text, drpType.Text, txtCareer.Text, DateTime.Parse(txtDate.Text).ToShortDateString(),
                txtNationality.Text, txtNationalNumber.Text, txtPhone.Text, txtMobil.Text, txtMail.Text, txtAnother.Text, x , txtNotes.Text,0);
            helper.cleartxt(UpdatePanel1);
            drpStatus.SelectedIndex = drpType.SelectedIndex = 0;
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