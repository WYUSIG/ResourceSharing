using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

public partial class GM_info : System.Web.UI.Page
{
    string password = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        

        string sid = "";
        string sname = "";
        string sphone = "";
        

        string sql = "SELECT * FROM admintor WHERE phone = '" + Session["id"] + "'";
        int count = SqlHelp.SqlServerRecordCount(sql);
        if (count > 0)
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(sql);
            while (reader.Read())
            {
                try
                {
                     sid = reader.GetInt32(0).ToString();
                     sname = reader.GetString(1);
                     sphone = reader.GetString(2);
                     password = reader.GetString(3);

                    string str = "";
                    for (int i = 0; i < password.Length; i++)
                    {
                        str += "●";
                    }

                    id.Text = "     ID ："+sid;
                    name.Text = " 姓名 ：" + sname;
                    phone.Text = " 电话 ：" + sphone;
                    pw.Text = " 密码 ：" + str;
                
                }
                catch (System.InvalidCastException eee)
                {
                    Response.Write("<script>alert('系统出错')</script>");
                }
            }
            reader.Close();
        }
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {     
        string str="";
        if (Button1.Text.Equals("显示密码"))
        {
            pw.Text = " 密码 ：" + password;

            Button1.Text = "隐藏密码";
        }
        else
        {
            for (int i = 0; i < password.Length; i++)
            {
                str += "●";
            }
            pw.Text = " 密码 ：" + str;
            Button1.Text = "显示密码";
        }

    }
}