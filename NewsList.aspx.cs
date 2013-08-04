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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["type"] != null && Request.QueryString["type"].ToString() == "news")
        {
                 showtype = "news";
                 sitemap.InnerHtml += "<a href=\"NewsList.aspx?type=news\">网站新闻</a>&nbsp;<img src=\"images/next.jpg\" />&nbsp;新闻列表";
             
        }
        else if (Request.QueryString["type"] != null && Request.QueryString["type"].ToString() == "notice")
        {
            showtype = "notice";
            sitemap.InnerHtml += "<a href=\"NewsList.aspx?type=notice\">网站公告</a>&nbsp;<img src=\"images/next.jpg\" />&nbsp;公告列表";
            title1.InnerText = "网站公告";
            
        }
        else if (Request.QueryString["type"] != null && Request.QueryString["type"].ToString() == "px")
        {
            showtype = "px";
            sitemap.InnerHtml += "<a href=\"NewsList.aspx?type=px\">读者培训</a>&nbsp;<img src=\"images/next.jpg\" />&nbsp;培训列表";
            title1.InnerText = "读者培训信息";

        }
        mynews.NewsDataOpen();
        string url = HttpContext.Current.Request.Url.ToString();//这个是带参数的
        url = Request.FilePath+"?type="+showtype;//不带参数的
        int nowpage=1;
        int allpage=9;
        int size = 30;//每页显示条数
        if (Request.QueryString["allpage"] != null && Request.QueryString["allpage"].ToString() != "")
           allpage = int.Parse(Request.QueryString["allpage"].ToString());
       else
            allpage = mynews.GetNewsNum(showtype, 1, size);
        if (Request.QueryString["pagenum"] != null && Request.QueryString["pagenum"].ToString() != "")
            nowpage = int.Parse(Request.QueryString["pagenum"].ToString());
        else nowpage = 1;

        SqlDataReader reader = mynews.GetNewsList(size, nowpage, showtype, 1);
        news_list_all.DataSource = reader;
        news_list_all.DataBind();
        reader.Close();
        mynews.NewsDataClose();
        mypage.PageURL = url;
        mypage.NowPage = nowpage;
        mypage.AllPage = allpage;
    }
}
