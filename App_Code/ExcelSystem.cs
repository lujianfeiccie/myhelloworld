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
using System.Data.OleDb;
using System.Collections.Generic;
using System.Text;


/// <summary>
/// ExcelSystem 的摘要说明
/// </summary>
public class ExcelSystem
{
    
	public ExcelSystem()
	{
        dataconnection = new DataSystem();
        dataconnection.ConnectionString = ConfigurationManager.ConnectionStrings["DBString"].ToString();
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public string filepath;
    private string sql;
    private DataSystem dataconnection;
    private DataTable dTable;
    /// <summary>
    /// 初始化类的新实例
    /// </summary>
    /// <param name="_filepath">文件名</param>


    /// <summary>
    /// 读取数据
    /// </summary>
    public void Read()
    {
        Read("Sheet1");
    }

    /// <summary>
    /// 读取数据
    /// </summary>
    /// <param name="sheetName">表名</param>
    public void Read(string sheetName)
    {
        OleDbDataAdapter ada = new OleDbDataAdapter("SELECT * FROM [" + sheetName + "$]", "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + HttpContext.Current.Request.MapPath("~/") + filepath + ";Extended Properties=Excel 8.0;");
        dTable = new DataTable();
        ada.Fill(dTable);
        bool rowisnull = false;
        for (int i = dTable.Rows.Count - 1; i >= 0; i--)
        {
            rowisnull = true;
            for (int j = 0; j < dTable.Columns.Count; j++)
            {
                if (dTable.Rows[i][j].ToString().Length != 0)
                {
                    rowisnull = false;
                    break;
                }
            }
            if (rowisnull) dTable.Rows.RemoveAt(i);
        }
    }

    /// <summary>
    /// 获取表数据
    /// </summary>
    public DataTable Table
    {
        get
        {
            return dTable;
        }
    }
    /// <summary>
    /// 插入的表名
    /// </summary>
    /// <param name="tablename"></param>
    /// <returns></returns>
    public bool Insert2SQL(string tablename,string sheetname)
    {
        sql = "insert INTO ["+tablename+"] select * FROM OPENROWSET('Microsoft.Jet.OLEDB.4.0','Excel 8.0;Database=" + HttpContext.Current.Request.MapPath("~/") + filepath + "', ' SELECT * FROM [" + sheetname + "$]')";
       //try
       //{
            dataconnection.Open();
            dataconnection.ExecuteSql(sql);
            dataconnection.Close();
            return true;
      // }
     //  catch { return false; }
    }
}
