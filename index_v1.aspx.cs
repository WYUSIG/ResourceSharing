using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class index_v1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id"] == null || Session["pwd"] == null)
        {
            Response.Redirect("登录.aspx", true);
        }
        initAdmin();
    }
    private void initAdmin()
    {
        string sql = "SELECT * FROM admintor WHERE phone = '" + Session["id"] + "'";
        try
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(sql);
            if (reader.Read())
            {
                String name = reader.GetString(1);
                user_name.InnerText = name;
            }
            
        }
        catch (System.InvalidCastException e)
        {
            
        }
    }
}