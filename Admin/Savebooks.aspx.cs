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

public partial class Admin_Savebooks : System.Web.UI.Page
{
   
    public Admin myadmin = new Admin();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null && Session["username"].ToString() != "" && Session["loginstate"] != null && Session["loginstate"].ToString() == "ok")
        {
            Functions myfun = new Functions();
            

            myadmin.UserName = Session["username"].ToString();
            myadmin.UserDataOpen();
            myadmin.GetAdminInfo();
            
            myadmin.UserDataClose();
        }
        else { Response.Write("请正确登陆后操作"); Response.End(); }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (myadmin.BookOP)
        {
            myadmin.UserDataOpen();
            Label1.Text = myadmin.BackUpBooks();
            myadmin.UserDataClose();
            this.Button1.Visible = false;
        }
        else { Response.Write("请正确登陆后操作"); Response.End(); }
    }
}
