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

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        if (Request.QueryString["act"] != null && Request.QueryString["UserName"] != null && Request.QueryString["act"].ToString() == "checkname")
        {
            string username = Request.QueryString["UserName"].ToString();
            User myuser = new User();
            myuser.UserName = username;
            myuser.UserDataOpen();
            if (!myuser.UserCheck(username))
                Response.Write("ok");
            else Response.Write("faild");
            myuser.UserDataClose();


        }
        else if (Request.QueryString["act"] != null && Request.QueryString["card"] != null && Request.QueryString["act"].ToString() == "checkcard")
        {
            string username = Request.QueryString["card"].ToString();
            User myuser = new User();
            //myuser.UserName = username;
            myuser.UserDataOpen();
            Response.Write(myuser.UserCheck(username, true));
            myuser.UserDataClose();


        }
        else if (Request.QueryString["act"] != null && Request.QueryString["act"].ToString() == "reg")
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];
            string tishi = Request.Form["tishi"];
            string answer = Request.Form["answer"];
            string card = Request.Form["card"];
           
            string ip = Page.Request.UserHostAddress;
            DateTime regtime = DateTime.Now;

            User myuser = new User();
            myuser.UserName = username;
            myuser.UserID = card;
            myuser.FindPswQuestion = tishi;
            myuser.FindPswAnswer = answer;
            myuser.PassWord = password;
            myuser.UserType = "普通用户";
            myuser.LoginTimes = 1;
            myuser.LoginTime = regtime;
            myuser.LoginIP = ip;
            myuser.LastLoginTime = regtime;
            myuser.LastLoginIP = ip;
            myuser.IsChecked = false;
            myuser.UserDataOpen();
            if (myuser.UserRegister()=="ok")
            {

                Session["userid"] = card;
                Session["username"] = username;
                Session["login_state"] = "ok";
                Session["usertype"] = "普通用户";
                Response.Redirect("MyLib.aspx");
            }
            else
            {
                Response.Write("对不起，注册失败！");
            }

            myuser.UserDataClose();

           

        }
        else
        {
            Response.Redirect("default.aspx");

        }
    }
}
