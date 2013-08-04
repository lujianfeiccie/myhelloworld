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

public partial class Admin_WebSet : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null && Session["username"].ToString() != "" && Session["loginstate"] != null && Session["loginstate"].ToString() == "ok")
        {
            Admin myadmin = new Admin();
            myadmin.UserName = Session["username"].ToString();
            myadmin.UserDataOpen();
            myadmin.GetAdminInfo();
            
           
            if (myadmin.WebOP)
            {
                LibWeb myweb = new LibWeb();
                if (IsPostBack)
                {
                    myweb.Title = title.Text;
                    myweb.KeyWord = keyword.Text;
                    myweb.Description = description.Text;
                    myweb.VisitNum = int.Parse(count.Text);
                    myweb.OnlineNum = int.Parse(online.Text);
                    myadmin.WebSet(myweb);
                }

                
                myweb.WebDataOpen();

                myweb.GetInfo();
                title.Text = myweb.Title;
                count.Text = myweb.VisitNum.ToString();
                online.Text = myweb.OnlineNum.ToString();
                keyword.Text = myweb.KeyWord;
                description.Text = myweb.Description;
                online.ReadOnly = true;

                myweb.WebDataClose();
            }
            else { Response.Write("对不起，你没有访问权限！"); Response.End(); }
            myadmin.UserDataClose();
        }
        else { Response.Write("请正确访问本页面！"); Response.End(); }
    }

}
