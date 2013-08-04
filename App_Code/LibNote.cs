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
/// LibNote 的摘要说明
/// </summary>
public class LibNote
{
    #region 字段属性定义
    private string noteid;
    private string title;
    private string info;
    private string pubuser;
    private string pubip;
    private DateTime pubtime;
    private bool ischeck;
    private bool istop;
    private bool ismail;
    private bool isover;
    private string checkadmin;
    private string replyid;
    private int visitnum;
    private string typename;
    private string replyuser;
    private DateTime replytime;
    private string replyinfo;

    public string NoteID
    {
        get { return noteid; }
        set { noteid = value; }
    }
    public string Title
    {
        get { return title; }
        set { title = value; }
    }
    public string Info
    {
        get { return info; }
        set { info = value; }
    }
    public string PubUser
    {
        get { return pubuser; }
        set { pubuser = value; }
    }
    public string PubIP
    {
        get { return pubip; }
        set { pubip = value; }
    }
    public DateTime PubTime
    {
        get { return pubtime; }
        set { pubtime = value; }
    }
    public bool IsCheck
    {
        get { return ischeck; }
        set { ischeck = value; }
    }
    public string CheckAdmin
    {
        get { return checkadmin; }
        set { checkadmin = value; }
    }
    public bool IsMail
    {
        get { return ismail; }
        set { ismail = value; }
    }
    public bool IsOver
    {
        get { return isover; }
        set { isover = value; }
    }
    public string ReplyUser
    {
        get { return replyuser; }
        set { replyuser = value; }
    }
    public string ReplyInfo
    {
        set { replyinfo = value; }
        get { return replyinfo; }
    }
    public DateTime ReplyTime
    {
        set { replytime = value; }
        get { return  replytime; }
    }
    public int VisitNum
    {
        get { return visitnum; }
        set { visitnum = value; }
    }
    public string TypeName
    {
        get { return typename; }
        set { typename = value; }
    }
    public bool IsTop
    {
        get { return istop; }
        set { istop = value; }
    }
    private DataSystem dataconnection;//用于数据链接
    private string sql;  
    #endregion

	public LibNote()
	{
        replyuser = "";
        pubuser = "guest";
        ischeck = false;
        istop = false;
        isover = false;
        ismail = false;
        visitnum = 0;
        checkadmin = "admin";
        pubtime = DateTime.Now;
        dataconnection = new DataSystem();
        dataconnection.ConnectionString = ConfigurationManager.ConnectionStrings["DBString"].ToString();
	}
    public void NoteDataOpen()
    {
        dataconnection.Open();
    }
    public void NoteDataClose()
    {
        dataconnection.Close();
    }
    public string GetInfo()
    {
        
        sql = "select * from [lib_note] where id=@BookID";
        SqlParameter[] mypara ={ new SqlParameter("@BookID", SqlDbType.VarChar) };
        mypara[0].Value = noteid;
        try
        {
            string result = "";
            SqlDataReader reader = dataconnection.GetDataReader(mypara, sql);
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    title = reader["title"].ToString();
                    info = reader["info"].ToString();
                    pubtime = DateTime.Parse(reader["pub_time"].ToString());
                    pubuser = reader["pub_user"].ToString();
                    pubip = reader["pub_ip"].ToString();
                    ischeck = bool.Parse(reader["ischeck"].ToString());
                    checkadmin=reader["check_admin"].ToString();
                    isover = bool.Parse(reader["isover"].ToString());
                    ismail = bool.Parse(reader["ismail"].ToString());
                    replyuser = reader["replyuser"].ToString();
                    replyinfo = reader["replyinfo"].ToString();
                    istop = bool.Parse(reader["istop"].ToString());
                    typename = reader["typename"].ToString();
                    visitnum = int.Parse(reader["visit_num"].ToString());
                    replytime = DateTime.Parse(reader["replytime"].ToString());
                }
                result = "ok";
            }
            else { result = "暂无记录"; }
            reader.Close();
            return result;
        }
        catch { return "对不起，系统错误！"; }
    }
    public SqlDataReader GetReplys()
    {

        sql = "select * from [lib_note] where reply_id=@ReplyID";
        SqlParameter[] mypara ={ new SqlParameter("@ReplyID",SqlDbType.VarChar) };
        mypara[0].Value = noteid;
        try
        {
            return dataconnection.GetDataReader(mypara, sql);
        }
        catch { return null; }
    }
    public string AddVisit()
    {
        sql = "update [lib_note] set visit_num=visit_num+1 where id=@bookID ";
        SqlParameter[] mypara ={ new SqlParameter("@BookID", SqlDbType.VarChar) };
        mypara[0].Value = noteid;
        try
        {
            if (dataconnection.ExecuteSql(mypara, sql) > 0)
                return "ok";
            else
                return "对不起，失败了。";
        }
        catch { return "对不起，系统错误"; }
    }
    
