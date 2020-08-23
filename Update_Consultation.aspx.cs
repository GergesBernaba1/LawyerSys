using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Update_Consultation : System.Web.UI.Page
{
    databaseaccesslayer dataObj = new databaseaccesslayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                string sql1 = @"select * from Application_Setting where User_Id=" + Session["Id"] + " and Appl_Id=23 and IsVaild=1";
                DataTable dt1 = dataObj.Selectdatatable(sql1);
                if (dt1.Rows.Count != 1)
                {
                    Response.Redirect("Select_Consultation.aspx");
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
                if (Page.Request.QueryString["Id"] != "" && Page.Request.QueryString["Id"] != null)
                {
                    string sql = "select * from Ta_Consultation where Id='" + Request.QueryString["Id"].ToString() + "'";
                    DataTable dt = dataObj.Selectdatatable(sql);
                    txtNotes.Text = dt.Rows[0]["Notes"].ToString();
                    txtDate.Text = DateTime.Parse(dt.Rows[0]["DateOfConsultation"].ToString()).ToShortDateString();
                    txtType.Text = dt.Rows[0]["Type"].ToString();
                    drpEmployee.SelectedValue = dt.Rows[0]["Employee_Id"].ToString();
                    drpUser.SelectedValue = dt.Rows[0]["User_Id"].ToString();
                    txtTasnif.Text = dt.Rows[0]["PublicRate"].ToString();
                    txtStage.Text = dt.Rows[0]["Stage"].ToString();
                    txtSubject.Text = dt.Rows[0]["Subject"].ToString();
                    txtDescription.Text = dt.Rows[0]["Description"].ToString();
                    txtAnswer.Text = dt.Rows[0]["Answer"].ToString();
                }
                else
                {
                    Response.Redirect("Select_Consultation.aspx");
                }
            }
            catch (Exception)
            {

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
            string sql = @"UPDATE [dbo].[Ta_Consultation]
   SET [DateOfConsultation] = @1
      ,[Employee_Id] = @2
      ,[User_Id] = @3
      ,[Type] = @4
      ,[PublicRate] = @5
      ,[Stage] = @6
      ,[Subject] = @7
      ,[Notes] = @8
      ,[Description] = @9
      ,[Answer] = @10
 WHERE [Id]=@11";
            dataObj.Execute(sql, DateTime.Parse(txtDate.Text).ToShortDateString(), drpEmployee.SelectedItem.Value, drpUser.SelectedItem.Value, txtType.Text,
                txtTasnif.Text, txtStage.Text, txtSubject.Text, txtNotes.Text, txtDescription.Text, txtAnswer.Text, Request.QueryString["Id"].ToString());
            Response.Redirect("Select_Consultation.aspx");
        }
        catch (Exception ex)
        {
            dataObj.Alert(ex.Message, this);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Select_Consultation.aspx");
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = @"DELETE FROM [dbo].[Ta_Consultation] WHERE [Id] =@1";
            dataObj.Execute(sql, Request.QueryString["Id"].ToString());
            Response.Redirect("Select_Consultation.aspx");
        }
        catch (Exception ex)
        {
            dataObj.Alert(ex.Message, this);
        }
    }
}