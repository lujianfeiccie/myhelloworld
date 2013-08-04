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

public partial class MyInfo : System.Web.UI.Page
{
    public Functions myfun = new Functions();
    public User myuser = new User();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] != null && Session["userid"].ToString() != "")
        {
            string oldpsw,newpsw;

            myuser.UserName = Session["username"].ToString();
           // myuser.UserID = Session["userid"].ToString();
            myuser.UserDataOpen();


            if (Request.QueryString["act"] != null && Request.QueryString["act"] == "psw")
            {

                oldpsw = Request.Form["oldpsw"].ToString();
                newpsw = Request.Form["newpsw"].ToString();
                myuser.PassWord = oldpsw;
                result.InnerText=  myuser.ChangePassword(newpsw);

            }

            myuser.GetUserInfo();
            myuser.UserDataClose();

        }
        else { Response.Write("请登录后操作！"); Response.End(); }
    }
}
