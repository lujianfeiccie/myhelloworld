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

public partial class Admin_DoVote : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["username"] != null && Session["username"].ToString() != "")
        {
            Admin myadmin = new Admin();
            myadmin.UserName = Session["username"].ToString();
            myadmin.UserDataOpen();
            myadmin.GetAdminInfo();

            if (myadmin.VoteOP)
            {

                if (Request.QueryString["act"] != null && Request.QueryString["act"].ToString() == "del")
                {
                    Response.Write(myadmin.DeleteVoteOption(Request.QueryString["id"].ToString()));

                }
                else  if (Request.QueryString["act"] != null && Request.QueryString["act"].ToString() == "update")
                {
                    string votetitle = Request.QueryString["title"].ToString();
                    string voteid = Request.QueryString["id"].ToString();
                    int votenum = int.Parse(Request.QueryString["num"].ToString());
                    int orderlist = int.Parse(Request.QueryString["orderlist"].ToString());

                    Response.Write(myadmin.UpdateVoteOption(voteid,votetitle,votenum,orderlist));
                }
                else if (Request.QueryString["act"] != null && Request.QueryString["act"].ToString() == "add")
                {

                    
                    string vote_title = Request.QueryString["title"].ToString();
                
                    int vote_num=int.Parse(Request.QueryString["num"].ToString());
                    
                    int vote_order = int.Parse(Request.QueryString["orderlist"].ToString());
                    Response.Write(myadmin.AddVoteOption(vote_title,vote_num,vote_order));
                }
                else if (Request.QueryString["act"] != null && Request.QueryString["act"].ToString() == "updatetitle")
                {


                    string vote_title = Request.QueryString["title"].ToString();
                     Response.Write(myadmin.UpdateVoteTitle("1",vote_title));
                }
                else
                { Response.Write("非法访问！"); }
                
            }
            else
            {
                Response.Write("对不起，您没有操作此项目的权限！");
                Response.End();
            }

            myadmin.UserDataClose();
        }
        else { Response.Write("请登录后操作！"); }
    }
}
