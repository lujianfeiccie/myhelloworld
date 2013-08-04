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
using System.IO;

/// <summary>
/// Download 的摘要说明
/// </summary>
public class Download
{
    #region 字段
    private string title;
    private string id;
    private string typename;
    private string info;
    private bool is_recommend;
    private bool ischeck;
    private string check_admin;
    private string pub_user;
    private DateTime pub_time;
    private string pub_ip;
    private int down_num;
    private int visit_num;
    private DateTime update_time;
    private string update_ip;
    private string update_user;
    private string file_url;
    private int file_size;
    private string file_name;
    private string file_extension;
    private string xingzhi;
    private string down_language;
    private string platform;
    private string rank;
    private string author;
    private string head_pic;
    private bool is_need_login;
    private int up_num;
    private int nb_num;
    private DataSystem dataconnection;//用于数据链接
    private string sql;
    #endregion

    #region 属性定义
    public string Title
    {
        set { title = value; }
        get { return title; }
    }
    public string ID
    {
        set { id = value; }
        get { return id; }
    }
    public string TypeName
    {
        set { typename = value; }
        get { return typename; }
    }
    public string Info
    {
        get { return info; }
        set { info = value; }
    }
    public bool IsRecommend
    {
        set { is_recommend = value; }
        get { return is_recommend; }
    }
    public bool IsChecked
    {
        set { ischeck = value; }
        get { return ischeck; }
    }
    public string CheckAdmin
    {
        set { check_admin = value; }
        get { return check_admin; }
    }
    public string PubUser
    {
        set { pub_user = value; }
        get { return pub_user; }
    }
    public DateTime PubTime
    {
        get { return pub_time; }
        set { pub_time = value; }
    }
    public string PubIP
    {
        get { return pub_ip; }
        set { pub_ip = value; }
    }
    public int DownloadTimes
    {
        get { return down_num; }
        set { down_num = value; }
    }
    public int VisitNum
    {
        get { return visit_num; }
        set { visit_num = value; }
    }
    public DateTime UpdateTime
    {
        get { return update_time; }
        set { update_time = value; }
    }
    public string UpdateIP
    {
        get { return update_ip; }
        set { update_ip = value; }
    }
    public string UpdateUser
    {
        get { return update_user; }
        set { update_user = value; }
    }
    public string FileURL
    {
        get { return file_url; }
        set { file_url = value; }
    }
    public string FileName
    {
        get { return file_name; }
        set { file_name = value; }
    }
    public string FileEXT
    {
        get { return file_extension; }
        set { file_extension = value; }
    }
    public int FileSize
    {
        set { file_size = value; }
        get { return file_size; }
    }
    public string XingZhi//软件性质，共享软件之类的
    {
        get { return xingzhi; }
        set { xingzhi = value; }
    }
    public string Language
    {
        set { down_language = value; }
        get { return down_language; }
    }
    public string PlatForm
    {
        get { return platform; }
        set { platform = value; }
    }
    public string Rank
    {
        get { return rank; }
        set { rank = value; }
    }
    public string Author
    {
        set { author = value; }
        get { return author; }
    }
    public string HeadPic
    {
        set { head_pic = value; }
        get { return head_pic; }
    }
    public bool IsNeedLogin
    {
        get { return is_need_login; }
        set { is_need_login = value; }
    }
    public int GoodNum
    {
        get { return up_num; }
        set { up_num = value; }
    }
    public int BadNum
    {
        get { return nb_num; }
        set { nb_num = value; }
    }
    #endregion

