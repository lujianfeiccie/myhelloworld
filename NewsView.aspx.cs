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

public partial class NewsView : System.Web.UI.Page
{
    public News mynews = new News();
        public Functions myfun=new Functions();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if(Request.QueryString["id"]!=null&&Request.QueryString["id"].ToString()!="")
        {
            
            mynews.NewsID = Request.QueryString["id"].ToString();
            mynews.NewsDataOpen();

            if (!mynews.GetNewsInfo(1))
                Response.Write("访问页面不存在！");
            else
            {
                mynews.AddVisit();
                SqlDataReader reader=  mynews.GetNewsList(10, "istop desc,visit_num desc", mynews.NewsType, "ischeck=1");
                top10.DataSource = reader;
                top10.DataBind();
                reader.Close();
                if (mynews.NewsType == "notice")
                {
                    sitemap.InnerHtml +="<a href=\"NewsList.aspx?type=notice\">网站公告</a>&nbsp;<img src=\"images/next.jpg\" />&nbsp;" + mynews.Title;
                    title1.InnerText = "网站公告";
                }
                else if (mynews.NewsType == "px")
                {
                    sitemap.InnerHtml += "<a href=\"NewsList.aspx?type=px\">读者培训</a>&nbsp;<img src=\"images/next.jpg\" />&nbsp;" + mynews.Title;
                    title1.InnerText = "读者培训";
                }
                else { 
                    sitemap.InnerHtml += "<a href=\"NewsList.aspx?type=news\">网站新闻</a>&nbsp;<img src=\"images/next.jpg\" />&nbsp;" + mynews.Title;
                    title1.InnerText = "网站新闻";
                }
            }
            mynews.NewsDataClose();
        }
        else
        {
            Response.Write("非法访问！");
        }
    }
}
