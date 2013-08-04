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
public partial class Admin_LinkList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["username"] != null && Session["username"].ToString() != "" && Session["loginstate"] != null && Session["loginstate"].ToString() == "ok")
        {
            Functions myfun = new Functions();
            Admin myadmin = new Admin();
            string url = "NewsList.aspx?type=news";
            myadmin.UserName = Session["username"].ToString();
            myadmin.UserDataOpen();
            myadmin.GetAdminInfo();
            if (myadmin.LinkOP)
            {
             SqlDataReader reader=  myadmin.GetWebLinks("");
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
    public string GetLinkType(string typename,string id)
    {
        string xnzy = "";
        string xnlj = "";
        string xwzy = "";
        string xwlj = "";
        string xkzywz = "";
        string linktype = "<select id=\"type_"+id+"\" name=\"ischeck\">";
            
        switch (typename) { 
            case "xnzy":
                xnzy = "selected=\"selected\"";
                break;
            case "xnlj":
                xnlj = "selected=\"selected\"";
                break;
            case "xwzy":
                xwzy = "selected=\"selected\"";
                break;
            case "xwlj":
                xwlj = "selected=\"selected\"";
                break;
            case "xkzywz":
                xkzywz = "selected=\"selected\"";
                break;
            default:
                xkzywz = "selected=\"selected\"";
                break;
        };
        linktype += "<option value=\"xkzywz\" "+xkzywz+">学科专业网站</option><option value=\"xnzy\" "+xnzy+">校内资源</option><option "+xwzy+" value=\"xwzy\">校外资源</option>"
            + "<option value=\"xnlj\" "+xwlj+">校内链接</option> <option "+xwlj+" value=\"xwlj\">校外链接</option></select>";
        return linktype;
    }
}
