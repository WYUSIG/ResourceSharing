using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class allUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["SqlDataSouce1Command"] = null;
        }
        if (!(Session["SqlDataSouce1Command"] == null))
        SqlDataSource1.SelectCommand = Session["SqlDataSouce1Command"].ToString();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.PageSize = int.Parse(DropDownList1.SelectedValue);
        GridView1.DataBind();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        lblMsg.Text = "当前页为第" + (GridView1.PageIndex + 1).ToString() + "页，共有" + (GridView1.PageCount).ToString() + "页";
        //鼠标滑过时，改变颜色
        e.Row.Attributes.Add("onmouseover", "myc = this.style.backgroundColor;this.style.backgroundColor='#CFCFCF'");
        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=myc");
       // e.Row.Cells[0].Visible = false;
        
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {   //获取删除按钮
                LinkButton delete = (LinkButton)e.Row.Cells[10].Controls[0];
                //设置JavaScript               
                delete.OnClientClick = "return confirm('您真要删除姓名为" + e.Row.Cells[1].Text + "的记录吗?');";
            }
            catch
            { }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string str = TextBox1.Text.ToString();
        SqlDataSource1.SelectCommand = "SELECT [id], [name], [sex], [phone], [password], [class], [taecher], [flag],[school] FROM [user] WHERE ( [id] like '%" + str + "%' OR [name] LIKE  '%" + str + "%' OR [class] LIKE  '%" + str + "%' OR [taecher] LIKE  '%" + str + "%' OR [flag] LIKE  '%" + str + "%' OR [school] LIKE  '%" + str + "%' OR [phone] LIKE  '%" + str + "%') ";

      Session["SqlDataSouce1Command"] = SqlDataSource1.SelectCommand;

      //GridView1.DataSourceID = "SqlDataSource1";

      GridView1.DataBind();
    }

}