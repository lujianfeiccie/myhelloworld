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

public partial class SearchBooks : System.Web.UI.Page
{
    public Functions myfun = new Functions();
    public string date1 = "", date2 = "", thekeytag = "";
    public string isresult="yes";
    protected void Page_Load(object sender, EventArgs e)
    {
        Search mysearch = new Search();
        mysearch.SearchDataOpen();

        SqlDataReader reader = mysearch.GetHotSearch(50);
        top10.DataSource = reader;
        top10.DataBind();
        reader.Close();
        reader = mysearch.GetHotSearch(10);
        all_hot_search.DataSource = reader;
        all_hot_search.DataBind();
        reader.Close();



        mysearch.SearchDataClose();

    }
}
