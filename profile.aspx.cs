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


public partial class profile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id"] == null || Session["pwd"] == null)
        {
            Response.Redirect("登录.aspx", true);
        }
        if (Request.QueryString["id"] == null)
        {
            String userPhone = Session["id"].ToString();
            String userId = getUserIdByPhone(userPhone);
            initUser(userId);
            createButton(userId,true,false);
        }
        else
        {
            if (Session["id"].ToString() == "管理员")
            {
                createButton(Request.QueryString["id"], false, false);
            }
            else
            {
                if (Request.QueryString["id"] == getUserIdByPhone(Session["id"].ToString()))
                {
                    createButton(Request.QueryString["id"], true, false);
                }
                else
                {
                    createButton(Request.QueryString["id"], false, true);
                }
            }
            
            initUser(Request.QueryString["id"]);
        }
        //initUser("10000");
        //createImg("7214f3587b804e5bb333aebe918b0a87.jpg");
    }
    protected void alter_click(object sender, EventArgs e)
    {
        //String userId = ((System.Web.UI.Control)(sender)).ID;
        Response.Redirect("alter_profile.aspx", true);
    }
    protected void fllow_click(object sender, EventArgs e)
    {
        String concernedId = ((System.Web.UI.Control)(sender)).ID;
        concernedId = concernedId.Replace("temp","");
        String now = Time.getDataTime();
        String insertsql = "INSERT INTO subscribe(concern,concerned,time) VALUES(" + getUserIdByPhone(Session["id"].ToString()) + "," + concernedId + ",'" + now + "')";
        try
        {
            SqlHelp.ExecuteNonQueryCount(insertsql);
            Response.Write("<script>alert('关注成功')</script>");
            Response.Redirect("profile.aspx?id="+Request.QueryString["id"], true);
        } 
        catch (System.InvalidCastException ee)
        {

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
                name.InnerText = name1;

                String sex1 = reader.GetString(2);
                sex.InnerText = sex1;

                String phone1 = reader.GetString(3);
                phone.InnerText = phone1;
                String headImage1;
                if (!(reader.IsDBNull(4)))
                {
                    headImage1 = reader.GetString(4);
                    //headImage.Attributes["src"] = "img/a2.jpg";
                    
                    //headImage.Controls.Add("src", "img/a2.jpg");
                }
                else
                {
                    headImage1="icon_head.png";
                }
                createImg(headImage1);
                createSmallImg(headImage1);
                if (!(reader.IsDBNull(6)))
                {
                    String student_class1 = reader.GetString(6);
                    student_class.InnerText = student_class1;
                }
                if (!(reader.IsDBNull(9)))
                {
                    String birthday1 = reader.GetDateTime(9).ToShortDateString();
                    birthday.InnerText = birthday1;
                }
                if (!(reader.IsDBNull(10)))
                {
                    String sig1 = reader.GetString(10);
                    sig.InnerText = sig1;
                }
                if (!(reader.IsDBNull(11)))
                {
                    String school1 = reader.GetString(11);
                    school.InnerText = school1;
                }
                initPublish(id, headImage1, name1);
            }
            initResourceCount(id);
            initconcernCount(id);
            initconcernedCount(id);
            
        }
        catch (System.InvalidCastException e)
        {

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
    private void initResourceCount(String id)
    {
        String selectsql = "SELECT COUNT(*) FROM [resource] WHERE uploader="+id;
        try
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(selectsql);
            if (reader.Read())
            {
                String count = reader.GetInt32(0).ToString();
                resourceCount.InnerText = count;

            }

        }
        catch (System.InvalidCastException e)
        {

        }
    }
    private void initconcernCount(String id)
    {
        String selectsql = "SELECT COUNT(*) FROM [subscribe] WHERE concern=" + id + " AND concern!=concerned";
        try
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(selectsql);
            if (reader.Read())
            {
                String count = reader.GetInt32(0).ToString();
                concernCount.InnerText = count;

            }

        }
        catch (System.InvalidCastException e)
        {

        }
    }
    private void initconcernedCount(String id)
    {
        String selectsql = "SELECT COUNT(*) FROM [subscribe] WHERE concerned=" + id + " AND concern!=concerned";
        try
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(selectsql);
            if (reader.Read())
            {
                String count = reader.GetInt32(0).ToString();
                concernedCount.InnerText = count;

            }

        }
        catch (System.InvalidCastException e)
        {

        }
    }

    private void initPublish(String id, String head, String userName)
    {
        String selectsql = "SELECT * FROM [publish] WHERE userId="+id+" ORDER BY time DESC";
        try
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(selectsql);
            while (reader.Read())
            {
                String publishId = reader.GetInt32(0).ToString();
                String title = reader.GetString(4);
                String content_temp = reader.GetString(2);
                String content;
                if (content_temp.Length > 200)
                {
                    content = content_temp.Substring(0, 200) + "......";
                }
                else
                {
                    content = content_temp;
                }
                String lable = reader.GetString(5);
                String time = reader.GetDateTime(3).ToShortDateString();
                createPublishDiv(publishId, head, title, userName, time, content, lable, getCommentCount(publishId));
            }
        }
        catch (System.InvalidCastException e)
        {

        }
    }

    private String getCommentCount(String publishId)
    {
        String selectsql = "SELECT COUNT(*) FROM comment WHERE publishId=" + publishId;
        try
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(selectsql);
            String count = null;
            if (reader.Read())
            {
                count = reader.GetInt32(0).ToString();

            }
            return count;
        }
        catch (System.InvalidCastException e)
        {
            return null;
        }
    }
    /**
    private void initPublish(String userid,String head,String userName)
    {
        String selectsql = "SELECT * FROM [publish] WHERE userId="+userid;

    }
     * **/
    private void createImg(String image)
    {
        HtmlGenericControl from_img = new HtmlGenericControl("img");
        from_img.Attributes.Add("src", "Files/"+image);
        from_img.Attributes.Add("class", "img-circle head");
        from_img.Attributes.Add("alt", "image");
        div111.Controls.Add(from_img);
    }
    private void createSmallImg(String image)
    {
        HtmlGenericControl from_img = new HtmlGenericControl("img");
        from_img.Attributes.Add("src", "Files/" + image);
        from_img.Attributes.Add("class", "img-circle smallhead");
        from_img.Attributes.Add("alt", "image");
        smallavatar.Controls.Add(from_img);
    }
    private void createButton(String id,Boolean alterFlag,Boolean fllowFlag)
    {
        Button alter=new Button();
        alter.ID=id;
        alter.CssClass="btn btn-primary btn-sm btn-block";
        alter.Click+=alter_click;
        alter.Text="修改个人资料";
        Button fllow=new Button();
        fllow.ID=id+"temp";
        fllow.CssClass="btn btn-primary btn-sm btn-block";
        fllow.Click+=fllow_click;
        fllow.Text="关注";
        if (alterFlag==true)
        {
            buttonList.Controls.Add(alter);
        }
        if (fllowFlag==true)
        {
            buttonList.Controls.Add(fllow);
        }
    }
    private void createPublishDiv(String id,String head,String title,String userName,String time,String content,String lable,String commentCount)
    {
        HtmlGenericControl from_div = new HtmlGenericControl("div");
        from_div.Attributes.Add("class", "ibox");
        HtmlGenericControl from_div1 = new HtmlGenericControl("div");
        from_div1.Attributes.Add("class", "ibox-content");
        HtmlGenericControl from_a = new HtmlGenericControl("a");//
        from_a.Attributes.Add("href", "#");
        from_a.Attributes.Add("class", "pull-left");
        HtmlGenericControl from_img = new HtmlGenericControl("img");
        from_img.Attributes.Add("alt", "image");
        from_img.Attributes.Add("class", "img-circle smallhead");
        from_img.Attributes.Add("src", "Files/"+head);
        from_a.Controls.Add(from_img);
        HtmlGenericControl from_a1 = new HtmlGenericControl("a");//
        from_a1.Attributes.Add("href", "publish_detail.aspx?id="+id);
        from_a1.Attributes.Add("class", "btn-link");
        HtmlGenericControl from_h = new HtmlGenericControl("h2");
        from_h.InnerText = title;
        from_a1.Controls.Add(from_h);
        HtmlGenericControl from_div2 = new HtmlGenericControl("div");//
        from_div2.Attributes.Add("class", "small m-b-xs");
        HtmlGenericControl from_strong = new HtmlGenericControl("strong");
        from_strong.InnerText = userName;
        HtmlGenericControl from_span = new HtmlGenericControl("span");
        from_span.Attributes.Add("class", "text-muted");
        HtmlGenericControl from_i = new HtmlGenericControl("i");
        from_i.Attributes.Add("class", "fa fa-clock-o");
        from_i.InnerText = time;
        from_span.Controls.Add(from_i);
        //from_span.InnerHtml = time;
        from_div2.Controls.Add(from_strong);
        from_div2.Controls.Add(from_span);
        HtmlGenericControl from_p = new HtmlGenericControl("p");//
        from_p.InnerText = content;
        HtmlGenericControl from_div3 = new HtmlGenericControl("div");//
        from_div3.Attributes.Add("class", "row");
        HtmlGenericControl from_div4 = new HtmlGenericControl("div");
        from_div4.Attributes.Add("class", "col-md-6");
        HtmlGenericControl from_h1 = new HtmlGenericControl("h5");
        from_h1.InnerText="标签：";
        HtmlGenericControl from_button = new HtmlGenericControl("button");
        from_button.Attributes.Add("class", "btn btn-primary btn-xs");
        from_button.Attributes.Add("type", "button");
        from_button.InnerText = lable;
        from_div4.Controls.Add(from_h1);
        from_div4.Controls.Add(from_button);
        HtmlGenericControl from_div5 = new HtmlGenericControl("div");
        from_div5.Attributes.Add("class", "col-md-6");
        HtmlGenericControl from_div6 = new HtmlGenericControl("div");
        from_div6.Attributes.Add("class", "small text-right");
        HtmlGenericControl from_h2 = new HtmlGenericControl("h5");
        from_h2.InnerText = "状态：";
        HtmlGenericControl from_div7 = new HtmlGenericControl("div");
        HtmlGenericControl from_i1 = new HtmlGenericControl("i");
        from_i1.Attributes.Add("class", "fa fa-comments-o");
        from_i1.InnerHtml = "&nbsp&nbsp"+commentCount + "评论";
        from_div7.Controls.Add(from_i1);
        //from_div7.InnerText = commentCount + "评论";
        ///HtmlGenericControl from_div8 = new HtmlGenericControl("div");
        //HtmlGenericControl from_i2 = new HtmlGenericControl("i");
        //from_i2.Attributes.Add("class", "fa fa-paw");
        //from_div8.Controls.Add(from_i2);
        //from_div8.InnerText = replyCount + "回复";
        Button button = new Button();
        button.ID = id;
        button.CssClass = "btn btn-w-m btn-danger";
        button.Click += delete_click;
        button.Attributes.Add("onclick", "javascript:if(confirm('确定要删除吗?')){}else{return false;}");
        button.Text = "删除";
        from_div6.Controls.Add(from_h2);
        from_div6.Controls.Add(from_div7);
        from_div6.Controls.Add(button);
        //from_div6.Controls.Add(from_div8);
        from_div5.Controls.Add(from_div6);
        from_div3.Controls.Add(from_div4);
        from_div3.Controls.Add(from_div5);

        from_div1.Controls.Add(from_a);
        from_div1.Controls.Add(from_a1);
        from_div1.Controls.Add(from_div2);
        from_div1.Controls.Add(from_p);
        from_div1.Controls.Add(from_div3);
        from_div.Controls.Add(from_div1);
        publish_list.Controls.Add(from_div);
        
    }
    protected void delete_click(object sender, EventArgs e)
    {
        String pId = ((System.Web.UI.Control)(sender)).ID;

        SqlHelp.ExecuteNonQuery("DELETE FROM [publish] WHERE publishId=" + pId);
    }
}