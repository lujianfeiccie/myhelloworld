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

public partial class BookListNew : System.Web.UI.Page
{
    public Functions myfun = new Functions();
    protected void Page_Load(object sender, EventArgs e)
    {
        Book mybook = new Book();
        mybook.BookDataOpen();
        string url =  Request.FilePath + "?";//不带参数的
        int nowpage = 1;
        int allpage = 9;
        int size = 15;//每页显示条数
        if (Request.QueryString["allpage"] != null && Request.QueryString["allpage"].ToString() != "")
            allpage = int.Parse(Request.QueryString["allpage"].ToString());
        else
            allpage = mybook.GetBooksNum(size);
        if (Request.QueryString["pagenum"] != null && Request.QueryString["pagenum"].ToString() != "")
            nowpage = int.Parse(Request.QueryString["pagenum"].ToString());
        else nowpage = 1;

        
        SqlDataReader reader = mybook.GetBookList(10, "visit_num desc", "1=1");
        top10.DataSource = reader;
        top10.DataBind();
        reader.Close();
        reader = mybook.GetBooksList(size, nowpage);
        books_list_all.DataSource = reader;
        books_list_all.DataBind();
        reader.Close();
        mybook.BookDataClose();

        mypage.PageURL = url;
        mypage.NowPage = nowpage;
        mypage.AllPage = allpage;

    }
}
