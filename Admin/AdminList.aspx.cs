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

public partial class Admin_AdminList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null && Session["username"].ToString() != "")
        {
            Admin myadmin = new Admin();
            myadmin.UserName = Session["username"].ToString();

            myadmin.UserDataOpen();
            myadmin.GetAdminInfo();
            if (myadmin.UserType == "超级管理员")
            {
              SqlDataReader reader=  myadmin.GetAdminList();
              admin_list.DataSource = reader;
              admin_list.DataBind();
              reader.Close();
            }
            else
            {
                Response.Write("您没有此项目的权限！");
                Response.End();
            }
            myadmin.UserDataClose();
        }
        else
        {
            Response.Write("您没有此项目的权限！");
            Response.End();
        }
    }
    public string IsCheck(string state)
    {
        bool mystate = bool.Parse(state);
        if (mystate)
            return "checked=\"checked\"";
        else return "";
    }
}
