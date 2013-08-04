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

public partial class DownloadList : System.Web.UI.Page
{
    public Functions myfun = new Functions();
    public string type = "wt";
    public string px = "class=\"content_left_guid_item\"";
    public string download = "class=\"content_left_guid_item\"";
    public string wt = "class=\"content_left_guid_item\"";

    public string[] result = new string[4];
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["type"] != null && Request.QueryString["type"] != "")
        { type = Request.QueryString["type"].ToString(); }
        switch (type)
        { 
            case"download":
                download = "class=\"content_left_guid_item_on\"";
                title1.InnerText = "软件下载";
                sitemap.InnerHtml += "软件下载";
                Download mydown = new Download();
                mydown.DownloadDataOpen();

                string url = Request.FilePath + "?type=download&";//不带参数的
                int nowpage = 1;
                int allpage = 9;
                int size = 24;//每页显示条数
                if (Request.QueryString["allpage"] != null && Request.QueryString["allpage"].ToString() != "")
                    allpage = int.Parse(Request.QueryString["allpage"].ToString());
                else
                    allpage = mydown.GetDownloadNum(size);
                if (Request.QueryString["pagenum"] != null && Request.QueryString["pagenum"].ToString() != "")
                    nowpage = int.Parse(Request.QueryString["pagenum"].ToString());
                else nowpage = 1;


                SqlDataReader reader = mydown.GetDownloadList(size, nowpage);
                download_list_all.DataSource = reader;
                download_list_all.DataBind();
                reader.Close();


                mypage.PageURL = url;
                mypage.NowPage = nowpage;
                mypage.AllPage = allpage;
                mydown.DownloadDataClose();
                break;
            case"wt":
                wt = "class=\"content_left_guid_item_on\"";
                title1.InnerText = "常见问题";
                sitemap.InnerHtml += "常见问题";
                LibWeb myweb = new LibWeb();
                myweb.WebDataOpen();
                result = myweb.GetPageInfo(type);
                myweb.WebDataClose();
                break;
            case"px":
                px = "class=\"content_left_guid_item_on\"";
                title1.InnerText = "读者培训";
                sitemap.InnerHtml += "读者培训";
                break;
            default:
                break;
        }
       
    }
}
