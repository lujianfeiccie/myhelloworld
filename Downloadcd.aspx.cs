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


public partial class Downloadcd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Functions myfun = new Functions();
        if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
        {
            LibCD mycd = new LibCD();
            mycd.CDID = Request.QueryString["id"].ToString();
            mycd.CDDataOpen();
            mycd.GetInfo();
            if (myfun.DownloadFile(Page.Request, Page.Response, mycd.CDURL, mycd.Title))
                mycd.AddDownload();
            else Response.Write("对不起没有找到文件！");
            mycd.CDDataClose();
        }
        else { Response.Write("对不起，非法访问！"); }
    }
}
