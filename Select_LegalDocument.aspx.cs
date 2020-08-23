using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Select_LegalDocument : System.Web.UI.Page
{
    databaseaccesslayer dataObj = new databaseaccesslayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                string sql1 = @"select * from Application_Setting where User_Id=" + Session["Id"] + " and Appl_Id=30 and IsVaild=1";
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
            if (drpEmployee.SelectedIndex > 0)
            {
                gridSelect.DataSource = dataObj.Selectdatatable("select l.Id as الكود,EmployeeName as العميل,Number as رقم_الوكالة,DocumentType as نوع_الوثيقة,Details as تفاصيل,DocumentNumber as رقم_الوثيقة,l.Notes as ملاحظات from Ta_LegalDocument l left join Ta_Employee e on l.Employee_Id=e.Id where Employee_Id=" + drpEmployee.SelectedItem.Value + " order by l.Id desc");
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
    protected void gridSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = gridSelect.SelectedRow;
                Response.Redirect("Update_LegalDocument.aspx?Id=" + row.Cells[1].Text);
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
    protected void drpEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindgrdTrades();
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReportDocumentLegal.aspx?Id=" + drpEmployee.SelectedValue);
    }
}