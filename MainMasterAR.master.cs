﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MainMasterAR : System.Web.UI.MasterPage
{
    databaseaccesslayer dataobj = new databaseaccesslayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                string setting = "select * from Ta_Sitting where AlertDate='" + DateTime.Now.ToShortDateString() + "' and Type=1";
                DataTable settingcount = dataobj.Selectdatatable(setting);
                string Task = "select * from Ta_Task where DateOfAlert='" + DateTime.Now.ToShortDateString() + "' and Status=1";
                DataTable TaskCount = dataobj.Selectdatatable(Task);
                if (TaskCount.Rows.Count > 0 || settingcount.Rows.Count>0)
                {
                    div.Visible = true;
                }
            }
            catch (Exception)
            {
                Response.Redirect("MainPage.aspx");
            }

        }
    }
}
