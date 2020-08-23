using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IssueData : System.Web.UI.Page
{
    databaseaccesslayer dataObj = new databaseaccesslayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                string sql1 = @"select * from Application_Setting where User_Id=" + Session["Id"] + " and Appl_Id=10 and IsVaild=1";
                DataTable dt1 = dataObj.Selectdatatable(sql1);
                if (dt1.Rows.Count != 1)
                {
                    Response.Redirect("MainPage.aspx");
                }
                drpMahkama.DataSource = dataObj.Selectdatatable("select Id,Name from Ta_LawerPlace");
                drpMahkama.DataTextField = "Name";
                drpMahkama.DataValueField = "Id";
                drpMahkama.DataBind();
                drpMahkama.Items.Insert(0, "أختار المحكمة");
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
                if (Page.Request.QueryString["Id"] != "" && Page.Request.QueryString["Id"] != null)
                {
                    string sql = "select * from Ta_Issue where IssueNumber='" + Request.QueryString["Id"].ToString() + "'";
                    DataTable dt = dataObj.Selectdatatable(sql);
                    drpGovenate.SelectedValue = dt.Rows[0]["Governate_Id"].ToString();
                    drpMahkama.SelectedValue = dt.Rows[0]["PlaceLawer_Id"].ToString();
                    drpEmployee.SelectedValue = dt.Rows[0]["Employee_Id"].ToString();
                    drpUser.SelectedValue = dt.Rows[0]["User_Id"].ToString();
                    bool x = bool.Parse(dt.Rows[0]["IssaueStatus"].ToString());
                    if (x==true)
                    {
                        drpStatus.Text = "نشطة";
                    }
                    else
                    {
                        drpStatus.Text = "ارشيف";
                    }
                    txtNumber.Text = dt.Rows[0]["IssueNumber"].ToString();
                    txtName.Text = dt.Rows[0]["HakemName"].ToString();
                    txtNameLawer.Text = dt.Rows[0]["LawerName"].ToString();
                    txtTypeInvite.Text = dt.Rows[0]["InvitationType"].ToString();
                    txtInviteText.Text = dt.Rows[0]["InvitionStatment"].ToString();
                    txtInviteDate.Text = DateTime.Parse(dt.Rows[0]["InvitationDate"].ToString()).ToShortDateString();
                    txtGaintName.Text = dt.Rows[0]["AgainstName"].ToString();
                    txtGaintAddress.Text = dt.Rows[0]["AgainstAddress"].ToString();
                    txtGaintLawer.Text = dt.Rows[0]["LawerAgainstName"].ToString();
                    txtGaintLawerAddress.Text = dt.Rows[0]["LawerAgainstAdderss"].ToString();
                    txtAmount.Text = dt.Rows[0]["Amount"].ToString();
                    txtNotes.Text = dt.Rows[0]["Notes"].ToString();
                    Session["Code"] = dt.Rows[0]["Code"].ToString();
                    LoadData();
                }
                else
                {
                    Response.Redirect("Select_Issue.aspx");
                }
            }
            catch (Exception)
            {
                Response.Redirect("MainPage.aspx");
            }
        }
    }
    private void LoadData()
    {
        try
        {
            string file = "select Id as الكود,Path as المسار from Ta_IssueFiles where Type=1 and Code='" + Session["Code"] + "'";
            gridSelect.DataSource = dataObj.Selectdatatable(file);
            gridSelect.DataBind();
        }
        catch (Exception)
        {
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Select_Issue.aspx");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("Update_Issue.aspx?Id=" + Request.QueryString["Id"].ToString());
    }
    protected void gridSelect_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridSelect.PageIndex = e.NewPageIndex;
        LoadData();
    }
    protected void gridSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gridSelect.SelectedRow;
        string str = "select * from Ta_IssueFiles where Type=1 and Code='" + Session["Code"] + "' and Id=" + row.Cells[1].Text ;
        DataTable dt = dataObj.Selectdatatable(str);
        Response.Redirect(dt.Rows[0]["Path"].ToString());
    }
}