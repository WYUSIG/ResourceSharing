using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Web.UI.HtmlControls;

public partial class 注册 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        String name1 = TextBox1.Text;
        String sex1 = RadioButtonList1.SelectedItem.Text;
        String phone1 = TextBox4.Text;
        //String headImage1=UP_FILE.Value;
        String pw1 = TextBox2.Text;
        String class1 = TextBox6.Text;
        String teacher1 = TextBox7.Text;
        
        String flag1;

        if (re_student.Checked==true)
        {
            flag1 = "学生";
        }
        else
        {
            flag1 = "教师";
        }
        String birthday1=TextBox8.Text;
        String sig1=TextBox9.Text;
        String school=TextBox10.Text;
        String selectSql = "SELECT * FROM [user] WHERE phone='" + phone1 + "'";
        int count = SqlHelp.SqlServerRecordCount(selectSql);//返回符合的结果数量
        
        if (count > 0)//如果信息>0表示该用户名已被占用
        { Response.Write("<script>alert('该电话号码已注册过')</script>"); }
        else
        {
            HttpFileCollection files = Request.Files;
            string filePath = Server.MapPath("~/Files/");
            if (avator_input.Value!="")
            {
                string fileName = files[0].FileName;
                String fileUUIDName = FileUtil.getUUID();
                files[0].SaveAs(System.IO.Path.Combine(filePath, fileUUIDName + FileUtil.FileSuffix(fileName)));
                //Response.Write("<script>alert('上传成功')</script>");
                String Sql = "INSERT INTO [user](name,sex,phone,headImage,password,class,taecher,flag,birthday,sig,school) values('" + name1 + "','" + sex1 + "','" + phone1 + "','" + fileUUIDName + FileUtil.FileSuffix(fileName) + "','" + pw1 + "','" + class1 + "','" + teacher1 + "','" + flag1 + "','" + birthday1 + "','" + sig1 + "','" + school + "')";

                SqlHelp.ExecuteNonQueryCount(Sql);
                insertSubscribe(phone1);
                Response.Write("<script>alert('注册成功')</script>");
                //Response.Redirect("登录.aspx", true);
            }
            else
            {
                Response.Write("<script>alert('未获取到文件')</script>");
                //Response.Write("<p>未获取到Files:" + files.Count.ToString() + "</p>");
            }
            

        }
    }
    
    

    private void insertSubscribe(String phone)
    {
        String selectsql = "SELECT id FROM [user] WHERE phone='"+phone+"'";
        String now = Time.getDataTime();
        
        try
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(selectsql);
            if (reader.Read())
            {
                String id = reader.GetInt32(0).ToString();
                String insertsql = "INSERT INTO subscribe(concern,concerned,time) values(" + id + "," + id + ",'" + now + "')";
                SqlHelp.ExecuteNonQueryCount(insertsql);
            }

        }
        catch (System.InvalidCastException e)
        {

        }
    }
}
