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

public partial class DownloadView : System.Web.UI.Page
{
    public Download mydown = new Download();
    public Functions myfun = new Functions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
        {
            mydown.DownloadDataOpen();
            SqlDataReader reader = mydown.GetDownloadList(10, "down_num desc", "ischeck=1");
            top10.DataSource = reader;
            top10.DataBind();
            reader.Close();

            mydown.ID = Request.QueryString["id"].ToString();
            mydown.AddVisit();
            mydown.GetDownloadInfo();
            mydown.DownloadDataClose();
        }
        else { Response.Write("非法访问！"); Response.End(); }

    }
}
