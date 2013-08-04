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


public partial class LibZYPage3 : System.Web.UI.Page
{
    public string gc = "class=\"content_left_guid_item\"";
    public string ts = "class=\"content_left_guid_item\"";
    public string js = "class=\"content_left_guid_item\"";
    public string gg = "class=\"content_left_guid_item\"";
    public string type = "js";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["type"] != null && Request.QueryString["type"].ToString() != "")
        {
           type = Request.QueryString["type"].ToString();
        }
            string typename = "特色电子资源";
            switch (type)
            {
                
                case "ts":
                    ts = "class=\"content_left_guid_item_on\"";
                    typename = "特色资源";
                    break;
                case "js":
                    js = "class=\"content_left_guid_item_on\"";
                   typename = "军事电子资源";
                    break;
                case "gg":
                    gg = "class=\"content_left_guid_item_on\"";
                    typename = "公共资源";
                    break;
               
                default:

                    break;

            };

            LibWeb myweb = new LibWeb();
            myweb.WebDataOpen();
            SqlDataReader reader = myweb.GetLibZy(typename, 0);
            link_list_all.DataSource = reader;
            link_list_all.DataBind();
            reader.Close();
            myweb.WebDataClose();


        
    }
}
