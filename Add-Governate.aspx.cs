using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Add_Governate : System.Web.UI.Page
{
    databaseaccesslayer dataObj = new databaseaccesslayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                string sql1 = @"select * from Application_Setting where User_Id=" + Session["Id"] + " and Appl_Id=40 and IsVaild=1";
                DataTable dt1 = dataObj.Selectdatatable(sql1);
                if (dt1.Rows.Count != 1)
                {
                    Response.Redirect("MainPage.aspx");
                }
                addValidationGroup();
                BindgrdTrades();
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
            string sql = @"select GovernateName as اسم_المحافظة from Ta_Governate";
            gridSelect.DataSource = dataObj.Selectdatatable(sql);
            gridSelect.DataBind();
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
     protected void gridSelect_SelectedIndexChanged(object sender, EventArgs e)
     {
          try
         {
             GridViewRow row = gridSelect.SelectedRow;
             string sql = @"delete from [dbo].[Ta_Governate] where [GovernateName]=@1";
             dataObj.Execute(sql, row.Cells[1].Text);
             BindgrdTrades();
             dataObj.Alert("Success", this);
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
             string sql = @"INSERT INTO [dbo].[Ta_Governate]([GovernateName]) VALUES(@1)";
             dataObj.Execute(sql, txtName.Text);
             helper.cleartxt(UpdatePanel1);
             BindgrdTrades();
             dataObj.Alert("Success", this);
         }
         catch (Exception ex)
         {
             dataObj.Alert(ex.Message, this);
         }
     }
}