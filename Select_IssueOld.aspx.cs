using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Select_IssueOld : System.Web.UI.Page
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
            if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "")
            {
                gridSelect.DataSource = dataObj.Selectdatatable("select IssueNumber as رقم_القضية,i.InvitationDate as تاريخ_الدعوة,EmployeeName as العميل,u.UserName as المسئول,AgainstName as الخصم from Ta_Issue i left join Ta_Employee e on i.Employee_Id=e.Id left join Ta_Users u on i.User_Id=u.Id where IssaueStatus=0 and i.InvitationDate between '" + DateTime.Parse(txtDateFrom.Text).ToShortDateString() + "' and '" + DateTime.Parse(txtDateTo.Text).ToShortDateString() + "' order by i.InvitationDate desc");
                gridSelect.DataBind();
            }
            else
            {
                gridSelect.DataSource = dataObj.Selectdatatable("select IssueNumber as رقم_القضية,i.InvitationDate as تاريخ_الدعوة,EmployeeName as العميل,u.UserName as المسئول,AgainstName as الخصم from Ta_Issue i left join Ta_Employee e on i.Employee_Id=e.Id left join Ta_Users u on i.User_Id=u.Id where IssaueStatus=0 order by i.InvitationDate desc");
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
            Response.Redirect("IssueData.aspx?Id=" + row.Cells[1].Text);
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
    protected void txtDateFrom_TextChanged(object sender, EventArgs e)
    {
        BindgrdTrades();
    }
    protected void txtDateTo_TextChanged(object sender, EventArgs e)
    {
        BindgrdTrades();
    }
}