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

public partial class Admin_DoNote : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         if (Session["username"] != null && Session["username"].ToString() != "")
        {
            Admin myadmin = new Admin();
            myadmin.UserName = Session["username"].ToString();
            myadmin.UserDataOpen();
            myadmin.GetAdminInfo();
            
            if (myadmin.NoteOP)
            {

                if (Request.QueryString["act"] != null && Request.QueryString["act"].ToString() == "del")
                {
                     string id = Request.QueryString["ids"].ToString();
                    string[] ids = id.Split(',');
                   
                   
                    try
                    {
                        for (int t = 0; t < ids.Length; t++)
                        {
                            myadmin.DeleteWebNote(ids[t].ToString());
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
                    if(Request.QueryString["state"]!=null&&Request.QueryString["state"].ToString()=="0")
                      checkstate = false;


                  string id = Request.QueryString["ids"].ToString();
                  string[] ids = id.Split(',');


                  try
                  {
                      for (int t = 0; t < ids.Length; t++)
                      {
                          myadmin.CheckWebNote(ids[t].ToString(), checkstate);
                      }
                      Response.Write("ok");
                  }
                  catch
                  {
                      Response.Write("审核失败");
                  }


                   
                }
                if (Request.QueryString["act"] != null && Request.QueryString["act"].ToString() == "over")
                {

                    
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
