using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Add_PlaceLawer : System.Web.UI.Page
{
    databaseaccesslayer dataObj = new databaseaccesslayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                string sql1 = @"select * from Application_Setting where User_Id=" + Session["Id"] + " and Appl_Id=41 and IsVaild=1";
                DataTable dt1 = dataObj.Selectdatatable(sql1);
                if (dt1.Rows.Count != 1)
                {
                    Response.Redirect("MainPage.aspx");
                }
                addValidationGroup();
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
            if (drpGovernate.SelectedIndex > 0)
            {
                string sqlcheck = "select * from [dbo].[Ta_LawerPlace] where Name='" + txtName.Text + "' and [Governate_Id]=" + drpGovernate.SelectedItem.Value;
                DataTable dt = dataObj.Selectdatatable(sqlcheck);
                if (dt.Rows.Count==0)
                {
                    string sql = @"INSERT INTO [dbo].[Ta_LawerPlace] ([Name],[Address],[Telephone],[Governate_Id],[Notes]) VALUES(@1,@2,@3,@4,@5)";
                    dataObj.Execute(sql, txtName.Text, txtAddress.Text, txtMobil.Text, drpGovernate.SelectedItem.Value, txtStatment.Text);
                    helper.cleartxt(UpdatePanel1);
                    drpGovernate.SelectedIndex = 0;
                    dataObj.Alert("Success", this);
                }
                else
                {
                    dataObj.Alert("هذه البيانات موجودة من قبل", this);
                }
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