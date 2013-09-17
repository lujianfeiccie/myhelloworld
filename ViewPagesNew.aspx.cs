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

public partial class ViewPagesNew : System.Web.UI.Page
{
    public string[] result = new string[4];

    protected void Page_Load(object sender, EventArgs e)
    {
        string type="jj";//默认为简介
        if(Request.QueryString["type"]!=null&&Request.QueryString["type"].ToString()!="")
        {
            type=Request.QueryString["type"].ToString();
        }
        LibWeb myweb = new LibWeb();
        myweb.WebDataOpen();
        result = myweb.GetPageInfo(type);
        for (int i = 0; i < result.Length;i++ )
        {
            result[i] = result[i].Replace("ViewPages", "ViewPagesNew");
        }
        myweb.WebDataClose();
    }
}
