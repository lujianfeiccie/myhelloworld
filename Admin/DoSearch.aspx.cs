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

public partial class Admin_DoSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null && Session["username"].ToString() != "")
        {
            Admin myadmin = new Admin();
            myadmin.UserName = Session["username"].ToString();
            myadmin.UserDataOpen();
            myadmin.GetAdminInfo();

            if (myadmin.SearchOP)
            {

                if (Request.QueryString["act"] != null && Request.QueryString["act"].ToString() == "del")
                {
                    string id = Request.QueryString["ids"].ToString();
                    string[] ids = id.Split(',');


                    try
                    {
                        for (int t = 0; t < ids.Length; t++)
                        {
                            myadmin.DeleteSearch(ids[t].ToString());
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
                            myadmin.CheckSearch("ischeck",checkstate,ids[t].ToString());
                        }
                        Response.Write("ok");
                    }
                    catch
                    {
                        Response.Write("审核失败");
                    }

                }
                if (Request.QueryString["act"] != null && Request.QueryString["act"].ToString() == "top")
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
                            myadmin.CheckSearch("istop", checkstate, ids[t].ToString());
                        }
                        Response.Write("ok");
                    }
                    catch
                    {
                        Response.Write("推荐失败");
                    }

                }
                if (Request.QueryString["act"] != null && Request.QueryString["act"].ToString() == "update")
                {
                    Search mysearch = new Search();
                    mysearch.SearchID = Request.QueryString["id"].ToString();
                    mysearch.KeyWord = Request.QueryString["title"].ToString();
                    mysearch.AllNum = int.Parse( Request.QueryString["allnum"].ToString());
                    mysearch.MonthNum = int.Parse(Request.QueryString["monthnum"].ToString());
                    Response.Write(myadmin.UpdateSearch(mysearch));
                }
                if (Request.QueryString["act"] != null && Request.QueryString["act"].ToString() == "add")
                {

                    Links mylink = new Links();
                    mylink.LinkTitle = Request.QueryString["title"].ToString();
                    // mylink.LinkID = Request.QueryString["id"].ToString();
                    mylink.LinkType = Request.QueryString["type"].ToString();
                    mylink.LinkURL = Request.QueryString["url"].ToString();
                    mylink.OrderList = int.Parse(Request.QueryString["orderlist"].ToString());
                    Response.Write(myadmin.AddLink(mylink));
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
