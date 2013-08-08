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

public partial class Admin_NoteList : System.Web.UI.Page
{
    public LibNote mynews = new LibNote();
    public Functions myfun = new Functions();
    public string showtype;
    public string jumpurl;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null && Session["username"].ToString() != "" && Session["loginstate"] != null && Session["loginstate"].ToString() == "ok")
        {
            Admin myadmin = new Admin();
            myadmin.UserName = Session["username"].ToString();
            myadmin.UserDataOpen();
            myadmin.GetAdminInfo();
            myadmin.UserDataClose();
            bool ismail = false;
            if (myadmin.NoteOP && Request.QueryString["type"] != null && Request.QueryString["type"].ToString() == "zx")
            {
                showtype = "zx";
                list_title.InnerHtml = "<strong>在线咨询列表</strong>";

            }
            else if (myadmin.NoteOP && Request.QueryString["type"] != null && Request.QueryString["type"].ToString() == "mail")
            {
                showtype = "mail";
                list_title.InnerHtml = "<strong>馆长信箱列表</strong>";
                ismail = true;

            }
            else { 
                Response.Write("对不起，您没有经过管理员授权管理此项目！"); Response.End(); 
            }
            mynews.NoteDataOpen();
            string url = HttpContext.Current.Request.Url.ToString();//这个是带参数的
            url = Request.FilePath + "?type=" + showtype;//不带参数的

            int nowpage = 1;
            int allpage = 9;
            int size = 20;//每页显示条数

            if (Request.QueryString["allpage"] != null && Request.QueryString["allpage"].ToString() != "")
            {
                allpage = int.Parse(Request.QueryString["allpage"].ToString());
            }
            else
            {
                allpage = mynews.GetNoteListNum(ismail, 2, size)[1]; 
            }
           
            if (Request.QueryString["pagenum"] != null && Request.QueryString["pagenum"].ToString() != "")
            {
                nowpage = int.Parse(Request.QueryString["pagenum"].ToString());
            }
            else
            {
                nowpage = 1;
            }
            jumpurl = Request.Url.ToString();
            SqlDataReader reader = mynews.GetNoteList(size, nowpage, ismail, 2);
            news_list_all.DataSource = reader;
            news_list_all.DataBind();
            reader.Close();
            mynews.NoteDataClose();
            mypagenum.PageURL = url;
            mypagenum.NowPage = nowpage;
            mypagenum.AllPage = allpage;
        }
        else { Response.Redirect("Default.aspx"); }
    }
}
