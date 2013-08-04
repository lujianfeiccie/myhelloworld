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

public partial class SearchNewBook : System.Web.UI.Page
{
    
    public Functions myfun = new Functions();
    public string date1 = "", date2 = "",thekeytag="";
    protected void Page_Load(object sender, EventArgs e)
    {
        Search mysearch = new Search();
        mysearch.SearchDataOpen();
        date1 = DateTime.Now.AddMonths(-1).ToString();
        date2 = DateTime.Now.ToString();
        
        string url = Request.FilePath + "?";//不带参数的
        mysearch.AllNum=0;
        mysearch.PageNum=1;
        int nowpage = 1;
        int allpage = 9;
        int size = 24;//每页显示条数
        if (Request.QueryString["allnum"] != null && Request.QueryString["allnum"].ToString() != "")
        {
           // mysearch.AllNum = int.Parse(Request.QueryString["allnum"].ToString());
            
        }
        if (Request.QueryString["pagenum"] != null && Request.QueryString["pagenum"].ToString() != "")
            nowpage = int.Parse(Request.QueryString["pagenum"].ToString());
        else nowpage = 1;

        string title = "",author="",typename="",timestr="",conditons=" 1=1 ";
        if (Request.QueryString["title"] != null && Request.QueryString["title"].ToString() != "")
        {
            title = myfun.No_SqlHack(Request.QueryString["title"].ToString());
            conditons += " and title like '%"+title+"%' ";
            url += "&title="+title;
            thekeytag = title;
            //mysearch.KeyWord=title;
            mysearch.AddSearchWord(title);//只是增加了对题名的搜索关注
        }
        if (Request.QueryString["author"] != null && Request.QueryString["author"].ToString() != "")
        {
            author = myfun.No_SqlHack(Request.QueryString["author"].ToString());
            conditons += " and author like '%"+author+"%' ";
            url += "&author="+author;
            thekeytag = author;
        }
        if (Request.QueryString["typename"] != null && Request.QueryString["typename"].ToString() != "")
        {
            typename = myfun.No_SqlHack(Request.QueryString["typename"].ToString());
            conditons += " and typename like '%"+typename+"%' ";
            url += "&typename=" + typename;
            thekeytag = typename;
        }

        if (Request.QueryString["date1"] != null && Request.QueryString["date1"].ToString() != "" && Request.QueryString["date2"] != null && Request.QueryString["date2"].ToString() != "")
        {
            
            date1 = myfun.No_SqlHack(Request.QueryString["date1"].ToString());
            date2 = myfun.No_SqlHack(Request.QueryString["date2"].ToString());
            timestr = " and addtime between '" + date1 + "' and '" + date2+"'";
            conditons += timestr;
            url += "&date1="+date1+"&date2="+date2;
            
        }

        SqlDataReader reader = mysearch.GetHotSearch(50);
        top10.DataSource = reader;
        top10.DataBind();
        reader.Close();
        

        //this.condition1.InnerHtml = conditons;
        DataTable myresult= mysearch.GetSearchList("lib_newbook", "id", "*", conditons, "addtime desc,id desc", 3, mysearch.AllNum, size, nowpage);
        books_list_all.DataSource = myresult;
        books_list_all.DataBind();
        myresult.Clear();
        mysearch.SearchDataClose();

        url += "&allnum=" + mysearch.AllNum;

        if (Request.QueryString["allpage"] != null && Request.QueryString["allpage"].ToString() != "")
            allpage = int.Parse(Request.QueryString["allpage"].ToString());
        else
            allpage = mysearch.PageNum;

        mypage.PageURL = url;
        mypage.NowPage = nowpage;
        mypage.AllPage = allpage;

    }
}
