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

public partial class publish_detail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String id = Request.QueryString["id"];
    }
    private void initPublish(String id)
    {
        String selectsql = "SELECT * FROM [publish] WHERE publishId="+id;
        try
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(selectsql);
            if (reader.Read())
            {
                
            }
        }
        catch (System.InvalidCastException e)
        {

        }
    }

    private void initComment(String id)
    {
        String selectsql = "SELECT * FROM [comment] WHERE publishId=" + id + " ORDER BY time DESC";
        try
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(selectsql);
            while (reader.Read())
            {

            }
        }
        catch (System.InvalidCastException e)
        {

        }
    }

    private void createCommentDiv(String id,String userId,String userName,String userHead,String )
    {
        HtmlGenericControl from_div = new HtmlGenericControl("div");
        from_div.Attributes.Add("class", "social-feed-box");
        HtmlGenericControl from_div1 = new HtmlGenericControl("div");//
        from_div1.Attributes.Add("class", "social-avatar");
        HtmlGenericControl from_a = new HtmlGenericControl("a");
        from_a.Attributes.Add("href", "profile.aspx?id="+userId);
        from_a.Attributes.Add("class", "pull-left");
        HtmlGenericControl from_img = new HtmlGenericControl("img");
        from_img.Attributes.Add("alt", "image");
    }
}