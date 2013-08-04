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

public partial class Admin_DoUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null && Session["username"].ToString() != "")
        {
            Admin myadmin = new Admin();
            myadmin.UserName = Session["username"].ToString();
            myadmin.UserDataOpen();
            myadmin.GetAdminInfo();

            if (myadmin.UserOP)
            {

                if (Request.QueryString["act"] != null && Request.QueryString["act"].ToString() == "del")
                {
                    string id = Request.QueryString["ids"].ToString();
                    string[] ids = id.Split(',');


                    try
                    {
                        for (int t = 0; t < ids.Length; t++)
                        {
                            myadmin.DeleteUser(ids[t].ToString());
                        }
                        Response.Write("ok");
                    }
                    catch
                    {
                        Response.Write("删除失败");
                    }

                }
                if (Request.QueryString["act"] != null && Request.QueryString["act"].ToString() == "check")
                {
                    bool checkstate = true;
                    if (Request.QueryString["state"] != null && Request.QueryString["state"].ToString() == "0")
                        checkstate = false;


                    string id = Request.QueryString["ids"].ToString();
                    string[] ids = id.Split(',');


                    try
                    {
                        for (int t = 0; t < ids.Length; t++)
                        {
                            myadmin.CheckUser( ids[t].ToString(), checkstate);
                        }
                        Response.Write("ok");
                    }
                    catch
                    {
                        Response.Write("审核失败");
                    }

                }
                if (Request.QueryString["act"] != null && Request.QueryString["act"].ToString() == "settype"&&myadmin.UserType=="超级管理员")
                {

                    string usertypeh = "普通用户";
                    if (Request.QueryString["usertype"] != null && Request.QueryString["usertype"].ToString() == "gly")
                    { usertypeh = "管理员"; }


                    string id = Request.QueryString["ids"].ToString();
                    string[] ids = id.Split(',');


                    try
                    {
                        for (int t = 0; t < ids.Length; t++)
                        {
                            myadmin.SetUserType(ids[t].ToString(),usertypeh);
                        }
                        Response.Write("ok");
                    }
                    catch
                    {
                        Response.Write("操作失败");
                    }

                }
                if (Request.QueryString["act"] != null&&Request.QueryString["type"]!=null && Request.QueryString["act"].ToString() == "update"&&Request.QueryString["type"].ToString()=="manage")
                {
                    Admin myadmin2 = new Admin();

                    myadmin2.UserName = Request.QueryString["username"].ToString();
                    myadmin2.PassWord = Request.QueryString["psw"].ToString();
                    myadmin2.UserOP = bool.Parse(Request.QueryString["user"].ToString());
                    myadmin2.NewsOP = bool.Parse(Request.QueryString["news"].ToString());
                    myadmin2.NoticeOP = bool.Parse(Request.QueryString["notice"].ToString());
                    myadmin2.LinkOP = bool.Parse(Request.QueryString["links"].ToString());
                    myadmin2.ZyOP = bool.Parse(Request.QueryString["zy"].ToString());
                    myadmin2.WebOP = bool.Parse(Request.QueryString["web"].ToString());
                    myadmin2.NoteOP = bool.Parse(Request.QueryString["note"].ToString());
                    myadmin2.DownloadOP = bool.Parse(Request.QueryString["download"].ToString());
                    myadmin2.SearchOP = bool.Parse(Request.QueryString["search"].ToString());
                    myadmin2.BookOP = bool.Parse(Request.QueryString["book"].ToString());
                    myadmin2.VoteOP = bool.Parse(Request.QueryString["vote"].ToString());
                    myadmin2.PaperOP = bool.Parse(Request.QueryString["paper"].ToString());
                    


                    try
                    {
                        myadmin2.UserDataOpen();
                        Response.Write(myadmin2.SetAdminInfo());
                        myadmin2.UserDataClose();
                    }
                    catch
                    {
                        Response.Write("审核失败");
                    }

                }
                if (Request.QueryString["act"] != null && Request.QueryString["type"] != null && Request.QueryString["act"].ToString() == "add" && Request.QueryString["type"].ToString() == "manage")
                {
                    Admin myadmin2 = new Admin();

                    myadmin2.UserName = Request.QueryString["username"].ToString();
                    myadmin2.PassWord = Request.QueryString["psw"].ToString();
                    myadmin2.UserOP = bool.Parse(Request.QueryString["user"].ToString());
                    myadmin2.NewsOP = bool.Parse(Request.QueryString["news"].ToString());
                    myadmin2.NoticeOP = bool.Parse(Request.QueryString["notice"].ToString());
                    myadmin2.LinkOP = bool.Parse(Request.QueryString["links"].ToString());
                    myadmin2.ZyOP = bool.Parse(Request.QueryString["zy"].ToString());
                    myadmin2.WebOP = bool.Parse(Request.QueryString["web"].ToString());
                    myadmin2.NoteOP = bool.Parse(Request.QueryString["note"].ToString());
                    myadmin2.DownloadOP = bool.Parse(Request.QueryString["download"].ToString());
                    myadmin2.SearchOP = bool.Parse(Request.QueryString["search"].ToString());
                    myadmin2.BookOP = bool.Parse(Request.QueryString["book"].ToString());
                    myadmin2.VoteOP = bool.Parse(Request.QueryString["vote"].ToString());
                    myadmin2.PaperOP = bool.Parse(Request.QueryString["paper"].ToString());



                    try
                    {
                        myadmin2.UserDataOpen();
                        Response.Write(myadmin2.AddAdmin());
                        myadmin2.UserDataClose();
                    }
                    catch
                    {
                        Response.Write("增加失败！");
                    }

                }
                
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
