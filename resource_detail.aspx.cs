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

public partial class resource_detail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void fllow_click(object sender, EventArgs e)
    {

    }
    protected void collect_click(object sender, EventArgs e)
    {

    }
    protected void alter_click(object sender, EventArgs e)
    {

    }
    protected void delete_click(object sender, EventArgs e)
    {

    }
    private void initResource(String id)
    {
        String selectsql = "SELECT * FROM [resource],resourceImage WHERE resourceImage.resourceId=[resource].resourceId AND [resource].resourceId=" + id;
        try
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(selectsql);
            if (reader.Read())
            {
                String categoryId = reader.GetInt32(1).ToString();
                String uploader = reader.GetInt32(2).ToString();
                String name = reader.GetString(3);
                if (!(reader.IsDBNull(4)))
                {
                    String descn = reader.GetString(4);
                }
                String codeFile = reader.GetString(5);
                if (!(reader.IsDBNull(5)))
                {
                    String level = reader.GetString(5);
                }
                String uploadTime = reader.GetDateTime(6).ToShortDateString();
                String image = reader.GetString(10);
            }
            
        }
        catch (System.InvalidCastException e)
        {
            
        }
    }
    private void createHeadImg(String image)
    {
        HtmlGenericControl from_img = new HtmlGenericControl("img");
        from_img.Attributes.Add("src", "Files/" + image);
        from_img.Attributes.Add("class", "img-circle head");
        from_img.Attributes.Add("alt", "image");
        author.Controls.Add(from_img);
    }
    private void createImg(String image)
    {
        HtmlGenericControl from_img = new HtmlGenericControl("img");
        from_img.Attributes.Add("src", "Files/" + image);
        from_img.Attributes.Add("class", "img-circle head");
        from_img.Attributes.Add("alt", "image");
        resourceImage.Controls.Add(from_img);
    }
    private void hind(Boolean flag)
    {
        if (flag == true)
        {
            admint.Visible = false;
        }
    }
}