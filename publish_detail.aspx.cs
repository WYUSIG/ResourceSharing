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
        initPublish(id);
    }
    protected void comment_click(object sender, EventArgs e)
    {
        String content = comment_content.Value;
        String id = Request.QueryString["id"];
        String userPhone = Session["id"].ToString();
        String userId = getUserIdByPhone(userPhone);
        String now = Time.getDataTime();
        String insertsql = "INSERT INTO comment(publishId,userId,content,time) VALUES(" + id + "," + userId + ",'"+content+"','"+now+"')";
        try
        {
            SqlHelp.ExecuteNonQueryCount(insertsql);
            Boolean levelFlag;
            if (userId == getPublishUserid(id))
            {
                levelFlag=true;
            }
            else
            {
                levelFlag = false;
            }
            createCommentDiv(getCommentId(id,userId,now),userId, getPublishUser(userId, 1), getPublishUser(userId, 4), content, getUserFlag(userId, "教师"), false, now, true, true, levelFlag);
        }
        catch (System.InvalidCastException ee)
        {
            Response.Write("<script>alert('评论失败')</script>");
        }
    }
    protected void delete_click(object sender, EventArgs e)
    {
        String commentId = ((System.Web.UI.Control)(sender)).ID;
        String deletesql = "DELETE FROM comment WHERE id="+commentId;
        try
        {
            SqlHelp.ExecuteNonQueryCount(deletesql);
            Response.Redirect("publish_detail.aspx?id="+Request.QueryString["id"], true);
        }
        catch (System.InvalidCastException ee)
        {
            
        }
    }
    protected void level_click(object sender, EventArgs e)
    {
        String commentId = ((System.Web.UI.Control)(sender)).ID;
        commentId = commentId.Replace("temp","");
        String updatesql = "UPDATE comment SET comment_level='优' WHERE id=" + commentId;
        try
        {
            SqlHelp.ExecuteNonQueryCount(updatesql);
            Response.Redirect("publish_detail.aspx?id=" + Request.QueryString["id"], true);
        }
        catch (System.InvalidCastException ee)
        {

        }
    }
    private String getCommentId(String publishId,String userId,String time)
    {
        String selectsql = "SELECT id FROM comment WHERE publishId="+publishId+" AND userId="+userId+" AND time='"+time+"'";
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
    private String getPublishUserid(String id)
    {
        String selectsql = "SELECT * FROM [publish] WHERE publishId=" + id;
        try
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(selectsql);
            String userId = null;
            if (reader.Read())
            {
                userId = reader.GetInt32(1).ToString();
                
            }
            return userId;
        }
        catch (System.InvalidCastException e)
        {
            return null;
        }
    }
    private void initPublish(String id)
    {
        String selectsql = "SELECT * FROM [publish] WHERE publishId="+id;
        try
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(selectsql);
            String userId=null;
            if (reader.Read())
            {
                userId = reader.GetInt32(1).ToString();
                String content = reader.GetString(2);
                content = content.Replace("\n", "<br>");
                content = content.Replace(" ", "&nbsp;");
                String time = reader.GetDateTime(3).ToShortDateString();
                String title = reader.GetString(4);
                String lable = reader.GetString(5);
                time1.InnerText = time;
                title1.InnerText = title;
                lable1.InnerText = lable;
                //publishContent.InnerText = content;
                publishContent.InnerHtml = content;
                createAuthor(userId, getPublishUser(userId, 4), getPublishUser(userId, 1));
            }
            initComment(id,userId);
        }
        catch (System.InvalidCastException e)
        {

        }
    }

    private void initComment(String id,String userId1)
    {
        String selectsql = "SELECT * FROM [comment] WHERE publishId=" + id + " ORDER BY case when comment_level is null then 1 else 0 end,time DESC";
        try
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(selectsql);
            while (reader.Read())
            {
                String commentId = reader.GetInt32(0).ToString();
                String userId = reader.GetInt32(2).ToString();//评论者
                String content = reader.GetString(3);
                String time = reader.GetDateTime(4).ToShortDateString();
                String userPhone = Session["id"].ToString();
                String userMine = getUserIdByPhone(userPhone);//登录者
                String role = Session["role"].ToString();
                Boolean deleteFlag;
                Boolean levelFlag;
                if (userMine == userId1)
                {
                    levelFlag = true;
                }
                else
                {
                    levelFlag = false;
                }
                if (userMine == userId)
                {
                    deleteFlag = true;
                }
                else
                {
                    deleteFlag = false;
                }
                if(role=="管理员")
                {
                    levelFlag = true;
                    deleteFlag = true;
                }
                Boolean good=false;
                if(!(reader.IsDBNull(5)))
                {
                    String comment_level = reader.GetString(5);
                    if (comment_level == "优")
                    {
                        good = true;
                    }
                }
                createCommentDiv(commentId,userId, getPublishUser(userId, 1), getPublishUser(userId, 4), content, getUserFlag(userId, "教师"), good, time, deleteFlag, false, levelFlag);
            }
        }
        catch (System.InvalidCastException e)
        {

        }
    }

    //1 name or 4 head
    private String getPublishUser(String id,int index)
    {
        String selectsql = "SELECT * FROM [user] WHERE id="+id;
        try
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(selectsql);
            if (reader.Read())
            {
                String a;
                if (index == 4)
                {
                    if (!(reader.IsDBNull(4)))
                    {
                        a = reader.GetString(index);
                    }
                    else
                    {
                        a = "icon_head.png";
                    }
                }
                else
                {
                    a = reader.GetString(index);
                }
                
                return a;
            }
            return null;
        }
        catch (System.InvalidCastException e)
        {
            return null;
        }
    }


    private Boolean getUserFlag(String userId,String flag)
    {
        String selectsql = "SELECT * FROM [user] WHERE id=" + userId;
        try
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(selectsql);
            if (reader.Read())
            {
                String userFlag = reader.GetString(8);
                if (flag == userFlag)
                { 
                    return true;
                }
            }
            return false;
        }
        catch (System.InvalidCastException e)
        {
            return false;
        }
    }

    private void createCommentDiv(String commentId,String userId, String userName, String userHead, String content, Boolean teacher_flag, Boolean good_flag, String time, Boolean deleteFlag, Boolean isNew, Boolean levelFlag)
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
        from_img.Attributes.Add("src", "Files/"+userHead);
        from_a.Controls.Add(from_img);
        HtmlGenericControl from_div2 = new HtmlGenericControl("div");///
        from_div2.Attributes.Add("class", "media-body");
        HtmlGenericControl from_a1 = new HtmlGenericControl("a");
        from_a1.Attributes.Add("href", "profile.aspx?id="+userId);
        from_a1.InnerText=userName;
        //if (teacher_flag == true)
        //{
            HtmlGenericControl from_button = new HtmlGenericControl("button");
            from_button.Attributes.Add("class", "btn btn-info btn-xs");
            from_button.Attributes.Add("type", "button");
            from_button.InnerText = "老师";
        //}
        //+&nbsp;
        //if (good_flag==true)
        //{
            HtmlGenericControl from_button1 = new HtmlGenericControl("button");
            from_button1.Attributes.Add("class", "btn btn-info btn-xs");
            from_button1.Attributes.Add("type", "button");
            from_button1.InnerText = "优";
        //}
        HtmlGenericControl from_small = new HtmlGenericControl("small");
        from_small.Attributes.Add("class", "text-muted");
        from_small.InnerText = time;
        //HtmlGenericControl from_button2 = new HtmlGenericControl("button");
        //from_button2.Attributes.Add("class", "btn btn-success btn pull-right");
        HtmlGenericControl from_i1 = new HtmlGenericControl("i");
        from_i1.Attributes.Add("class", "pull-right");
        Button deletebutton = new Button();
        deletebutton.CssClass = "btn btn-danger btn";
        deletebutton.Text = "删除";
        deletebutton.ID = commentId;
        deletebutton.Click += delete_click;
        Button levelbutton = new Button();
        if (deleteFlag == true)
        {
            levelbutton.CssClass = "btn btn-success btn publishmargin5";
        }
        else
        {
            levelbutton.CssClass = "btn btn-success btn";
        }
        levelbutton.Text = "评论置优";
        levelbutton.ID = commentId+"temp";
        levelbutton.Click += level_click;
        from_div2.Controls.Add(from_a1);
        if (teacher_flag == true)
        {
            from_div2.Controls.Add(from_button);
        }
        if (good_flag == true)
        {
            if (teacher_flag == true)
            {
                from_div2.InnerHtml = "&nbsp;";
            }
            from_div2.Controls.Add(from_button1);
        }
        from_div2.Controls.Add(from_small);
        if (deleteFlag == true)
        {
            from_i1.Controls.Add(deletebutton); 
            //from_div2.Controls.Add(button);
        }
        if (levelFlag == true)
        {
               
            from_i1.Controls.Add(levelbutton);
        }
        from_div2.Controls.Add(from_i1);
        from_div1.Controls.Add(from_a);
        from_div1.Controls.Add(from_div2);
        HtmlGenericControl from_div3 = new HtmlGenericControl("div");//
        from_div3.Attributes.Add("class", "social-body");
        HtmlGenericControl from_p = new HtmlGenericControl("p");
        from_p.InnerText = content;
        from_div3.Controls.Add(from_p);
        from_div.Controls.Add(from_div1);
        from_div.Controls.Add(from_div3);
        if (isNew == true)
        {
            createComment.Controls.Add(from_div);
        }
        else
        {
            commentList.Controls.Add(from_div);
        }
        
    }

    private void createAuthor(String userId,String head,String name)
    {
        HtmlGenericControl from_a = new HtmlGenericControl("a");
        from_a.Attributes.Add("href", "profile.aspx?id=" + userId);   
        HtmlGenericControl from_img = new HtmlGenericControl("img");
        from_img.Attributes.Add("alt", "image");
        from_img.Attributes.Add("src", "Files/"+head);
        from_img.Attributes.Add("class", "smallhead img-circle");
        HtmlGenericControl from_i = new HtmlGenericControl("i");
        from_i.InnerText = name;
        from_a.Controls.Add(from_img);
        from_a.Controls.Add(from_i);
        author.Controls.Add(from_a);
    }
}