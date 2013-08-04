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

public partial class DelayBook : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] != null && Session["userid"].ToString() != "")
        {
            User myuser = new User();
            myuser.UserID = Session["userid"].ToString();
            myuser.UserDataOpen();

            string id = Request.QueryString["ids"].ToString();
            string[] ids = id.Split(',');
            for (int t = 0; t < ids.Length; t++)
            {
              Response.Write(  myuser.DelayBook(ids[t], 28)+"<br />");
            }
            
            myuser.UserDataClose();
        }
        else { Response.Write("请正确访问！"); }
    }
}
