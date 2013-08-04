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

public partial class Admin_LibInfoSet : System.Web.UI.Page
{
    public string[] result = new string[4];
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["username"] != null && Session["username"].ToString() != "" && Session["loginstate"] != null && Session["loginstate"].ToString() == "ok")
        {
            Admin myadmin = new Admin();
            myadmin.UserName = Session["username"].ToString();
            myadmin.UserDataOpen();
            myadmin.GetAdminInfo();


            if (myadmin.WebOP)
            {
                string type = "jj";//默认为简介
                if (Request.QueryString["type"] != null && Request.QueryString["type"].ToString() != "")
                {
                    type = Request.QueryString["type"].ToString();
                }
                LibWeb myweb = new LibWeb();
                if (IsPostBack)
                {
                    myadmin.PageInfoSet(type, title.Text, FCKeditor1.Value);
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
