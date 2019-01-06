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

public partial class subscribe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id"] == null || Session["pwd"] == null)
        {
            Response.Redirect("登录.aspx", true);
        }
        String userPhone = Session["id"].ToString();
        getSub(userPhone);
    }

    private void getSub(String phone)
    {
        String selectsql = "SELECT concerned FROM [user],subscribe WHERE concern=[user].id AND phone='" + phone + "' AND concern!=concerned";
        try
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(selectsql);
            while (reader.Read())
            {
                String id = reader.GetInt32(0).ToString();
                getUser(id);
            }

        }
        catch (System.InvalidCastException e)
        {

        }
    }
    private void getUser(String id)
    {
        String selectsql = "SELECT * FROM [user] WHERE id=" + id;
        try
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(selectsql);
            if (reader.Read())
            {
                //String id = reader.GetInt32(0).ToString();
                String name = reader.GetString(1);
                String headImage;
                if (reader.IsDBNull(4))
                {
                    headImage = "icon_head.png";
                }
                else
                {
                    headImage = reader.GetString(4);
                }
                String role=reader.GetString(8);
                String school;

                String sig;
                if (reader.IsDBNull(10))
                {
                    sig = "这人很懒，什么也没有留下...";
                }
                else
                {
                    sig = reader.GetString(10);
                }
                if (reader.IsDBNull(11))
                {
                    school = "未知";
                }
                else
                {
                    school = reader.GetString(11);
                }
                createUserDiv(id, name, headImage,school,role,sig);
            }

        }
        catch (System.InvalidCastException e)
        {

        }
    }

    private void createUserDiv(String userId,String userName,String userHead,String school,String role,String sig)
    {
        HtmlGenericControl from_div = new HtmlGenericControl("div");
        from_div.Attributes.Add("class", "col-sm-4");
        HtmlGenericControl from_div1 = new HtmlGenericControl("div");
        from_div1.Attributes.Add("class", "contact-box");
        HtmlGenericControl from_a = new HtmlGenericControl("a");
        from_a.Attributes.Add("href", "profile.aspx?id="+userId);//
        HtmlGenericControl from_div2 = new HtmlGenericControl("div");
        from_div2.Attributes.Add("class", "col-sm-4");
        HtmlGenericControl from_div3 = new HtmlGenericControl("div");
        from_div3.Attributes.Add("class", "text-center");
        HtmlGenericControl from_img = new HtmlGenericControl("img");
        from_img.Attributes.Add("alt", "image");
        from_img.Attributes.Add("class", "img-circle m-t-xs img-responsive avatarImage");
        from_img.Attributes.Add("src", "Files/"+userHead);
        from_div3.Controls.Add(from_img);
        from_div2.Controls.Add(from_div3);
        HtmlGenericControl from_div4 = new HtmlGenericControl("div");
        from_div4.Attributes.Add("class", "col-sm-8");//
        HtmlGenericControl from_h = new HtmlGenericControl("h3");
        HtmlGenericControl from_strong = new HtmlGenericControl("strong");
        from_strong.InnerText = userName;
        from_h.Controls.Add(from_strong);
        HtmlGenericControl from_div5 = new HtmlGenericControl("div");
        HtmlGenericControl from_p = new HtmlGenericControl("p");
        HtmlGenericControl from_i = new HtmlGenericControl("i");
        from_i.Attributes.Add("class", "fa fa-institution");
        from_i.InnerText = "学校："+school;
        from_p.Controls.Add(from_i);

        HtmlGenericControl from_p1 = new HtmlGenericControl("p");
        HtmlGenericControl from_i1 = new HtmlGenericControl("i");
        from_i1.Attributes.Add("class", "fa fa-graduation-cap");
        from_i1.InnerText = "身份：" + role;
        from_p1.Controls.Add(from_i1);

        HtmlGenericControl from_p2 = new HtmlGenericControl("p");
        HtmlGenericControl from_i2 = new HtmlGenericControl("i");
        from_i2.Attributes.Add("class", "fa fa-hand-rock-o");
        from_i2.InnerText = "宣言：" + sig;
        from_p2.Controls.Add(from_i2);

        from_div5.Controls.Add(from_p);
        from_div5.Controls.Add(from_p1);
        from_div5.Controls.Add(from_p2);
        from_div4.Controls.Add(from_h);
        from_div4.Controls.Add(from_div5);
        HtmlGenericControl from_div6 = new HtmlGenericControl("div");
        from_div6.Attributes.Add("class", "clearfix");
        from_a.Controls.Add(from_div2);
        from_a.Controls.Add(from_div4);
        from_a.Controls.Add(from_div6);
        from_div1.Controls.Add(from_a);
        from_div.Controls.Add(from_div1);
        userList.Controls.Add(from_div);
    }
}