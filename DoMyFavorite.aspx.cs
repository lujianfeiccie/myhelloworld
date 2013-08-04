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

public partial class DoMyFavorite : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null && Session["username"].ToString() != "")
        {
            if (Request.QueryString["act"] != null && Request.QueryString["act"].ToString() == "reserv")
            {
                string id = Request.QueryString["ids"].ToString();
                string[] ids = id.Split(',');

                User myuser = new User();
                myuser.UserName = Session["username"].ToString();
                myuser.UserID = Session["userid"].ToString();
                myuser.UserDataOpen();
              //  try
              //  {
                    for (int t = 0; t < ids.Length; t++)
                    {
                       Response.Write( myuser.AddRerveBook(ids[t]));
                       Response.Write( ids[t].ToString()+"DSFS");
                    }
                   
              //  }
              //  catch
              //  {
                  //  Response.Write("添加失败");
              //  }

                myuser.UserDataClose();
            }
            if (Request.QueryString["act"] != null && Request.QueryString["act"].ToString() == "add")
            {
                string id = Request.QueryString["ids"].ToString();
                string[] ids = id.Split(',');

                User myuser = new User();
                myuser.UserName = Session["username"].ToString();
                myuser.UserDataOpen();
                try
                {
                    for (int t = 0; t < ids.Length; t++)
                    {
                        myuser.AddFavorite(ids[t]);
                    }
                    Response.Write("ok");
                }
                catch
                {
                    Response.Write("添加失败");
                }

                myuser.UserDataClose();
            }
            if (Request.QueryString["act"] != null && Request.QueryString["act"].ToString() == "delete")
            {
                string id = Request.QueryString["ids"].ToString();
                string[] ids = id.Split(',');

                User myuser = new User();
                myuser.UserName = Session["username"].ToString();
                myuser.UserDataOpen();
                try
                {
                    for (int t = 0; t < ids.Length; t++)
                    {
                        myuser.DeleteFavorite(ids[t]);
                    }
                    Response.Write("ok");
                }
                catch
                {
                    Response.Write("删除失败");
                }

                myuser.UserDataClose();
            }
        }
        else { Response.Write("请正确登录后操作！"); }
    }
}
