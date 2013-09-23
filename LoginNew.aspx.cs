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

public partial class LoginNew : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Functions myfun = new Functions();
        if (Request.QueryString["act"] != null && Request.QueryString["act"] == "in")
        {
            string username =myfun.No_SqlHack( Request.Form["username"].ToString());
            string psw =myfun.No_SqlHack( Request.Form["password"].ToString());

            User myuser = new User();
            myuser.UserName = username;
            myuser.PassWord = psw;
            myuser.LoginIP = Request.UserHostAddress;
            myuser.UserDataOpen();

            if (myuser.UserLogin())
            {
                myuser.GetUserInfo();
                Session["userid"] = myuser.UserID;
                Session["username"] = username;
                Session["loginstate"] = "ok";
                Response.Redirect("MyLibNew.aspx");
            }
            else 
            {
                Response.Redirect("index.aspx"); 
            }
            myuser.UserDataClose();

        }
        else if (Request.QueryString["act"] != null && Request.QueryString["act"] == "out")
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("index.aspx");
        }
        else
        { Response.Write("请正确访问本页面！"); Response.End(); }

    }
}