    public void DownloadDataOpen()
    {
        dataconnection.Open(); 
    }
    public void DownloadDataClose()
    {
        dataconnection.Close();
    }
    /// <summary>
    /// 获取信息
    /// </summary>
    /// <returns>ok/其他信息</returns>
    public string GetDownloadInfo()
    {
        sql = "select * from [lib_download] where id=@DownloadID";
        SqlParameter[] myparas ={ new SqlParameter("@DownloadID", SqlDbType.VarChar) };
        myparas[0].Value = id;
        try
        {
            string result = "";
            SqlDataReader reader = dataconnection.GetDataReader(myparas, sql);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    title = reader["title"].ToString();
                    typename = reader["typename"].ToString();
                    info = reader["info"].ToString();
                    is_recommend =bool.Parse( reader["is_recommend"].ToString());
                    ischeck =bool.Parse( reader["ischeck"].ToString());
                    check_admin = reader["check_admin"].ToString();
                    pub_user = reader["pub_user"].ToString();
                    pub_time=DateTime.Parse(reader["pub_time"].ToString());
                    pub_ip = reader["pub_ip"].ToString();
                    down_num =int.Parse( reader["down_num"].ToString());
                    visit_num =int.Parse( reader["visit_num"].ToString());
                    update_time =DateTime.Parse( reader["update_time"].ToString());
                    update_user = reader["update_user"].ToString();
                    update_ip = reader["update_ip"].ToString();
                    file_url = reader["file_url"].ToString();
                    file_size =int.Parse( reader["file_size"].ToString());
                    file_name = reader["file_name"].ToString();
                    file_extension = reader["file_extension"].ToString();
                    xingzhi = reader["xingzhi"].ToString();
                    down_language = reader["down_language"].ToString();
                    platform = reader["platform"].ToString();
                    rank = reader["rank"].ToString();
                    author = reader["author"].ToString();
                    head_pic = reader["head_pic"].ToString();
                    is_need_login = bool.Parse(reader["is_need_login"].ToString());
                    nb_num = int.Parse(reader["nb_num"].ToString());
                    up_num = int.Parse(reader["up_num"].ToString());
                }
                result = "ok";
            }
            else { result = "暂时没有记录"; }
            reader.Close();
            return result;
        }
        catch { return "对不起，系统错误！"; }
        
    }
    
	public Download()
	{
        update_time = DateTime.Now;
        pub_time = DateTime.Now;
        dataconnection = new DataSystem();
        dataconnection.ConnectionString = ConfigurationManager.ConnectionStrings["DBString"].ToString();
	}

    /// <summary>
    /// 单线程下载,并且记录了下载记录，增加下载次数，扣除用户的分数
    /// </summary>
    /// <param name="_reqest"></param>
    /// <param name="_response"></param>
    /// <param name="user_id">后面要记录下载记录</param>
    /// <returns></returns>
    public bool DownloadFile(HttpRequest _reqest, HttpResponse _response, string user_id)
    {
        Stream mystream = null;
        byte[] buffer = new Byte[10240];//buffer to read 10k bytes inchunk;
        int length;
        long datatoread;
        string filepath = HttpContext.Current.Request.MapPath("~/") + file_url;
        //   string filename = FileName;
        try
        {
            mystream = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read);
            _response.Clear();
            datatoread = mystream.Length;
            long p = 0;
            if (_reqest.Headers["Range"] != null)
            {
                _response.StatusCode = 206;
                p = long.Parse(_reqest.Headers["Range"].Replace("bytes=", "").Replace("-", ""));
            }
            if (p != 0)
            {
                _response.AddHeader("Content-Range", "bytes " + p.ToString() + "-" + ((long)(datatoread - 1)).ToString() + "/" + datatoread.ToString());
            }
            _response.AddHeader("Content-Length", ((long)(datatoread - p)).ToString());
            _response.ContentType = "application/octet-stream";
            _response.AddHeader("Content-Disposition", "attachment; filename=" + System.Web.HttpUtility.UrlEncode(title + "." + file_extension));
            mystream.Position = p;
            datatoread = datatoread - p;
            while (datatoread > 0)
            {
                if (_response.IsClientConnected)
                {
                    length = mystream.Read(buffer, 0, 10240);
                    _response.OutputStream.Write(buffer, 0, length);
                    _response.Flush();
                    buffer = new Byte[10240];
                    datatoread = datatoread - length;
                }
                else
                {
                    datatoread = -1;
                }
            }
            mystream.Close();
            AddDownloadRecord(_reqest.UserHostAddress, user_id);
            return true;
        }
        catch { return false; }

    }
    public string AddVisit()
    {
        sql = "update [lib_download] set visit_num=visit_num+1 where id=@DownloadID";
        SqlParameter[] mypara ={ new SqlParameter("@DownloadID", SqlDbType.VarChar) };
        mypara[0].Value = id;
        if (dataconnection.ExecuteSql(mypara, sql) > 0)
            return "ok";
        else return "对不起系统错误！";
    }
    /// <summary>
    /// 增加下载记录，记录文件下载次数，更新文件下载次数
    /// </summary>
    /// <param name="ip"></param>
    /// <param name="userid">下载者id</param>
    public void AddDownloadRecord(string ip, string userid)
    {
        sql = "insert into [lib_download_log] (download_id,down_user,down_time,down_ip) values (@FileID,@UserID,@NowTime,@IP)";
        string sql2 = "update [lib_download] set down_num=down_num+1 where id=@DownloadID";
       SqlParameter[] mypara ={ new SqlParameter("@DownloadID",SqlDbType.VarChar)};
       mypara[0].Value = id;
        SqlParameter[] myparas ={ 
            new SqlParameter("@FileID",SqlDbType.VarChar),
            new SqlParameter("@UserID",SqlDbType.VarChar),
            new SqlParameter("@NowTime",SqlDbType.DateTime),
            new SqlParameter("@IP",SqlDbType.VarChar)
        };
        myparas[0].Value = id;
        myparas[1].Value = userid;
        myparas[2].Value = DateTime.Now;
        myparas[3].Value = ip;
       dataconnection.ExecuteSql(mypara, sql2);
        dataconnection.ExecuteSql(myparas, sql);
        return;
    }
    public SqlDataReader GetTopDownload(int viewnum)
    {
        sql = "select top "+viewnum+" id,title,down_num from [lib_download] order by down_num desc";
        try
        {
            return dataconnection.GetDataReader(sql);
        }
        catch { return null; }
    }
    /// <summary>
    /// 得到列表
    /// </summary>
    /// <param name="topnum"></param>
    /// <param name="orderfield"></param>
    /// <param name="condition"></param>
    /// <returns></returns>
    public SqlDataReader GetDownloadList(int topnum, string orderfield, string condition)
    {
        sql = "select top " + topnum + " * from [lib_download] where " + condition + " order by " + orderfield;

        SqlDataReader reader;
        try
        {
            reader = dataconnection.GetDataReader(sql);
        }
        catch { reader = null; }
        return reader;
    }

    /// <summary>
    /// 得到列表
    /// </summary>
    /// <param name="size">每页显示数量</param>
    /// <param name="nowpage">当前页</param>
    /// <returns></returns>
    public SqlDataReader GetDownloadList(int size, int nowpage)
    {
        sql = "SELECT * FROM [lib_download] t1 WHERE (SELECT count(*) FROM [lib_download] t2 WHERE t2.id < t1.id ) > = @StartNum AND (SELECT count(*) FROM [lib_download] t2 WHERE t2.id < t1.id) < @EndNum order by is_recommend desc, pub_time desc";

        SqlParameter[] myparas ={  
            new SqlParameter("@StartNum",SqlDbType.Int),
            new SqlParameter("@EndNum",SqlDbType.Int)
        };

        myparas[0].Value = (nowpage - 1) * size;
        myparas[1].Value = nowpage * size;
        SqlDataReader reader;
        try
        {
            reader = dataconnection.GetDataReader(myparas, sql);
        }
        catch { reader = null; }
        return reader;
    }
    public int[] GetComentNum()
    {
        int[] mynums ={0,0};
        sql = "select up_num,nb_num from [lib_download] where id=@ID";
        SqlParameter[] myparas ={ new SqlParameter("@ID", SqlDbType.VarChar) };
        myparas[0].Value = id;
        try {
             SqlDataReader reader=   dataconnection.GetDataReader(myparas, sql);
             if (reader.HasRows)
             {
                 while (reader.Read())
                 {
                     mynums[0] = int.Parse(reader["up_num"].ToString());
                     mynums[1] = int.Parse(reader["nb_num"].ToString());
                 }
             }
             reader.Close();
             return mynums;
        }
        catch { return mynums; }

    }
    /// <summary>
    /// 投票的
    /// </summary>
    /// <param name="type">bad,默认为good</param>
    /// <returns></returns>
    public string AddComment(string type)
    {
        sql = "update [lib_download] set up_num=up_num+1 where id=@ID";
        if (type == "bad")
            sql = "update [lib_download] set nb_num=nb_num+1 where id=@ID";
        SqlParameter[] myparas ={ new SqlParameter("@ID", SqlDbType.VarChar) };
        myparas[0].Value = id;
        try
        {
            if (dataconnection.ExecuteSql(myparas, sql) > 0)
                return "ok";
            else return "投票失败，稍后重试！";
        }
        catch { return "投票失败，稍后重试！"; }
    }
    /// <summary>
    /// 返回页数
    /// </summary>
    /// <param name="size">每页数量</param>
    /// <returns></returns>
    public int GetDownloadNum(int size)
    {
        sql = "select count(*) as allnum  from[lib_download]";

        try
        {
            SqlDataReader reader = dataconnection.GetDataReader(sql);
            reader.Read();

            int nownums = int.Parse(reader["allnum"].ToString());
            int allpages = nownums / size;
            if (nownums % size > 0)
                allpages = allpages + 1;
            reader.Close();
            return allpages;
        }
        catch { return 1; }

    }
}
