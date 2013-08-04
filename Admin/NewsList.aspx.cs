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
public partial class NewsList : System.Web.UI.Page
{
    public News mynews = new News();
    public Functions myfun = new Functions();
    public string showtype;
    public string jumpurl;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null && Session["username"].ToString() != "" && Session["loginstate"] != null && Session["loginstate"].ToString() == "ok")
        {
            Admin myadmin = new Admin();
            myadmin.UserName = Session["username"].ToString();
            myadmin.UserDataOpen();
            myadmin.GetAdminInfo();
            myadmin.UserDataClose();
            if (myadmin.NewsOP&&Request.QueryString["type"] != null && Request.QueryString["type"].ToString() == "news")
            {
                showtype = "news";
                list_title.InnerHtml = "<strong>新闻管理列表</strong>";

            }
            else if (myadmin.NoticeOP && Request.QueryString["type"] != null && Request.QueryString["type"].ToString() == "notice")
            {
                showtype = "notice";
                list_title.InnerHtml = "<strong>公告管理列表</strong>";

            }
            else if (myadmin.DownloadOP && Request.QueryString["type"] != null && Request.QueryString["type"].ToString() == "px")
            {
                showtype = "px";
                list_title.InnerHtml = "<strong>读者培训信息管理列表</strong>";

            }
            else { Response.Write("对不起，您没有经过管理员授权管理此项目！"); Response.End(); }
            mynews.NewsDataOpen();
            string url = HttpContext.Current.Request.Url.ToString();//这个是带参数的
            url = Request.FilePath + "?type=" + showtype;//不带参数的
            int nowpage = 1;
            int allpage = 9;
            int size = 20;//每页显示条数
            if (Request.QueryString["allpage"] != null && Request.QueryString["allpage"].ToString() != "")
                allpage = int.Parse(Request.QueryString["allpage"].ToString());
            else
                allpage = mynews.GetNewsNum(showtype, 2, size);
            if (Request.QueryString["pagenum"] != null && Request.QueryString["pagenum"].ToString() != "")
                nowpage = int.Parse(Request.QueryString["pagenum"].ToString());
            else nowpage = 1;
            jumpurl = Request.Url.ToString();
            SqlDataReader reader = mynews.GetNewsList(size, nowpage, showtype, 2);
            news_list_all.DataSource = reader;
            news_list_all.DataBind();
            reader.Close();
            mynews.NewsDataClose();
            mypagenum.PageURL = url;
            mypagenum.NowPage = nowpage;
            mypagenum.AllPage = allpage;
        }
        else { Response.Redirect("Default.aspx"); }
    }
}
