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

public partial class NoteList : System.Web.UI.Page
{
    public string zx = "class=\"content_left_guid_item\"";
    public string mail = "class=\"content_left_guid_item\"";
    public string dc = "class=\"content_left_guid_item\"";
    public string type="zx";
    public Functions myfun = new Functions();
    public string ShowReply(string replyuser, string replytime, string replyinfo)
    {
        if (replyuser != "")
        {
            return ">>>>[" + replytime + "]&nbsp;&nbsp;【" + replyuser + "】回复如下：<br />" + replyinfo;
        }
        else return "";
    }
    public string ShowIsReply(bool isre)
    {
        if (isre)
        {
            return "<b>已回复</b>";

        }
        else { return "未回复"; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["type"] != null && Request.QueryString["type"].ToString() != "")
        {
           type = Request.QueryString["type"].ToString();
           LibNote mynote = new LibNote();
           mynote.NoteDataOpen();
           SqlDataReader reader;
            switch (type)
            {
                case "zx":
                    zx = "class=\"content_left_guid_item_on\"";
                    title1.InnerText = "在线咨询";
                    sitemap.InnerHtml += "<a href=\"NoteList.aspx?type=zx\">互动专区</a>&nbsp;<img src=\"images/next.jpg\" />&nbsp;在线咨询";
                   
                    string url = "NoteList.aspx?type=zx";//不带参数的
                    int nowpage = 1;
                    int allpage = 9;
                    int size = 10;//每页显示条数
                    if (Request.QueryString["allpage"] != null && Request.QueryString["allpage"].ToString() != "")
                        allpage = int.Parse(Request.QueryString["allpage"].ToString());
                    else
                        allpage = mynote.GetNoteListNum(false, 1, size)[1];
                    if (Request.QueryString["pagenum"] != null && Request.QueryString["pagenum"].ToString() != "")
                        nowpage = int.Parse(Request.QueryString["pagenum"].ToString());
                    else nowpage = 1;

                    reader= mynote.GetNoteList(size, nowpage, false, 1 );
                    note_list.DataSource = reader;
                    note_list.DataBind();
                    reader.Close();
                    mypage.PageURL = url;
                    mypage.NowPage = nowpage;
                    mypage.AllPage = allpage;
                    break;
                case "mail":
                    //if (Session["username"] == null || Session["username"].ToString() == "")
                    //{
                    //    Response.Write("请登录后操作<a href='default.aspx'>点击返回首页登录</a>");
                    //    Response.End();
                    //}
                    mail = "class=\"content_left_guid_item_on\"";
                    title1.InnerText = "馆长信箱";
                    sitemap.InnerHtml += "<a href=\"NoteList.aspx?type=zx\">互动专区</a>&nbsp;<img src=\"images/next.jpg\" />&nbsp;馆长信箱";

                    break;
                case "dc":
                    dc = "class=\"content_left_guid_item_on\"";
                    title1.InnerText = "在线调查";
                    sitemap.InnerHtml += "<a href=\"NoteList.aspx?type=zx\">互动专区</a>&nbsp;<img src=\"images/next.jpg\" />&nbsp;在线调查";
                    LibWeb mylib = new LibWeb();
                    mylib.WebDataOpen();
                    Vote libvote = mylib.GetVoteOptions("1");
                    mylib.WebDataClose();
                    lib_vote.InnerHtml = "<li><strong>" + libvote.Title + "</strong></li>";
                    for (int i = 0; i < libvote.Options.Length; i++)
                    {
                        if (libvote.Options[i] != "")
                            lib_vote.InnerHtml += "<li><input type=\"radio\" name=\"web_vote_value\" value=\"" + libvote.OptionsID[i] + "\" />" + libvote.Options[i] + "</li>";
                    }
                    lib_vote.InnerHtml += "<li><img onclick=\"vote();\" src=\"Images/vote.gif\" />&nbsp;&nbsp;<img onclick=\"viewvote();\" src=\"images/view.gif\" /></li>";

                    break;

                default:

                    break;

            };

           
           

            mynote.NoteDataClose();
            


        }
        else
        { Response.Write("非法访问！"); Response.End(); }
    }
}
