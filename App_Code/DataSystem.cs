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
/// DataSystem 的摘要说明
/// </summary>
public class DataSystem
{
    public DataSystem()
    {
        dataConnection = new SqlConnection();
    }
    public string ConnectionString
    {
        get { return this.connectionString; }
        set { this.connectionString = value; }
    }
    private SqlConnection dataConnection = null;
    private string connectionString;

    #region 属性
    /// &lt;summary&gt;
    /// 设置或获取SqlConnection类型数据库联接dataConnection的值
    /// &lt;/summary&gt;
    public SqlConnection DataConnection
    {
        get
        {
            if (dataConnection == null)
                dataConnection = new SqlConnection();
            return dataConnection;
        }
        set
        {
            dataConnection = value;
        }
    }
    /// &lt;summary&gt;
    /// 获取数据库联接的状态
    /// &lt;/summary&gt;
    public ConnectionState SqlState
    {
        get
        {
            return dataConnection.State;
        }
    }
    #endregion
    #region 状态操作
    /// &lt;summary&gt;
    /// 打开数据库联接
    /// &lt;/summary&gt;
    public void Open()
    {
        this.dataConnection.ConnectionString = this.ConnectionString;
        if (dataConnection.State != ConnectionState.Open)
            dataConnection.Open();
    }
    /// &lt;summary&gt;
    /// 关闭数据库联接
    /// &lt;/summary&gt;
    public void Close()
    {
        if (dataConnection.State != ConnectionState.Closed)
            dataConnection.Close();
    }
    #endregion
    #region 一般数据语句操作
    /// &lt;summary&gt;
    /// 获取检索出来首行首列的值
    /// &lt;/summary&gt;
    /// &lt;param name="sqlStr"&gt;sql查询串&lt;/param&gt;
    /// &lt;returns&gt;结果&lt;/returns&gt;
    public object ExecuteScalar(string sqlStr)
    {
        if (SqlState == ConnectionState.Closed)
            this.Open();
        SqlCommand cmd = new SqlCommand(sqlStr, dataConnection);
        return cmd.ExecuteScalar();
    }
    /// &lt;summary&gt;
    ///检索数据以SqlDataReader形式返检索结果
    /// &lt;/summary&gt;
    /// &lt;param name="sqlStr"&gt;sql查询串&lt;/param&gt;
    /// &lt;returns&gt;SqlDataReader数据集&lt;/returns&gt;
    public SqlDataReader GetDataReader(string sqlStr)
    {
        if (SqlState == ConnectionState.Closed)
            this.Open();
        SqlCommand cmd = new SqlCommand(sqlStr, dataConnection);
        return cmd.ExecuteReader();
    }
    //带有参数的sql语句执行重载
    public SqlDataReader GetDataReader(SqlParameter[] sqlParameters, string sqlStr)
    {
        if (SqlState == ConnectionState.Closed)
            this.Open();
        SqlCommand cmd = new SqlCommand(sqlStr, dataConnection);
        if (sqlParameters != null && sqlParameters.Length != 0)
            foreach (object parameter in sqlParameters)
            {
                cmd.Parameters.Add((SqlParameter)parameter);
            }
        return cmd.ExecuteReader();
    }
    /// &lt;summary&gt;
    /// 检索数据以DataTable形式返检索结果
    /// &lt;/summary&gt;
    /// &lt;param name="sqlStr"&gt;sql查询串&lt;/param&gt;
    /// &lt;returns&gt;DataTale数据集&lt;/returns&gt;
    public DataTable GetDataTable(string sqlStr)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, dataConnection);
        adapter.Fill(dt);
        return dt;
    }
    /// <summary>
    /// 暂时没用
    /// </summary>
    /// <param name="sqlParameters"></param>
    /// <param name="sqlStr"></param>
    /// <returns></returns>
    public DataTable GetDataTable(SqlParameter[] sqlParameters, string sqlStr)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, dataConnection);
        adapter.Fill(dt);
        return dt;
    }
    /// &lt;summary&gt;
    /// 执行出检索以外的其它数据操作返回影响条数
    /// &lt;/summary&gt;
    /// &lt;param name="sqlStr"&gt;sql操作语句&lt;/param&gt;
    /// &lt;returns&gt; 操作影响条数&lt;/returns&gt;
    public int ExecuteSql(String sqlStr)
    {
        if (SqlState == ConnectionState.Closed)
            this.Open();
        SqlCommand cmd = new SqlCommand(sqlStr, DataConnection);
        return cmd.ExecuteNonQuery();
    }
    /// <summary>
    /// 重载带参数的sql语句
    /// </summary>
    /// <param name="sqlStr"></param>
    /// <returns></returns>
    public int ExecuteSql(SqlParameter[] sqlParameters, String sqlStr)
    {
        if (SqlState == ConnectionState.Closed)
            this.Open();
        SqlCommand cmd = new SqlCommand(sqlStr, DataConnection);
        if (sqlParameters != null && sqlParameters.Length != 0)
            foreach (object parameter in sqlParameters)
            {
                cmd.Parameters.Add((SqlParameter)parameter);
            }
        return cmd.ExecuteNonQuery();
    }
    #endregion
    #region 存储过程操作
    /// &lt;summary&gt;
    /// 执行存储过程获得DataTable数据
    /// &lt;/summary&gt;
    /// &lt;param name="storedProcedureName"&gt;存储过程名称&lt;/param&gt;
    /// &lt;returns&gt;DataTable形式的结果集&lt;/returns&gt;
    public DataTable StoredProcGetDataTable(string storedProcedureName)
    {
        return StoredProcGetDataTable(null, storedProcedureName);
    }
    /// &lt;summary&gt;
    /// 执行存储过程获得DataTable数据
    /// &lt;/summary&gt;
    /// &lt;param name="sqlParameters"&gt;存储过程参数ArrayList类型的SqlParameter集合&lt;/param&gt;
    /// &lt;param name="storedProcedureName"&gt;存储过程名称&lt;/param&gt;
    /// &lt;returns&gt;DataTable形式的结果集&lt;/returns&gt;
    public DataTable StoredProcGetDataTable(SqlParameter[] sqlParameters, string storedProcedureName)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = dataConnection;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = storedProcedureName;
        if (sqlParameters != null && sqlParameters.Length != 0)
        {
            foreach (object parameter in sqlParameters)
            {
                cmd.Parameters.Add((SqlParameter)parameter);
            }
        }
        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        dataAdapter.Fill(dt);
        return dt;
    }
    /// &lt;summary&gt;
    /// 执行存储过程返回影响条数
    /// &lt;/summary&gt;
    /// &lt;param name="storedProcedureName"&gt;存储过程名称&lt;/param&gt;
    /// &lt;returns&gt;影响条数&lt;/returns&gt;
    public int StoredProcExecute(string storedProcedureName)
    {
        return StoredProcExecute(null, storedProcedureName);
    }
    /// &lt;summary&gt;
    /// 执行存储过程返回影响条数
    /// &lt;/summary&gt;
    /// &lt;param name="sqlParameters"&gt;存储过程参数ArrayList类型的SqlParameter集合&lt;/param&gt;
    /// &lt;param name="storedProcedureName"&gt;存储过程名称&lt;/param&gt;
    /// &lt;returns&gt;影响条数&lt;/returns&gt;
    public int StoredProcExecute(SqlParameter[] sqlParameters, string storedProcedureName)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = dataConnection;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = storedProcedureName;
        if (sqlParameters != null && sqlParameters.Length != 0)
            foreach (object parameter in sqlParameters)
            {
                cmd.Parameters.Add((SqlParameter)parameter);
            }
        return cmd.ExecuteNonQuery();
    }
    /// &lt;summary&gt;
    /// 执行存储过程获得数据并以SqlDataReader返回结果
    /// &lt;/summary&gt;
    /// &lt;param name="storedProcedureName"&gt;存储过程名称&lt;/param&gt;
    /// &lt;returns&gt;SqlDataReader形式的结果集&lt;/returns&gt;
    public SqlDataReader StoredProcGetDataReader(string storedProcedureName)
    {
        return StoredProcGetDataReader(null, storedProcedureName);
    }
    /// &lt;summary&gt;
    /// 执行存储过程获得数据并以SqlDataReader返回结果
    /// &lt;/summary&gt;
    /// &lt;param name="sqlParameters"&gt;存储过程参数ArrayList类型的SqlParameter集合&lt;/param&gt;
    /// &lt;param name="storedProcedureName"&gt;存储过程名称&lt;/param&gt;
    /// &lt;returns&gt;SqlDataReader形式的结果集&lt;/returns&gt;
    public SqlDataReader StoredProcGetDataReader(SqlParameter[] sqlParameters, string storedProcedureName)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = dataConnection;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = storedProcedureName;
        if (sqlParameters != null && sqlParameters.Length != 0)
            foreach (object parameter in sqlParameters)
            {
                cmd.Parameters.Add((SqlParameter)parameter);
            }
        return cmd.ExecuteReader();
    }
    /// &lt;summary&gt;
    /// 执行存储过程获得数据并返回首行首列
    /// &lt;/summary&gt;
    /// &lt;param name="storedProcedureName"&gt;存储过程名称&lt;/param&gt;
    /// &lt;returns&gt;返回首行首列&lt;/returns&gt;
    public object StoredProcExecuteScalar(string storedProcedureName)
    {
        return StoredProcExecuteScalar(null, storedProcedureName);
    }
    /// &lt;summary&gt;
    /// 执行存储过程获得数据并返回首行首列
    /// &lt;/summary&gt;
    /// &lt;param name="sqlParameters"&gt;存储过程参数ArrayList类型的SqlParameter集合&lt;/param&gt;
    /// &lt;param name="storedProcedureName"&gt;存储过程名称&lt;/param&gt;
    /// &lt;returns&gt;返回首行首列&lt;/returns&gt;
    public object StoredProcExecuteScalar(SqlParameter[] sqlParameters, string storedProcedureName)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = dataConnection;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = storedProcedureName;
        if (sqlParameters != null && sqlParameters.Length != 0)
            foreach (object parameter in sqlParameters)
            {
                cmd.Parameters.Add((SqlParameter)parameter);
            }
        return cmd.ExecuteScalar();
    }
    #endregion
    #region 事务操作
    /// &lt;summary&gt;
    /// 开启事务
    /// &lt;/summary&gt;
    public void BeginTransaction()
    {
        ExecuteSql("begin transaction;");
    }
    /// &lt;summary&gt;
    /// 提交事务
    /// &lt;/summary&gt;
    public void Commit()
    {
        ExecuteSql("commit;");
    }
    /// &lt;summary&gt;
    /// 回滚事务
    /// &lt;/summary&gt;
    public void Rollback()
    {
        ExecuteSql("rollback;");
    }
    #endregion
}
