using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Add_Issue : System.Web.UI.Page
{
    databaseaccesslayer dataObj = new databaseaccesslayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
            string sql1 = @"select * from Application_Setting where User_Id=" + Session["Id"] + " and Appl_Id=9 and IsVaild=1";
            DataTable dt1 = dataObj.Selectdatatable(sql1);
            if (dt1.Rows.Count != 1)
            {
                Response.Redirect("MainPage.aspx");
            }
            addValidationGroup();
            generateguid();
            drpGovenate.DataSource = dataObj.Selectdatatable("select Id,GovernateName from Ta_Governate");
            drpGovenate.DataTextField = "GovernateName";
            drpGovenate.DataValueField = "Id";
            drpGovenate.DataBind();
            drpGovenate.Items.Insert(0, "أختار المحافظة");
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
            drpStatus.Items.Insert(0, "اختار الحالة");
            drpStatus.Items.Insert(1, "نشطة");
            drpStatus.Items.Insert(2, "ارشيف");

            }
            catch (Exception)
            {
                Response.Redirect("MainPage.aspx");
            }
        }
    }
    private void generateguid()
    {
        Guid autocode = Guid.NewGuid();
        string Code = autocode.ToString().Substring(0, 8);
        ViewState["Code"] = Code;
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
    protected void drpGovenate_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (drpGovenate.SelectedIndex > 0)
            {
                drpMahkama.DataSource = dataObj.Selectdatatable("select Id,Name from Ta_LawerPlace where Governate_Id=" + drpGovenate.SelectedItem.Value);
                drpMahkama.DataTextField = "Name";
                drpMahkama.DataValueField = "Id";
                drpMahkama.DataBind();
                drpMahkama.Items.Insert(0, "أختار المحكمة");
            }
            else
            {
                drpMahkama.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            dataObj.Alert(ex.Message, this);
        }
    }
    protected void btnUploadImage_Click(object sender, EventArgs e)
    {
        try
        {
            if (FileUpload1.HasFile)
            {
                HttpFileCollection hfc = Request.Files;
                for (int i = 0; i < hfc.Count; i++)
                {
                    HttpPostedFile hpf = hfc[i];
                    if (hpf.ContentLength > 0)
                    {
                        string strs = ViewState["Code"].ToString() + "-" + DateTime.Now.Second + "-" + i + "-" + "0.jpg";
                        hpf.SaveAs(Server.MapPath(".") + "/IssueFiles/" + strs);
                        string path = "IssueFiles/" + strs.ToString();
                        string strimge = @"INSERT INTO [dbo].[Ta_IssueFiles]
           ([Code]
           ,[Path]
           ,[Type])
     VALUES
           (@1,@2,@3)";
                        dataObj.Execute(strimge, ViewState["Code"].ToString(), path, 0);
                        dataObj.Alert("Success", this);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            dataObj.Alert(ex.Message, this);
        }
    }
    protected void btnUploadFile_Click(object sender, EventArgs e)
    {
        try
        {
            if (FileUpload2.HasFile)
            {
                HttpFileCollection hfc = Request.Files;
                for (int i = 0; i < hfc.Count; i++)
                {
                    HttpPostedFile hpf = hfc[i];
                    if (hpf.ContentLength > 0)
                    {
                        string strs = ViewState["Code"].ToString() +"-"+ DateTime.Now.Second +"-"+ i +"-"+ "1.pdf";
                        hpf.SaveAs(Server.MapPath(".") + "/IssueFiles/" + strs);
                        string path = "IssueFiles/" + strs.ToString();
                        string strimge = @"INSERT INTO [dbo].[Ta_IssueFiles]
           ([Code]
           ,[Path]
           ,[Type])
     VALUES
           (@1,@2,@3)";
                        dataObj.Execute(strimge, ViewState["Code"].ToString(), path, 1);
                        dataObj.Alert("Success", this);
                    }
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
        try
        {
            string del = @"delete from Ta_IssueFiles where Code=@1";
            dataObj.Execute(del, ViewState["Code"].ToString());
            Response.Redirect("MainPage.aspx");
        }
        catch (Exception ex)
        {
            dataObj.Alert(ex.Message, this);
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
            string sql = @"INSERT INTO [dbo].[Ta_Issue]
           ([Code]
           ,[Governate_Id]
           ,[PlaceLawer_Id]
           ,[IssueNumber]
           ,[HakemName]
           ,[Employee_Id]
           ,[LawerName]
           ,[User_Id]
           ,[InvitationType]
           ,[InvitionStatment]
           ,[InvitationDate]
           ,[AgainstName]
           ,[AgainstAddress]
           ,[LawerAgainstName]
           ,[LawerAgainstAdderss]
           ,[IssaueStatus]
           ,[Amount]
           ,[Notes])
     VALUES
           (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18)";
            dataObj.Execute(sql, ViewState["Code"].ToString(), drpGovenate.SelectedItem.Value, drpMahkama.SelectedItem.Value, txtNumber.Text, txtName.Text, drpEmployee.SelectedItem.Value,
                txtNameLawer.Text, drpUser.SelectedItem.Value, txtTypeInvite.Text, txtInviteText.Text, DateTime.Parse(txtInviteDate.Text).ToShortDateString(), txtGaintName.Text,
                txtGaintAddress.Text, txtGaintLawer.Text, txtGaintLawerAddress.Text, x, float.Parse(txtAmount.Text), txtNotes.Text);
            string Up = @"UPDATE [dbo].[Ta_Employee]
   SET [Balance] = [Balance]+@1
 WHERE [Id]=@2";
            dataObj.Execute(Up,float.Parse(txtAmount.Text),drpEmployee.SelectedItem.Value);

            string pay = @"INSERT INTO [dbo].[Ta_PayMoney]
           ([DateOfOperation]
           ,[Employee_Id]
           ,[Amount]
           ,[Notes],[Type])
     VALUES
           (@1,@2,@3,@4,@5)";
            dataObj.Execute(pay, DateTime.Now.ToShortDateString(), drpEmployee.SelectedItem.Value, float.Parse(txtAmount.Text), "حساب القضية","سند دفع");

            helper.cleartxt(UpdatePanel1);
            helper.cleartxt(UpdatePanel2);
            drpStatus.SelectedIndex = drpEmployee.SelectedIndex = drpGovenate.SelectedIndex = drpUser.SelectedIndex = 0;
            drpMahkama.Items.Clear();
            generateguid();
            dataObj.Alert("تم الحفظ بنجاح", this);
        }
        catch (Exception ex)
        {
            dataObj.Alert(ex.Message, this);
        }
    }
}