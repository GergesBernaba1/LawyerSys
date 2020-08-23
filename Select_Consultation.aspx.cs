using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Select_Consultation : System.Web.UI.Page
{
    databaseaccesslayer dataObj = new databaseaccesslayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                string sql1 = @"select * from Application_Setting where User_Id=" + Session["Id"] + " and Appl_Id=22 and IsVaild=1";
                DataTable dt1 = dataObj.Selectdatatable(sql1);
                if (dt1.Rows.Count != 1)
                {
                    Response.Redirect("MainPage.aspx");
                }
                drpEmployee.DataSource = dataObj.Selectdatatable("select Id,EmployeeName from Ta_Employee where Status=1");
                drpEmployee.DataTextField = "EmployeeName";
                drpEmployee.DataValueField = "Id";
                drpEmployee.DataBind();
                drpEmployee.Items.Insert(0, "اختار العميل");
                addValidationGroup();
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
            if (drpEmployee.SelectedIndex > 0 && txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "")
            {
                gridSelect.DataSource = dataObj.Selectdatatable("select c.Id as الكود,EmployeeName as العميل,UserName as المسئول,Type as نوع_الاستشارة,PublicRate as التصنيف_العام,Stage as المرحلة_الحالية,Subject as الموضوع from Ta_Consultation c left join Ta_Employee e on c.Employee_Id=e.Id left join Ta_Users u on c.User_Id=u.Id where c.Employee_Id=" + drpEmployee.SelectedItem.Value + " and DateOfConsultation between '" + DateTime.Parse(txtDateFrom.Text).ToShortDateString() + "' and '" + DateTime.Parse(txtDateTo.Text).ToShortDateString() + "' order by DateOfConsultation desc");
                gridSelect.DataBind();
            }
            else if (drpEmployee.SelectedIndex > 0)
            {
                gridSelect.DataSource = dataObj.Selectdatatable("select c.Id as الكود,EmployeeName as العميل,UserName as المسئول,Type as نوع_الاستشارة,PublicRate as التصنيف_العام,Stage as المرحلة_الحالية,Subject as الموضوع from Ta_Consultation c left join Ta_Employee e on c.Employee_Id=e.Id left join Ta_Users u on c.User_Id=u.Id where c.Employee_Id="+drpEmployee.SelectedItem.Value+" order by DateOfConsultation desc");
                gridSelect.DataBind();
            }
            else
            {
                gridSelect.DataSource = null;
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
    protected void gridSelect_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridSelect.PageIndex = e.NewPageIndex;
        BindgrdTrades();
    }
    protected void txtDateFrom_TextChanged(object sender, EventArgs e)
    {
        BindgrdTrades();
    }
    protected void txtDateTo_TextChanged(object sender, EventArgs e)
    {
        BindgrdTrades();
    }
    protected void drpEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindgrdTrades();
    }
    protected void gridSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        try {
            GridViewRow row = gridSelect.SelectedRow;
            Response.Redirect("Update_Consultation.aspx?Id=" + row.Cells[1].Text);
        }
        catch (Exception ex)
        {
            dataObj.Alert(ex.Message, this);
        }
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        Session["DateFrom"] = DateTime.Parse(txtDateFrom.Text).ToShortDateString();
        Session["DateTo"] = DateTime.Parse(txtDateTo.Text).ToShortDateString();
        Response.Redirect("ReportConsultion.aspx?Id=" + drpEmployee.SelectedValue);
    }
}