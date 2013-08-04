using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class NoteView : System.Web.UI.Page
{
    public LibNote mynote = new LibNote();
    public Functions myfun = new Functions();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
        {

            mynote.NoteID = Request.QueryString["id"].ToString();
            mynote.NoteDataOpen();

          

            if (mynote.GetInfo()!="ok")
                Response.Write("访问页面不存在！");
            else if (mynote.IsMail == true && Session["username"] == null)
            {
                Response.Write(" 请登录后查看！");
                Response.End();
            }
            else
            {
                mynote.AddVisit();
                

                sitemap.InnerHtml += "<a href=\"NoteList.aspx?type=zx\">在线咨询</a>&nbsp;<img src=\"images/next.jpg\" />&nbsp;" + mynote.Title;
                title1.InnerText = "在线咨询";
            }
               mynote.NoteDataClose();
        }
        else
        {
            Response.Write("非法访问！");
        }
    }
}
