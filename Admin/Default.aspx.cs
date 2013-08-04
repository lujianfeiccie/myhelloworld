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

public partial class Admin_Default : System.Web.UI.Page
{
    public string loginfo = "欢迎登陆后台管理系统";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["action"] != null && Request.QueryString["action"].ToString() == "login")
        {
            Functions myfun = new Functions();
            Admin myadmin = new Admin();
            string username = myfun.No_SqlHack(Request.Form["username"].ToString());
            string password = myfun.No_SqlHack(Request.Form["userpsw"].ToString());
            myadmin.UserName = username;
            myadmin.PassWord = password;
            myadmin.LoginIP = Request.UserHostAddress;
            myadmin.UserDataOpen();
            if (myadmin.AdminLogin())
            {
                Session["username"] = username;
                Session["admin"] = "ok";
                Session["loginstate"] = "ok";
                Response.Redirect("Index.aspx");

            }
            else
            {
                loginfo = "用户名或密码错误，请重试！";
            }
            myadmin.UserDataClose();
        }
    }
}
