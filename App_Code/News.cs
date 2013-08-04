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
/// News 的摘要说明
/// </summary>
public class News
{
	public News()
	{
        dataconnection = new DataSystem();
        dataconnection.ConnectionString = ConfigurationManager.ConnectionStrings["DBString"].ToString();
        ischeck = true;
        istop = false;
        checkadmin = "admin";
        newspages = 0;
        newslistnum = 0;
        orderlist = 0;
        visit_num = 0;
        news_type = "news";
        head_pic = "";
	}
    public News(string newsid)
    {
        id = newsid;
        dataconnection = new DataSystem();
        dataconnection.ConnectionString = ConfigurationManager.ConnectionStrings["DBString"].ToString();

        newspages = 0;
        newslistnum = 0;
    }
    private string title;
    private string info;
    private string news_type;//新闻，还是公告，news notice
    private string head_pic;
    private string id;
    private bool ischeck;
    private string checkadmin;
    private DateTime pub_time;
    private string pub_user;
    private string pub_ip;
    private bool istop;//置顶
    private int visit_num;
    private int orderlist;
    private int newslistnum;
    private int newspages;
    public DataSystem dataconnection;//用于数据链接
    private string sql;

    /// <summary>
    /// 属性定义
    /// </summary>
    #region
    public int NewsListNum
    {
        get { return newslistnum; }
        set { newslistnum = value; }
    }
    public int NewsPageNum
    {
        get { return newspages; }
        set { newspages = value; }
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
    /// <summary>
    /// 新闻news,公告notice
    /// </summary>
    public string NewsType
    {
        get { return news_type; }
        set { news_type = value; }
    }
    public string HeadPicUrl
    {
        get { return head_pic; }
        set { head_pic = value; }
    }
    public string NewsID
    {
        get { return id; }
        set { id = value; }

    }
    public bool IsChecked
    {
        get { return ischeck; }
        set { ischeck = value; }
    }
    public bool IsTop
    {
        get { return istop; }
        set { istop = value; }
    }
    public string CheckAdmin
    {
        get { return checkadmin; }
        set { checkadmin = value; }
    }
    public string PubUser
    {
        get { return pub_user; }
        set { pub_user = value; }
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
    public int VisitNum
    {
        get { return visit_num; }
        set { visit_num = value; }
    }
    public int OrderList
    {
        get { return orderlist; }
        set { orderlist = value; }
    }
    #endregion


    #region 数据链接操作
    public void NewsDataOpen()
    {
        dataconnection.Open();
    }
    public void NewsDataClose()
    {
        dataconnection.Close();
    }

    #endregion

    /// <summary>
    /// 审核信息
    /// </summary>
    /// <returns></returns>
  
    /// <summary>
    /// 获取新闻列表,仅供内部参考
    /// </summary>
    /// <param name="topnum">数量</param>
    /// <param name="orderfield">排序字段条件</param>
    /// <param name="newstype">新闻类型,news/notice</param>
    /// <param name="condition">查询条件</param>
    /// <returns>SqlDataReader</returns>
    public SqlDataReader GetNewsList(int topnum,string orderfield,string newstype,string condition)
    {
        sql = "select top " + topnum + " * from [lib_news] where news_type=@NewsType and "+condition+" order by "+orderfield;
        SqlParameter[] myparas ={ 
            new SqlParameter("@NewsType",SqlDbType.VarChar)
        };

        myparas[0].Value = newstype;
        SqlDataReader reader;
        try
        {
             reader = dataconnection.GetDataReader(myparas, sql);
        }
        catch { reader = null; }
        return reader;
    }
    /// <summary>
    /// 返回页数
    /// </summary>
    /// <param name="newstype">news/notice</param>
    /// <param name="check">是否审核的,0未审核,1审核的,2所有的,默认审核的</param>
    /// <param name="size">每页数量</param>
    /// <returns></returns>
    public int GetNewsNum(string newstype,int check,int size)
    {
        sql = "select count(*) as allnum  from[lib_news] where news_type=@NewsType and ischeck=1";
        switch (check) { 
            case 0:
                sql = "select count(*) as allnum from[lib_news] where news_type=@NewsType and ischeck=0";
                break;
            case 1:
                sql = "select count(*) as allnum  from[lib_news] where news_type=@NewsType and ischeck=1";
                break;
            case 2:
                sql = "select count(*) as allnum  from[lib_news] where news_type=@NewsType";
                break;
            default:
                break;
        };
        SqlParameter[] mypara ={ new SqlParameter("@NewsType",SqlDbType.VarChar)};
        mypara[0].Value = newstype;
        try
        {
            SqlDataReader reader = dataconnection.GetDataReader(mypara, sql);
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
    /// <summary>
    /// 得到新闻列表
    /// </summary>
    /// <param name="size">每页显示数量</param>
    /// <param name="nowpage">当前页</param>
    /// <param name="newstype">新闻类型，news/notice</param>
    /// <param name="checktype">是否审核1-审核的，0-未审核，2全部，默认审核</param>
    /// <returns></returns>
    public SqlDataReader GetNewsList(int size, int nowpage, string newstype, int check)
    {
        string condition = " news_type='" + newstype + "' ";
        int topbefore = (nowpage - 1) * size;
        string ordertype = " istop desc,pub_time desc";
        switch(check)
        {
            case 0:
                condition = " news_type='" + newstype + "' and ischeck=0 ";
                break;
            case 1:
                condition = " news_type='" + newstype + "' and ischeck=1 ";
                break;
            case 2:
                condition = " news_type='" + newstype + "' ";
                break;
            default:
                break;
        };

        sql = "select top " + size + " * from [lib_news] where " + condition + " and id not in(select top " + topbefore + " id from [lib_news] where " + condition + " order by " + ordertype + " ) order by " + ordertype ;
        SqlDataReader reader = dataconnection.GetDataReader(sql);
        return reader;
    }
    public SqlDataReader GetTopNewsList(int topnum)
    {
        return GetNewsList(topnum, "visit_num desc", "news", "ischeck=1");
    }
    public SqlDataReader GetIndexTop2News()
    {
        return GetNewsList(2, "pub_time desc", "news", "ischeck=1 and istop=1");
    }
   
    public SqlDataReader GetTopNoticeList(int topnum)
    {
        return GetNewsList(topnum, "visit_num desc", "notice", "ischeck=1");
    }
    /// <summary>
    /// 获取新闻信息
    /// </summary>
    /// <param name="ischecneed">1,审核的，0，没有审核的，2，所有的</param>
    /// <returns></returns>
    public bool GetNewsInfo(int ischecneed)
    {
        sql = "select * from [lib_news] where id=@NewsID and ischeck=1";
        switch (ischecneed) { 
            case 0:
                sql = "select * from [lib_news] where id=@NewsID and ischeck=0";
                break;
            case 1:
                sql = "select * from [lib_news] where id=@NewsID and ischeck=1";
                break;
            case 2:
                sql = "select * from [lib_news] where id=@NewsID";
                break;
            default:
                sql = "select * from [lib_news] where id=@NewsID and ischeck=1";
                break;
        };
       
        SqlParameter[] myparas ={ new SqlParameter("@NewsID", SqlDbType.Int) };
        myparas[0].Value = int.Parse(id);
        SqlDataReader reader = dataconnection.GetDataReader(myparas, sql);
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                title = reader["title"].ToString();
                info = reader["info"].ToString();
                ischeck =bool.Parse( reader["ischeck"].ToString());
                istop = bool.Parse(reader["istop"].ToString());
                news_type = reader["news_type"].ToString();
                head_pic = reader["head_pic"].ToString();
                pub_ip = reader["pub_ip"].ToString();
                pub_time = DateTime.Parse(reader["pub_time"].ToString());
                pub_user = reader["pub_user"].ToString();
                checkadmin = reader["check_admin"].ToString();
                visit_num = int.Parse(reader["visit_num"].ToString());
                orderlist = int.Parse(reader["orderlist"].ToString());



            }
            reader.Close();
            return true;
        }
        else
        {
            reader.Close();
            return false;
        }
    }
    /// <summary>
    /// 增加访问量
    /// </summary>
    /// <returns></returns>
    public bool AddVisit()
    {
        sql = "update [lib_news] set visit_num=visit_num+1 where id=@NewsID";
        SqlParameter[] mypara ={ new SqlParameter("@NewsID", SqlDbType.Int) };
        mypara[0].Value = int.Parse(id);
        try
        {
            if (dataconnection.ExecuteSql(mypara, sql) > 0)
                return true;
            else return false;
        }
        catch { return false; }
    }
}
