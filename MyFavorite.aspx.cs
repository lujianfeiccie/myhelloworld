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

public partial class MyFavorite : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null && Session["username"].ToString() != "")
        {
            User myuser = new User();
            myuser.UserName = Session["username"].ToString();
            myuser.UserDataOpen();

            SqlDataReader reader;


            reader = myuser.GetFavoriteList();
            this.myfavoritelist.DataSource = reader;
            myfavoritelist.DataBind();
            reader.Close();
            myuser.UserDataClose();

        }
        else { Response.Write("请登录后操作！"); Response.End(); }
    }
}
