using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class resourceUpload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        for (int i = 0; i < 10; i++)
        {
            CreateFileDiv();
        }
    }
    protected void InputFileUploadButton_Click(object sender, EventArgs e)
    {
        HttpFileCollection files = Request.Files;
        string filePath = Server.MapPath("~/Files/");
        if (files.Count != 0)
        {
            string fileName = files[0].FileName;
            String fileUUIDName = FileUtil.getUUID();
            files[0].SaveAs(System.IO.Path.Combine(filePath, fileUUIDName));
            Response.Write("<p>上传成功</p>");
        }
        else
        {
            Response.Write("<p>未获取到Files:" + files.Count.ToString() + "</p>");
        }
    }
    protected void upload(object sender, EventArgs e)
    {
        HttpFileCollection files = Request.Files;
        String descn = descn1.Value;
        String categoryName = lable.Title;
        string filePath = Server.MapPath("~/Files/");
        if (files.Count != 0)
        {
            string fileName = files[0].FileName;
            String fileUUIDName = FileUtil.getUUID();
            files[0].SaveAs(System.IO.Path.Combine(filePath, fileUUIDName));
            Response.Write("<p>上传成功</p>");
        }
        else
        {
            Response.Write("<p>未获取到Files:" + files.Count.ToString() + "</p>");
        }
    }
    protected void aaa(object sender, EventArgs e)
    {
        //Response.Write("<p>未获取到Files:</p>");
        for (int i = 0; i < 10; i++)
        {
            CreateFileDiv();
        }
            
    }
    public void downloadFile_click(object sender, EventArgs e)
    {
        //Response.Write("<script>alert('下载')</script>");
        DownloadFile("111.jpg", "Files/350947-106.jpg");
    }
    private void CreateHtmlTag(string htmlTag)
    {
        HtmlGenericControl hgg_div = new HtmlGenericControl(htmlTag);
        hgg_div.Attributes.Add("style", "width:200px; height:200px;");
        hgg_div.InnerText = "我是一个" + htmlTag;
        Page.Controls.Add(hgg_div);
    }
    private void CreateFileDiv()
    {
        HtmlGenericControl from_div = new HtmlGenericControl("div");
        from_div.Attributes.Add("class", "file-box");
        HtmlGenericControl from_div1 = new HtmlGenericControl("div");
        from_div1.Attributes.Add("class", "file");
        HtmlGenericControl from_a = new HtmlGenericControl("a");
        from_a.Attributes.Add("href", "#");
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
        from_small.InnerText = "添加时间：2014-10-13";
        from_div3.InnerHtml = "111<br/>";
        //from_div3.Controls.Add(from_br);
        from_div3.Controls.Add(from_small);

        Button button = new Button();
        button.Text="下载";
        //button.ID = "444";
        button.CssClass = "btn btn-primary btn-block";
        button.Click += downloadFile_click; ; 

        from_a.Controls.Add(from_span);
        from_a.Controls.Add(from_div2);
        from_a.Controls.Add(from_div3);
        from_a.Controls.Add(button);

        from_div1.Controls.Add(from_a);
        from_div.Controls.Add(from_div1);

        fileList.Controls.Add(from_div);
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
}