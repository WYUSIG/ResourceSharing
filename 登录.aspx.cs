using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class 登录 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        String id = account.Text;
        String pw = PW.Text;
        String flag2 = RadioButtonList1.SelectedItem.Text;
        if (flag2 == "教师" || flag2 == "学生")
        {
            String selectSql = "SELECT * FROM [user] WHERE phone='" + id + "'";
            int count = SqlHelp.SqlServerRecordCount(selectSql);//返回符合的结果数量
            
        
            if (count > 0)//如果信息>0则说明匹配成功
            {
                SqlDataReader reader = SqlHelp.GetDataReaderValue(selectSql);
                while (reader.Read())
                {
                    try
                    {
                        String b = reader.GetString(5);

                        if (b.Equals(pw))
                        {
                            Session["id"] = account.Text;
                            Session["pwd"] = PW.Text;
                            Session["role"] = RadioButtonList1.SelectedItem.Text;
                            //Response.Redirect("index.aspx?id=" + Session["id"]);
                            Response.Write("<script>alert('登陆成功')</script>");
                            Response.Redirect("index.aspx", true);
                        }
                        else
                        {
                            Response.Write("<script>alert('密码错误')</script>");

                        }
                    }
                    catch (System.InvalidCastException eee)
                    {
                        Response.Write("<script>alert('系统出错')</script>");

                    }
                }
                reader.Close();
                SqlHelp.CloseConn();
            }
            else
            {
                Response.Write("<script>alert('账号不存在')</script>");
            }
        }
        else {
            
            String selectSql1 = "SELECT * FROM [admintor] WHERE phone='" + id+ "'";
            int count1 = SqlHelp.SqlServerRecordCount(selectSql1);//返回符合的结果数量
            if (count1 > 0)//如果信息>0则说明匹配成功
            {
                SqlDataReader reader = SqlHelp.GetDataReaderValue(selectSql1);
                while (reader.Read())
                {
                    try
                    {
                        String b = reader.GetString(3);

                        if (b.Equals(pw))
                        {
                            //Session["id"] = account.Text;
                            //Session["pwd"] = PW.Text;
                            //Session["role"] = RadioButtonList1.SelectedItem.Text;
                            //Response.Redirect("index.aspx?id=" + Session["id"]);
                            Response.Write("<script>alert('登陆成功')</script>");
                            Session["id"] = account.Text;
                            Session["pwd"] = PW.Text;
                            Session["role"] = RadioButtonList1.SelectedItem.Text;
                            Response.Redirect("index_v1.aspx", true);
                        }
                        else
                        {
                            Response.Write("<script>alert('密码错误')</script>");

                        }
                    }
                    catch (System.InvalidCastException ec)
                    {
                        Response.Write("<script>alert('系统出错')</script>");

                    }
                }
                reader.Close();
                SqlHelp.CloseConn();
            }
            else
            {
                Response.Write("<script>alert('账号不存在')</script>");
            }
        }
    }
   
    
}