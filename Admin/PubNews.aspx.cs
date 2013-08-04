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

public partial class Admin_PubNews : System.Web.UI.Page
{
    public string newstypeh = "news";
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


            if (Request.QueryString["act"] != null && Request.QueryString["act"].ToString() == "edit" && Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
            {
               
                News mynews = new News();
                mynews.NewsID = Request.QueryString["id"].ToString();
                mynews.NewsDataOpen();
                mynews.GetNewsInfo(2);
                string headpicstring = mynews.HeadPicUrl;
                if (myadmin.NewsOP && mynews.NewsType == "news")
                {
                    title.InnerText = "新闻修改";
                    newstypeh = "news";
                    
                }
                else if (myadmin.NoticeOP && mynews.NewsType == "notice")
                {
                    url = "NewsList.aspx?type=notice";
                    title.InnerText = "公告修改";
                    newstypeh = "notice";
                }
                else if (myadmin.DownloadOP && mynews.NewsType == "px")
                {
                    url = "NewsList.aspx?type=px";
                    title.InnerText = "读者培训信息修改";
                    newstypeh = "px";
                }
                else { Response.Write("非法访问，请联系超级管理员授权此项目！"); Response.End(); }

                if (IsPostBack)
                {
					mynews.OrderList = int.Parse(orderlist.Text);
                    mynews.Title = newstitle.Text;
                    mynews.IsTop = istop.Checked;
                    mynews.Info = info.Value;
                    mynews.IsChecked = true;
                    mynews.CheckAdmin = myadmin.UserName;
                    if (headpic.HasFile)
                        mynews.HeadPicUrl = myfun.UploadImageThumbFile(headpic, 1);
                    else
                        mynews.HeadPicUrl = headpicstring;
                    myadmin.EditNews(mynews);
                    Response.Redirect(url);
                }
                newstitle.Text = mynews.Title;
                info.Value = mynews.Info;
                istop.Checked = mynews.IsTop;
                orderlist.Text = mynews.OrderList.ToString();
                
                

                mynews.NewsDataClose();
                

            }
            else if (Request.QueryString["act"] != null && Request.QueryString["act"].ToString() == "delete" && Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
            {
                if (Request.QueryString["type"] != null && Request.QueryString["type"].ToString() == "news")
                {
                    myadmin.DeleteNews(Request.QueryString["id"].ToString(), "news");
                    newstypeh = "news";
                }
                else if (Request.QueryString["type"] != null && Request.QueryString["type"].ToString() == "notice")
                {
                    url = "NewsList.aspx?type=notice";
                    myadmin.DeleteNews(Request.QueryString["id"].ToString(), "notice");
                    newstypeh = "notice";
                }
                else if (Request.QueryString["type"] != null && Request.QueryString["type"].ToString() == "px")
                {
                    url = "NewsList.aspx?type=px";
                    myadmin.DeleteNews(Request.QueryString["id"].ToString(), "px");
                    newstypeh = "px";
                }
                else { Response.Write("非法访问，请联系超级管理员授权此项目！"); Response.End(); }
                Response.Redirect(url);

            }
            else
            {
                if (myadmin.NewsOP && Request.QueryString["type"] != null && Request.QueryString["type"].ToString() == "news")
                {
                   
                    title.InnerText = "新闻发布";
                    newstypeh = "news";
                }
                else if (myadmin.NoticeOP && Request.QueryString["type"] != null && Request.QueryString["type"].ToString() == "notice")
                {
                    url = "NewsList.aspx?type=notice";
                    title.InnerText = "公告发布";
                    newstypeh = "notice";
                }
                else if (myadmin.DownloadOP && Request.QueryString["type"] != null && Request.QueryString["type"].ToString() == "px")
                {
                    url = "NewsList.aspx?type=px";
                    title.InnerText = "读者培训信息发布";
                    newstypeh = "px";
                }
                else { Response.Write("非法访问，请联系超级管理员授权此项目！"); Response.End(); }
                if (IsPostBack)
                {
                    
                    News mynews = new News();
                    mynews.Title = newstitle.Text;
                    mynews.IsTop = istop.Checked;
                    mynews.Info = info.Value;
                    mynews.IsChecked = true;
                    mynews.NewsType = Request.QueryString["type"].ToString();
                    mynews.OrderList = int.Parse(orderlist.Text);
                    mynews.CheckAdmin = Session["username"].ToString();
                    mynews.PubTime = DateTime.Now;
                    mynews.PubIP = Request.UserHostAddress;
                    mynews.PubUser = Session["username"].ToString();
                    mynews.VisitNum = 0;
                    mynews.HeadPicUrl = myfun.UploadImageThumbFile(headpic, 1);
                    myadmin.AddNews(mynews);
                    Response.Redirect(url);
                   

                }


            }

           

            myadmin.UserDataClose();
            

        }
        else
        { Response.Redirect("Default.aspx"); }
    }
}
