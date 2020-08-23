using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    databaseaccesslayer dataobj = new databaseaccesslayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Id"] != null)
            {
                Response.Redirect("MainPage.aspx");
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = @"select * from Ta_Users where UserName='" + txtName.Text + "' and UsePassword='" + txtPassword.Text + "'";
            DataTable dt = dataobj.Selectdatatable(sql);
            if (dt.Rows.Count == 1)
            {
                int Id = int.Parse(dt.Rows[0]["Id"].ToString());
                Session.Add("Id", dt.Rows[0]["Id"].ToString());
                Response.Redirect("MainPage.aspx");
            }
            else
            {
                txtName.Text = txtPassword.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            dataobj.Alert(ex.Message, this);
        }
    }
}