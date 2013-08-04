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

public partial class Admin_SearchList : System.Web.UI.Page
{
    public Functions myfun = new Functions();
    public string jumpurl = "SearchList.aspx";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null && Session["username"].ToString() != "" && Session["loginstate"] != null && Session["loginstate"].ToString() == "ok")
        {
            Admin myadmin = new Admin();
            myadmin.UserName = Session["username"].ToString();
            myadmin.UserDataOpen();
            myadmin.GetAdminInfo();
            myadmin.UserDataClose();
            if (myadmin.SearchOP)
            {
                string url = HttpContext.Current.Request.Url.ToString();//这个是带参数的
                url = Request.FilePath + "?";//不带参数的
                Search mysearch = new Search();
                mysearch.SearchDataOpen();
                string condition = " 1=1 ";
               // if (Request.QueryString["condition"] != null && Request.QueryString["condition"].ToString() != "")
                //    condition = Request.QueryString["condition"].ToString();
                if (Request.QueryString["keyword"] != null && Request.QueryString["keyword"].ToString() != "")
                {
                    this.title.Value = Request.QueryString["keyword"].ToString();
                    condition = " keyword like '%" + this.title.Value + "%'";
                    url += "&keyword=" + this.title.Value;

                }
                if (IsPostBack)
                {
                    condition = " keyword like '%" + this.title.Value + "%'";
                    url += "&keyword=" + this.title.Value;

                }
                
                int nowpage = 1;
                int allpage = 9;
                int size = 5;//每页显示条数
                if (Request.QueryString["allpage"] != null && Request.QueryString["allpage"].ToString() != "")
                    allpage = int.Parse(Request.QueryString["allpage"].ToString());
                else
                    allpage = mysearch.GetResultNum("lib_search",condition,size)[0];
                if (Request.QueryString["pagenum"] != null && Request.QueryString["pagenum"].ToString() != "")
                    nowpage = int.Parse(Request.QueryString["pagenum"].ToString());
                else nowpage = 1;
                jumpurl = Request.Url.ToString();
                DataTable reader = mysearch.GetSearchList("lib_search","id","*",condition,"all_num desc,id desc",3,0,size,nowpage);
                news_list_all.DataSource = reader;
                news_list_all.DataBind();
                reader.Clear();
                mysearch.SearchDataClose();

                mypagenum.PageURL = url;
                mypagenum.NowPage = nowpage;
                mypagenum.AllPage = allpage;
                jumpurl =HttpContext.Current.Request.Url.ToString();//这个是带参数的
            }

            else { Response.Write("对不起，您没有经过管理员授权管理此项目！"); Response.End(); }

        }
        else { Response.Redirect("Default.aspx"); }
    }
}
