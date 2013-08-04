<%@ WebHandler Language="C#" Class="imagehandler" %>

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public class imagehandler : IHttpHandler 
{
    //取得数据库连接设置
    private static ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["DBString"];

    public void ProcessRequest(HttpContext context)
    {
        MemoryStream ms = null;
        try
        {
            //取得员工代号
            string id = context.Request.QueryString["id"];
            //通过ReadImage类的GetImage()方法取得SQL Server中图片资料
            //创建Sql命令
            string strSQL = "select _图片 from j_ContentImage where ID='" + id + "'" ;
            //创建SqlDataSource
            SqlDataSource sqldsPhoto = new SqlDataSource(connString.ConnectionString, strSQL);
            sqldsPhoto.SelectParameters.Add("paramEmployeeID", TypeCode.Int32, id);
            //通过SqlDataSource进行查询
            DataView dv = (DataView)sqldsPhoto.Select(DataSourceSelectArguments.Empty);
            //返回DataView第一个Row的Photo字段资料
            Byte[] PhotoImage = (Byte[])dv[0]["_图片"];
            ms = new MemoryStream(PhotoImage, 0, PhotoImage.Length);
        }
        catch
        {
        }
        
        if (ms != null)
        {
            //取得图像MemoryStream大小
            int bufferSize = (int)ms.Length;
            //创建 buffer
            byte[] buffer = new byte[bufferSize];
            //调用MemoryStream.Read，自MemoryStream 读取至buffer，并返回count
            int countSize = ms.Read(buffer, 0, bufferSize);
            //返回图像buffer
            context.Response.OutputStream.Write(buffer, 0, countSize);
        }
    }
 
    public bool IsReusable 
    {
        get 
        {
            return false;
        }
    }
}