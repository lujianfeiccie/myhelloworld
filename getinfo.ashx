<%@ WebHandler Language="C#" Class="statistic" %>

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public class statistic : IHttpHandler 
{
    //取得数据库连接设置
    private static ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["DBString"];
    private readonly string table_name = "tb_statistic";
    bool IHttpHandler.IsReusable
    {
        get
        {
            return false;
        }
    }

    void IHttpHandler.ProcessRequest(HttpContext context)
    {
        string user_id="",page_id="";
        user_id = context.Request["user_id"];
        page_id = context.Request["page_id"];

        if (user_id == null || page_id == null)
        {
            context.Response.Write("not ok");
            return;
        }
        if (user_id.Equals("") || page_id.Equals(""))
        {
              context.Response.Write("not ok");
            return;
        }
        DataSystem dataconnection = new DataSystem();
        dataconnection.ConnectionString = connString.ConnectionString;
        dataconnection.Open();
        System.Text.StringBuilder sb= new System.Text.StringBuilder();
            sb.Append("INSERT INTO [milnets].[dbo].[tb_statistic] ");
            sb.Append(" ([user_id],[page_id],[invite_time]) ");
            sb.Append(string.Format("VALUES({0},{1},'{2}')",user_id,page_id,TimeHelper.getStringTime()));
            dataconnection.ExecuteSql(sb.ToString());
        context.Response.Write("ok");
        dataconnection.Close();
    }

   
}