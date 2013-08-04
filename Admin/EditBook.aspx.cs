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

public partial class Admin_EditBook : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null && Session["username"].ToString() != "")
        {
            Admin myadmin = new Admin();
            myadmin.UserName = Session["username"].ToString();

            myadmin.UserDataOpen();
            myadmin.GetAdminInfo();
            if (myadmin.BookOP)
            {

                if (Request.QueryString["act"] != null && Request.QueryString["act"].ToString() == "del")
                {
                    string id = Request.QueryString["ids"].ToString();
                    string[] ids = id.Split(',');
                    try
                    {
                        for (int t = 0; t < ids.Length; t++)
                        {
                            myadmin.DeleteBook(ids[t]);
                        }
                        Response.Write("ok");
                    }
                    catch
                    {
                        Response.Write("删除失败");
                    }
                }
                else if (Request.QueryString["act"] != null && Request.QueryString["act"].ToString() == "check")
                {
                    bool type1 = false;
                    string id = Request.QueryString["ids"].ToString();
                    string checkstate = Request.QueryString["state"].ToString();
                    if (checkstate == "1")
                        type1 = true;
                    string[] ids = id.Split(',');

                    try
                    {
                        for (int t = 0; t < ids.Length; t++)
                        {
                            myadmin.TopSetBook(ids[t],type1);
                        }
                        Response.Write("ok");
                    }
                    catch
                    {
                        Response.Write("failed3");
                    }

                    myadmin.UserDataClose();
                }

                else
                {
                    Response.Write("非法访问");
                }

            }
            else
            {
                Response.Write("对不起，您没有此项目的权限");
            }
            myadmin.UserDataClose();
        }
        else
        {
            Response.Write("请以管理员身份登陆后进行操作！");
        }
    }
}
