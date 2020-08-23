using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Select_Employee : System.Web.UI.Page
{
    databaseaccesslayer dataObj = new databaseaccesslayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                string sql1 = @"select * from Application_Setting where User_Id=" + Session["Id"] + " and Appl_Id=6 and IsVaild=1";
                DataTable dt1 = dataObj.Selectdatatable(sql1);
                if (dt1.Rows.Count != 1)
                {
                    Response.Redirect("MainPage.aspx");
                }
                BindgrdTrades();
                
            }
            catch (Exception)
            {
                Response.Redirect("MainPage.aspx");
            }

        }
    }
    private void BindgrdTrades()
    {
        try
        {
            int x = 0;
            if (RadioType.SelectedValue == "نشط")
            {
                x = 1;
            }
            if (txtSearch.Text.Trim() != "")
            {
                gridSelect.DataSource = dataObj.Selectdatatable("select Id as الكود,EmployeeName as اسم_العميل,Adderss as العنوان,EmployeeType as نوع_العميل,EmployeeJob as المهنة,DateOfBirth as تاريخ_الميلاد,Nationality as الجنسية,NationalNumber as الرقم_القومي,Phone as الهاتف,Mobil as الموبيل,Email as الايميل,Notes as ملاحظات from Ta_Employee where Status="+x+" and EmployeeName like '%"+txtSearch.Text+"%'");
                gridSelect.DataBind();
            }
            else
            {
                gridSelect.DataSource = dataObj.Selectdatatable("select Id as الكود,EmployeeName as اسم_العميل,Adderss as العنوان,EmployeeType as نوع_العميل,EmployeeJob as المهنة,DateOfBirth as تاريخ_الميلاد,Nationality as الجنسية,NationalNumber as الرقم_القومي,Phone as الهاتف,Mobil as الموبيل,Email as الايميل,Notes as ملاحظات from Ta_Employee where Status="+x);
                gridSelect.DataBind();
            }
        }
        catch (Exception ex)
        {
            dataObj.Alert(ex.Message, this);
        }
    }
    protected void drpGovernate_TextChanged(object sender, EventArgs e)
    {
        BindgrdTrades();
    }
    protected void gridSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = gridSelect.SelectedRow;
            Response.Redirect("Update-Employee.aspx?Id=" + row.Cells[1].Text);
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
    protected void RadioType_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindgrdTrades();
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        Response.Redirect("MainReportEmployee.aspx");
    }
}