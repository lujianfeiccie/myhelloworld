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

public partial class LinkList : System.Web.UI.Page
{
    public string xnzy = "class=\"content_left_guid_item\"";
   public string xnlj = "class=\"content_left_guid_item\"";
    public string xwlj = "class=\"content_left_guid_item\"";
    public string xwzy = "class=\"content_left_guid_item\"";
    public string xkzywz = "class=\"content_left_guid_item\"";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["type"] != null && Request.QueryString["type"].ToString() != "")
        {
            string type=Request.QueryString["type"].ToString();
           
            switch (type) { 
                case "xnzy":
                    xnzy = "class=\"content_left_guid_item_on\"";
                    title1.InnerText = "校内资源";
                    sitemap.InnerHtml += "<a href=\"LinkList.aspx?type=xnzy\">校内资源</a>&nbsp;<img src=\"images/next.jpg\" />&nbsp;链接列表";
                    break;
                case "xnlj":
                    xnlj = "class=\"content_left_guid_item_on\"";
                    title1.InnerText = "校内链接";
                    sitemap.InnerHtml += "<a href=\"LinkList.aspx?type=xnlj\">校内链接</a>&nbsp;<img src=\"images/next.jpg\" />&nbsp;链接列表";
                    break;
                case "xwlj":
                    xwlj = "class=\"content_left_guid_item_on\"";
                    title1.InnerText = "校外链接";
                    sitemap.InnerHtml += "<a href=\"LinkList.aspx?type=xwlj\">校外链接</a>&nbsp;<img src=\"images/next.jpg\" />&nbsp;链接列表";
                    break;
                case "xwzy":
                    xwzy = "class=\"content_left_guid_item_on\"";
                    title1.InnerText = "校外资源";
                    sitemap.InnerHtml += "<a href=\"LinkList.aspx?type=xwzy\">校外资源</a>&nbsp;<img src=\"images/next.jpg\" />&nbsp;链接列表";
                    break;
                case "xkzywz":
                    xkzywz = "class=\"content_left_guid_item_on\"";
                    title1.InnerText = "学科专业网站";
                    sitemap.InnerHtml += "<a href=\"LinkList.aspx?type=xkzywz\">学科专业网站</a>&nbsp;<img src=\"images/next.jpg\" />&nbsp;链接列表";
                    break;
                default:
                   
                    break;

            };
            LibWeb myweb = new LibWeb();
            myweb.WebDataOpen();
            SqlDataReader reader = myweb.GetWebLinks(type, 0);
            link_list_all.DataSource = reader;
            link_list_all.DataBind();
            reader.Close();
            myweb.WebDataClose();
        
        
        }
        else
        { Response.Write("非法访问！"); Response.End(); }
    }
}
