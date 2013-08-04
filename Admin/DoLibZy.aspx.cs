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

public partial class Admin_DoLibZy : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null && Session["username"].ToString() != "")
        {
            Admin myadmin = new Admin();
            myadmin.UserName = Session["username"].ToString();
            myadmin.UserDataOpen();
            myadmin.GetAdminInfo();

            if (myadmin.ZyOP)
            {

                if (Request.QueryString["act"] != null && Request.QueryString["act"].ToString() == "del")
                {
                    Response.Write(myadmin.DeleteLibZy(Request.QueryString["id"].ToString()));

                }
                if (Request.QueryString["act"] != null && Request.QueryString["act"].ToString() == "update")
                {
                    LibZy myzy = new LibZy();
                    myzy.ID = Request.QueryString["id"].ToString();
                    myzy.Title = Request.QueryString["title"].ToString();
                    myzy.Url = Request.QueryString["url"].ToString();
                    myzy.TypeName = Request.QueryString["type"].ToString();
                    myzy.OrderList = int.Parse(Request.QueryString["orderlist"].ToString());
                    myzy.IsIndex = bool.Parse(Request.QueryString["index"].ToString());
                    myzy.IsNew = bool.Parse(Request.QueryString["new"].ToString());
                    myzy.IsHot = false;
                    myzy.Description = "";
                    Response.Write(myadmin.UpdateLibZy(myzy));

                }
                if (Request.QueryString["act"] != null && Request.QueryString["act"].ToString() == "add")
                {
                    LibZy myzy = new LibZy();
                    myzy.Title = Request.QueryString["title"].ToString();
                    myzy.Url = Request.QueryString["url"].ToString();
                    myzy.TypeName = Request.QueryString["type"].ToString();
                    myzy.OrderList = int.Parse(Request.QueryString["orderlist"].ToString());
                    myzy.IsIndex = bool.Parse(Request.QueryString["index"].ToString());
                    myzy.IsNew = bool.Parse(Request.QueryString["new"].ToString());
                    myzy.IsHot = false;
                    myzy.Description = "";
                    Response.Write(myadmin.AddLibZy(myzy));
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
