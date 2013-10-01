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

public partial class test : System.Web.UI.Page
{
    protected Model_LibWeb mModel_LibWeb = new Model_LibWeb ();
    protected void Page_Load(object sender, EventArgs e)
    {
        //BriefIntroduction();
        GetContent();
    }

    private void BriefIntroduction()
    {
        string type = "jj";//默认为简介
        if (Request.QueryString["type"] != null && Request.QueryString["type"].ToString() != "")
        {
            type = Request.QueryString["type"].ToString();
        }
        LibWeb myweb = new LibWeb();
        myweb.WebDataOpen();
        SqlDataReader reader = myweb.GetTypeList(type);
        result.DataSource = reader;
        result.DataBind();
        reader.Close();
        myweb.WebDataClose();
    }
    private void GetContent()
    {
        string type = "jj";//默认为简介
        if (Request.QueryString["type"] != null && Request.QueryString["type"].ToString() != "")
        {
            type = Request.QueryString["type"].ToString();
        }
        LibWeb myweb = new LibWeb();
        myweb.WebDataOpen();
        mModel_LibWeb = myweb.GetContent(type);
        myweb.WebDataClose();
    }
}
