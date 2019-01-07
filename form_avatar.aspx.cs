using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class form_avatar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id"] == null || Session["pwd"] == null)
        {
            Response.Redirect("登录.aspx", true);
        }
    }
    protected void submit_click(object sender, EventArgs e)
    {
        String userPhone = Session["id"].ToString();
        HttpFileCollection files = Request.Files;
        string filePath = Server.MapPath("~/Files/");
        if (files.Count != 0)
        {
            string fileName = files[0].FileName;
            String fileUUIDName = FileUtil.getUUID();
            files[0].SaveAs(System.IO.Path.Combine(filePath, fileUUIDName + FileUtil.FileSuffix(fileName)));
            String now = Time.getDataTime();
            String updatesql = "UPDATE  [user] SET headImage='"+fileUUIDName + FileUtil.FileSuffix(fileName)+"' WHERE phone='"+userPhone+"'";
           
            try
            {
                SqlHelp.ExecuteNonQueryCount(updatesql);
                Response.Write("<script>alert('上传成功')</script>");
            }
            catch (System.InvalidCastException ee)
            {
                Response.Write("<script>alert('上传失败')</script>");
            }
            
        }
        else
        {
            Response.Write("<script>alert('请选择文件')</script>");
            //Response.Write("<p>未获取到Files:" + files.Count.ToString() + "</p>");
        }
        
        
    }
    
}