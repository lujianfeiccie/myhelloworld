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

public partial class Admin_UserList : System.Web.UI.Page
{
    public Functions myfun = new Functions();
    public string jumpurl = "SearchList.aspx";
    public bool isadmin = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null && Session["username"].ToString() != "" && Session["loginstate"] != null && Session["loginstate"].ToString() == "ok")
        {
            Admin myadmin = new Admin();
            myadmin.UserName = Session["username"].ToString();
            myadmin.UserDataOpen();
            myadmin.GetAdminInfo();
            myadmin.UserDataClose();
            
            if (myadmin.UserOP)
            {
                if (myadmin.UserType == "超级管理员")
                    isadmin = true;
                string url = HttpContext.Current.Request.Url.ToString();//这个是带参数的
                url = Request.FilePath + "?";//不带参数的
                Search mysearch = new Search();
                mysearch.SearchDataOpen();
                string condition = " 1=1 ";
                string check="yes";

                // if (Request.QueryString["condition"] != null && Request.QueryString["condition"].ToString() != "")
                //    condition = Request.QueryString["condition"].ToString();
              
                if (Request.QueryString["keyword"] != null && Request.QueryString["keyword"].ToString() != "")
                {
                    this.title.Value = Request.QueryString["keyword"].ToString();
                    condition = " username like '%" + this.title.Value + "%'";
                    url += "&keyword="+this.title.Value;

                }
                if (IsPostBack)
                {
                    condition = " username like '%" + this.title.Value + "%'";
                    url += "&keyword=" + this.title.Value;

                }
                if (Request.QueryString["check"] != null && Request.QueryString["check"].ToString() == "no")
                {
                    condition += " and ischeck=0";
                    url += "&check=no";
                }
                if (Request.QueryString["check"] != null && Request.QueryString["check"].ToString() == "yes")
                {
                    condition += " and ischeck=1";
                    url += "&check=yes";
                }
                if (Request.QueryString["type"] != null && Request.QueryString["type"].ToString() == "manage")
                {
                    condition += " and user_type='管理员'";
                }
                else { condition += " and user_type='普通用户'"; }
                
                int nowpage = 1;
                int allpage = 9;
                int size = 20;//每页显示条数
                if (Request.QueryString["allpage"] != null && Request.QueryString["allpage"].ToString() != "")
                    allpage = int.Parse(Request.QueryString["allpage"].ToString());
                else
                    allpage = mysearch.GetResultNum("lib_user", condition, size)[0];
                if (Request.QueryString["pagenum"] != null && Request.QueryString["pagenum"].ToString() != "")
                    nowpage = int.Parse(Request.QueryString["pagenum"].ToString());
                else nowpage = 1;
                jumpurl = Request.Url.ToString();
                DataTable reader = mysearch.GetSearchList("lib_user", "username", "username,userid,password,ischeck,reg_time,last_time,last_ip,login_times", condition, "username desc,userid desc", 3, 0, size, nowpage);
                news_list_all.DataSource = reader;
                news_list_all.DataBind();
                reader.Clear();
                mysearch.SearchDataClose();

                mypagenum.PageURL = url;
                mypagenum.NowPage = nowpage;
                mypagenum.AllPage = allpage;
                jumpurl = HttpContext.Current.Request.Url.ToString();//这个是带参数的
            }

            else { Response.Write("对不起，您没有经过管理员授权管理此项目！"); Response.End(); }

        }
        else { Response.Redirect("Default.aspx"); }
    }
}
