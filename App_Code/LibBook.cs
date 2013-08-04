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
/// LibBook 的摘要说明
/// </summary>
public class LibBook
{
    private DataSystem dataconnection;//用于数据链接
    private string sql;
    private string recid;
    public string Recid
    {
        get { return recid; }
        set { recid = value; }
    }
	public LibBook()
	{
        dataconnection = new DataSystem();
        dataconnection.ConnectionString = ConfigurationManager.ConnectionStrings["DBString"].ToString();
	}
    public void DataOpen()
    {
        dataconnection.Open();
    }
    public void DataClose()
    {
        dataconnection.Close();
    }
    public SqlDataReader GetReaderSql(string sql)
    {
        return dataconnection.GetDataReader(sql);
    }
}