public SqlDataReader GetNoteList(int size, int nowpage, bool notetype, int check)
    {
        sql = "SELECT * FROM [lib_note] t1 WHERE (SELECT count(*) FROM [lib_note] t2 WHERE t2.id < t1.id AND t2.ismail=@NewsType  and t2.ischeck=1  ) > = @StartNum AND (SELECT count(*) FROM [lib_note] t2 WHERE t2.id < t1.id AND t2.ismail=@NewsType  and t2.ischeck=1 ) < @EndNum AND t1.ismail=@NewsType and ischeck=1 order by pub_time desc,istop desc ";
        switch (check)
        {
            case 0:
                sql = "SELECT * FROM [lib_note] t1 WHERE (SELECT count(*) FROM [lib_note] t2 WHERE t2.id < t1.id AND t2.ismail=@NewsType  and t2.ischeck=0  ) > = @StartNum AND (SELECT count(*) FROM [lib_note] t2 WHERE t2.id < t1.id AND t2.ismail=@NewsType  and t2.ischeck=0 ) < @EndNum AND t1.ismail=@NewsType and ischeck=0 order by pub_time desc,istop desc  ";
                break;
            case 1:
                sql = "SELECT * FROM [lib_note] t1 WHERE (SELECT count(*) FROM [lib_note] t2 WHERE t2.id < t1.id AND t2.ismail=@NewsType  and t2.ischeck=1  ) > = @StartNum AND (SELECT count(*) FROM [lib_note] t2 WHERE t2.id < t1.id AND t2.ismail=@NewsType  and t2.ischeck=1 ) < @EndNum AND t1.ismail=@NewsType and ischeck=1 order by pub_time desc,istop desc  ";
                break;
            case 2:
                sql = "SELECT * FROM [lib_note] t1 WHERE (SELECT count(*) FROM [lib_note] t2 WHERE t2.id < t1.id AND  t2.ismail=@NewsType ) > = @StartNum AND (SELECT count(*) FROM [lib_note] t2 WHERE t2.id < t1.id AND t2.ismail=@NewsType ) < @EndNum AND t1.ismail=@NewsType order by pub_time desc,istop desc ";
                break;
            default:
                break;
        };
        //sql = "SELECT * FROM [lib_note] t1 WHERE (SELECT count(*) FROM [lib_note] t2 WHERE t2.id < t1.id AND t2.news_type=@NewsType) > = @StartNum AND (SELECT count(*) FROM [lib_note] t2 WHERE t2.id < t1.id AND t2.news_type=@NewsType) < @EndNum AND t1.news_type=@NewsType order by pub_time desc,istop desc ";
        // sql = "select top " + topnum + " * from [lib_note] where news_type=@NewsType and " + condition + " order by " + orderfield;
        SqlParameter[] myparas ={ 
            new SqlParameter("@NewsType",SqlDbType.Bit),
            new SqlParameter("@StartNum",SqlDbType.Int),
            new SqlParameter("@EndNum",SqlDbType.Int)
        };

        myparas[0].Value = notetype;
        myparas[1].Value = (nowpage - 1) * size;
        myparas[2].Value =  nowpage * size;
        SqlDataReader reader;
        try
        {
            reader = dataconnection.GetDataReader(myparas, sql);
        }
        catch { reader = null; }
        return reader;
    }
    public int[] GetNoteListNum(bool newstype,int check,int size)
    {
        sql = "select count(*) as allnum  from [lib_note] where ismail=@NewsType and ischeck=1";
        switch (check)
        {
            case 0:
                sql = "select count(*) as allnum from[lib_note] where ismail=@NewsType and ischeck=0 ";
                break;
            case 1:
                sql = "select count(*) as allnum  from[lib_note] where ismail=@NewsType and ischeck=1 ";
                break;
            case 2:
                sql = "select count(*) as allnum  from[lib_note] where ismail=@NewsType ";
                break;
            default:
                sql = "select * from [lib_note] where id=@NewsType and ischeck=1 ";
                break;
        };
        SqlParameter[] mypara ={ new SqlParameter("@NewsType", SqlDbType.Bit) };
        mypara[0].Value = newstype;
        try
        {
            SqlDataReader reader = dataconnection.GetDataReader(mypara, sql);
            reader.Read();
            int[] result = new int[2];
            int nownums = int.Parse(reader["allnum"].ToString());
            int allpages = nownums / size;
            if (nownums % size > 0)
                allpages = allpages+ 1;
            reader.Close();
            result[1] = allpages;
            return result;
        }
        catch { return null; }
    }


}
