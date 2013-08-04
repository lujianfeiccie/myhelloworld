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

public partial class DoVote : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "" && Request.QueryString["act"] != null && Request.QueryString["act"].ToString() == "vote")
        {
            if (Session["isvote"] != null)
            {
                Response.Redirect("dovote.aspx");
                Response.End();
            }
            string voteid = Request.QueryString["id"].ToString();
            User myuser = new User();
            myuser.UserName = "guest";
            if (Session["username"] != null)
                myuser.UserName = Session["username"].ToString();
            try
            {
                string output="";
                myuser.UserDataOpen();
                myuser.VistVote(voteid, Request.UserHostAddress);
                myuser.UserDataClose();
                Session["isvote"] = "yes";//已经投票了
               //显示投票结果
                Vote myvote = new Vote();
                myvote.VoteID = "1";
                myvote.VoteDataOpen();
                output = myvote.ShowResult();
                myvote.VoteDataClose();

                Response.Write(output);
            }
            catch { Response.Write("0"); }
        }
        else
        {
            try
            {
                string output = "";
                //显示投票结果
                Vote myvote = new Vote();
                myvote.VoteID = "1";
                myvote.VoteDataOpen();
                output = myvote.ShowResult();
                myvote.VoteDataClose();
                
                Response.Write(output);
            }
            catch { Response.Write("0"); }
        }
    }
   
}
