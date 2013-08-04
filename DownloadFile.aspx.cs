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

public partial class DownloadFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
        {
            string userid = "guest";
            if (Session["username"] != null && Session["username"].ToString() != "")
                userid = Session["username"].ToString();
            Download mydown = new Download();
            mydown.ID = Request.QueryString["id"].ToString();
            mydown.DownloadDataOpen();
            mydown.GetDownloadInfo();
            try
            {
                //mydown.AddDownloadRecord(Request.UserHostAddress, userid);
                mydown.DownloadFile(Page.Request, Page.Response, userid);
                
            }
            catch { Response.Write("对不起，系统错误！"); }
            finally { mydown.DownloadDataClose(); }
           
        }
        else { Response.Write("对不起，非法访问！"); }
    }
}
