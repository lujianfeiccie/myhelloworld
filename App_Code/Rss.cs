using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Rss 的摘要说明
/// </summary>
public class Rss
{
    private DataSystem dataconnection;//用于数据链接
    private string sql;
	public Rss()
	{
        dataconnection = new DataSystem();
        dataconnection.ConnectionString = ConfigurationManager.ConnectionStrings["DBString"].ToString();
		
	}
    public void RssDataOpen()
    {
        dataconnection.Open();
    }
    public void RssDataClose()
    {
        dataconnection.Close();
    }
    public SqlDataReader GetNewBooks()
    {
        sql = "SELECT TOP 200 * FROM bib ORDER BY _入档日期 DESC";
        try
        { return dataconnection.GetDataReader(sql); }
        catch { return null; }
    }
    public SqlDataReader GetNewPapers()
    {
        sql = "SELECT * FROM j_bib ORDER BY recid DESC";
        try
        { return dataconnection.GetDataReader(sql); }
        catch { return null; }
    }
    public SqlDataReader GetNewAlert()
    {
        sql = "SELECT TOP 200 * FROM bib ORDER BY _入档日期 DESC";
        try
        { return dataconnection.GetDataReader(sql); }
        catch { return null; }
    }
    public SqlDataReader GetNewOrder()
    {
        sql = "SELECT * FROM a_BibsView ORDER BY TimeStamp DESC";
        try
        { return dataconnection.GetDataReader(sql); }
        catch { return null; }
    }
    public SqlDataReader GetNewBing()
    {
        sql = "SELECT * FROM cb_bib ORDER BY _编目日期 DESC";
        try
        { return dataconnection.GetDataReader(sql); }
        catch { return null; }
    }
}
