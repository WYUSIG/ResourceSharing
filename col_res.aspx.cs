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

public partial class col_res : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string str = Request.QueryString["col_res"];
        search(str);
    }


    private void search(string str)
    {
        //Session["id"] = "13066238768";
        string idstr = SqlHelp.ExecuteScalar("SELECT id FROM [user] WHERE phone ='" + Session["id"] + "'").ToString();
        string sql = "SELECT [resource].name,[user].name,[resource].resourceId,[resource].codeFile,[collection].[time] FROM [user],[resource],[collection] WHERE [resource].[resourceId] = [collection].[resourceId] AND  [user].id=[collection].[userId] AND [user].id=" + idstr + " AND ([user].name LIKE '%" + str + "%' OR [resource].name LIKE '%" + str + "%') order by uploadTime desc";
        int count = SqlHelp.SqlServerRecordCount(sql);
        if (count > 0)
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(sql);
            while (reader.Read())
            {
                try
                {
                    string res_name = reader.GetString(0);
                    string user_name = reader.GetString(1);
                    string res_id = reader.GetInt32(2).ToString();
                    string filename = reader.GetString(3);
                    string colTime = reader.GetDateTime(4).ToShortDateString();

                    CreateFileDiv(res_name, getUserName(res_id), res_id, filename, colTime);
                }
                catch (System.InvalidCastException eee)
                {
                    Response.Write("<script>alert('系统出错')</script>");

                }
            }
            reader.Close();
        }
    }

    private String getUserName(String id)
    {
        String selectsql = "SELECT [user].name FROM [resource],[user] WHERE [resource].uploader=[user].id AND [resource].resourceId=" + id;
        try
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(selectsql);
            if (reader.Read())
            {
                String name = reader.GetString(0);
                return name;
            }
            return null;
        }
        catch (System.InvalidCastException e)
        {
            return null;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("col_res.aspx?col_res=" + TextBox1.Text);
    }

    public void downloadFile_click(object sender, EventArgs e)
    {
        //Response.Write("<script>alert('下载')</script>");
        String UUIDName = ((System.Web.UI.Control)(sender)).ID;
        DownloadFile(UUIDName, "Files/" + UUIDName);
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

    private void CreateFileDiv(String name, String username, String res_id, String UUIDName, String time)
    {
        HtmlGenericControl from_div = new HtmlGenericControl("div");
        from_div.Attributes.Add("class", "file-box");
        HtmlGenericControl from_div1 = new HtmlGenericControl("div");
        from_div1.Attributes.Add("class", "file");
        HtmlGenericControl from_a = new HtmlGenericControl("a");
        from_a.Attributes.Add("href", "resource_detail.aspx?id=" + res_id);
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

        HtmlGenericControl from_username = new HtmlGenericControl("div");
        from_username.InnerText = "上传者：" + username;

        HtmlGenericControl from_small = new HtmlGenericControl("small");
        from_small.InnerText = "收藏日期：" + time;
        from_div3.InnerHtml = name + "<br/>";
        //from_div3.Controls.Add(from_br);
        from_div3.Controls.Add(from_username);
        from_div3.Controls.Add(from_small);


        Button button = new Button();
        button.Text = "下载";
        button.ID = UUIDName;
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

}