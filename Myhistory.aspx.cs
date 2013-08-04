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

public partial class Myhistory : System.Web.UI.Page
{
    public Functions myfun = new Functions();
    public string time1, time2;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] != null && Session["userid"].ToString() != "")
        {
            User myuser = new User();
            myuser.UserID = Session["userid"].ToString();
            myuser.UserDataOpen();

            string url = HttpContext.Current.Request.Url.ToString();//这个是带参数的
            
            int nowpage = 1;
            int allpage = 9;
            int size = 15;//每页显示条数

            

            SqlDataReader reader;
            if (Request.QueryString["act"]!=null&&Request.QueryString["act"]=="query")//如果是第一次查询
            {
                url = Request.FilePath + "?act=query2" ;//不带参数的
                time1 = Request.Form["starttime"].ToString();
                time2 =Request.Form["endtime"].ToString();
                
            }
            else if (Request.QueryString["act"] != null && Request.QueryString["act"] == "query2")//如果是翻页
            {
                
                time1 = Request.QueryString["starttime"].ToString();
                time2 = Request.QueryString["endtime"].ToString();
                url = Request.FilePath + "?act=query2";//不带参数的
            }
            else
            {
                time1 = DateTime.Now.AddDays(-30).ToString();
                time2 = DateTime.Now.ToString();
            }
            url += "&starttime="+time1+"&endtime="+time2;
            if (Request.QueryString["allpage"] != null && Request.QueryString["allpage"].ToString() != "")
                allpage = int.Parse(Request.QueryString["allpage"].ToString());
            else
                allpage = myuser.GetHistoryNum(DateTime.Parse(time1), DateTime.Parse(time2), size);
            if (Request.QueryString["pagenum"] != null && Request.QueryString["pagenum"].ToString() != "")
                nowpage = int.Parse(Request.QueryString["pagenum"].ToString());
            else nowpage = 1;

            reader = myuser.GetMyHistory(DateTime.Parse(time1), DateTime.Parse(time2),size,nowpage);
            myhistorylist.DataSource=reader;
            myhistorylist.DataBind();
            reader.Close();
            myuser.UserDataClose();
            mypage.PageURL = url;
            mypage.NowPage = nowpage;
            mypage.AllPage = allpage;

        }
        else { Response.Write("请登录后操作！"); Response.End(); }
    }
}
