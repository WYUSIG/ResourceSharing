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
        //Session["phone"] = "13066288360";
        string idstr = SqlHelp.ExecuteScalar("SELECT id FROM [user] WHERE phone ='" + Session["id"] + "'").ToString();
        Session["id"] = idstr;
        string sql = "SELECT [publish].title,[user].name,[publish].time,[publish].content ,[publish].publishId FROM [user],[publish],[subscribe] WHERE  publish.userId = [user].id AND [user].id=subscribe.concerned AND subscribe.concern=" + Session["id"] + "order by time desc";

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
                         content = content.Substring(0,200)+"...";
                     }

                     createPublishDiv(title, name, time, content, "lable", countReply,publishId);
                 }
                 catch (System.InvalidCastException eee)
                 {
                     Response.Write("<script>alert('系统出错')</script>");

                 }
             }
             reader.Close();
         }

    }


    private void createPublishDiv(String title, String userName, String time, String content,String lable, String commentCount,String publishId)
    {
        HtmlGenericControl from_divbox = new HtmlGenericControl("div");
        from_divbox.Attributes.Add("class", "ibox");

        HtmlGenericControl from_divcontent = new HtmlGenericControl("div");
        from_divcontent.Attributes.Add("class", "ibox-content");

        HtmlGenericControl from_atitle = new HtmlGenericControl("a");
        from_atitle.Attributes.Add("href", "publish_detail.aspx?id=" + publishId);
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
        from_btn.Attributes.Add("type","button");
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
        from_div2211.Controls.Add(from_icomment);    
    }

}