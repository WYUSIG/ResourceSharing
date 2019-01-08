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

public partial class form_avatar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id"] == null || Session["pwd"] == null)
        {
            Response.Redirect("登录.aspx", true);
        }
        initUser();
    }
    protected void submit_click(object sender, EventArgs e)
    {
        String userPhone = Session["id"].ToString();
        HttpFileCollection files = Request.Files;
        string filePath = Server.MapPath("~/Files/");
        if (files.Count != 0)
        {
            string fileName = files[0].FileName;
            String fileUUIDName = FileUtil.getUUID();
            files[0].SaveAs(System.IO.Path.Combine(filePath, fileUUIDName + FileUtil.FileSuffix(fileName)));
            String now = Time.getDataTime();
            String updatesql = "UPDATE  [user] SET headImage='"+fileUUIDName + FileUtil.FileSuffix(fileName)+"' WHERE phone='"+userPhone+"'";
           
            try
            {
                SqlHelp.ExecuteNonQueryCount(updatesql);
                Response.Write("<script>alert('上传成功')</script>");
            }
            catch (System.InvalidCastException ee)
            {
                Response.Write("<script>alert('上传失败')</script>");
            }
            
        }
        else
        {
            Response.Write("<script>alert('请选择文件')</script>");
            //Response.Write("<p>未获取到Files:" + files.Count.ToString() + "</p>");
        }
        
        
    }
    private void initUser()
    {
        String phone = Session["id"].ToString();
        String selectsql = "SELECT * FROM [user] WHERE phone='"+phone+"'";
        try
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(selectsql);
            String headImage;
            if (reader.Read())
            {

                if (reader.IsDBNull(4))
                {
                    headImage = "icon_head.png";
                }
                else
                {
                    headImage = reader.GetString(4);
                }
            }
            else
            {
                headImage = "icon_head.png";
            }
            createImg(headImage);
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
        user_avator.Controls.Add(from_img);
    }
}