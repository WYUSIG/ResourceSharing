﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Web.UI.HtmlControls;

public partial class posting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void submit_click(object sender, EventArgs e)
    {
        String title = Request["publish_title"];
        String lable = Request["publish_lable"];
        String content = publish_content.Value;
        Boolean b = content.IndexOf("\r\n") > 0;
        Boolean a = content.IndexOf("\n") > 0;
        String now = Time.getDataTime();
        String insertsql = "INSERT INTO [publish](userId,content,time,title,flag) VALUES(10000,'"+content+"','"+now+"','"+title+"','"+lable+"')";
        try
        {
            SqlHelp.ExecuteNonQueryCount(insertsql);
            
        }
        catch (System.InvalidCastException ee)
        {
            
        }
        //if (a == true || b == true)
        //{
        //    Response.Write(b);
            //Response.Write("<script>alert('有换行符')</script>");
        //}
    }
}