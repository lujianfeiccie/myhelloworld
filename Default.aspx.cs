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

public partial class _Default : System.Web.UI.Page
{
   public Functions myfun = new Functions();
    protected void Page_Load(object sender, EventArgs e)
    {
        LibWeb mylib = new LibWeb();
        mylib.WebDataOpen();
        //链接
        SqlDataReader reader = mylib.GetWebLinks("xkzywz",6);
        xkzywz.DataSource = reader;
        xkzywz.DataBind();
        reader.Close();
        reader = mylib.GetWebLinks("xnzy",0);
        xnzy.DataSource = reader;
        xnzy.DataBind();
        reader.Close();
        reader = mylib.GetWebLinks("xnlj",0);
        xnlj.DataSource = reader;
        xnlj.DataBind();
        reader.Close();
        reader = mylib.GetWebLinks("xwzy",0);
        xwzy.DataSource = reader;
        xwzy.DataBind();
        reader.Close();
        reader = mylib.GetWebLinks("xwlj",0);
        xwlj.DataSource = reader;
        xwlj.DataBind();
        reader.Close();
        //借阅排行
        reader = mylib.GetDepLoanTop(4, DateTime.Parse("2009-9-1"), DateTime.Now);
        departmenttop.DataSource = reader;
        departmenttop.DataBind();
        reader.Close();
        //投票
        Vote libvote = mylib.GetVoteOptions("1");
        lib_vote.InnerHtml = "<li><strong>"+libvote.Title+"</strong></li>";
        for (int i = 0; i < libvote.Options.Length; i++)
        {
            if(libvote.Options[i]!="")
                lib_vote.InnerHtml += "<li><input type=\"radio\" name=\"web_vote_value\" value=\""+libvote.OptionsID[i]+"\" />"+libvote.Options[i]+"</li>";
        }
        lib_vote.InnerHtml += "<li><img onclick=\"vote();\" src=\"Images/vote.gif\" />&nbsp;&nbsp;<img onclick=\"viewvote();\" src=\"images/view.gif\" /></li>";


        //下载排行
        reader=mylib.GetDownloadTop(4);
        downloadtop.DataSource = reader;
        downloadtop.DataBind();
        reader.Close();
        //各种资源链接
        reader = mylib.GetLibZy("馆藏资源", 0);
        gczy.DataSource = reader;
        gczy.DataBind();
        reader.Close();

        reader = mylib.GetLibZy("公共资源", 6);
        ggzy.DataSource = reader;
        ggzy.DataBind();
        reader.Close();

        reader = mylib.GetLibZy("军事电子资源", 6);
        jszy.DataSource = reader;
        jszy.DataBind();
        reader.Close();

        reader = mylib.GetLibZy("特色资源", 7);
        tszy.DataSource = reader;
        tszy.DataBind();
        reader.Close();

        mylib.WebDataClose();

        News mynews = new News();
        mynews.NewsDataOpen();
        reader = mynews.GetNewsList(1, "orderlist desc,pub_time desc", "notice", "istop=1 and ischeck=1");//置顶通知
        top2notice.DataSource = reader;
        top2notice.DataBind();
        reader.Close();
        //首页公告
        reader = mynews.GetNewsList(5, "orderlist desc,pub_time desc", "notice", "istop=0 and ischeck=1");
        this.indexnotice.DataSource = reader;
        indexnotice.DataBind();
        reader.Close();
        //置顶新闻
        reader = mynews.GetNewsList(0, "orderlist desc,pub_time desc", "news", "istop=1 and ischeck=1");
        top2news.DataSource = reader;
        top2news.DataBind();
        reader.Close();
        //首页新闻
        reader = mynews.GetNewsList(5, "orderlist desc,pub_time desc", "news", "istop=0 and ischeck=1");
        indexnews.DataSource = reader;
        indexnews.DataBind();
        reader.Close();
        mynews.NewsDataClose();
        //新书推荐
        Book mybook = new Book();
        mybook.BookDataOpen();
        reader = mybook.GetBookList(8,"addtime desc","istop=1");
        newbook.DataSource = reader;
        newbook.DataBind();
        reader.Close();
        mybook.BookDataClose();
        
        
        
    }
    public string IsNew(string pub_date)
    {
        DateTime pub_time = DateTime.Parse(pub_date);
        TimeSpan ss= DateTime.Now.Subtract(pub_time);
        if (ss.TotalDays < 3)
            return "<img src=\"Images/new.gif\" />";
        else
        {
            return pub_time.Year.ToString()+"-"+ pub_time.Month.ToString()+"-"+pub_time.Day.ToString();
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
