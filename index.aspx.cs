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

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id"] == null || Session["pwd"] == null)
        {
            Response.Redirect("登录.aspx", true);
        }
        String userPhone = Session["id"].ToString();
        initUser(userPhone);
    }
    private void initUser(String phone)
    {
        String selectsql = "SELECT * FROM [user] WHERE phone='" + phone + "'";
        try
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(selectsql);
            if (reader.Read())
            {
                String id = reader.GetInt32(0).ToString();
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
                String flag = Session["role"].ToString();
                user_name.InnerText = name;
                role.InnerText = flag;
                createHead(headImage);
            }

        }
        catch (System.InvalidCastException e)
        {

        }
    }

    private void createHead(String headImage)
    {
        HtmlGenericControl from_img = new HtmlGenericControl("img");
        from_img.Attributes.Add("class", "img-circle indexhead");
        from_img.Attributes.Add("src", "Files/" + headImage);
        avatar.Controls.Add(from_img);
    }
}