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
/// Book 的摘要说明
/// </summary>
public class Book
{
    #region 字段
    private string title;
    private string picurl;
    private string id;
    private string author;
    private DateTime pub_time;
    private string publisher;
    private string isbn;
    private int num1;//馆藏多少本
    private int num2;//可用多少本
    private string typename;
    private string infos;
    private DateTime addtime;
    private string adduser;
    private bool istop;
    private string addip;
    private int visit_num;
    private int good_num;
    private int bad_num;
    private DataSystem dataconnection;//用于数据链接
    private string sql; 
    #endregion

    #region 属性
    public string Title
    {
        get { return title; }
        set { title = value; }
    }
    public string ID
    {
        set { id = value; }
        get { return id; }
    }
    public string PicURL
    {
        set { picurl = value; }
        get { return picurl; }
    }
    public string Author
    {
        get { return author; }
        set { author = value; }
    }
    public string Publisher
    {
        get { return publisher; }
        set { publisher = value; }
    }
    public DateTime PubTime
    {
        get { return pub_time; }
        set { pub_time = value; }
    }
    public DateTime AddTime
    {
        get { return addtime; }
        set { addtime = value; }
    }
    public string AddUser
    {
        get { return adduser; }
        set { adduser = value; }
    }
    public string AddIP
    {
        set { addip = value; }
        get { return addip; }
    }
    public string ISBN
    {
        get { return isbn; }
        set { isbn = value; }
    }
    public int TotalNum
    {
        get { return num1; }
        set { num1 = value; }
    }
    public int NowNum
    {
        get { return num2; }
        set { num2 = value; }
    }
    public bool IsTop
    {
        get { return istop; }
        set { istop = value; }
    }
    public int VisitNum
    {
        get { return visit_num; }
        set { visit_num = value; }
    }
    public int GoodNum
    {
        get { return good_num; }
        set { good_num = value; }
    }
    public int BadNum
    {
        get { return bad_num; }
        set { bad_num = value; }
    }
    public string Infos
    {
        get { return infos; }
        set { infos = value; }
    }
    public string TypeName
    {
        get { return typename; }
        set { typename = value; }
    } 
    #endregion

    public void BookDataOpen()
    {
        dataconnection.Open(); 
    }
    public void BookDataClose()
    {
        dataconnection.Close(); 
    }

	public Book()
	{
        picurl = "Images/ad2.gif";
        num1 = 0;
        num2 = 0;
        visit_num = 0;
        good_num = 0;
        bad_num = 0;
        dataconnection = new DataSystem();
        dataconnection.ConnectionString = ConfigurationManager.ConnectionStrings["DBString"].ToString();
	}
    /// <summary>
    /// 得到列表
    /// </summary>
    /// <param name="topnum"></param>
    /// <param name="orderfield"></param>
    /// <param name="condition"></param>
    /// <returns></returns>
    public SqlDataReader GetBookList(int topnum, string orderfield, string condition)
    {
        sql = "select top " + topnum + " * from [lib_newbook] where " + condition + " order by " + orderfield;
        
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
    public SqlDataReader GetBooksList(int size, int nowpage)
    {
        int topbefore = (nowpage - 1) * size;
        //sql = "SELECT  * FROM [lib_newbook] t1 WHERE (SELECT count(*) FROM [lib_newbook] t2 WHERE t2.id < t1.id ) > = @StartNum AND (SELECT count(*) FROM [lib_newbook] t2 WHERE t2.id < t1.id) < @EndNum order by istop desc, addtime desc";
        sql = "select top " + size + " * from [lib_newbook] where id not in(select top "+topbefore+" id from [lib_newbook] order by istop desc,addtime desc ) order by istop desc,addtime desc";
      //  SqlParameter[] myparas ={  
          //  new SqlParameter("@StartNum",SqlDbType.Int),
            //new SqlParameter("@EndNum",SqlDbType.Int)
        //};
      //  myparas[0].Value = (nowpage - 1) * size;
        //myparas[1].Value = nowpage * size;
        SqlDataReader reader;
        try
        {
            reader = dataconnection.GetDataReader(sql);
        }
        catch { reader = null; }
        return reader;
    }
    /// <summary>
    /// 返回页数
    /// </summary>
    /// <param name="size">每页数量</param>
    /// <returns></returns>
    public int GetBooksNum(int size)
    {
        sql = "select count(*) as allnum  from[lib_newbook]";
        
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
    public string GetInfo()
    {
        sql = "select * from [lib_newbook] where id=@BookID";
        SqlParameter[] mypara ={ new SqlParameter("@BookID",SqlDbType.VarChar)};
        mypara[0].Value = id;
        try {
            string result="";
            SqlDataReader reader = dataconnection.GetDataReader(mypara, sql);
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    title = reader["title"].ToString();
                    picurl = reader["picurl"].ToString();
                    infos = reader["infos"].ToString();
                    publisher = reader["publisher"].ToString();
                    bad_num = int.Parse(reader["bad_num"].ToString());
                    good_num = int.Parse(reader["good_num"].ToString());
                    visit_num = int.Parse(reader["visit_num"].ToString());
                    addip = reader["addip"].ToString();
                    addtime = DateTime.Parse(reader["addtime"].ToString());
                    adduser = reader["adduser"].ToString();
                    istop = bool.Parse(reader["istop"].ToString());
                    typename = reader["typename"].ToString();
                    author = reader["author"].ToString();
                    num1 = int.Parse(reader["num1"].ToString());
                    num2 = int.Parse(reader["num2"].ToString());
                    pub_time = DateTime.Parse(reader["pub_time"].ToString());
                    isbn = reader["isbn"].ToString();

                }
                result = "ok";
            }
            else { result= "暂无记录"; }
            reader.Close();
            return result;
        }
        catch { return "对不起，系统错误！"; }
        
    }
    /// <summary>
    /// 增加或者减少记录
    /// </summary>
    /// <param name="visitid">其他增加访问量，2增加好评数量，3增加坏评数量</param>
    /// <returns></returns>
    public string AddVisit(int visitid)
    {
        sql = "update [lib_newbook] set visit_num=visit_num+1 where id=@BookID";
        switch (visitid) { 
        
            case 2:
              sql=  "update [lib_newbook] set good_num=good_num+1 where id=@BookID";
                break;
            case 3:
              sql=  "update [lib_newbook] set bad_num=bad_num+1 where id=@BookID";
                break;
            default:
                
                break;
           
        };
         SqlParameter[] mypara ={ new SqlParameter("@BookID",SqlDbType.VarChar)};
        mypara[0].Value = id;
        try
        {
            dataconnection.ExecuteSql(mypara, sql);
            return "ok";
        }
        catch { return "对不起，系统错误"; }
    
    }
}
