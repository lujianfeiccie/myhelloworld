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
using System.Collections.Generic;
using System.Collections.Specialized;
/// <summary>
/// User 用户类
/// </summary>
public class Statistics
{ 
    protected DataSystem dataconnection;//用于数据链接
    private string sql;
    public Statistics()
	{
        dataconnection = new DataSystem();
        dataconnection.ConnectionString = ConfigurationManager.ConnectionStrings["DBString"].ToString();
	}
    public void StatisticsDataOpen()
    {
        dataconnection.Open();
    }
    public void StatisticsDataClose()
    {
        dataconnection.Close();
    }
    public SqlDataReader GetBorrowInfoCount(string where)
    {
        sql = "select count([bib].recid) as num from [bib],[l_loan] where [bib].recid = [l_loan].recid";
        if (!where.Equals(""))
        {
            sql = sql + " and " + where;
        }

        try
        {
            return dataconnection.GetDataReader(sql);
        }
        catch { return null; }
    }
    public SqlDataReader GetDigitalInfoCount(string where)
    {
        sql = "select count(id) as num from dbo.tb_statistic where page_id = '2'";
        if (!where.Equals(""))
        {
            sql = sql + " and " + where;
        }

        try
        {
            return dataconnection.GetDataReader(sql);
        }
        catch { return null; }
    }
    public SqlDataReader GetDigitalInfoCount(string where,string pageid)
    {
        sql = string.Format("select count(id) as num from dbo.tb_statistic where page_id = '{0}'", pageid);
        if (!where.Equals(""))
        {
            sql = sql + " and " + where;
        }

        try
        {
            return dataconnection.GetDataReader(sql);
        }
        catch { return null; }
    }
}
