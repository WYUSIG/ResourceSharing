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

public partial class resource_detail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id"] == null || Session["pwd"] == null)
        {
            Response.Redirect("登录.aspx", true);
        }
        String id = Request.QueryString["id"];    
        if (Session["role"].ToString() != "管理员")
        {
            if (!(checkFllow(getUserIdByPhone(Session["id"].ToString()), getUserIdByResourceId(Request.QueryString["id"]))))
            {
                fllow.Text = "已关注";
            }
            if (!(checkCollect(getUserIdByPhone(Session["id"].ToString()), id)))
            {
                collect.Text = "已收藏";
            }
            hind(true);
        }
        else
        {
            hind1(true);
        }
           
        initResource(id);
        initCollect(id);
        initLables();
        
    }
    protected void fllow_click(object sender, EventArgs e)
    {
        String concernedId = getUserIdByResourceId(Request.QueryString["id"]);
        if (!(checkFllow(getUserIdByPhone(Session["id"].ToString()), concernedId)))
        {
            return;
        }
        if(getUserIdByPhone(Session["id"].ToString())==concernedId)
        {
            Response.Write("<script>alert('不能关注自己')</script>");
            return;
        }
        String now = Time.getDataTime();
        String insertsql = "INSERT INTO subscribe(concern,concerned,time) VALUES(" + getUserIdByPhone(Session["id"].ToString()) + "," + concernedId + ",'" + now + "')";
        try
        {
            SqlHelp.ExecuteNonQueryCount(insertsql);
            fllow.Text = "已关注";
            Response.Write("<script>alert('关注成功')</script>");
        }
        catch (System.InvalidCastException ee)
        {

        }
    }
    protected void collect_click(object sender, EventArgs e)
    {
        if (!(checkCollect(getUserIdByPhone(Session["id"].ToString()), Request.QueryString["id"])))
        {
            return;
        }
        String userId = getUserIdByPhone(Session["id"].ToString());
        String now = Time.getDataTime();
        String insertsql = "INSERT INTO [collection](resourceId,userId,time) VALUES(" + Request.QueryString["id"] + ","+userId+",'"+now+"')";
        try
        {
            SqlHelp.ExecuteNonQueryCount(insertsql);
            collect.Text = "已收藏";
            Response.Write("<script>alert('收藏成功')</script>");
            Response.Redirect("resource_detail.aspx?id=" + Request.QueryString["id"], true);
        }
        catch (System.InvalidCastException ee)
        {
            Response.Write("<script>alert('收藏失败')</script>");
        }
    }
    protected void alter_click(object sender, EventArgs e)
    {
        String resource_lable = lable.Value;
        String resource_level = level.Value;
        String updatesql = "UPDATE [resource] SET categoryId=" + getCategoryId(resource_lable) + "',level='" + resource_level + "' WHERE resourceId="+Request.QueryString["id"];
        try
        {
            SqlHelp.ExecuteNonQueryCount(updatesql);
            
            Response.Write("<script>alert('修改成功')</script>");
            Response.Redirect("resource_detail.aspx?id="+Request.QueryString["id"], true);
        }
        catch (System.InvalidCastException ee)
        {
            Response.Write("<script>alert('修改失败')</script>");
        }
    }
    protected void delete_click(object sender, EventArgs e)
    {
        String deletesql = "DELETE FROM [resource] WHERE resourceId=" + Request.QueryString["id"];
        try
        {
            SqlHelp.ExecuteNonQueryCount(deletesql);

            Response.Write("<script>alert('修改成功')</script>");
            if (Session["role"].ToString() == "管理员")
            {
                Response.Redirect("index_v1.aspx", true);
            }
            else
            {
                Response.Redirect("index.aspx", true);
            }
        }
        catch (System.InvalidCastException ee)
        {
            Response.Write("<script>alert('修改失败')</script>");
        }
    }
    protected void download_click(object sender, EventArgs e)
    {
        String UUIDName = ((System.Web.UI.Control)(sender)).ID;
        DownloadFile(UUIDName, "Files/" + UUIDName);
    }
    private String getCategoryId(String name)
    {
        String selectsql = "SELECT categoryId FROM category WHERE name='"+name+"'";
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
    private void initResource(String id)
    {
        String selectsql = "SELECT * FROM [resource],resourceImage WHERE resourceImage.resourceId=[resource].resourceId AND [resource].resourceId=" + id;
        try
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(selectsql);
            if (reader.Read())
            {
                String categoryId = reader.GetInt32(1).ToString();
                setCategory(categoryId);
                String uploader = reader.GetInt32(2).ToString();
                
                setUploader(uploader);
                String name = reader.GetString(3);
                title1.InnerText = name;
                file_name.InnerText = name;
                if (!(reader.IsDBNull(4)))
                {
                    String descn = reader.GetString(4);
                    descn=descn.Replace("\n", "<br/>");
                    descn = descn.Replace(" ", "&nbsp;");
                    resourceContent.InnerHtml = descn;
                }
                String codeFile = reader.GetString(5);
                Button button = new Button();
                button.ID = codeFile;
                button.CssClass = "btn btn-primary btn-block";
                button.Text = "下载";
                button.Click += download_click;
                download.Controls.Add(button);
                if (!(reader.IsDBNull(6)))
                {
                    String level = reader.GetString(6);
                    level_flag.InnerText = level;
                }
                else
                {
                    level_flag.Visible = false;
                }
                String uploadTime = reader.GetDateTime(7).ToShortDateString();
                file_time.InnerText = "上传时间："+uploadTime;
                String image = reader.GetString(10);
                createImg(image);
            }
            
        }
        catch (System.InvalidCastException e)
        {
            
        }
    }

    private void initCollect(String id)
    {
        String selectsql = "SELECT COUNT(*) FROM collection WHERE resourceId="+id;
        try
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(selectsql);
            if (reader.Read())
            {
                String count = reader.GetInt32(0).ToString();
                collect_count.InnerText ="收藏数："+count;

            }

        }
        catch (System.InvalidCastException e)
        {

        }
    }
    private void setUploader(String id)
    {
        String selectsql = "SELECT * FROM [user] WHERE id="+id;
        try
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(selectsql);
            if (reader.Read())
            {
                String name = reader.GetString(1);
                String headImage = reader.GetString(4);
                createHeadImg(id,headImage,name);

            }

        }
        catch (System.InvalidCastException e)
        {

        }
    }
    private void setCategory(String id)
    {
        String selectsql = "SELECT * FROM category WHERE categoryId="+id;
        try
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(selectsql);
            if (reader.Read())
            {
                String name = reader.GetString(1);
                category.InnerText = name;
            }

        }
        catch (System.InvalidCastException e)
        {

        }
    }
    private void createHeadImg(String id,String image,String name)
    {
        HtmlGenericControl from_img = new HtmlGenericControl("img");
        from_img.Attributes.Add("src", "Files/" + image);
        from_img.Attributes.Add("class", "smallhead img-circle");
        from_img.Attributes.Add("alt", "image");
        author_i.Controls.Add(from_img);
        author_n.InnerHtml = "&nbsp;";
        author_n.InnerHtml = name + "&nbsp;&nbsp;";
        author.Attributes.Add("href","profile.aspx?id="+id);
    }
    private void createImg(String image)
    {
        HtmlGenericControl from_img = new HtmlGenericControl("img");
        from_img.Attributes.Add("src", "Files/" + image);
        from_img.Attributes.Add("class", "resourceImage");
        from_img.Attributes.Add("alt", "image");
        resourceImage.Controls.Add(from_img);
    }
    
    private void hind(Boolean flag)
    {
        if (flag == true)
        {
            admint.Visible = false;
            
        }
    }
    private void hind1(Boolean flag)
    {
        if (flag == true)
        {
            
            fllow.Visible = false;
            collect.Visible = false;
        }
    }
    public void DownloadFile(string fileName, string fPath)
    {
        string filePath = Server.MapPath(fPath);//路径
        //以字符流的形式下载文件
        FileStream fs = new FileStream(filePath, FileMode.Open);
        byte[] bytes = new byte[(int)fs.Length];
        fs.Read(bytes, 0, bytes.Length);
        fs.Close();
        Response.ContentType = "application/octet-stream";
        //通知浏览器下载文件而不是打开
        Response.AddHeader("Content-Disposition", "attachment;   filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));
        Response.BinaryWrite(bytes);
        Response.Flush();
        Response.End();
    }
    private String getUserIdByResourceId(String resourceId)
    {
        String selectsql = "SELECT * FROM [resource] WHERE resourceId=" + resourceId;
        try
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(selectsql);
            if (reader.Read())
            {
                String userId = reader.GetInt32(2).ToString();
                return userId;
            }
            return null;
        }
        catch (System.InvalidCastException e)
        {
            return null;
        }
    }
    private Boolean checkFllow(String userId,String author)
    {
        String selectsql = "SELECT * FROM subscribe WHERE concern="+userId+" AND concerned="+author+"";
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
    private Boolean checkCollect(String userId,String resourceId)
    {
        String selectsql = "SELECT * FROM [collection] WHERE resourceId="+resourceId+" AND userId="+userId+"";
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
    private void createLable(String name)
    {
        HtmlGenericControl from_li = new HtmlGenericControl("li");
        HtmlGenericControl from_a = new HtmlGenericControl("a");
        from_a.Attributes.Add("class", "lables");
        
        from_a.InnerText = name;
        from_li.Controls.Add(from_a);
        lable_ul.Controls.Add(from_li);
    }
    private void initLables()
    {
        String selectsql = "SELECT * FROM category";
        try
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(selectsql);
            while (reader.Read())
            {
                String name = reader.GetString(1);

                createLable(name);

            }

        }
        catch (System.InvalidCastException e)
        {

        }
    }
}