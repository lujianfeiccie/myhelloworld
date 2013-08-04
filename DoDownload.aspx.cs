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

public partial class DoDownload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null && Request.QueryString["type"] != null)
        {
            string type="good";
            if(Request.QueryString["type"].ToString()=="bad")
                type="bad";
            if (Session["voteids"] != null)
            {
                string voteids = Session["voteids"].ToString();
                string[] ids = voteids.Split(',');
                for (int i = 0; i < ids.Length; i++)
                {
                    if (ids[i] == Request.QueryString["id"].ToString())
                    {
                        Response.Write("您已经对此项目投过票了，请稍后重试！" );
                        return;
                    }
                }
              

                Download mydown = new Download();
                mydown.ID = Request.QueryString["id"].ToString();
                mydown.DownloadDataOpen();
                Response.Write(mydown.AddComment(type));
                mydown.DownloadDataClose();
                
                Session["voteids"] = Session["voteids"].ToString() + "," + Request.QueryString["id"].ToString();
                return;

            }
            else
            {
                Session["voteids"] = Request.QueryString["id"].ToString();

                Download mydown = new Download();
                mydown.ID = Request.QueryString["id"].ToString();
                mydown.DownloadDataOpen();
                Response.Write(mydown.AddComment(type));
                mydown.DownloadDataClose();
                
                return;
            }
           
           
           
        }
        else { Response.Write("请正确访问！"); }
    }
}
