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

public partial class resourceUpload : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        initFileList();
        initLables();
    }
    protected void InputFileUploadButton_Click(object sender, EventArgs e)
    {
        HttpFileCollection files = Request.Files;
        string filePath = Server.MapPath("~/Files/");
        if (files.Count !=0)
        {
            string fileName = files[0].FileName;
            String fileUUIDName = FileUtil.getUUID();
            files[0].SaveAs(System.IO.Path.Combine(filePath, fileName));
            Response.Write("<script>alert('上传成功')</script>");
        }
        else
        {
            Response.Write("<script>alert('文件选择不完整')</script>");
            //Response.Write("<p>未获取到Files:" + files.Count.ToString() + "</p>");
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
    protected void upload_click(object sender, EventArgs e)
    {
        HttpFileCollection files = Request.Files;
        
        String name = Request["resourceName"];
        String descn = descn1.Value;
        String categoryName = Request["lable"];
        //String categoryName = Request["resourceName"];
        string filePath = Server.MapPath("~/Files/");
        String categoryId = FileUtil.getCategoryIdByName(categoryName);
        
        if (categoryId == null)
        {
            Response.Write("<script>alert('标签无效')</script>");
            return;
        }
        
        if (files.Count==2)
        {
            Response.Write(files.Count);
            string imageName = files[0].FileName;
            String imageUUIDName = FileUtil.getUUID();
            files[0].SaveAs(System.IO.Path.Combine(filePath, imageUUIDName + FileUtil.FileSuffix(imageName)));

            String fileUUIDName = FileUtil.getUUID();
            string fileName = files[1].FileName;
            files[1].SaveAs(System.IO.Path.Combine(filePath, fileUUIDName + FileUtil.FileSuffix(fileName)));
            FileUtil.uploadFile(categoryName, getUserIdByPhone(Session["id"].ToString()), name, descn, fileUUIDName + FileUtil.FileSuffix(fileName), imageUUIDName + FileUtil.FileSuffix(imageName));
            CreateFileDiv(getResourceId(fileUUIDName + FileUtil.FileSuffix(fileName)), name, fileUUIDName + FileUtil.FileSuffix(fileName), Time.getDate());
            //Response.Write(categoryName + "   " + name + "   " + descn);

            Response.Write("<script>alert('上传成功')</script>");
            //Response.Write(files.Count);
        }
        else
        {
            //Response.Write("<script>alert('文件选择不完整')</script>");
        }
    }
    
    public void downloadFile_click(object sender, EventArgs e)
    {
        //Response.Write("<script>alert('下载')</script>");
        String UUIDName = ((System.Web.UI.Control)(sender)).ID;
        DownloadFile(UUIDName, "Files/"+UUIDName);
    }
    private void CreateHtmlTag(string htmlTag)
    {
        HtmlGenericControl hgg_div = new HtmlGenericControl(htmlTag);
        hgg_div.Attributes.Add("style", "width:200px; height:200px;");
        hgg_div.InnerText = "我是一个" + htmlTag;
        Page.Controls.Add(hgg_div);
    }
    private String getResourceId(String UUIDName)
    {
        String selectsql = "SELECT resourceId FROM resource WHERE codeFile='"+UUIDName+"'";
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
    private void CreateFileDiv(String id,String name,String UUIDName,String time)
    {
        HtmlGenericControl from_div = new HtmlGenericControl("div");
        from_div.Attributes.Add("class", "file-box");
        HtmlGenericControl from_div1 = new HtmlGenericControl("div");
        from_div1.Attributes.Add("class", "file");
        HtmlGenericControl from_a = new HtmlGenericControl("a");
        from_a.Attributes.Add("href", "resource_detail.aspx?id="+id);
        HtmlGenericControl from_span = new HtmlGenericControl("span");
        from_span.Attributes.Add("class", "corner");
        HtmlGenericControl from_div2 = new HtmlGenericControl("div");
        from_div2.Attributes.Add("class", "icon");
        HtmlGenericControl from_i = new HtmlGenericControl("i");
        from_i.Attributes.Add("class", "fa fa-file");

        from_div2.Controls.Add(from_i);

        HtmlGenericControl from_div3 = new HtmlGenericControl("div");
        from_div3.Attributes.Add("class", "file-name");
        //from_div3.InnerText="111";
        //HtmlGenericControl from_br = new HtmlGenericControl("br");
        HtmlGenericControl from_small = new HtmlGenericControl("small");
        from_small.InnerText = "上传时间："+time;
        from_div3.InnerHtml = name+"<br/>";
        //from_div3.Controls.Add(from_br);
        from_div3.Controls.Add(from_small);

        Button button = new Button();
        button.Text="下载";
        button.ID = UUIDName;
        button.CssClass = "btn btn-primary btn-block";
        button.Click += downloadFile_click; 

        from_a.Controls.Add(from_span);
        from_a.Controls.Add(from_div2);
        from_a.Controls.Add(from_div3);
        from_a.Controls.Add(button);

        from_div1.Controls.Add(from_a);
        from_div.Controls.Add(from_div1);

        fileList.Controls.Add(from_div);
    }

    private void createLable(String name)
    {
        HtmlGenericControl from_li = new HtmlGenericControl("li");
        HtmlGenericControl from_a = new HtmlGenericControl("a");
        from_a.Attributes.Add("class", "lables");
        
        from_a.InnerText=name;
        from_li.Controls.Add(from_a);
        lable_ul.Controls.Add(from_li);
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
    private void initFileList()
    {
        String selectsql = "SELECT * FROM [resource]";
        try
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(selectsql);
            while (reader.Read())
            {
                String resourceId=reader.GetInt32(0).ToString();
                String name = reader.GetString(3);
                String UUIDName = reader.GetString(5);
                String time = reader.GetDateTime(7).ToShortDateString();
                CreateFileDiv(resourceId, name, UUIDName, time);
                
            }
            
        }
        catch (System.InvalidCastException e)
        {
            
        }
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