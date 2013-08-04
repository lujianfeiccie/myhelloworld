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

public partial class Admin_LibZyList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["username"] != null && Session["username"].ToString() != "" && Session["loginstate"] != null && Session["loginstate"].ToString() == "ok")
        {
            Functions myfun = new Functions();
            Admin myadmin = new Admin();
            string url = "LibZyList.aspx";
            myadmin.UserName = Session["username"].ToString();
            myadmin.UserDataOpen();
            myadmin.GetAdminInfo();
            if (myadmin.ZyOP)
            {
                SqlDataReader reader = myadmin.GetLibZy();
                link_list_all.DataSource = reader;
                link_list_all.DataBind();
                reader.Close();


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
    public string GetLinkType(string typename, string id)
    {
        string gczy = "";
        string tszy = "";
        string jszy = "";
        string ggzy = "";
        string linktype = "<select id=\"type_" + id + "\" name=\"ischeck\">";

        switch (typename)
        {
            case "馆藏资源":
                gczy = "selected=\"selected\"";
                break;
            case "特色资源":
                tszy = "selected=\"selected\"";
                break;
            case "军事电子资源":
                jszy = "selected=\"selected\"";
                break;
            case "公共资源":
                ggzy = "selected=\"selected\"";
                break;
          default:
              ggzy = "selected=\"selected\"";
                break;
        };
        linktype += "<option value=\"馆藏资源\" " + gczy + ">馆藏资源</option><option value=\"特色资源\" " + tszy + ">特色资源</option><option " + jszy + " value=\"军事电子资源\">军事电子资源</option>"
            + "<option value=\"公共资源\" " + ggzy + ">公共资源</option> </select>";
        return linktype;
    }
    public string IsCheck(string state)
    {
        bool mystate = bool.Parse(state);
        if (mystate)
            return "checked=\"checked\"";
        else return "";
    }
}
