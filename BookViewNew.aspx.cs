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

public partial class Admin_BookViewNew : System.Web.UI.Page
{
    public Book mybook = new Book();
    public  Functions myfun = new Functions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
        {
            mybook.BookDataOpen();
            SqlDataReader reader = mybook.GetBookList(10, "visit_num desc", "1=1");
            top10.DataSource = reader;
            top10.DataBind();
            reader.Close();

            mybook.ID = Request.QueryString["id"].ToString();
            mybook.AddVisit(0);
            mybook.GetInfo();
            mybook.BookDataClose();
        }
        else { Response.Write("非法访问！"); Response.End(); }
        
    }
}
