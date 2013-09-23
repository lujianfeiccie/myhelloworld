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

public partial class index : System.Web.UI.Page
{
    public Functions myfun = new Functions();
    protected void Page_Load(object sender, EventArgs e)
    {
        LibWeb mylib = new LibWeb();
        mylib.WebDataOpen();
        //链接
        SqlDataReader reader;

        News mynews = new News();
        mynews.NewsDataOpen();
      //  reader = mynews.GetNewsList(1, "orderlist desc,pub_time desc", "notice", "istop=1 and ischeck=1");//置顶通知
       // top2notice.DataSource = reader;
       // top2notice.DataBind();
      //  reader.Close();
        //首页公告
     //   reader = mynews.GetNewsList(5, "orderlist desc,pub_time desc", "notice", "istop=0 and ischeck=1");
      //  this.indexnotice.DataSource = reader;
      //  indexnotice.DataBind();
      //  reader.Close();
        //置顶新闻
        reader = mynews.GetNewsList(6, "orderlist desc,pub_time desc", "news", "istop=0 and ischeck=1");
        top2news.DataSource = reader;
        top2news.DataBind();
        reader.Close();
        //首页新闻
      //  reader = mynews.GetNewsList(5, "orderlist desc,pub_time desc", "news", "istop=0 and ischeck=1");
      //  indexnews.DataSource = reader;
      //  indexnews.DataBind();
      //  reader.Close();
      //  mynews.NewsDataClose();
        //新书推荐
        Book mybook = new Book();
        mybook.BookDataOpen();
        reader = mybook.GetBookList(6, "addtime desc", "istop=1");
        newbook.DataSource = reader;
        newbook.DataBind();
        reader.Close();
        mybook.BookDataClose();
        
    }
    public string IsNew(string pub_date)
    {
        DateTime pub_time = DateTime.Parse(pub_date);
        TimeSpan ss = DateTime.Now.Subtract(pub_time);
        if (ss.TotalDays < 3)
            return "<img src=\"Images/new.gif\" />";
        else
        {
            return pub_time.Year.ToString() + "-" + pub_time.Month.ToString() + "-" + pub_time.Day.ToString();
        }
    }
    public string IsNewView(string isnew)
    {
        if (isnew.ToLower() == "true")
        {
            return "<img style='border:none;' src=\"Images/new.gif\" />";
        }
        else return "";
    }
}
