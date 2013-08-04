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

public partial class DoNote : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Functions myfun = new Functions();
        LibNote mynote = new LibNote();
        User myuser = new User();
        if (Request.QueryString["type"] != null && Request.QueryString["type"].ToString() == "zx")
        {
            string title = "",info="",replyid="";
            mynote.IsOver = false;
            if (Request.QueryString["title"] != null)
                title = myfun.No_SqlHack(Request.QueryString["title"].ToString());
            if (Request.QueryString["info"] != null)
                info = myfun.No_SqlHack(Request.QueryString["info"].ToString());
            
            if (Session["username"] != null && Session["username"].ToString() != "")
            {
                myuser.UserName = Session["username"].ToString();
                mynote.PubUser = myuser.UserName;
            }
            else { mynote.PubUser = "guest"; myuser.UserName = "guest"; }
            mynote.VisitNum = 0;
            mynote.TypeName = "";
            mynote.Title = title;
            mynote.ReplyTime = DateTime.Now;
            mynote.PubTime = DateTime.Now;
            mynote.PubIP = Request.UserHostAddress;
            mynote.IsTop = false;
           
            mynote.IsMail = false;
            mynote.IsCheck = false;
            mynote.Info = info;
            mynote.CheckAdmin = "";
            try
            {
                myuser.UserDataOpen();
                if (Request.QueryString["act"] != null && Request.QueryString["act"].ToString() == "add")
                {
                    mynote.IsOver = false;
                    myuser.AddLibNote(mynote);
                }
                else if (Request.QueryString["act"] != null && Request.QueryString["act"].ToString() == "reply")
                {
                    replyid = Request.QueryString["replyid"].ToString();
                    myuser.UpdateNoteOver(replyid,mynote.Info);

                }
                
              
                myuser.UserDataClose();
                Response.Write("ok");
            }
            catch { Response.Write("对不起系统错误"); }
        }
        else if (Request.QueryString["type"] != null && Request.QueryString["type"].ToString() == "mail")
        {
            string title = "", info = "", typename = "";
            if (Request.QueryString["title"] != null)
                title = myfun.No_SqlHack(Request.QueryString["title"].ToString());
            if (Request.QueryString["info"] != null)
                info = myfun.No_SqlHack(Request.QueryString["info"].ToString());
            if (Request.QueryString["typename"] != null)
                typename = myfun.No_SqlHack(Request.QueryString["typename"].ToString());
            if (Session["username"] != null && Session["username"].ToString() != "")
            {
                myuser.UserName = Session["username"].ToString();
                mynote.PubUser = myuser.UserName;
            }
            else { Response.Write("请登录后操作！"); Response.End(); }
            mynote.VisitNum = 0;
            mynote.TypeName = typename;
            mynote.Title = title;
            mynote.ReplyUser = "";
            mynote.PubTime = DateTime.Now;
            mynote.PubIP = Request.UserHostAddress;
            mynote.IsTop = false;
            mynote.IsOver = false;
            mynote.IsMail = true;
            mynote.IsCheck = false;
            mynote.Info = info;
            mynote.CheckAdmin = "";
            try
            {
                myuser.UserDataOpen();
                myuser.AddLibNote(mynote);
                myuser.UserDataClose();
                Response.Write("ok");
            }
            catch { Response.Write("对不起系统错误"); }
        }
        else { Response.Write("请正确访问！"); }
    }
}
