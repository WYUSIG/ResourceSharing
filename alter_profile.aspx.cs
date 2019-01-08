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

public partial class alter_profile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id"] == null || Session["pwd"] == null)
        {
            Response.Redirect("登录.aspx", true);
        }
        initUser(getUserIdByPhone(Session["id"].ToString()));
    }

    protected void submit_click(object sender, EventArgs e)
    {
        String newPhone = phone.Value;
        String newName = name.Value;
        String newSex;
        if(optionsRadios1.Checked == true)
        {
            newSex = "男";
        }
        else
        {
            newSex = "女";
        }
        String newPassword = user_password.Value;
        String newSchool = school.Value;
        String newClass = user_class.Value;
        String newTeacher = teacher.Value;
        String newBirthday = birthday.Value;
        String newSig = sig.Value;
        String userPhone = Session["id"].ToString();
        String userId = getUserIdByPhone(userPhone);
        if (checkPhone(userId, newPhone) == false)
        {
            Response.Write("<script>alert('电话与其他用户重复')</script>");
            return;
        }
        HttpFileCollection files = Request.Files;
        String filePath = Server.MapPath("~/Files/");
        String fileName=null;
        String fileUUIDName = null;
        String updatesql;
        if (avatar_input.Value != "")
        {
            fileName = files[0].FileName;
            fileUUIDName = FileUtil.getUUID();
            files[0].SaveAs(System.IO.Path.Combine(filePath, fileUUIDName + FileUtil.FileSuffix(fileName)));
            updatesql = "UPDATE  [user] SET name='" + newName + "',sex='" + newSex + "',phone='" + newPhone + "',password='" + newPassword + "',class='" + newClass + "',taecher='" + newTeacher + "',birthday='" + newBirthday + "',sig='" + newSig + "',school='" + newSchool + "',headImage='" + fileUUIDName + FileUtil.FileSuffix(fileName) + "' WHERE id=" + userId;
        }
        else
        {
            updatesql = "UPDATE  [user] SET name='" + newName + "',sex='" + newSex + "',phone='" + newPhone + "',password='" + newPassword + "',class='" + newClass + "',taecher='" + newTeacher + "',birthday='" + newBirthday + "',sig='" + newSig + "',school='" + newSchool + "' WHERE id=" + userId;
        }
        
        try
        {
            SqlHelp.ExecuteNonQueryCount(updatesql);
            Response.Write("<script>alert('修改成功')</script>");
        }
        catch (System.InvalidCastException ee)
        {
            Response.Write("<script>alert('修改失败')</script>");
        }
        
    }
    private String getUserIdByPhone(String phone)
    {
        String selectsql = "SELECT id FROM [user] WHERE phone='" + phone + "'";
        try
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(selectsql);
            if (reader.Read())
            {
                String id = reader.GetInt32(0).ToString();
                return id;
            }
            return null;
        }
        catch (System.InvalidCastException e)
        {
            return null;
        }
    }
    private Boolean checkPhone(String id,String phone)
    {
        String selectsql = "SELECT * FROM [user] WHERE phone='"+phone+"' AND id!="+id;
        try
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(selectsql);
            if (reader.Read())
            {
                
                return false;
            }
            return true;
        }
        catch (System.InvalidCastException e)
        {
            return false;
        }
    }
    private void initUser(String id)
    {
        String selectsql = "SELECT * FROM [user] WHERE id="+id;
        try
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(selectsql);
            if (reader.Read())
            {
                String name1 = reader.GetString(1);
                name.Value = name1;
                
                String sex1 = reader.GetString(2);
                if (sex1 == "男")
                {
                    optionsRadios1.Checked = true;
                    optionsRadios2.Checked = false;
                }
                else
                {
                    optionsRadios1.Checked = false;
                    optionsRadios2.Checked = true;
                }
                

                
                String phone1 = reader.GetString(3);
                phone.Value = phone1;
                String password = reader.GetString(5);
                user_password.Value = password;
                String headImage1;
                if (!(reader.IsDBNull(4)))
                {
                    headImage1 = reader.GetString(4);
                    //headImage.Attributes["src"] = "img/a2.jpg";

                    //headImage.Controls.Add("src", "img/a2.jpg");
                }
                else
                {
                    headImage1 = "icon_head.png";
                }
                createImg(headImage1);
                
                if (!(reader.IsDBNull(6)))
                {
                    String student_class1 = reader.GetString(6);
                    user_class.Value = student_class1;
                }
                if (!(reader.IsDBNull(9)))
                {
                    String birthday1 = reader.GetDateTime(9).ToShortDateString();
                    birthday.Value = birthday1;
                }
                if (!(reader.IsDBNull(10)))
                {
                    String sig1 = reader.GetString(10);
                    sig.InnerText = sig1;
                }
                if (!(reader.IsDBNull(11)))
                {
                    String school1 = reader.GetString(11);
                    school.Value = school1;
                }
                String flag = reader.GetString(8);
                if (flag == "老师")
                {
                    class_flag.Visible = false;
                    teacher_flag.Visible = false;
                }
                 
            }
            

        }
        catch (System.InvalidCastException e)
        {

        }
    }
    private void createImg(String image)
    {
        HtmlGenericControl from_img = new HtmlGenericControl("img");
        from_img.Attributes.Add("src", "Files/" + image);
        from_img.Attributes.Add("class", "avatarImage img-circle");
        from_img.Attributes.Add("alt", "image");
        from_img.Attributes.Add("id", "avator");
        avator_p.Controls.Add(from_img);
    }
    
}