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

public partial class IndexPicNews : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string output = "<?xml version=\"1.0\" encoding=\"utf-8\"?>"
                    +"<bcaster autoPlayTime=\"3\">";
        News mynews = new News();
        mynews.NewsDataOpen();
        SqlDataReader reader = mynews.GetNewsList(5, "pub_time desc", "news", "ischeck=1 and head_pic<>''");
        while (reader.Read())
        {
            output += "<item item_url=\""+reader["head_pic"].ToString().Substring(1)+"\" link=\"NewsView.aspx?id="+reader["id"].ToString()+"\" itemtitle=\"\"></item>";
        }
        output += "</bcaster>";
        mynews.NewsDataClose();
        Response.Write(output);
    }
}
