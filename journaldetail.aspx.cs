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
using System.Collections.Generic;

public partial class journaldetail : System.Web.UI.Page
{
    private string connString = "";
    private string recid = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DBString"].ConnectionString;
        //TODO 合法性验证，用户可能手动更改 URL
        if (Request.QueryString["id"] == null || Request.QueryString["id"].Trim().Length == 0)
        {
            Response.Redirect("PaperSearch.aspx");
        }
        else
        {
            recid = Request.QueryString["id"];
        }
        BindData();
        checkMyBookList();
    }

    private void BindData()
    {
        string Q = "'";
        string ODB = " ORDER BY _卷, _期 DESC";
        //string ODB = "";

        string sqlDetail = "SELECT * FROM vj_bib WHERE recid = " + Q + recid + Q;
        string sqlAvailable = "SELECT * FROM vj_location WHERE recid = " + Q + recid + Q + ODB;
        string sqlNotAvailable = "SELECT * FROM vj_urge WHERE recid = " + Q + recid + Q;

        GetData(sqlDetail, sqlAvailable, sqlNotAvailable);
    }

    private void GetData(string sqlDetail, string sqlAvailable, string sqlNotAvailable)
    {
        SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlDetail, connString);
        SqlDataAdapter dataAdapter1 = new SqlDataAdapter(sqlAvailable, connString);
        SqlDataAdapter dataAdapter2 = new SqlDataAdapter(sqlNotAvailable, connString);

        DataSet dataSet = new DataSet();

        dataAdapter.Fill(dataSet, "detail");
        dataAdapter1.Fill(dataSet, "available");
        dataAdapter2.Fill(dataSet, "notavailable");

        DataTable dataTableDetail = dataSet.Tables["detail"];
        DataTable dataTableAvailable = dataSet.Tables["available"];
        DataTable dataTableNotAvailable = dataSet.Tables["notavailable"];

        DataList1.DataSource = dataTableDetail;
        DataList1.DataBind();

        GridView1.DataSource = dataTableAvailable;
        GridView1.DataBind();

        GridView2.DataSource = dataTableNotAvailable;
        GridView2.DataBind();
    }

    private void checkMyBookList()
    {
        if (Session["IDS"] != null && ((List<Book2>)Session["IDS"]).Count > 0)
        {
            Label1.Text = "(" + ((List<Book2>)Session["IDS"]).Count.ToString() + ")";
        }
    }
}
