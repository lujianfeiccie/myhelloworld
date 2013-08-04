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

public partial class Admin_VoteList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null && Session["username"].ToString() != "" && Session["loginstate"] != null && Session["loginstate"].ToString() == "ok")
        {
            Functions myfun = new Functions();
            Admin myadmin = new Admin();
            string url = "NewsList.aspx?type=news";
            myadmin.UserName = Session["username"].ToString();
            myadmin.UserDataOpen();
            myadmin.GetAdminInfo();
            if (myadmin.VoteOP)
            {
                Vote myvote = new Vote();
                myvote.VoteID = "1";
                myvote.VoteDataOpen();
                myvote.GetVoteTitle();
               SqlDataReader reader= myvote.GetVoteOptions_reader();

               this.vote_title_head.InnerHtml = "<strong>"+myvote.Title+"----投票管理</strong>";
             link_list_all.DataSource = reader;
             link_list_all.DataBind();
             reader.Close();
             myvote.VoteDataClose();
            
            }
            else { Response.Write("对不起，你没有管理此项目的权限！"); Response.End(); }
            myadmin.UserDataClose();
        }
        else
        {
            Response.Write("请正确登陆后操作！");
            Response.End();
        }
    }
  
}
