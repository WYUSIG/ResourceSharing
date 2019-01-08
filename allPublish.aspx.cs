using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class allPublish : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        /*
            string sql = "SELECT [publish].title,[user].name,[publish].time,[publish].content ,[publish].publishId FROM [user],[publish] WHERE  publish.userId = [user].id ";
            int count = SqlHelp.SqlServerRecordCount(sql);
            if (count > 0)
            {
                SqlDataReader reader = SqlHelp.GetDataReaderValue(sql);
                while (reader.Read())
                {
                    try
                    {
                        // String userId = reader.GetInt32(0).ToString();

                        String title = reader.GetString(0);
                        string name = reader.GetString(1);
                        string time = reader.GetDateTime(2).ToString();
                        string content = reader.GetString(3);
                        string publishId = reader.GetInt32(4).ToString();

                        string countReply = SqlHelp.SqlServerRecordCount("SELECT * FROM comment WHERE publishId = '" + publishId + "'").ToString();

                        if (content.Length > 200)
                        {
                            content = content.Substring(0, 200) + "...";
                        }

                        createPublishDiv(title, name, time, content, "lable", countReply, publishId);
                    }
                    catch (System.InvalidCastException eee)
                    {
                        Response.Write("<script>alert('系统出错')</script>");

                    }
                }
                reader.Close();
            }
        */
        string str = Request.QueryString["search"];
            search(str);
        
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("allPublish.aspx?search="+TextBox1.Text);
        /*string str = TextBox1.Text.ToString();
        string sql = "SELECT [publish].title,[user].name,[publish].time,[publish].content ,[publish].publishId FROM [user],[publish] WHERE  publish.userId = [user].id AND  ([user].name LIKE '%" + str + "%' OR [publish].title LIKE '%" + str + "%')";
        int count = SqlHelp.SqlServerRecordCount(sql);
        if (count > 0)
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(sql);
            while (reader.Read())
            {
                try
                {
                    String title = reader.GetString(0);
                    string name = reader.GetString(1);
                    string time = reader.GetDateTime(2).ToString();
                    string content = reader.GetString(3);
                    string publishId = reader.GetInt32(4).ToString();

                    string countReply = SqlHelp.SqlServerRecordCount("SELECT * FROM comment WHERE publishId = '" + publishId + "'").ToString();

                    if (content.Length > 200)
                    {
                        content = content.Substring(0, 200) + "...";
                    }

                    createPublishDiv(title, name, time, content, "lable", countReply, publishId);
                }
                catch (System.InvalidCastException eee)
                {
                    Response.Write("<script>alert('系统出错')</script>");

                }
            }
            reader.Close();
        }
        */
    }

    private void search(string str)
    {
        //string str = TextBox1.Text.ToString();
        string sql = "SELECT [publish].title,[user].name,[publish].time,[publish].content ,[publish].publishId,[publish].flag FROM [user],[publish] WHERE  publish.userId = [user].id AND  ([user].name LIKE '%" + str + "%' OR [publish].title LIKE '%" + str + "%') order by time desc";
        int count = SqlHelp.SqlServerRecordCount(sql);
        if (count > 0)
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(sql);
            while (reader.Read())
            {
                try
                {
                    String title = reader.GetString(0);
                    string name = reader.GetString(1);
                    string time = reader.GetDateTime(2).ToString();
                    string content = reader.GetString(3);
                    string publishId = reader.GetInt32(4).ToString();
                    String lable = "";
                    if(!(reader.IsDBNull(5)))
                    {
                        lable = reader.GetString(5);
                    }
                    string countReply = SqlHelp.SqlServerRecordCount("SELECT * FROM comment WHERE publishId = '" + publishId + "'").ToString();

                    if (content.Length > 200)
                    {
                        content = content.Substring(0, 200) + "...";
                    }

                    createPublishDiv(title, name, time, content, lable, countReply, publishId, getDeleteFlag(publishId));
                }
                catch (System.InvalidCastException eee)
                {
                    Response.Write("<script>alert('系统出错')</script>");

                }
            }
            reader.Close();
        }
    }

    private Boolean getDeleteFlag(String publishId)
    {
        if (Session["role"].ToString() == "管理员")
        {
            return true;
        }
        if (getUserIdByPhone(Session["id"].ToString()) == getUserId(publishId))
        {
            return true;
        }
        else
        {
            return false;
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
    private String getUserId(String publishId)
    {
        String selectsql = "SELECT userId FROM publish WHERE publishId=" + publishId;
        try
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(selectsql);
            String userId = null;
            if (reader.Read())
            {
                userId = reader.GetInt32(0).ToString();

            }
            return userId;
        }
        catch (System.InvalidCastException e)
        {
            return null;
        }
    }

    private void delete_click(object sender, EventArgs e)
    {
        String pId = ((System.Web.UI.Control)(sender)).ID;

        SqlHelp.ExecuteNonQuery("DELETE FROM [publish] WHERE publishId="+pId);
    }


    private void createPublishDiv(String title, String userName, String time, String content, String lable, String commentCount,String pId,Boolean deleteFlag)
    {
        HtmlGenericControl from_divbox = new HtmlGenericControl("div");
        from_divbox.Attributes.Add("class", "ibox");

        HtmlGenericControl from_divcontent = new HtmlGenericControl("div");
        from_divcontent.Attributes.Add("class", "ibox-content");

        HtmlGenericControl from_atitle = new HtmlGenericControl("a");
        from_atitle.Attributes.Add("href", "publish_detail.aspx?id=" +pId);
        from_atitle.Attributes.Add("class", "btn-link");

        HtmlGenericControl from_h2 = new HtmlGenericControl("h2");
        from_h2.InnerText = title;

        HtmlGenericControl from_divmsg = new HtmlGenericControl("div");
        from_divmsg.Attributes.Add("class", "small m-b-xs");

        HtmlGenericControl from_divname = new HtmlGenericControl("strong");
        from_divname.InnerText = userName;

        HtmlGenericControl from_span = new HtmlGenericControl("span");
        from_span.Attributes.Add("class", "text-muted");


        HtmlGenericControl from_itime = new HtmlGenericControl("i");
        from_itime.Attributes.Add("class", "fa fa-clock-o");
        from_itime.InnerText = time;

        HtmlGenericControl from_p = new HtmlGenericControl("p");
        from_p.InnerText = content;

        HtmlGenericControl from_div2 = new HtmlGenericControl("div");
        from_div2.Attributes.Add("class", "row");

        HtmlGenericControl from_div21 = new HtmlGenericControl("div");
        from_div21.Attributes.Add("class", "col-md-6");

        HtmlGenericControl from_h51 = new HtmlGenericControl("h5");
        from_h51.InnerText = "标签：";

        HtmlGenericControl from_btn = new HtmlGenericControl("button");
        from_btn.Attributes.Add("class", "btn btn-primary btn-xs");
        from_btn.Attributes.Add("type", "button");
        from_btn.InnerText = lable;

        HtmlGenericControl from_div22 = new HtmlGenericControl("div");
        from_div22.Attributes.Add("class", "col-md-6");

        HtmlGenericControl from_div221 = new HtmlGenericControl("div");
        from_div221.Attributes.Add("class", "small text-right");

        HtmlGenericControl from_h52 = new HtmlGenericControl("h5");
        from_h52.InnerText = "状态：";

        HtmlGenericControl from_div2211 = new HtmlGenericControl("div");


        HtmlGenericControl from_icomment = new HtmlGenericControl("i");
        from_icomment.Attributes.Add("class", "fa fa-comments-o");
        from_icomment.InnerText = commentCount + "评论";

        HtmlGenericControl from_divbtn = new HtmlGenericControl("div");


        Button button_delete = new Button();
        button_delete.Text = "删 除";
        button_delete.ID = pId;
        button_delete.CssClass = "btn btn-w-m btn-danger";
        button_delete.Click += delete_click;
        button_delete.Attributes.Add("onclick", "javascript:if(confirm('确定要删除吗?')){}else{return false;}");


        publish_list.Controls.Add(from_divbox);

        from_divbox.Controls.Add(from_divcontent);

        from_divcontent.Controls.Add(from_atitle);
        from_atitle.Controls.Add(from_h2);
        from_divcontent.Controls.Add(from_divmsg);

        from_divmsg.Controls.Add(from_divname);
        from_divmsg.Controls.Add(from_span);

        from_span.Controls.Add(from_itime);

        from_divcontent.Controls.Add(from_p);

        from_divcontent.Controls.Add(from_div2);

        from_div2.Controls.Add(from_div21);
        from_div21.Controls.Add(from_h51);
        from_div21.Controls.Add(from_btn);
        from_div2.Controls.Add(from_div22);
        from_div22.Controls.Add(from_div221);
        from_div221.Controls.Add(from_h52);
        from_div221.Controls.Add(from_div2211);
        from_div221.Controls.Add(from_divbtn);
        if (deleteFlag == true)
        {
            from_divbtn.Controls.Add(button_delete);
        }
        
        from_div2211.Controls.Add(from_icomment);
    }
    
}