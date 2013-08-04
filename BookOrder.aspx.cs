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

public partial class BookOrder : System.Web.UI.Page
{
    public Functions myfun = new Functions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null && Session["userid"] != null)
        {

            User myuser = new User();
            myuser.UserID = Session["userid"].ToString();
            myuser.UserDataOpen();

            SqlDataReader reader = myuser.GetResever();
            myborrow.DataSource = reader;
            myborrow.DataBind();
            reader.Close();
            myuser.UserDataClose();
        }
        else { Response.Write("请正确登陆后操作！"); Response.End(); }
    }
}
