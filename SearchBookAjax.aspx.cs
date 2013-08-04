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

public partial class SearchBookAjax : System.Web.UI.Page
{
    public Functions myfun = new Functions();
    protected void Page_Load(object sender, EventArgs e)
    {
        Search mysearch = new Search();
        
        string title = "",keyword="",author="",publisher="",classno="",mode="and",orderlist="title",ordertype="desc",jsfs="title",sql="",tablename="[v_search]",condition=" 1=1 ",ordery="" ;
        int pagesize = 20, nowpage = 1;

        if (Request.QueryString["type"] != null && Request.QueryString["type"].ToString() == "simple")
        {
            mysearch.SearchDataOpen();
            if (Request.QueryString["pagesize"] != null)
            {
                pagesize = int.Parse(Request.QueryString["pagesize"].ToString());
            }
            if (Request.QueryString["nowpage"] != null && Request.QueryString["nowpage"].ToString() != "")
            {
                int temp = int.Parse(Request.QueryString["nowpage"].ToString());
                if (temp > 1)
                    nowpage = temp;
                    
            }
            //sql = "select distinct top "+pagesize+" * from [v_search] where 1=1 ";
            if (Request.QueryString["jsfs"] != null)
            {
                string temp=Request.QueryString["jsfs"].ToString();
                switch (temp)
                { 
                    case "title":
                    case "classno":
                    case "publisher":
                    case "keyword":
                    case "author":
                        jsfs = temp;
                        break;
                };
            }
             if (Request.QueryString["keyword"] != null && Request.QueryString["keyword"].ToString() != "")
            {
                keyword = myfun.No_SqlHack(Request.QueryString["keyword"].ToString());
                mysearch.AddSearchWord(keyword);
            }
            if (Request.QueryString["mode"] != null && Request.QueryString["mode"].ToString() == "0")
            {

                condition = condition + " and " + jsfs + " like '%" + keyword + "%' ";
            }
            else
            {
                condition = condition + " and " + jsfs + "='" + keyword + "' ";
            }

           

            if (Request.QueryString["orderlist"] != null)
            {

                switch (Request.QueryString["orderlist"].ToString())
                {

                    case "pubdate":
                       
                    case "classno":
                       
                    case "bookno":
                      
                    case "author":
                        
                    case "title":
                       
                    case "createdate":
                        orderlist = Request.QueryString["orderlist"].ToString();
                    
                        break;
                };
            }


            if (Request.QueryString["ordertype"] != null && Request.QueryString["ordertype"].ToString() == "asc")
            {
                ordertype = "asc";
                ordery =" order by " + orderlist + " " + ordertype;
            }
            else {
                
                ordertype = "desc";
                ordery = " order by " + orderlist + " " + ordertype;
            }
            sql = "select   top " + pagesize + " * from [v_search] where recid not in(select  top " + (nowpage - 1) * pagesize + " recid from [lib_search_v] where " + condition + ordery + " ) and " + condition + ordery;
            SqlDataReader reader=  mysearch.GetResult(sql);
             list_all.DataSource = reader;
            list_all.DataBind();
             reader.Close();
             int[] mynum = mysearch.GetResultNum("v_search", condition, pagesize);
            mysearch.SearchDataClose();
            if (nowpage > mynum[0])
                nowpage = mynum[0];
            mypage.AllPage = mynum[0];
            mypage.NowPage = nowpage;
            mypage.PageURL = "#";
            mypage.OnClikAction = "SearchAjax";
            mypage.ActionParas = "'"+keyword+"','type=simple&jsfs=" + jsfs + "&pagesize=" + pagesize.ToString() + "&mode=" + Request.QueryString["mode"].ToString() + "&orderlist=" + orderlist + "&ordertype=" + ordertype+"'";

            //Response.Write(sql+"共有"+mynum[0].ToString()+"/"+mynum[1].ToString());

        }
        else if (Request.QueryString["type"] != null && Request.QueryString["type"].ToString() == "complex")
        {
            mysearch.SearchDataOpen();
            if (Request.QueryString["pagesize"] != null)
            {
                pagesize = int.Parse(Request.QueryString["pagesize"].ToString());
            }
            if (Request.QueryString["nowpage"] != null && Request.QueryString["nowpage"].ToString() != "")
            {
                int temp = int.Parse(Request.QueryString["nowpage"].ToString());
                if (temp > 1)
                    nowpage = temp;

            }
            //sql = "select distinct top "+pagesize+" * from [v_search] where 1=1 ";
            if (Request.QueryString["mode"] != null && Request.QueryString["mode"].ToString() == "0")
            {

                mode = " or ";
            }
            else
            {
                mode = " and ";
            }
            if (Request.QueryString["keyword"] != null && Request.QueryString["keyword"].ToString() != "")
            {
                keyword = myfun.No_SqlHack(Request.QueryString["keyword"].ToString());
                mysearch.AddSearchWord(keyword);
                condition += mode+" keyword like '%"+keyword+"%' ";
            }
            if (Request.QueryString["title"] != null && Request.QueryString["title"].ToString() != "")
            {
                title = myfun.No_SqlHack(Request.QueryString["title"].ToString());
                mysearch.AddSearchWord(title);
                condition = condition+ mode + " title like '%" + title + "%' ";
            }
            if (Request.QueryString["author"] != null && Request.QueryString["author"].ToString() != "")
            {
                author = myfun.No_SqlHack(Request.QueryString["author"].ToString());
                condition = condition+ mode + " author like '%" + author + "%' ";
                
            }
            if (Request.QueryString["publisher"] != null && Request.QueryString["publisher"].ToString() != "")
            {
                publisher = myfun.No_SqlHack(Request.QueryString["publisher"].ToString());
                condition = condition + mode + " publisher like '%" + publisher + "%' ";
               
            }
            if (Request.QueryString["classno"] != null && Request.QueryString["classno"].ToString() != "")
            {
                classno = myfun.No_SqlHack(Request.QueryString["classno"].ToString());
                condition = condition + mode + " classno like '%" + classno + "%' ";
                
            }
            



            if (Request.QueryString["orderlist"] != null)
            {

                switch (Request.QueryString["orderlist"].ToString())
                {

                    case "pubdate":

                    case "classno":

                    case "bookno":

                    case "author":

                    case "title":

                    case "createdate":
                        orderlist = Request.QueryString["orderlist"].ToString();

                        break;
                };
            }


            if (Request.QueryString["ordertype"] != null && Request.QueryString["ordertype"].ToString() == "asc")
            {
                ordertype = "asc";
                
            }
            else
            {

                ordertype = "desc";
              
            }
            ordery = " order by " + orderlist + " " + ordertype;
                
            sql = "select   top " + pagesize + " * from [v_search] where recid not in(select  top " + (nowpage - 1) * pagesize + " recid from [lib_search_v] where " + condition + ordery + " ) and " + condition + ordery;
          
            SqlDataReader reader = mysearch.GetResult(sql);
            list_all.DataSource = reader;
            list_all.DataBind();
            reader.Close();
            int[] mynum = mysearch.GetResultNum("v_search", condition, pagesize);
            mysearch.SearchDataClose();
            if (nowpage > mynum[0])
                nowpage = mynum[0];
            mypage.AllPage = mynum[0];
            mypage.NowPage = nowpage;
            mypage.PageURL = "#";
            mypage.OnClikAction = "SearchAjax2";
            mypage.ActionParas = "'" + keyword + "','" + title + "','" + author + "','" + publisher + "','type=complex&classno=" + classno + "&pagesize=" + pagesize.ToString() + "&mode=" + mode + "&orderlist=" + orderlist + "&ordertype=" + ordertype + "'";

            
        }
        else
        { Response.Write("请正确访问页面！"); }
    }
}
