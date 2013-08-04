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

public partial class Admin_LibWT : System.Web.UI.Page
{
    public string[] result = new string[4];
    public string type = "px";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["username"] != null && Session["username"].ToString() != "" && Session["loginstate"] != null && Session["loginstate"].ToString() == "ok")
        {
            Admin myadmin = new Admin();
            myadmin.UserName = Session["username"].ToString();
            myadmin.UserDataOpen();
            myadmin.GetAdminInfo();


            if (myadmin.DownloadOP)
            {
               
                LibWeb myweb = new LibWeb();
                if (IsPostBack)
                {
                    myadmin.PageInfoSet("px", title.Text, FCKeditor1.Value);
                }

                myweb.WebDataOpen();
                result = myweb.GetPageInfo(type);
                FCKeditor1.Value = result[1];
                title.Text = result[0];
                myweb.WebDataClose();
            }
            else { Response.Write("对不起，你没有访问权限！"); Response.End(); }
            myadmin.UserDataClose();
        }
        else { Response.Write("请正确访问本页面！"); Response.End(); }
    }
}
