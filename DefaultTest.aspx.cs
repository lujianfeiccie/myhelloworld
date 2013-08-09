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

public partial class DefaultTest : System.Web.UI.Page
{
    public Functions myfun = new Functions();
    protected void Page_Load(object sender, EventArgs e)
    {
        Book mybook = new Book();
        mybook.BookDataOpen();

        string url = HttpContext.Current.Request.Url.ToString();//这个是带参数的
        url = Request.FilePath + "?";//不带参数的
        int nowpage = 1;
        int allpage = 9;
        int size = 5;//每页显示条数
        if (Request.QueryString["allpage"] != null && Request.QueryString["allpage"].ToString() != "")
            allpage = int.Parse(Request.QueryString["allpage"].ToString());
        else
            allpage = mybook.GetBooksNum(size);
        if (Request.QueryString["pagenum"] != null && Request.QueryString["pagenum"].ToString() != "")
            nowpage = int.Parse(Request.QueryString["pagenum"].ToString());
        else nowpage = 1;
        SqlDataReader reader = mybook.GetBooksList(size, nowpage);
        top2notice.DataSource = reader;
        top2notice.DataBind();
        reader.Close();
        mybook.BookDataClose();

       
    }
    public string IsNew(string pub_date)
    {
        DateTime pub_time = DateTime.Parse(pub_date);
        TimeSpan ss = DateTime.Now.Subtract(pub_time);
        if (ss.TotalDays < 3)
            return "<img src=\"Images/new.gif\" />";
        else
        {
            return pub_time.Year.ToString() + "-" + pub_time.Month.ToString() + "-" + pub_time.Day.ToString();
        }
    }
}
