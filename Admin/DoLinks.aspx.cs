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

public partial class Admin_DoLinks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["username"] != null && Session["username"].ToString() != "")
        {
            Admin myadmin = new Admin();
            myadmin.UserName = Session["username"].ToString();
            myadmin.UserDataOpen();
            myadmin.GetAdminInfo();
            
            if (myadmin.LinkOP)
            {

                if (Request.QueryString["act"] != null && Request.QueryString["act"].ToString() == "del")
                {
                    Response.Write( myadmin.DeleteLink(Request.QueryString["id"].ToString()));
                    
                }
                if (Request.QueryString["act"] != null && Request.QueryString["act"].ToString() == "update")
                {

                    Links mylink = new Links();
                    mylink.LinkTitle = Request.QueryString["title"].ToString();
                    mylink.LinkID = Request.QueryString["id"].ToString();
                    mylink.LinkType = Request.QueryString["type"].ToString();
                    mylink.LinkURL = Request.QueryString["url"].ToString();
                    mylink.OrderList = int.Parse(Request.QueryString["orderlist"].ToString());
                    Response.Write(myadmin.UpdateLink(mylink));
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
