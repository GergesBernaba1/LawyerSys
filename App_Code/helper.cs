using System;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Win32;

using System.Drawing;
/// <summary>
/// Summary description for helper
/// </summary>
public class helper
{
	public helper()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static void cleartxt(Control control)
    {
        Color emptxtbcolor = Color.Red;


        foreach (Control ctrl in control.Controls[0].Controls)
        {
            TextBox txtbx = ctrl as TextBox;
            if (txtbx != null)
            {
                txtbx.Text = "";

            }
        }







    }
}