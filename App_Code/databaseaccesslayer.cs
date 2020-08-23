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

using System.Web.Script.Serialization;
    public class databaseaccesslayer
    {
        #region sql server connection string
        //public static string ERPConnectionString = @"Server=142.4.219.154\SQLEXP2016;Database=antoneid_Lawer;uid=antoneid;pwd=Anton12345;"; //

        /// <summary>
        /// change the connection string name to your connection string in the webconfig
        /// </summary>
        public static string ERPConnectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Lawer;Data Source=."; //
       /// <summary>
       /// create connection
       /// </summary>
       /// <returns></returns>
        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(ERPConnectionString);
        }

        public databaseaccesslayer()
        { }
        /// <summary>
        /// return data table from database without parameters
        /// </summary>
        /// <param name="SelectStatement"></param>
        /// <returns></returns>
        public DataTable Selectdatatable(string SelectStatement)
        {
            SqlConnection Conn = CreateConnection();
            Conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(SelectStatement, Conn);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            Conn.Close();

            return dt;
        }
       /// <summary>
        /// return data table from database using sql parameters
       /// </summary>
       /// <param name="SelectStatement"></param>
       /// <param name="parameters"></param>
       /// <returns></returns>
        public DataTable Selectdatatable(string SelectStatement, params object[] parameters)
        {
            SqlConnection Conn = CreateConnection();
            Conn.Open();

            SqlCommand cmd = new SqlCommand(SelectStatement, Conn);
            int index = 0;
            foreach (object parameter in parameters)
            {
                index++;
                SqlParameter sp = new SqlParameter("@" + index.ToString(), parameter);
                sp.Value = (parameter);
                cmd.Parameters.Add(sp);
            }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            Conn.Close();

            return dt;

        }
        /// <summary>
        /// insert data to database
        /// </summary>
        /// <param name="insertStatement"></param>
        public void insertdata(string insertStatement)
        {
            SqlConnection Conn = CreateConnection();
            SqlCommand cmd = new SqlCommand(insertStatement, Conn);
            Conn.Open();
            cmd.ExecuteNonQuery();
            Conn.Close();
        }
       
        /// <summary>
        /// update data in database
        /// </summary>
        /// <param name="updatesql"></param>
        public void updateordeletedata(string updatesql)
        {
            SqlConnection Conn = CreateConnection();
            SqlCommand cmd = new SqlCommand(updatesql, Conn);
            Conn.Open();
            cmd.ExecuteNonQuery();
            Conn.Close();

        }
        
        /// <summary>
        /// return one decimal value from databse (the frist value in the frist Column in frist selected row)
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        public decimal Excute_single(string Query)
        {
            decimal x;
            SqlConnection conn = new SqlConnection(ERPConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(Query, conn);
            try
            {
                x = Convert.ToDecimal(cmd.ExecuteScalar());

                conn.Close();
                return x;
            }
            catch
            {
                conn.Close();
                return 0;
            }
        }
        /// <summary>
        /// return only one string value from database (the frist value in the frist Column in frist selected row)
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        public string getsinglestring(string Query)
        {
            string x;
            SqlConnection conn = new SqlConnection(ERPConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(Query, conn);
            try
            {
                x = Convert.ToString(cmd.ExecuteScalar());

                conn.Close();
                return x;
            }
            catch
            {
                conn.Close();
                return "";
            }
        }

        /// <summary>
        /// return only one datatime value from database (the frist value in the frist Column in frist selected row)
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>

        public string getsingledatetime(string Query)
        {
            string x;
            SqlConnection conn = new SqlConnection(ERPConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(Query, conn);
            try
            {
                x = Convert.ToDateTime(cmd.ExecuteScalar()).ToShortDateString();

                conn.Close();
                return x;
            }
            catch
            {
                conn.Close();
                return "";
            }
        }
       /// <summary>
       ///  execute insert or update or delete query using sql paramters
       /// </summary>
       /// <param name="sqlStatment"></param>
       /// <param name="parameters"></param>
       /// <returns></returns>
        public int Execute(string sqlStatment, params object[] parameters)
        {

            SqlConnection conn = new SqlConnection(ERPConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlStatment, conn);
            int index = 0;
            foreach (object parameter in parameters)
            {
                index++;
                cmd.Parameters.Add(new SqlParameter("@" + index.ToString(), parameter));
            }

            int val=cmd.ExecuteNonQuery();
            conn.Close();

            return val;
        }


        public int Executedate(string sqlStatment, params object[] parameters)
        {

            SqlConnection conn = new SqlConnection(ERPConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlStatment, conn);
            int index = 0;
            foreach (object parameter in parameters)
            {
                index++;
                cmd.Parameters.Add(new SqlParameter("@" + index.ToString(), parameter));
            }

            int val = cmd.ExecuteNonQuery();
            conn.Close();

            return val;
        }
        public int update(string sqlStatment, params object[] parameters)
        {

            SqlConnection conn = new SqlConnection(ERPConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlStatment, conn);
            int index = 0;
            foreach (object parameter in parameters)
            {
                index++;
                cmd.Parameters.Add(new SqlParameter("@" + index.ToString(), parameter));
            }

            int val = cmd.ExecuteNonQuery();
            conn.Close();

            return val;
        }
        /// <summary>
        /// return only one object value from database (the frist value in the frist Column in frist selected row)
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        public object get_single_value(string Query)
        {
            object x;
            SqlConnection conn = new SqlConnection(ERPConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(Query, conn);
            try
            {
                x = cmd.ExecuteScalar();

                conn.Close();
                return x;
            }
            catch
            {
                conn.Close();

                return 0;
            }

           
        }

        /// <summary>
        /// get the last index in data table
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="columnname"></param>
        /// <returns></returns>

        public int getthelastindex(string tablename,string columnname)
        {
           
            string sql = @"SELECT * FROM "+tablename+" WHERE " + columnname + " = (    SELECT IDENT_CURRENT('"+tablename+"'))";
            try
            {
                return Convert.ToInt32( get_single_value(sql));
               
            }
            catch 
            {
              
                return 0;
            }
        
        }
        /// <summary>
        /// show message box from server side code
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="page"></param>
        public void Alert(string msg, Control page)
        {
            var message = new JavaScriptSerializer().Serialize(msg.ToString());
            var script = string.Format("alert({0});", message);
            ScriptManager.RegisterClientScriptBlock(page, this.GetType(), "", script, true);
       
        }

        public void Alert2(string msg, Control page)
        {
            var message = new JavaScriptSerializer().Serialize(msg.ToString());
            var script = string.Format("window.onbeforeunload = function() { return '{0}'; };", message);
            ScriptManager.RegisterClientScriptBlock(page, this.GetType(), "", script, true);

        }


        public void AlertofException(string msg, Control page,string Exceptionidentifier)
        {
           if (msg.Contains("Cannot insert duplicate key"))
            {
                msg = " you can not insert  " + " " + Exceptionidentifier + " " + "    more than one ";
            }
            var message = new JavaScriptSerializer().Serialize(msg.ToString());

            var script = string.Format("alert({0});", message);
            ScriptManager.RegisterClientScriptBlock(page, this.GetType(), "", script, true);
           
        }


        public void openprintwindow(string pagename, Control page)
        {
           // var message = new JavaScriptSerializer().Serialize(msg.ToString());
            var script = string.Format(" window.showModalDialog('{0}','','');", pagename);
            ScriptManager.RegisterClientScriptBlock(page, this.GetType(), "", script, true);

        }

         //function fnOpen() {
         // var sFeatures = fnSetValues();
         // window.showModalDialog("test.aspx", "", sFeatures)
        
        #endregion
    }

