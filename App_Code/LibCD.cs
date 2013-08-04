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
/// LibCD 的摘要说明
/// </summary>
public class LibCD
{
    private string title;
    private string keyword;
    private string bookno;
    private string id;
    private string adduser;
    private string addtime;
    private int downtimes;
    private string publisher;
    private string cdurl;
    private string cdsize;
    private string info;
    protected DataSystem dataconnection;//用于数据链接
    private string sql;

    public string Title
    {
        get { return title; }
        set { title = value; }
    }
    public string KeyWord
    {
        get { return keyword; }
        set { keyword = value; }
    }
    public string BookNo
    {
        get { return bookno; }
        set { bookno = value; }
    }
    public string CDID
    {
        get { return id; }
        set { id = value; }
    }
    public string CDURL
    {
        get { return cdurl; }
        set { cdurl = value; }
    }
    public string CDSize
    {
        get { return cdsize; }
        set { cdsize = value; }
    }
    public int DownloadTimes
    {
        get { return downtimes; }
        set { downtimes = value; }
    }
    public string AddTime
    {
        get { return addtime; }
        set { addtime = value; }
    }
    public string AddUser
    {
        get { return adduser; }
        set { adduser = value; }
    }
    public string Publisher
    {
        get { return publisher; }
        set { publisher = value; }
    }
    public string CDInfo
    {
        get { return info; }
        set { info = value; }
    }
	public LibCD()
	{
        dataconnection = new DataSystem();
        dataconnection.ConnectionString = ConfigurationManager.ConnectionStrings["DBString"].ToString();
        cdurl = "";
        title = "";
	}
    public void CDDataOpen()
    {
        dataconnection.Open();
    }
    public void CDDataClose()
    {
        dataconnection.Close();
    }
    public string AddDownload()
    {
        sql = "update [lib_cd] set 下载次数=下载次数+1 where id=@CDID";
        SqlParameter[] mypara ={ new SqlParameter("@CDID",SqlDbType.VarChar)};
        mypara[0].Value = CDID;
        try
        {
            if (dataconnection.ExecuteSql(mypara, sql) > 0)
                return "ok";
            else return "failed!";
        }
        catch { return "failed2!"; }
    }
    public string GetInfo()
    {
        sql = "select * from [lib_cd] where id=@UserID";
        SqlParameter[] mypara ={ new SqlParameter("@UserID", SqlDbType.VarChar) };
        mypara[0].Value = CDID;
        try
        {
            SqlDataReader reader = dataconnection.GetDataReader(mypara, sql);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    title = reader["光盘名称"].ToString();
                    keyword = reader["题名"].ToString();
                    bookno = reader["索书号"].ToString();
                    publisher = reader["出版社"].ToString();
                    cdsize = reader["光盘大小"].ToString();
                    adduser = reader["光盘制作者"].ToString();
                    
                    cdurl = reader["路径"].ToString();
                    addtime = reader["上传时间"].ToString();
                    info = reader["介绍"].ToString();
                    downtimes = int.Parse(reader["下载次数"].ToString());



                }
                reader.Close();
                return "ok";

            }
            else { reader.Close(); return "暂无记录"; }
        }
        catch { return "读取错误"; }
    }
}
