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
    string type = "jj";//默认为简介
   // LibWeb myweb = new LibWeb();
    User myweb = new User();
    int PageSize = 2;
    protected void Page_Load(object sender, EventArgs e)
    {
        init();
        //BriefIntroduction();
       // GetContent();
        dataBinding();
    }
    void init()
    {
        AspNetPager1.PageSize = PageSize;
        AspNetPager1.AlwaysShow = true;
        myweb.UserDataOpen();
        DataTable mDataTable = myweb.GetViewList("");
        AspNetPager1.RecordCount = mDataTable.Rows.Count;
        myweb.UserDataClose();
    }
    void dataBinding()
    {
        myweb.UserDataOpen();
        DataTable mDataTable = myweb.GetViewList(AspNetPager1.StartRecordIndex,AspNetPager1.EndRecordIndex,"");
        result2.DataSource = mDataTable.DefaultView;
        result2.DataBind();
        myweb.UserDataClose();

    }
    //private void BriefIntroduction()
    //{
       
    //    if (Request.QueryString["type"] != null && Request.QueryString["type"].ToString() != "")
    //    {
    //        type = Request.QueryString["type"].ToString();
    //    }
        
    //    myweb.WebDataOpen();
    //    DataTable mDataTable = myweb.GetViewList(AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex,type);
    //    AspNetPager1.RecordCount = mDataTable.Rows.Count;
    //    result.DataSource = mDataTable.DefaultView;
    //    result.DataBind();
       
    //    myweb.WebDataClose();
    //}
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

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {

    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        dataBinding();
    }
}
