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

public partial class Admin_EditNews : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["username"] != null &&Session["username"].ToString() != "")
        {
            if (Request.QueryString["act"] != null && Request.QueryString["act"].ToString() == "del")
            {
                string id = Request.QueryString["ids"].ToString();
                string[] ids = id.Split(',');
                string newstype ="news";
                if(Request.QueryString["newstype"]!=null&&Request.QueryString["newstype"].ToString()=="notice")
                    newstype="notice";
                Admin myadmin = new Admin();
                myadmin.UserName = Session["username"].ToString();

                myadmin.UserDataOpen();
                myadmin.GetAdminInfo();
               
                try
                {
                    for (int t = 0; t < ids.Length; t++)
                    {
                        myadmin.DeleteNews(ids[t], newstype);
                    }
                    Response.Write("ok");
                }
                catch
                {
                    Response.Write("删除失败");
                }

                myadmin.UserDataClose();
            }
            else if (Request.QueryString["act"] != null && Request.QueryString["act"].ToString() == "check")
            {
                bool type1 =false;
                string id = Request.QueryString["ids"].ToString();
                string checkstate = Request.QueryString["state"].ToString();
                if(checkstate=="1")
                    type1=true;
                string newstype ="news";
                if(Request.QueryString["newstype"]!=null&&Request.QueryString["newstype"].ToString()=="notice")
                    newstype="notice";
                
                string[] ids = id.Split(',');
                Admin myadmin = new Admin();
                myadmin.UserName = Session["username"].ToString();
                myadmin.UserDataOpen();
                myadmin.GetAdminInfo();
                try
                {
                    for (int t = 0; t < ids.Length; t++)
                    {
                        myadmin.CheckNews(ids[t],newstype, type1);
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
            Response.Write("请以管理员身份登陆后进行操作！");
        }
    }
}
